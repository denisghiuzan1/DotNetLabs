﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference1
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseEntity", Namespace="http://schemas.datacontract.org/2004/07/PostComment", IsReference=true)]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ServiceReference1.Comment))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ServiceReference1.Post))]
    public partial class BaseEntity : object
    {
        
        private ServiceReference1.State StateField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference1.State State
        {
            get
            {
                return this.StateField;
            }
            set
            {
                this.StateField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Comment", Namespace="http://schemas.datacontract.org/2004/07/PostComment", IsReference=true)]
    public partial class Comment : ServiceReference1.BaseEntity
    {
        
        private string AuthorField;
        
        private int CommentIdField;
        
        private string CommentTextField;
        
        private string DateCommentField;
        
        private ServiceReference1.Post PostField;
        
        private int PostPostIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Author
        {
            get
            {
                return this.AuthorField;
            }
            set
            {
                this.AuthorField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CommentId
        {
            get
            {
                return this.CommentIdField;
            }
            set
            {
                this.CommentIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CommentText
        {
            get
            {
                return this.CommentTextField;
            }
            set
            {
                this.CommentTextField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DateComment
        {
            get
            {
                return this.DateCommentField;
            }
            set
            {
                this.DateCommentField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference1.Post Post
        {
            get
            {
                return this.PostField;
            }
            set
            {
                this.PostField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PostPostId
        {
            get
            {
                return this.PostPostIdField;
            }
            set
            {
                this.PostPostIdField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Post", Namespace="http://schemas.datacontract.org/2004/07/PostComment", IsReference=true)]
    public partial class Post : ServiceReference1.BaseEntity
    {
        
        private string AuthorField;
        
        private ServiceReference1.Comment[] CommentsField;
        
        private string DatePostField;
        
        private int PostIdField;
        
        private string TitleField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Author
        {
            get
            {
                return this.AuthorField;
            }
            set
            {
                this.AuthorField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference1.Comment[] Comments
        {
            get
            {
                return this.CommentsField;
            }
            set
            {
                this.CommentsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DatePost
        {
            get
            {
                return this.DatePostField;
            }
            set
            {
                this.DatePostField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PostId
        {
            get
            {
                return this.PostIdField;
            }
            set
            {
                this.PostIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title
        {
            get
            {
                return this.TitleField;
            }
            set
            {
                this.TitleField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="State", Namespace="http://schemas.datacontract.org/2004/07/PostComment")]
    public enum State : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Added = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Unchanged = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Modified = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Deleted = 3,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IServicePC")]
    public interface IServicePC
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePC/GetPostById", ReplyAction="http://tempuri.org/IServicePC/GetPostByIdResponse")]
        System.Threading.Tasks.Task<ServiceReference1.Post> GetPostByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePC/AMDPost", ReplyAction="http://tempuri.org/IServicePC/AMDPostResponse")]
        System.Threading.Tasks.Task<bool> AMDPostAsync(ServiceReference1.Post post);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePC/GetAllPosts", ReplyAction="http://tempuri.org/IServicePC/GetAllPostsResponse")]
        System.Threading.Tasks.Task<ServiceReference1.Post[]> GetAllPostsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePC/GetComments", ReplyAction="http://tempuri.org/IServicePC/GetCommentsResponse")]
        System.Threading.Tasks.Task<ServiceReference1.Comment[]> GetCommentsAsync(ServiceReference1.Post post);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePC/AMDComment", ReplyAction="http://tempuri.org/IServicePC/AMDCommentResponse")]
        System.Threading.Tasks.Task<bool> AMDCommentAsync(ServiceReference1.Post post, ServiceReference1.Comment comment);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface IServicePCChannel : ServiceReference1.IServicePC, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class ServicePCClient : System.ServiceModel.ClientBase<ServiceReference1.IServicePC>, ServiceReference1.IServicePC
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public ServicePCClient() : 
                base(ServicePCClient.GetDefaultBinding(), ServicePCClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IServicePC.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServicePCClient(EndpointConfiguration endpointConfiguration) : 
                base(ServicePCClient.GetBindingForEndpoint(endpointConfiguration), ServicePCClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServicePCClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(ServicePCClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServicePCClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(ServicePCClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServicePCClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.Post> GetPostByIdAsync(int id)
        {
            return base.Channel.GetPostByIdAsync(id);
        }
        
        public System.Threading.Tasks.Task<bool> AMDPostAsync(ServiceReference1.Post post)
        {
            return base.Channel.AMDPostAsync(post);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.Post[]> GetAllPostsAsync()
        {
            return base.Channel.GetAllPostsAsync();
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.Comment[]> GetCommentsAsync(ServiceReference1.Post post)
        {
            return base.Channel.GetCommentsAsync(post);
        }
        
        public System.Threading.Tasks.Task<bool> AMDCommentAsync(ServiceReference1.Post post, ServiceReference1.Comment comment)
        {
            return base.Channel.AMDCommentAsync(post, comment);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IServicePC))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IServicePC))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:8080/post");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return ServicePCClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IServicePC);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return ServicePCClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IServicePC);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IServicePC,
        }
    }
}
