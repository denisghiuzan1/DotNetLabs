using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceHost host = new ServiceHost(typeof(PostComment.ServicePC),
                new Uri("http://localhost:8080/post"));
            //host.AddDefaultEndpoints();

            host.Open();
            var dd = host.Description;
            foreach (ServiceEndpoint sea in dd.Endpoints)
            {
                Console.WriteLine(" {0} {1} {2}", sea.Address, sea.Binding.Name,
                    sea.Contract.Name);
            }
            Console.WriteLine("WCF started...");
            Console.ReadLine();
        }


    }
}
