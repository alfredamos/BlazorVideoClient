using AutoMapper;
using BlazorVideoClient.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorVideoClient.Server.Mappings
{
    public class Mapp : Profile
    {
        public Mapp()
        {
            CreateMap<Category, Category>();
            CreateMap<Video, Video>();
        }
    }
}
