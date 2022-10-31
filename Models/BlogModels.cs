using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Content
    {
        public string Text { get; set; }
        public string Link { get; set; }
        public List<string> Tags { get; set; }
    }


    public class Entry
    {
        public string Date { get; set; }
        public string Title { get; set; }
        public List<Content> Content { get; set; }
    }

    public class BlogRoot
    {
        public List<Entry> Entries { get; set; }
    }
}
