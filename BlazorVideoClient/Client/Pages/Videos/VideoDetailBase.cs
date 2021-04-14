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
    public class VideoDetailBase : ComponentBase
    {      
        [Inject]
        public IVideoService VideoService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public int Id { get; set; }

        public VideoView Video { get; set; } = new();

        public Video VideoDB { get; set; } = new();

        protected async override Task OnInitializedAsync()
        {          
            VideoDB = await VideoService.GetById(Id);

            Mapper.Map(VideoDB, Video);
        }
      
    }
}
