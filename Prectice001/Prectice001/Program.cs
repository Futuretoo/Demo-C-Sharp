using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Prectice001
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    //getDate();
        //    MatchName();
        //    Console.ReadKey();
        //}

        public static void getDate()
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");
            Console.WriteLine(date);

            // d 月中的某一天。一位数的日期没有前导零。 
            //dd 月中的某一天。一位数的日期有一个前导零。 
            //ddd 周中某天的缩写名称，在 AbbreviatedDayNames 中定义。 
            //dddd 周中某天的完整名称，在 DayNames 中定义。 
            //M 月份数字。一位数的月份没有前导零。 
            //MM 月份数字。一位数的月份有一个前导零。 
            //MMM 月份的缩写名称，在 AbbreviatedMonthNames 中定义。 
            //MMMM 月份的完整名称，在 MonthNames 中定义。 
            //y 不包含纪元的年份。如果不包含纪元的年份小于 10，则显示不具有前导零的年份。 
            //yy 不包含纪元的年份。如果不包含纪元的年份小于 10，则显示具有前导零的年份。 
            //yyyy 包括纪元的四位数的年份。 
            //gg 时期或纪元。如果要设置格式的日期不具有关联的时期或纪元字符串，则忽略该模式。

            // h 12 小时制的小时。一位数的小时数没有前导零。 
            //hh 12 小时制的小时。一位数的小时数有前导零。 
            //H 24 小时制的小时。一位数的小时数没有前导零。 
            //HH 24 小时制的小时。一位数的小时数有前导零。 
        }

        public static void MatchName()
        {
            string NameStr = "His name is Kobe Bryant Lakes";
            string name = "";
            Match m = null;
            Regex reg = new Regex("(?<name>([A-Z]{1}[a-z]+)+(\\s[A-Z]{1}[a-z]+)*)$");
            m = reg.Match(NameStr);
            if (m.Success)
            {
                name = m.Groups["name"].Value;
            }
            Console.WriteLine(name);
        }
    }
}
