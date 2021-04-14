using AutoMapper;
using BlazorVideoClient.Client.ViewModels;
using BlazorVideoClient.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorVideoClient.Client.Mapings.Map
{
    public class Map : Profile
    {
        public Map()
        {
            CreateMap<Category, CategoryView>().ReverseMap();
            CreateMap<Video, VideoView>().ReverseMap();
        }
    }
}
