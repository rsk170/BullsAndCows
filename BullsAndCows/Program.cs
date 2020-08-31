using System;

namespace BullsAndCows
{
	public class Program
	{
		public const int Min = 3;
		public const int Max = 5;

		public static void Main(string[] args)
		{
			int numberOfDigits;
			while (!PromptNumberOfDigits(out numberOfDigits))
			{
				continue;
			}

			Game game = new Game(numberOfDigits);
			game.PlayGame();
		}

		public static bool PromptNumberOfDigits(out int numberOfDigits)
		{
			Console.Write($"Please enter the length of the number you would like to guess (from {Program.Min} to {Program.Max}): ");
			var numberOfDigitsString = Console.ReadLine();
			var validationResult = ValidateNumberOfDigits(out numberOfDigits, numberOfDigitsString);
			if (!validationResult.Success)
			{
				Console.WriteLine(validationResult.Error);
			}
			return validationResult.Success;
		}

		public static ValidationResult ValidateNumberOfDigits(out int numberOfDigits, string numberOfDigitsString)
		{
			if (!int.TryParse(numberOfDigitsString, out numberOfDigits))
			{
				return new ValidationResult("Please enter a single digit.");
			}

			if (!(numberOfDigits >= Program.Min && numberOfDigits <= Program.Max))
			{
				return new ValidationResult($"Please enter a number between {Min} and {Max}.");
			}

			return new ValidationResult();
		}
	}
}
