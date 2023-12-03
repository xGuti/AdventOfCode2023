using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
	static class Digits
	{
		public const String zero = "zero";
		public const String one = "one";
		public const String two = "two";
		public const String three = "three";
		public const String four = "four";
		public const String five = "five";
		public const String six = "six";
		public const String seven = "seven";
		public const String eight = "eight";
		public const String nine = "nine";
		public static readonly String[] any = { zero, one, two, three, four, five, six, seven, eight, nine };
	}
	internal class Day1
	{
		static public void Solve()
		{
			int sum = 0;
			String line;
			var path = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..");
			path += "\\input1.txt";
			
			//solve day 1.2
			var regexInString = @"(?=(\d";
			foreach (var digit in Digits.any)
				regexInString += "|" + digit;
			regexInString += "))";

			Regex exp = new Regex(regexInString); //solve day 1.1 "\\d"

            try
			{
				StreamReader streamReader = new StreamReader(path);
				do
				{
					line = streamReader.ReadLine();
					if(line == null) break;

					MatchCollection matches = exp.Matches(line.ToLower());
			
					var firstMatch = matches.First().Groups[1].ToString();
					var lastMatch = matches.Last().Groups[1].ToString();
                    
                    var x = Convert(firstMatch)+Convert(lastMatch);

                    sum += Int32.Parse(x);

                } while (line != null);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
			finally
			{
				Console.WriteLine($"final sum: {sum}");
			}
		}

		public static string Convert(string value)
		{
			for (int i = 0; i < Digits.any.Count(); i++)
			{
				if (value == Digits.any[i])
					return i.ToString();
			}
			return value;
		}
	}
}
