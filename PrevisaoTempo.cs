using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

public static class PrevisaoTempoFunction
{
    [FunctionName("GetWeather")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "weather/{city}")] HttpRequest req, string city)
    {
        if (string.IsNullOrEmpty(city))
        {
            return new BadRequestObjectResult("A cidade deve ser especificada.");
        }

        string apiKey = "SUA_API_KEY"; // Substitua pela sua chave de API
        string weatherApiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric&lang=pt";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(weatherApiUrl);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var weatherData = JsonConvert.DeserializeObject(responseBody);

                return new OkObjectResult(weatherData);
            }
            catch (HttpRequestException e)
            {
                return new BadRequestObjectResult($"Erro ao obter os dados do clima: {e.Message}");
            }
        }
    }
}
