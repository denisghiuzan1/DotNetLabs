﻿using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using ObjectWCF;
using AutoMapper;
using AutoMapper.Configuration;
using PostComment.API;

namespace PostCommentService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServicePostComment : IPostComment
    {
        /// <summary>
        /// Instanta a clasei ServicePost, clasa ce expune metode de lucru cu EF pentru
        /// baza de date WCF.
        /// Exemplu de cod din aceasta clasa, ServicePost. Vedeti acces la context.
        /// public List<Post> GetAll()
        /// {
        /// List<Post> lp = new List<Post>();
        /// using (var context = new ModelPostBlogContainer())
        /// {
        /// lp = context.Posts.Include(p => p.Comments).ToList();
        /// }
        /// return lp;
        /// }
        /// </summary>
        private PostComm _svcPostComm;
        //
        // In ctor configurez AutoMapper
        //
        MapperConfiguration config;
        IMapper iMapper;
        public ServicePostComment()
        {
            _svcPostComm = new PostComm();
            // Configurare AutoMapper
            config = new MapperConfiguration(
            cfg =>
            {
                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<Comment, CommentDTO>();
            });
            iMapper = config.CreateMapper();
        }
        public void Cleanup()
        {
            Cleanup();
        }
        // Interfata ILoadData
        public List<PostDTO> GetAllPosts()
        {
            var lp = _svcPostComm.GetAll();
            // Constructie lista PostDTO
            List<PostDTO> lpDto = new List<PostDTO>();
            lpDto = iMapper.Map<List<Post>, List<PostDTO>>(lp);
            return lpDto;
            #region Comentariu
            /* Cam acest lucru face AutoMapper.
           Construieste DTO din obiectele din server (EF)
            foreach (var p in lp)
            {
            PostDTO pd = new PostDTO()
            {
            PostId = p.PostId,
           Title = p.Title
            };
            if (p.Comments.Count > 0)
            {
            foreach (var c in p.Comments)
           {
            //pd.Comments = new List<CommentDTO>();
           CommentDTO cd = new CommentDTO();
           cd.CommentId = c.CommentId;
           cd.CommentText = c.CommentText;
           //cd.PostId = c.PostId;
           //cd.PostPostId = c.PostPostId;
           pd.Comments.Add(cd);
            }
            }
            lpDto.Add(pd);
            }
            return lpDto;
            */
            #endregion
        }
        public void DeleteComment(CommentDTO comment)
        {
            Comment comm = new Comment();
            // map CommentDTO la Comment
            comm = iMapper.Map<CommentDTO, Comment>(comment);
            _svcPostComm.DeleteComment(comm);
        }
        public PostDTO GetPostByTitle(string title)
        {
            Post post = _svcPostComm.GetPostByTitle(title);
            if (post != null)
            {
                PostDTO postDTO = iMapper.Map<Post, PostDTO>(post);
                return postDTO;
            }
            return null;
        }
        // IPost implementation methods
        public PostDTO GetPostById(int id)
        {
            Wcf.Post post = _svcPostComm.GetPostById(id);
            // Reconstructie obiecte cunoscute in serviciu
            PostDTO postDTO = iMapper.Map<Post, PostDTO>(post);
            return postDTO;
        }
        public PostDTO SubmitPost(PostDTO postDTO)
        {
            Post post = new Post();
            post = iMapper.Map<PostDTO, Post>(postDTO);
            post = _svcPostComm.SubmitPost(post);
            postDTO = iMapper.Map<Post, PostDTO>(post);
            return postDTO;
        }
        public PostDTO UpdatePost(PostDTO newPost)
        {
            Post post = iMapper.Map<PostDTO, Post>(newPost);
            post = _svcPostComm.UpdatePost(post);
            PostDTO postDTO = iMapper.Map<Post, PostDTO>(post);
            return postDTO;
        }
        public bool DeletePost(int postId)
        {
            return _svcPostComm.DeletePost(postId);
        }
        // IComment implementation method
        public CommentDTO GetCommentById(int id)
        {
            Comment comment = _svcPostComm.GetCommentById(id);
            CommentDTO commentDTO = iMapper.Map<Comment, CommentDTO>(comment);
            return commentDTO;
        }
        public CommentDTO SubmitComment(CommentDTO commentDTO)
        {
            Comment comment = iMapper.Map<CommentDTO, Comment>(commentDTO);
            comment = _svcPostComm.SubmitComment(comment);
            CommentDTO commDTO = iMapper.Map<Comment, CommentDTO>(comment);
            return commDTO;
        }
        public CommentDTO SubmitComment(int postId, CommentDTO commentDTO)
        {
            Comment comment = iMapper.Map<CommentDTO, Comment>(commentDTO);
            comment = _svcPostComm.SubmitComment(postId, comment);
            CommentDTO comm = iMapper.Map<Comment, CommentDTO>(comment);
            return comm;
        }
        public CommentDTO UpdateComment(CommentDTO oldCommentDTO,
       CommentDTO newCommentDTO)
        {
            Comment oldComment = iMapper.Map<CommentDTO, Comment>(oldCommentDTO);
            Comment newComment = iMapper.Map<CommentDTO, Comment>(newCommentDTO);
            Comment comment = _svcPostComm.UpdateComment(oldComment, newComment);
            CommentDTO comm = iMapper.Map<Comment, CommentDTO>(comment);
            return comm;
        }
        public bool DeleteComment(int commentId)
        {
            return _svcPostComm.DeleteComment(commentId);
        }
        List<PostDTO> ILoadData.GetAllPostsAndRelatedComments()
        {
            // redirectare !!!!????
            return GetAllPosts();
        }
    }
}
