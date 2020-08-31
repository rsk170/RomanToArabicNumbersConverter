using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RomanToArabic
{
	public class ValidationResult
	{
		public bool Success { get; set; }
		public string Error { get; set; }

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
