using System.Collections.Generic;
using Comment = PostComment.API.Comment;
using Post = PostComment.API.Post;

namespace ObjectWCF
{
    public class PostComm : IPostComment
    {
        bool InterfaceComment.AddComment(Comment comment)
        {
            return comment.AddComment();
        }
        bool InterfacePost.AddPost(Post post)
        {
            return post.AddPost();
        }
        int InterfacePost.DeletePost(int id)
        {
            Post post = new Post();
            return post.DeletePost(id);
        }
        PostComment.Comment InterfaceComment.GetCommentById(int id)
        {
            Comment comment = new Comment();
            return comment.GetCommentById(id);
        }
        PostComment.Post InterfacePost.GetPostById(int id)
        {
           return new Post().GetPostById(id);
        }
        List<PostComment.Post> InterfacePost.GetPosts()
        {
            Post post = new Post();
            return post.GetAllPosts();
        }
        PostComment.Comment InterfaceComment.UpdateComment(Comment newComment)
        {
            return newComment.UpdateComment(newComment);
        }
        PostComment.Post InterfacePost.UpdatePost(Post post)
        {
            return post.UpdatePost(post);
        }
    }
}
