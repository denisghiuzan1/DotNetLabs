using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostComment.API
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        public bool AddComment()
        {
            using (ModelPostCommentContainer ctx = new ModelPostCommentContainer())
            {
                bool bResult = false;
                if (this == null || this.PostId == 0)
                    return bResult;

                if (this.Id == 0)
                {
                    ctx.Entry<Comment>(this).State = EntityState.Added;
                    PostComment.Post p = ctx.Posts.Find(this.PostId);
                    ctx.Entry<PostComment.Post>(p).State = EntityState.Unchanged;
                    ctx.SaveChanges();
                    bResult = true;
                }
                return bResult;
            }
        }
        public PostComment.Comment UpdateComment(Comment newComment)
        {
            using (ModelPostCommentContainer ctx = new ModelPostCommentContainer())
            {
                PostComment.Comment oldComment = ctx.Comments.Find(newComment.Id);

                if (newComment.Text != null)
                    oldComment.Text = newComment.Text;

                if ((oldComment.PostId != newComment.PostId)
                    && (newComment.PostId != 0))
                {
                    oldComment.PostId = newComment.PostId;
                }
                ctx.SaveChanges();
                return oldComment;
            }
        }
        public PostComment.Comment GetCommentById(int id)
        {
            using (ModelPostCommentContainer ctx = new ModelPostCommentContainer())
            {
                var items = from c in ctx.Comments where (c.Id == id) select c;
                return items.Include(p => p.Post).SingleOrDefault();
            }
        }
    }
}
