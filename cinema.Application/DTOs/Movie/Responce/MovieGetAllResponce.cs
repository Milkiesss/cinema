﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.DTOs.Movie.Responce
{
    public class MovieGetAllResponce : BaseMovieDto
    {
        public Guid Id { get; set; }
    }
}
