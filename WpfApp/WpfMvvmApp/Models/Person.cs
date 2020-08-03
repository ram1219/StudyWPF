using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMvvmApp.Helpers;

namespace WpfMvvmApp.Models
{
	public class Person
	{
		// 값을 가져와서 바로 사용(출력)하는 경우 바로 get; set; 으로 사용
		public string FirstName { get; set; }
		public string LastName { get; set; }

		// 값을 가져와서 올바른지 확인하는 등의 추가 작업을 할 경우 아래와 같이 사용
		string email;
		public string Email
		{
			// get { return email; } 과 같다
			get => email;
			set 
			{
				// 올바른 이메일 형식인지 확인
				if (Commons.IsValudEmail(value))
					email = value;
				else
					throw new Exception("Invalid Email");	
			}
		}

		DateTime date;
		public DateTime Date
		{
			get { return date; }
			set 
			{
				var result = Commons.CalcAge(value);	
				if (result > 150 || result < 0)
					throw new Exception("Invalud Age");
				else
					date = value; 
			}
		}

		// 속성들만 넣은 생성자 생성
		public Person(string firstName, string lastName, string email, DateTime date)
		{
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			Date = date;
		}

		// 생일인지 확인하는 함수
		public bool IsBirthDay
		{
			get
			{
				// 생일일 경우 true
				return DateTime.Now.Month == Date.Month && DateTime.Now.Day == Date.Day;
			}
		}
		
		// 성인인지 확인하는 함수
		public bool IsAdult
		{
			get
			{
				return Commons.CalcAge(Date) > 18;
			}
		}

		// 띠 
		public string ChnZodiac
		{
			get
			{
				return Commons.GetChineseZodiac(Date);
			}
		}

		// 별자리
		public string CalcZodiac
		{
			get
			{
				return Commons.GetCalcZodiac(Date);
			}
		}
	}
}
