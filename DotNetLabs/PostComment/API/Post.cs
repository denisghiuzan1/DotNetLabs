using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostComment.API
{
    public partial class Post
    {
        public int Id { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public string Description { get; set; }
        public string Domain { get; set; }
        public string Date { get; set; }

        public bool AddPost()
        {
            using (ModelPostCommentContainer context = new ModelPostCommentContainer())
            {
                bool bResult = false;
                if (this.Id == 0)
                {
                    var it = context.Entry<Post>(this).State = EntityState.Added;
                    context.SaveChanges();
                    bResult = true;
                }

                return bResult;
            }
        }

        public PostComment.Post UpdatePost(Post newPost)
        {
            using (ModelPostCommentContainer ctx = new ModelPostCommentContainer())
            {
                PostComment.Post oldPost = ctx.Posts.Find(newPost.Id);
                if (oldPost == null) 
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

        public int DeletePost(int id)
        {
            using (ModelPostCommentContainer ctx = new ModelPostCommentContainer())
            {
                return ctx.Database.ExecuteSqlCommand("Delete From Post where Id =@p0", id);
            }
        }

        public PostComment.Post GetPostById(int id)
        {
            using (ModelPostCommentContainer ctx = new ModelPostCommentContainer())
            {
                var items = from p in ctx.Posts where (p.Id == id) select p;
                if (items != null)
                    return items.Include(c => c.Comments).SingleOrDefault();
                return null; 
            }
        }

        public List<PostComment.Post> GetAllPosts()
        {
            using (ModelPostCommentContainer ctx = new ModelPostCommentContainer())
            {
                return ctx.Posts.Include("Comments").ToList<PostComment.Post>();
            }
        }

    }
}
