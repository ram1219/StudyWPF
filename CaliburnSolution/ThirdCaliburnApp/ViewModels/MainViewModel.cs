using Caliburn.Micro;
using ControlzEx.Standard;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using ThirdCaliburnApp.Helpers;
using ThirdCaliburnApp.Models;

namespace ThirdCaliburnApp.ViewModels
{
	public class MainViewModel : Conductor<object>, IHaveDisplayName
	{
		EmployeesModel employeesModel;

		#region 속성 영역
		private int id;
		public int Id 
		{ 
			get => id;
			set
			{
				id = value;
				NotifyOfPropertyChange(() => Id);
			}
		}

		private string empname;
		public string EmpName 
		{
			get => empname;
			set
			{
				empname = value;
				NotifyOfPropertyChange(() => EmpName);
			}
		}

		private decimal salary;
		public decimal Salary 
		{
			get => salary;
			set
			{
				salary = value;
				NotifyOfPropertyChange(() => Salary);
			} 
		}

		private string deptname;
		public string DeptName 
		{
			get => deptname;
			set
			{
				deptname = value;
				NotifyOfPropertyChange(() => DeptName);
			} 
		}

		private string destination;
		public string Destination 
		{
			get => destination;
			set
			{
				destination = value;
				NotifyOfPropertyChange(() => Destination);
			}
		}

		public BindableCollection<EmployeesModel> employees;
		// 전체 Employess 리스트
		public BindableCollection<EmployeesModel> Employees 
		{
			get => employees;
			set
			{
				employees = value;
				NotifyOfPropertyChange(() => Employees);
			}
		}

		// 리스트 중 선택된 하나의 Employee
		EmployeesModel selectedEmployee;
		public EmployeesModel SelectedEmployee 
		{
			get => selectedEmployee;
			set
			{
				selectedEmployee = value;

				Id = value.Id;
				EmpName = value.EmpName;
				Salary = value.Salary;
				DeptName = value.DeptName;
				Destination = value.Destination;

				NotifyOfPropertyChange(() => SelectedEmployee);
			}
		}

		#endregion

		#region 생성자 영역
		public MainViewModel()
		{
			GetEmployees();
		}

		#endregion

		public void NewEmployee()
		{
			Id = 0;
			EmpName = string.Empty;
			Salary = 0;
			DeptName = Destination = string.Empty;
		}

		public void GetEmployees()
		{
			using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTRING))
			{
				conn.Open();
				MySqlCommand cmd = new MySqlCommand(Commons.EmployeesTbl.SELECT_EMPLOYEES, conn);

				MySqlDataReader reader = cmd.ExecuteReader();
				Employees = new BindableCollection<EmployeesModel>();

				while (reader.Read())
				{
					var temp = new EmployeesModel
					{
						// []안은 DB의 테이블의 속성명
						Id = (int)reader["Id"],
						EmpName = reader["empname"].ToString(),
						Salary = (decimal)reader["salary"],
						DeptName = reader["deptname"].ToString(),
						Destination = reader["destination"].ToString()
					};

					Employees.Add(temp);
				}
			}
		}

		public bool CanSaveEmployee
		{
			get
			{
				return !(Id == 0 && string.IsNullOrEmpty(EmpName) && Salary == 0 && string.IsNullOrEmpty(DeptName) && string.IsNullOrEmpty(Destination));
			}
		}

		// Save 버튼
		public void SaveEmployee()
		{
			int resultRow = 0;

			using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTRING))
			{
				conn.Open();
				MySqlCommand cmd = new MySqlCommand(Commons.EmployeesTbl.UPDATE_EMPLOYEES, conn);

				MySqlParameter paramEmpName = new MySqlParameter("@empname", MySqlDbType.VarChar, 45);
				paramEmpName.Value = EmpName;
				cmd.Parameters.Add(paramEmpName);

				MySqlParameter paramSalary = new MySqlParameter("@salary", MySqlDbType.Decimal);
				paramSalary.Value = Salary;
				cmd.Parameters.Add(paramSalary);

				MySqlParameter paramDeptName = new MySqlParameter("@deptname", MySqlDbType.VarChar, 45);
				paramDeptName.Value = DeptName;
				cmd.Parameters.Add(paramDeptName);

				MySqlParameter paramDestination = new MySqlParameter("@destination", MySqlDbType.VarChar, 45);
				paramDestination.Value = Destination;
				cmd.Parameters.Add(paramDestination);

				MySqlParameter paramId = new MySqlParameter("@Id", MySqlDbType.Int32);
				paramId.Value = Id;
				cmd.Parameters.Add(paramId);

				resultRow = cmd.ExecuteNonQuery();
			}

			if(resultRow > 0)
			{
				MessageBox.Show("저장했습니다.");
				GetEmployees();
			}
		}
	}
}
