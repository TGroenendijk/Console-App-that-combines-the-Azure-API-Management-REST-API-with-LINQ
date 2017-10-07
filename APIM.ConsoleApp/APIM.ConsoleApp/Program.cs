using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIM.ConsoleApp.Repositories;


namespace APIM.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Primary key: ");
            string token = Console.ReadLine();

            ApimRepository repository = new ApimRepository();

            string userId = repository.GetUserIdByToken(token).Result;

           
            Console.WriteLine("\nUser: \n{0}", userId);

            Console.Read();
        }
    }
}
