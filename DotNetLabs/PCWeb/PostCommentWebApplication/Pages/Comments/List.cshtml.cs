using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PostCommentWebApplication.Models;
using ServiceReferencePostComment;

namespace PostCommentWebApplication.Pages.Comments
{
    public class ListModel : PageModel
    {
        PostCommentClient pcc = new PostCommentClient();
        public List<CommentDTO> Comments { get; set; }
        public ListModel()
        {
            Comments = new List<CommentDTO>();
        }
        public async Task OnGetAsync(int? id)
        {
            if (!id.HasValue)
                return;
            var item = await pcc.GetPostByIdAsync(id.Value);
            ViewData["Post"] = item.Id.ToString() + " : " + item.Description.Trim();
            foreach (var cc in item.Comments)
            {
                CommentDTO cdto = new CommentDTO();
                cdto.PostId = cc.PostId;
                cdto.Text = cc.Text;
                cdto.Id = cc.Id;
                Comments.Add(cdto);
            }
        }

    }
}