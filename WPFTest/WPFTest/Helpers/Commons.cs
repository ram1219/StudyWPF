using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFTest.Helpers
{
    public class Commons
    {
        public static string STRCONNSTRING = "Data Source=localhost;Port=3306;Database=iot_sensordata;uid=root;password=mysql_p@ssw0rd";

        public static string INSERTQUERY = @"INSERT INTO sensordatatbl
											 (Date, Value) 
											 VALUES
											 (@Date, @Value)";
    }
}
