using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
	internal class Day2
	{
		public static void Solve()
		{
			const int RED_CUBES = 12;
			const int GREEN_CUBES = 13;
			const int BLUE_CUBES = 14;

			int sum = 0;

			String line;
			var path = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..");
			path += "\\input2.txt";

			try
			{
				StreamReader streamReader = new StreamReader(path);
				do
				{
					line = streamReader.ReadLine();
					if (line == null) break;

					var possible = true;
					var data = line.Split(' ');
/*					 * [0] - Game
					 * [1] - ID + ':'
					 * [even] - amount
					 * [odd] - color + {','|';'}
*/
					data[1] = data[1].Trim(':');
					int id = int.Parse(data[1]);

					int[] min = { 0, 0, 0 };

					for (int i = 2; i < data.Length - 1; i += 2)
					{
						var amount = Int32.Parse(data[i]);
						var color = data[i + 1][0];
						/* solution Day 2.1
						var limit = color == 'r' ? RED_CUBES : color == 'g' ? GREEN_CUBES : BLUE_CUBES;
						if (amount) > limit)
						{
							possible = false;
							break;
						}
						*/
						var colorLimit = color == 'r' ? 0 : color == 'g' ? 1 : 2;
						if (amount > min[colorLimit])
							min[colorLimit] = amount;
					}
					//if (possible) sum += id; //solution Day 2.1
					sum += min[0] * min[1] * min[2];

                } while (line != null);
			}
			catch (Exception ex) { Console.WriteLine(ex.Message); }
			finally { Console.WriteLine(sum); }
		}
	}
}
