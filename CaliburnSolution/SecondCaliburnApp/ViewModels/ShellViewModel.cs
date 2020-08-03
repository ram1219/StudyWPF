using Caliburn.Micro;
using MySql.Data.MySqlClient;
using SecondCaliburnApp.Helpers;
using SecondCaliburnApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondCaliburnApp.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHaveDisplayName
    {
        public override string DisplayName { get; set; }

        string firstName;
        public string FirstName 
        {
            get => firstName;
			set
			{
                firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
                NotifyOfPropertyChange(() => CanClearName);
            }
        }

        string lastName;
        public string LastName
		{
            get => lastName;
			set
			{
                lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
                NotifyOfPropertyChange(() => CanClearName);
            }
		}

        public string FullName
		{
            get => $"{FirstName} {LastName}";
		}

        public ShellViewModel()
        {
            DisplayName = "Second Caliburn App";
            FirstName = "Garam";

            // People 모델 생성
            People = new BindableCollection<PersonModel>();

            //People.Add(new PersonModel { LastName = "Gates", FirstName = "Bill" });
            //People.Add(new PersonModel { LastName = "Tim", FirstName = "Hole" });
            //People.Add(new PersonModel { LastName = "Jobs", FirstName = "Steve" });

            InitComboBox();
        }

		private void InitComboBox()
		{
            People.Add(new PersonModel { LastName = "", FirstName = "선택" });

			using(MySqlConnection conn = new MySqlConnection(Commons.STRCONNSTRING))
			{
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Commons.SELECTPEOPLEQUERY, conn);

                // DB 값을 읽어오는 reader
                MySqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
                    var temp = new PersonModel
                    {
                        FirstName = reader["firstname"].ToString(),
                        LastName = reader["lastname"].ToString()
                    };
                    People.Add(temp);
				}
			}
            SelectedPerson = People.Where(v => v.FirstName.Contains("선택")).First();
        }

		// 콤보박스 사람 리스트
		public BindableCollection<PersonModel> People { get; set; }

        PersonModel selectedPerson;
        public PersonModel SelectedPerson
		{
            get => selectedPerson;
			set
			{
                selectedPerson = value;
                // ViewModels의 LastName
                this.LastName = selectedPerson.LastName;
                this.FirstName = selectedPerson.FirstName;

                // 값의 변경사항을 페이지에 전달
                NotifyOfPropertyChange(() => SelectedPerson);
                NotifyOfPropertyChange(() => CanClearName);
			}
		}
        
        public void ClearName()
		{
            this.FirstName = this.LastName = string.Empty;
		}

        // 속성
        public bool CanClearName
		{
            get => !(string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName));
            /*
            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
                return false;
            else
                return true;
            */
		}

        // Usercontrol FirstChildView Load
        public void LoadPageOne()
		{
            ActivateItem(new FirstChildViewModel());
		}

        // UeserControl SecondChildView Load
        public void LoadPageTwo()
		{
            ActivateItem(new SecondChileViewModel());
		}
    }
}
