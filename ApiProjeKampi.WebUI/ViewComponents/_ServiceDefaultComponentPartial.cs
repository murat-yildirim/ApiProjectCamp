﻿using ApiProjeKampi.WebUI.Dtos.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeKampi.WebUI.ViewComponents
{
    public class _ServiceDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ServiceDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            
            var client = _httpClientFactory.CreateClient();
            //istekte bulunucağımız adresi belirliyoruz
            var responseMessage= await client.GetAsync("https://localhost:7215/api/Services/");
            if(responseMessage.IsSuccessStatusCode)//200'lü durum kodlarını temsil eder
            {
                //boş bir değişken tanımladık responsemessage'den gelen içeriği string olarak oku
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
