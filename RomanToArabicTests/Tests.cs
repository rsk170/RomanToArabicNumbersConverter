using RomanToArabic;
using NUnit.Framework;

namespace RomanToArabicTests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[TestCase(1009, "MIX")]
		[TestCase(105, "CV")]
		[TestCase(15, "XV")]
		[TestCase(49, "XLIX")]
		[TestCase(94, "XCIV")]
		[TestCase(559, "DLIX")]
		[TestCase(1904, "MCMIV")]
		[TestCase(1559, "MDLIX")]
		[TestCase(1444, "MCDXLIV")]
		[TestCase(599, "DXCIX")]
		[TestCase(1999, "MCMXCIX")]
		[TestCase(3, "III")]
		[TestCase(8, "VIII")]
		[TestCase(256, "CCLVI")]
		[TestCase(20, "XX")]
		[TestCase(68, "LXVIII")]
		[TestCase(500, "D")]
		[TestCase(909, "CMIX")]
		public void Should_Convert_Correctly(int expected, string roman)
		{
			var arabic = Program.Convert(roman);
			Assert.AreEqual(expected, arabic);
		}

		private const string errorMessage = "Please enter a valid roman number!";

		[TestCase(true, "CMIX", null)]
		[TestCase(false, "1111", errorMessage)]
		[TestCase(true, "XV", null)]
		[TestCase(true, "CMIX", null)]
		[TestCase(true, "CM", null)]
		[TestCase(false, "CM22", errorMessage)]
		public void Validation(bool expected, string roman, string expectedErrorMessage)
		{
			var validationResult = Program.ValidateInput(out string _, roman);
			Assert.AreEqual(expected, validationResult.Success);
			if (!validationResult.Success)
			{
				Assert.AreEqual(expectedErrorMessage, validationResult.Error);
			}
		}

		[TestCase(true, "VIII")]
		[TestCase(false, "IIII")]
		[TestCase(true, "VII")]
		[TestCase(false, "IXI")]
		public void Should_allow_correct_number_of_digits(bool expected, string roman)
		{
			bool actual = Program.ValidateNumberOfSymbols(roman);
			Assert.AreEqual(expected, actual);
		}
	}
}