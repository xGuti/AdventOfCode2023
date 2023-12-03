using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
	internal class Day1
	{
		static public void Solve()
		{
			String line;
			try
			{
				StreamReader sr = new StreamReader("input1.txt");
				do
				{
					line = sr.ReadLine();
					Console.WriteLine(line);
				} while (sr != null);
			}catch (Exception ex) { Console.WriteLine(ex.Message); }
		}
		
	}
}
