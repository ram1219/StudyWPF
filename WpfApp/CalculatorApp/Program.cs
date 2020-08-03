using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
	class Program
	{
		static void Main(string[] args)
		{
			Calculator calc = new Calculator();

			double a = 4.5, b = 2.5;
			double result = calc.Add(a, b);
			Console.WriteLine($"result={result}");

			double result2 = calc.Subtract(a, b);
			Console.WriteLine($"result2={result2}");

			double result3 = calc.Multiple(a, b);
			Console.WriteLine($"result3={result3}");

			double result4 = calc.Divied(a, b);
			Console.WriteLine($"result4={result4}");
		}

		private static double Add(double a, double b)
		{
			return a + b;
		}

		/* 디버깅 
			직접실행창 : ?하고 입력 -> 값 확인 (?a) 
					   : 그냥 입력 -> 값 변경 (a=10)
			로컬 : 변수 값 출력
			조사식 : 알고싶은 값 또는 계산식을 넣어 결과를 확인 가능
		*/
	}
}
