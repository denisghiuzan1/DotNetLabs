using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostComment
{
    public class ServicePC : IServicePC
    {
        public Post GetPostById(int id)
        {
            using (var context = new EfCore2020Entities())
            {
                //context.Configuration.LazyLoadingEnabled = false;
                //context.Configuration.ProxyCreationEnabled = false;
                context.NoLazyLoading(); 
                var item = context.Posts.Where(x => x.PostId == id).FirstOrDefault();
                Console.WriteLine(item.ToString());
                return item;
            }
        }
        public bool AMDPost(Post post)
        {
            // trebuie implementata
            return true;
        }
        public Post[] GetAllPosts()
        {
            using (var context = new EfCore2020Entities())
            {
                context.NoLazyLoading();
                var items = context.Posts;
                Post[] posts = items.ToArray<Post>();
                return posts;
            }
        }
        public Comment[] GetComments(Post post)
        {
            using (var context = new EfCore2020Entities())
            {
                context.NoLazyLoading();
                var item = context.Posts.Where(x => x.Equals(post)).FirstOrDefault();

                return item.Comments.ToArray();
            }
        }
        public bool AMDComment(Post post, Comment comment)
        {
            // cod
            return true;
        }
    }
}
