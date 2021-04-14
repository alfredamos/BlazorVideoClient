using BlazorVideoClient.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorVideoClient.Client.ViewModels
{
    public class VideoView
    {
        public int VideoID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string YoutubeVid { get; set; }
        public double StarsCount { get; set; }

        public int CategoryID { get; set; }
        public CategoryView Category { get; set; }
        public SkillLevel Level { get; set; }
        public bool IsActive { get; set; }
        public DateTime DatePosted { get; set; } = DateTime.Now;
        public DateTime LastUpdated { get; set; }
    }
}
