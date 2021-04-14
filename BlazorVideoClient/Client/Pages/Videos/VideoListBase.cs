using AutoMapper;
using BlazorVideoClient.Client.Contracts;
using BlazorVideoClient.Client.ViewModels;
using BlazorVideoClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorVideoClient.Client.Pages.Videos
{
    public class VideoListBase : ComponentBase
    {
        [Inject]
        public IVideoService VideoService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public List<VideoView> Videos { get; set; } = new List<VideoView>();

        public List<Video> VideosDB { get; set; } = new List<Video>();

        protected async override Task OnInitializedAsync()
        {
            VideosDB = (await VideoService.GetAll()).ToList();

            Mapper.Map(VideosDB, Videos);
        }

        protected async Task HandleSearch(string searchKey)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))VideosDB = (await VideoService.Search(searchKey)).ToList();
            else VideosDB = (await VideoService.GetAll()).ToList();

            Mapper.Map(VideosDB, Videos);
        }

    }
}
