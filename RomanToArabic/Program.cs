using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace RomanToArabic
{
	public class Program
	{
		static void Main(string[] args)
		{
			string roman;
			while (!PromptInput(out roman))
			{
				continue;
			}

			Console.WriteLine($"The Roman number is {Convert(roman)}");
		}

		public static bool PromptInput(out string romanNumber)
		{
			Console.WriteLine("Please enter a roman number: ");
			string roman = Console.ReadLine();
			var validationResult = ValidateInput(out romanNumber, roman);
			if (!validationResult.Success)
			{
				Console.WriteLine(validationResult.Error);
			}

			return validationResult.Success;
		}

		public static ValidationResult ValidateInput(out string romanNumber, string roman)
		{
			if (!ValidateSymbols(roman) || !ValidateNumberOfSymbols(roman))
			{
				romanNumber = null;
				return new ValidationResult("Please enter a valid roman number!");
			}

			romanNumber = roman;
			return new ValidationResult();
		}

		public static bool ValidateSymbols(string roman)
		{
			Regex rgx = new Regex(@"^[IVXLCDM]+$");
			return rgx.IsMatch(roman);
		}

		public static bool ValidateNumberOfSymbols(string roman)
		{
			Regex rgx = new Regex(@"^
(?<thousands>(CM)|(M{1,3}))?
(?<fivehundreds>(CD)|D)?
(?<hundreds>(XC)|(C{1,3}))?
(?<fifthies>(XL)|L)?
(?<tens>(IX)|(X{1,3}))?
(?<fives>(IV)|V)?
(?<ones>I{1,3})?
$", RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);
			return rgx.IsMatch(roman);
		}

		public static int Convert(string roman)
		{
			int arabicNumber = 0;

			for (int i = 0; i < roman.Length; i++)
			{
				int current = ParseNumber(roman[i]);
				int sum = current;

				if (i > 0)
				{
					int prev = ParseNumber(roman[i - 1]);

					if (prev < current)
					{
						sum = -2 * prev + current;
					}
				}

				arabicNumber += sum;
			}

			return arabicNumber;
		}

		public static int ParseNumber(char roman)
		{
			int arabic;
			switch (roman)
			{
				case 'I':
					arabic = 1;
					break;
				case 'V':
					arabic = 5;
					break;
				case 'X':
					arabic = 10;
					break;
				case 'L':
					arabic = 50;
					break;
				case 'C':
					arabic = 100;
					break;
				case 'D':
					arabic = 500;
					break;
				case 'M':
					arabic = 1000;
					break;
				default:
					arabic = 0;
					break;
			}

			return arabic;
		}
	}
}
