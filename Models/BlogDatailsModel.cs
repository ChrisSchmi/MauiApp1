using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    // Border in the UI: https://learn.microsoft.com/de-de/dotnet/maui/user-interface/controls/border

    public class BlogDatailsModel
    {
        public BlogDatailsModel(Models.Entry blogentry)
        {
            Title = blogentry.Title;
            Date = blogentry.Date;
            Content = blogentry.Content;
        }
        public string Title { get; set; }
        public string Date { get; set; }
        public List<Content> Content { get; set; }
    }
}
