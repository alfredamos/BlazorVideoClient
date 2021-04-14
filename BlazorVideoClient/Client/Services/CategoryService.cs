﻿using BlazorVideoClient.Client.Contracts;
using BlazorVideoClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorVideoClient.Client.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "api/categories";

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Category> AddEntity(Category newService)
        {
            return await _httpClient.PostJsonAsync<Category>(_baseUrl, newService);
        }

        public async Task DeleteEntity(int id)
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _httpClient.GetJsonAsync<Category[]>(_baseUrl);
        }

        public async Task<Category> GetById(int id)
        {
            return await _httpClient.GetJsonAsync<Category>($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<Category>> Search(string searchKey)
        {
            return await _httpClient.GetJsonAsync<Category[]>($"{ _baseUrl}/search/{searchKey}");
        }

        public async Task<Category> UpdateEntity(Category updatedService)
        {
            return await _httpClient.PutJsonAsync<Category>($"{_baseUrl}/{updatedService.CategoryID}", updatedService);
        }
    }
}
