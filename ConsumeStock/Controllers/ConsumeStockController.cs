using ConsumeStock.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumeStock.Controllers
{
    public class ConsumeStockController : Controller
    {
       
         Uri baseAddress = new Uri("http://localhost:5095/api");
        private readonly HttpClient _httpClient;

        public ConsumeStockController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<StockPrices> stockList = new List<StockPrices>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Stocks").Result;
            if (response.IsSuccessStatusCode)
            {
                string stockData = response.Content.ReadAsStringAsync().Result;
                stockList = JsonConvert.DeserializeObject<List<StockPrices>>(stockData);

            }
            return View(stockList);
        }
    }
}
