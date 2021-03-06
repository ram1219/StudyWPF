﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogustTestApp
{
	public class Customer
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Address { get; set; }

		public string Phone { get; set; }

		public string ContactName { get; set; }

		// Order Class를 리스트 형식으로 생성(List도 사용 가능)
		public IEnumerable<Order> Orders { get; set; } 
	}
}
