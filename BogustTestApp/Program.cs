using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogustTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //SampleCustomerRepository repository = new SampleCustomerRepository();
            //IEnumerable<Customer> customers = repository.GetCustomers();

            var repository = new SampleCustomerRepository(); // 위의 주석처리한 부분과같음
            var customers = repository.GetCustomers();

            Console.WriteLine(JsonConvert.SerializeObject(customers, Formatting.Indented));
        }
    }
}
