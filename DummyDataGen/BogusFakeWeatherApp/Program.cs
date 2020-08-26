﻿using Bogus;
using Newtonsoft.Json;
using System;

namespace BogusFakeWeatherApp
{
	class Program
	{
		static void Main()
		{
			var Rooms = new[] { "DiningRoom", "LivingRoom", "BathRoom", "BedRoom", "GuestRoom" };

			var sensorFaker = new Faker<SensorInfo>()
				.RuleFor(s => s.Dev_Id, f => f.PickRandom(Rooms))
				.RuleFor(s => s.Curr_Time, f => f.Date.Past(0).ToString("yyyy-MM-dd HH:mm:ss.ff"))
				.RuleFor(s => s.Temp, f => float.Parse(f.Random.Float(19.0f, 35.9f).ToString("0.00")))
				.RuleFor(s => s.Humid, f => float.Parse(f.Random.Float(40.0f, 63.9f).ToString("0.00")))
				.RuleFor(s => s.Press, f => float.Parse(f.Random.Float(800.0f, 999.0f).ToString("0.00")));

			var thisValue = sensorFaker.Generate();

			//// 소수점 두 자릿 수 까지 표현
			//thisValue.Temp = float.Parse(thisValue.Temp.ToString("0.00"));
			//thisValue.Humid = float.Parse(thisValue.Humid.ToString("0.00"));
			//thisValue.Press = float.Parse(thisValue.Press.ToString("0.00"));

			Console.WriteLine(JsonConvert.SerializeObject(thisValue, Formatting.Indented));
		}
	}
}
