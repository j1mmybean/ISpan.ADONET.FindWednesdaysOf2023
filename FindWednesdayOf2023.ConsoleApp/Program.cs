using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindWednesdayOf2023.ConsoleApp
{
	/// <summary>
	/// 找出2023年每個星期三的日期
	/// </summary>
	internal class Program
	{
		static void Main(string[] args)
		{
			string result = string.Empty;
			foreach (var day in FindWednesdayOf2023.FindWeekOfDay(2023, DayOfWeek.Wednesday))
			{
				result += day.ToString("yyyy/MM/dd") + "\n";
			}
			Console.WriteLine(result);
		}
	}
	public class FindWednesdayOf2023
	{
		/// <summary>
		/// 輸入年分和星期?，用List輸出此年的所有星期?之日期
		/// </summary>
		/// <param name="year"></param>
		/// <param name="dayOfWeek"></param>
		/// <returns></returns>
		public static List<DateTime> FindWeekOfDay(int year, DayOfWeek dayOfWeek)
		{
			//先找出此年的第一個星期?
			DateTime firstDayOfWeek = FindFirstWeekOfDay(year, dayOfWeek);

			var CollectionOfWeekOfDay = new List<DateTime>();

			//從第一個星期?開始，依序將此年的所有星期三加入List中，直到日期年份為下一年為止
			while (firstDayOfWeek.Year == year)
			{
				CollectionOfWeekOfDay.Add(firstDayOfWeek);
				firstDayOfWeek = firstDayOfWeek.AddDays(7);
			}
			return CollectionOfWeekOfDay;
		}

		/// <summary>
		/// 輸入年份和星期?,找出此年的第一個星期?
		/// </summary>
		/// <param name="year"></param>
		/// <param name="dayOfWeek"></param>
		/// <returns></returns>
		public static DateTime FindFirstWeekOfDay(int year, DayOfWeek dayOfWeek)
		{
			int day = 1;			
			//從此年的一月一日開始找，若不是則換下一天直到找到為止
			while (new DateTime(year, 1, day).DayOfWeek != dayOfWeek)
			{
				day++;
			}

			DateTime firstWeekOfDay = new DateTime(year, 1, day);
			return firstWeekOfDay;
		}
	}
}
