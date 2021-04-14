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
    public class EditVideoBase : ComponentBase
    {
        [Inject]
        public ICategoryService CategoryService { get; set; }

        [Inject]
        public IVideoService VideoService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public int Id { get; set; }

        public List<CategoryView> Categories { get; set; } = new();

        public List<Category> CategoriesDB { get; set; } = new();

        public VideoView Video { get; set; } = new();

        public Video VideoDB { get; set; } = new();

        protected async override Task OnInitializedAsync()
        {
            CategoriesDB = (await CategoryService.GetAll()).ToList();

            VideoDB = await VideoService.GetById(Id);

            Mapper.Map(CategoriesDB, Categories);

            Mapper.Map(VideoDB, Video);
        }

        protected async Task UpdateVideo()
        {
            Mapper.Map(Video, VideoDB);

            var video = await VideoService.UpdateEntity(VideoDB);

            if (video != null)
            {
                NavigationManager.NavigateTo("videoList");
            }
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("videoList");
        }
    }
}
