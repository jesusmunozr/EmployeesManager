using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using EmployeesManager.Dal.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EmployeesManager.Dal
{
    public class ApiDataAccess<T> : IApiDataAccess<T>, IDisposable where T : IEntity
    {
        private HttpClient client;
        private IConfiguration _config;
        private ILogger _logger;

        public ApiDataAccess(IConfiguration configuration, ILogger<ApiDataAccess<T>> logger)
        {
            this._config = configuration;
            this._logger = logger;
            client = new HttpClient();
            client.BaseAddress = new Uri(this._config.GetSection("ExternalApi:BaseUrl").Value);
        }

        public void Dispose()
        {
            client.Dispose();
        }

        public async Task<IEnumerable<T>> Get(string path)
        {
            IEnumerable<T> data = null;

            try
            {
                var response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<IEnumerable<T>>(content);
                }

                return data;
            }
            catch (HttpRequestException rex)
            {
                this._logger.LogError(rex, "An error has occurred getting the data");
                return null;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Unknown error.");
                return null;
            }
            
        }
    }
}
