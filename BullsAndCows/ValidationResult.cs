namespace BullsAndCows
{
	public class ValidationResult
	{
		public bool Success { get; private set; }
		public string Error { get; private set; }

		public ValidationResult()
		{
			Success = true;
		}

		public ValidationResult(string errorMessage)
		{
			Success = false;
			Error = errorMessage;
		}
	}
}
