﻿using AutoMapper;
using BlazorVideoClient.Client.Contracts;
using BlazorVideoClient.Client.ViewModels;
using BlazorVideoClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorVideoClient.Client.Pages.Categories
{
    public class CategoryListBase : ComponentBase
    {
        [Inject]
        public ICategoryService CategoryService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public List<CategoryView> Categories { get; set; } = new List<CategoryView>();

        public List<Category> CategoriesDB { get; set; } = new List<Category>();

        protected async override Task OnInitializedAsync()
        {
            CategoriesDB = (await CategoryService.GetAll()).ToList();

            Mapper.Map(CategoriesDB, Categories);
        }

        
       
    }
}
