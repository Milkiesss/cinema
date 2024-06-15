using cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.DTOs.Comment
{
    public class BaseCommentDto
    {
        public Guid MovieId { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; }
    }
}
