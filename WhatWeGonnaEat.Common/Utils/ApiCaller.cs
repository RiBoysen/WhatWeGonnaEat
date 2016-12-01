using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WhatWeGonnaEat.Common.Utils
{
    public static class ApiRecipesCaller
    {

        private static readonly HttpClient client = new HttpClient();

        static ApiRecipesCaller()
        {
            client.BaseAddress = new Uri(@"http://localhost:51294");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<string> GetRecipesAsync()
        {
            string a = null;
            HttpResponseMessage response = await client.GetAsync("Recipes");
            if (response.IsSuccessStatusCode)
            {
                a = await response.Content.ReadAsAsync<string>();
            }
            return a;
        }
    }
}
