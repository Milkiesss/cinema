using AutoMapper;
using cinema.Application.DTOs.Movie.Request;
using cinema.Application.DTOs.Movie.Response;
using cinema.Application.Interfaces.Repository;
using cinema.Application.Interfaces.Services;
using cinema.Domain.Entities;

namespace cinema.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _rep;
        private readonly IMapper _mapper;
        private readonly IGoogleStorageService _googleStorageService;
        public MovieService(IMovieRepository rep, IMapper mapper, IGoogleStorageService googleStorageService)
        {
            _rep = rep;
            _mapper = mapper;
            _googleStorageService = googleStorageService;
        }

        public async Task<MovieCreateResponse> CreateAsync(MovieCreateRequest entity,string fileName, string contentType,Stream source)
        {
            var result = _mapper.Map<Movie>(entity);
            result.ImageUrl = await _googleStorageService.UploadFile(fileName, contentType, source);
            await _rep.CreateAsync(result);
            return _mapper.Map<MovieCreateResponse>(result);
        }
        public async Task<MovieUpdateResponse> UpdateAsync(MovieUpdateRequest entity,string fileName, string contentType,Stream source)
        {
            var fileExist = await _rep.GetByIdAsync(entity.Id);
            var oldFileName = fileExist.ImageUrl.Substring(fileExist.ImageUrl.LastIndexOf("/") + 1);
            _mapper.Map(entity, fileExist);
            await _googleStorageService.DeleteFile(oldFileName);
            fileExist.ImageUrl = await _googleStorageService.UploadFile(fileName,contentType,source);
            
            await _rep.UpdateAsync(fileExist);
            return _mapper.Map<MovieUpdateResponse>(fileExist);
        } 

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _rep.DeleteAsync(id);
        }

        public async Task<ICollection<MovieGetAllResponse>> GetAllAsync()
        {
            var result = await _rep.GetAllAsync();
            return _mapper.Map<ICollection<MovieGetAllResponse>>(result);
        }

        public async Task<MovieGetByIdResponse> GetByIdAsync(Guid id)
        {
            var result = await _rep.GetByIdAsync(id);
            return _mapper.Map<MovieGetByIdResponse>(result);
        }

    }
}
