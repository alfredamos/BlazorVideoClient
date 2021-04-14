using AutoMapper;
using BlazorVideoClient.Client.Contracts;
using BlazorVideoClient.Client.Shared.UI;
using BlazorVideoClient.Client.ViewModels;
using BlazorVideoClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorVideoClient.Client.Pages.Categories
{
    public class CategoryDetailBase : ComponentBase
    {
        [Inject]
        public ICategoryService CategoryService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public int Id { get; set; }

        public CategoryView Category { get; set; } = new CategoryView();

        public Category CategoryDB { get; set; } = new Category();

        protected ConfirmDelete DeleteConfirmation { get; set; }


        protected async override Task OnInitializedAsync()
        {
            CategoryDB = await CategoryService.GetById(Id);

            Mapper.Map(CategoryDB, Category);
        }

        protected void DeleteClick()
        {
            DeleteConfirmation.Show();
        }

        protected async Task DeleteCategory(bool deleteConfirmed)
        {
            Mapper.Map(Category, CategoryDB);

            if (deleteConfirmed)
            {
                await CategoryService.DeleteEntity(Id);
            }

            NavigationManager.NavigateTo("categoryList");
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("categoryList");
        }

    }
}
