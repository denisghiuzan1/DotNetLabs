using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using ServiceReferencePostComment;

namespace PostCommentWebApplication.Models
{
    public class CommentDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public int PostId { get; set; }

        [DataMember]
        public virtual Post Post { get; set; }
    }
}
