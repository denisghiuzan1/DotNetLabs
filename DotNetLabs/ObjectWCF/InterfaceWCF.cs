using System.Collections.Generic;
using System.ServiceModel;
using Comment = PostComment.API.Comment;
using Post = PostComment.API.Post;

namespace ObjectWCF
{
    [ServiceContract]
    public interface InterfacePost
    {
        [OperationContract]
        bool AddPost(Post post);
        [OperationContract]
        PostComment.Post UpdatePost(Post post);
        [OperationContract]
        int DeletePost(int id);
        [OperationContract]
        PostComment.Post GetPostById(int id);
        [OperationContract]
        List<PostComment.Post> GetPosts();
    }
    [ServiceContract]
    public interface InterfaceComment
    {
        [OperationContract]
        bool AddComment(Comment comment);
        [OperationContract]
        PostComment.Comment UpdateComment(Comment newComment);
        [OperationContract]
        PostComment.Comment GetCommentById(int id);
    }

    [ServiceContract]
    public interface IPostComment : InterfacePost, InterfaceComment
    {
    }
}
