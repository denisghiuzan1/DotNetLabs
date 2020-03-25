using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostComment.API;

namespace PostCommentService
{
    class PostComm : IPost
    {
        public void Cleanup()
        {
            throw new NotImplementedException();
        }

        public PostDTO GetPostById(int id)
        {
            throw new NotImplementedException();
        }

        public PostDTO GetPostByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public PostDTO SubmitPost(PostDTO post)
        {
            throw new NotImplementedException();
        }

        public PostDTO UpdatePost(PostDTO newPost)
        {
            throw new NotImplementedException();
        }

        public bool DeletePost(int postId)
        {
            throw new NotImplementedException();
        }

        public List<PostDTO> GetAllPosts()
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool DeleteComment(Comment comm)
        {
            throw new NotImplementedException();
        }

        public Comment GetCommentById(int id)
        {
            throw new NotImplementedException();
        }

        public Comment SubmitComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Comment UpdateComment(Comment oldComment, Comment newComment)
        {
            throw new NotImplementedException();
        }
    }
}
