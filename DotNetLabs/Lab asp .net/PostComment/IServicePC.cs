using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PostComment
{
    [ServiceContract]
    public interface IServicePC
    {
        [OperationContract]
        Post GetPostById(int id);
        [OperationContract]
        bool AMDPost(Post post); // AddModifyDeletePost
        [OperationContract]
        Post[] GetAllPosts();
        [OperationContract]
        Comment[] GetComments(Post post);
        [OperationContract]
        bool AMDComment(Post post, Comment comment);
    }

}
