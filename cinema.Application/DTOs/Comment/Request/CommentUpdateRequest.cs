using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.DTOs.Comment.Request
{
    public class CommentUpdateRequest : BaseCommentDto
    {
        public Guid Id { get; set; }
    }
}
