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
			var repository = new SampleCustomerRepository();
			IEnumerable<Customer> customers = repository.GetCustomers();

			Console.WriteLine(JsonConvert.SerializeObject(customers, Formatting.Indented));
		}
	}
}
