using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PostCommentWebApplication.Models;
using ServiceReferencePostComment;

namespace PostCommentWebApplication.Pages.Posts
{
    public class IndexModel : PageModel
    {
        PostCommentClient postCommentClient = new PostCommentClient();
        public List<PostDTO> Posts { get; set; }

        public IndexModel()
        {
            Posts = new List<PostDTO>();
        }
        public async Task OnGetAsync()
        {
            var posts = await postCommentClient.GetPostsAsync();
            foreach (var item in posts)
            {
                // Trebuia folosit AutoMapper. Transform Post in PostDTO
                PostDTO postDto = new PostDTO();
                postDto.Description = item.Description;
                postDto.Id = item.Id;
                postDto.Domain = item.Domain;
                postDto.Date = item.Date;
                foreach (var cc in item.Comments)
                {
                    CommentDTO cdto = new CommentDTO();
                    cdto.PostId = cc.PostId;
                    cdto.Text = cc.Text;
                    postDto.Comments.Add(cdto);
                }
                Posts.Add(postDto);
            }
        }
    }
}
