using System;
using System.Collections.Generic;
using System.Text;

namespace BullsAndCows
{
	public class Game
	{
		private readonly int _numberOfDigits;
		private readonly string _secret;

		public Game(int numberOfDigits)
		{
			_numberOfDigits = numberOfDigits;
			_secret = Digits.GetRandomNumber(numberOfDigits);
		}

		public void PlayGame()
		{
			while (true)
			{
				if (!PromptGuess(out string guess))
				{
					continue;
				}

				if (_secret == guess)
				{
					Console.WriteLine("Congratulations! You won!");
					break;
				}

				var counts = CountBullsAndCows(_secret, guess);
				Console.WriteLine($"{counts.Bulls} bulls");
				Console.WriteLine($"{counts.Cows} cows");
			}
		}

		public BullsAndCowsCount CountBullsAndCows(string secret, string guess)
		{
			int matchedByPosition = 0;

			for (int i = 0; i < _numberOfDigits; i++)
			{
				if (secret[i] == guess[i])
				{
					matchedByPosition++;
				}
			}

			int matchedByValue = 0;
			for (int i = 0; i < _numberOfDigits; i++)
			{
				if (secret.Contains(guess[i]))
				{
					matchedByValue++;
				}
			}

			return new BullsAndCowsCount(matchedByPosition, matchedByValue - matchedByPosition);
		}

		public bool PromptGuess(out string guess)
		{
			Console.Write("Please enter a number: ");
			guess = Console.ReadLine();

			if (!Digits.HasUniqueDigits(guess, _numberOfDigits))
			{
				Console.WriteLine("Please enter unique digits.");
				return false;
			}

			if (guess.Length != _numberOfDigits)
			{
				Console.WriteLine($"Please enter {_numberOfDigits} digits.");
				return false;
			}

			for (int i = 0; i < _numberOfDigits; i++)
			{
				if (!char.IsDigit(guess[i]))
				{
					Console.WriteLine("Please enter numbers!");
					return false;
				}
			}

			return true;
		}

	}
}
