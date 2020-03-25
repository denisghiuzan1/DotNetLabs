using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostComment.APIStatic
{
    public static class API
    {
        public static bool AddPost(Post post)
        {
            using (ModelPostCommentContainer ctx = new ModelPostCommentContainer())
            {
                bool bResult = false;
                if (post.Id == 0)
                {
                    var it = ctx.Entry<Post>(post).State = EntityState.Added;
                    ctx.SaveChanges();
                    bResult = true;
                }
                return bResult;
            }
        }
        public static Post UpdatePost(Post newPost)
        {
            using (ModelPostCommentContainer ctx = new ModelPostCommentContainer())
            {
                // Ce e in bd. PK nu poate fi modificata
                Post oldPost = ctx.Posts.Find(newPost.Id);
                if (oldPost == null) // nu exista in bd
                {
                    return null;
                }
                oldPost.Description = newPost.Description;
                oldPost.Domain = newPost.Domain;
                oldPost.Date = newPost.Date;
                ctx.SaveChanges();
                return oldPost;
            }
        }

        public static int DeletePost(int id)
        {
            using (ModelPostCommentContainer ctx = new ModelPostCommentContainer())
            {
                return ctx.Database.ExecuteSqlCommand("Delete From Post where Id =@p0", id);
            }
        }

        public static Post GetPostById(int id)
        {
            using (ModelPostCommentContainer ctx = new ModelPostCommentContainer())
            {
                var items = from p in ctx.Posts where (p.Id == id) select p;
                if (items != null)
                    return items.Include(c => c.Comments).SingleOrDefault();
                return null;
            }
        }

        public static List<Post> GetAllPosts()
        {
            using (ModelPostCommentContainer ctx = new ModelPostCommentContainer())
            {
                return ctx.Posts.Include("Comments").ToList<Post>();
            }
        }

        public static bool AddComment(Comment comment)
        {
            using (ModelPostCommentContainer ctx = new ModelPostCommentContainer())
            {
                bool bResult = false;
                if (comment == null || comment.PostId == 0)
                    return bResult;
                if (comment.Id == 0)
                {
                    ctx.Entry<Comment>(comment).State = EntityState.Added;
                    Post p = ctx.Posts.Find(comment.PostId);
                    ctx.Entry<Post>(p).State = EntityState.Unchanged;
                    ctx.SaveChanges();
                    bResult = true;
                }
                return bResult;
            }
        }

        public static Comment UpdateComment(Comment newComment)
        {
            using (ModelPostCommentContainer ctx = new ModelPostCommentContainer())
            {
                Comment oldComment = ctx.Comments.Find(newComment.Id);
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

        public static Comment GetCommentById(int id)
        {
            using (ModelPostCommentContainer ctx = new ModelPostCommentContainer())
            {
                var items = from c in ctx.Comments where (c.Id == id) select c;
                return items.Include(p => p.Post).SingleOrDefault();
            }
        }




    }
}
