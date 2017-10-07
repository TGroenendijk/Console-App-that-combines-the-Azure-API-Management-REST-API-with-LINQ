using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using APIM.ConsoleApp.Models;


namespace APIM.ConsoleApp.Repositories
{
    public class ApimRepository
    {

        string ApimRestHost = ConfigurationManager.AppSettings["ApimRestHost"];
        string ApimRestAuthHeader = ConfigurationManager.AppSettings["ApimRestAuthHeader"];
        string ApimRestApiVersion = "2014-02-14-preview";       

        #region GetUserIdByToken
        public async Task<string> GetUserIdByToken(string primaryKey)
        {

            string userId = null;

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(ApimRestHost);
                client.DefaultRequestHeaders.Add("Authorization", ApimRestAuthHeader);

                // Get all the subscriptions from API Management
                HttpResponseMessage response = await client.GetAsync("/subscriptions?api-version=" + ApimRestApiVersion);
                if (response.IsSuccessStatusCode)
                {
                    HttpContent cont = response.Content;         

                    string jsonContent = cont.ReadAsStringAsync().Result;
                    Subscriptions list = JsonConvert.DeserializeObject<Subscriptions>(jsonContent);

                    // Get the subscription from the subscriptions list with LINQ and the primaryKey
                    Subscription s = list.value.Where(a => a.primaryKey == primaryKey).FirstOrDefault();

                    if (s != null)
                    {
                        // Remove "/users/" from id
                        userId = s.userId.Substring(7);
                    }
                }
            }

            return userId;
        }
        #endregion

    }
}
