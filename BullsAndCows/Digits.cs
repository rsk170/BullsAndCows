using System;
using System.Collections.Generic;
using System.Text;

namespace BullsAndCows
{
	public class Digits
	{
		public static bool HasUniqueDigits(string possibility, int numberOfDigits)
		{
			for (int i = 0; i < numberOfDigits - 1; i++)
			{
				for (int j = i + 1; j < numberOfDigits; j++)
				{
					if (possibility[i] == possibility[j])
					{
						return false;
					}
				}
			}

			return true;
		}

		public static string GetRandomNumber(int numberOfDigits)
		{
			string possibility;
			do
			{
				possibility = GeneratePossibleNumber(numberOfDigits);
			} while (!HasUniqueDigits(possibility, numberOfDigits));

			return possibility;
		}

		private static string GeneratePossibleNumber(int numberOfDigits)
		{
			Random random = new Random();
			string possibility = "";
			for (int i = 0; i < numberOfDigits; i++)
			{
				possibility += random.Next(1, 9).ToString();
			}

			return possibility;
		}

	}
}
