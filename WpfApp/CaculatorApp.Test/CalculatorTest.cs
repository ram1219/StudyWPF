using System;
using CalculatorApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaculatorApp.Test
{
	[TestClass]
	public class CalculatorTest
	{
		[TestMethod]
		public void TestAdd3and7()
		{
			// 참조 - 참조 추가 - 프로젝트 에서 테스트할 프로젝트를 체크하여 추가한다.

			// 3 + 7 = 10
			double a = 3.0;
			double b = 7.0;
			double expected = 10.0;

			Calculator calc = new Calculator();
			double actual = calc.Add(a, b);

			// expected와 actual이 같은 값인지 비교
			Assert.AreEqual(expected, actual);
		}

		// [TestMethod] 안에 들어가 있어야 단위 테스트가 가능하다.
		[TestMethod]
		public void TestMultiple4and5()
		{
			// 4 * 5 = 20
			double a = 4.0;
			double b = 5.0;
			double expected = 20.0;

			Calculator calc = new Calculator();
			double actual = calc.Multiple(a, b);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void TestDivied10and2()
		{
			// 10 / 2 = 5
			double a = 10.0;
			double b = 5.0;
			double expected = 2.0;

			Calculator calc = new Calculator();
			double actual = calc.Divied(a, b);

			Assert.AreEqual(expected, actual);
		}

		// Ctrl + F5 로 실행하지 않고 파일에서 우클릭 - 테스트 실행 으로 실행한다.
	}
}
