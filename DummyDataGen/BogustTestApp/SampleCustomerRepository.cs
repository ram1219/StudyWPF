using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogustTestApp
{
	public class SampleCustomerRepository
	{
		public IEnumerable<Customer> GetCustomers()
		{
			// Bogus를 사용하여 123456개의 랜덤 수 생성
			Randomizer.Seed = new Random(123456);

			// 가상의 Order 데이터 생성
			var genOrder = new Faker<Order>()
				.RuleFor(o => o.Id, Guid.NewGuid)                               // Guid 타입 생성
				.RuleFor(o => o.Date, f => f.Date.Past(1))                      // Date 타입 생성
				.RuleFor(o => o.OrderValue, f => f.Finance.Amount(10, 10000))	// 금융 -> 10 부터 10000까지의 데이터
				.RuleFor(o => o.Shipped, f => f.Random.Bool(0.9f));             // 10개 중 9개는 ture 1개는 false

			var genCustomer = new Faker<Customer>()
				.RuleFor(o => o.Id, Guid.NewGuid)
				.RuleFor(o => o.Name, f => f.Company.CompanyName())             // 임의의 회사 이름들을 자동으로 생성
				.RuleFor(o => o.Address, f => f.Address.StreetAddress())		// 임의의 주소(Street 까지)
				.RuleFor(o => o.Phone, f => f.Phone.PhoneNumber())
				.RuleFor(o => o.ContactName, f => f.Name.FullName())
				.RuleFor(o => o.Orders, f => genOrder.Generate(f.Random.Number(1, 2)).ToList());

			// 가상의 데이터 10개 생성
			return genCustomer.Generate(10);
		}
	}
}
