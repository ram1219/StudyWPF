using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BikeShopApp
{
	/// <summary>
	/// TestPage.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class TestPage : Page
	{
		public TestPage()
		{
			InitializeComponent();
			InitListBox();
		}

		private void InitListBox()
		{
			Random rand = new Random();
			string[] names = { "SMG", "LHY", "YYJ", "KGR", "Jeff", "Dave" };
			List<Car> lists = new List<Car>();
			for(int i = 0; i < 10; i++)
			{
				// 아무 의미 없는 랜덤 색상
				byte red = (byte)(i % 3 == 0 ? 255 : (i * 50) % 255);
				byte green = 0;
				byte blue = (byte)(i % 3 == 0 ? (i * 50) % 255 : 255);
				// names배열의 길이안에서 랜덤으로 인덱스 번호 생성
				int index = rand.Next(names.Length);

				lists.Add(new Car
				{
					// 스피드 값 리스트 생성
					//Speed = i * 30,
					// 컬러 리스트 생성
					Color = Color.FromRgb(red, green, blue),
					// 드라이브 객체 리스트 생성
					Driver = new Human { Name=names[index], HasDrivingLicense=true}
				}) ;
			}
			// lists의 값을 바인딩한다.
			// xaml파일에서 사용을 할려면 {Binding} 을 이용해 할 수 있다.
			// lists에서 변수를 정해서 사용하고 싶으면 {Binding Speed}로 사용 가능하다. 
			// ListCar는 ListBaxt 네임(Name)
			//ListCar.DataContext = lists;
		}

		private void Grid_Loaded(object sender, RoutedEventArgs e)
		{
			//Human h = new Human();
			//h.Name = "Ram";
			//h.HasDrivingLicense = true;

			Car car = new Car();
			//car.Speed = 100;
			car.Color = Colors.Blue;
			car.Driver = new Human { Name = "Ram", HasDrivingLicense = true };
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Hello, World");
		}
	}
}
