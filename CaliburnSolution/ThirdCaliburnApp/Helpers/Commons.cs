using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdCaliburnApp.Helpers
{
	public class Commons
	{
		public static readonly string CONNSTRING = "Data Source=localhost;Port=3306;Database=testdb;uid=root;password=mysql_p@ssw0rd";

		public class EmployeesTbl
		{
			public static string SELECT_EMPLOYEES = @"SELECT 
														Id,
														empname,
														salary,
														deptname,
														destination
													  FROM testdb.employeestbl";

			internal static string UPDATE_EMPLOYEES = @"UPDATE 
															employeestbl
														SET
															empname = @empname,		
															salary = @salary,
															deptname = @deptname,
															destination = @destination
														WHERE Id = @Id";

			internal static string INSERT_EMPLOYEES = "";
		}		
	}
}
