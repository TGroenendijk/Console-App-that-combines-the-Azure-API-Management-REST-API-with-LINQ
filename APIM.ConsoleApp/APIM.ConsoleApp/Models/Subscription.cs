using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIM.ConsoleApp.Models
{
    public class Subscription
    {
        public string id { get; set; }
        public string userId { get; set; }
        public string productId { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public DateTime createdDate { get; set; }
        public string startDate { get; set; }
        public string expirationDate { get; set; }
        public string endDate { get; set; }
        public string notificationDate { get; set; }
        public string primaryKey { get; set; }
        public string secondaryKey { get; set; }
        public string stateComment { get; set; }
    }

}
