using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesAJAX.Models;

namespace RazorPagesAJAX.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public JsonResult OnGetTime()
        {
            return new JsonResult(DateTime.Now.ToString());
        }

        public JsonResult OnPostSend()
        {
            return new JsonResult("You rang?");
        }

        public JsonResult OnPostSendPerson([FromBody] Person p)
        {
            p.FirstName = p.FirstName.ToUpper();
            p.LastName = p.LastName.ToUpper();
            return new JsonResult(p);
        }
    }
}
