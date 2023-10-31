using CStoreAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Json;

namespace CStoreAPI.Pages
{
    public class AdminManageModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminManageModel (IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Message { get; private set; } = "";
        public void OnGet()
        {
            Message = "Create new admin";
        }
        public async void OnPost(string Email, string Password)
        {
            Admin admin = new Admin { Email = Email, Password = Password };
            var httpClient = _httpClientFactory.CreateClient();
            var result = await httpClient.PostAsJsonAsync("https://localhost:7030/api/adminaccount", admin);
            if (result.IsSuccessStatusCode)
            {
                Message = "Admin Succesfully added";
            }
            else
            {
                Message = "Something Went wrong, Maybe you didnt write email correctly or password dont complete the requierments";
            }
        }
    }
}

