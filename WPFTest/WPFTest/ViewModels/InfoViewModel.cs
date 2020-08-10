using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFTest.Views;

namespace WPFTest.ViewModels
{
	public class InfoViewModel : ViewAware
	{      
        // 솔루션 탐색기 - Properties - AssemblyInfo.cs 에서 없는 값 입력

        // 제품 이름
        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")                  
                        return titleAttribute.Title;
                    
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        // 버전
        public string AssemblyVersion
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }

        // 저작권
        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                    return "";

                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        // 회사 이름
        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                    return "";

                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        // 설명
        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                    return "";

                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }
    }
}
