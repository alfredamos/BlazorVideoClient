using BlazorVideoClient.Client.Contracts;
using BlazorVideoClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorVideoClient.Client.Services
{
    public class VideoService : IVideoService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "api/videos";

        public VideoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Video> AddEntity(Video newService)
        {
            return await _httpClient.PostJsonAsync<Video>(_baseUrl, newService);
        }

        public async Task DeleteEntity(int id)
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<Video>> GetAll()
        {
            return await _httpClient.GetJsonAsync<Video[]>(_baseUrl);
        }

        public async Task<Video> GetById(int id)
        {
            return await _httpClient.GetJsonAsync<Video>($"{_baseUrl}/{id}");
        }

        public async Task<IEnumerable<Video>> Search(string searchKey)
        {
            return await _httpClient.GetJsonAsync<Video[]>($"{ _baseUrl}/search/{searchKey}");
        }

        public async Task<Video> UpdateEntity(Video updatedService)
        {
            return await _httpClient.PutJsonAsync<Video>($"{_baseUrl}/{updatedService.VideoID}", updatedService);
        }
    }
}
