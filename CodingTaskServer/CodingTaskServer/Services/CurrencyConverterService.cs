using CodingTaskServer;
using Grpc.Core;
using System.Text.RegularExpressions;

namespace CodingTaskServer.Services
{
	public class CurrencyConverterService : CurrencyConverter.CurrencyConverterBase
	{
		private readonly ILogger<CurrencyConverterService> _logger;
		public CurrencyConverterService(ILogger<CurrencyConverterService> logger) => _logger = logger;


		private static readonly Regex numbersOnlyRegex = new(@"\D");
		public override Task<WordReply> ConvertToWords(WordRequest request, ServerCallContext context)
		{
			if (request.NumericAmount != null)
			{
				string[] numberParts = request.NumericAmount.Split(',');
				if (numberParts != null && numberParts.Length > 0)
				{
					WordReply reply = new() { AmountInWords = "", ValidatedNumericAmount = "" };
					//cents
					if (numberParts.Length > 1)
					{
						string centString = numbersOnlyRegex.Replace(numberParts[1], "");
						if (centString.Length > 2) //reduce the number to two decimal places (eg. 1203 to 12) NOTE: this does not round up (eg. 126 to 12) as cents should never have 3 digits.
						{
							centString = centString[..2];
						}
						else if (centString.Length == 1) //add zero for 0,1 to yield 10 cents and not 1 cent.
						{
							centString = string.Concat(centString, "0");
						}
						if (int.TryParse(centString, out int centValue)) //convert to cent string to int value
						{
							if (centValue > 0)
							{
								//the "and" has to be added as it will always be needed when there is a cent value even if the dollar value is zero (zero dollars AND ... cents)
								reply.AmountInWords = string.Concat(" and ", GetWord(centValue), centValue > 1 ? " cents" : " cent");
								if (centValue < 10) //add 0 to string as this would turn 2 cents into ,2 which would be 20 cents
								{
									reply.ValidatedNumericAmount = string.Concat(",0", centValue);
								}
								else
								{
									reply.ValidatedNumericAmount = string.Concat(",", centValue);
								}
							}
						}
					}
					//dollars
					string dollarString = numbersOnlyRegex.Replace(numberParts[0], "");
					//ignore any characters beyond 9 (due to limit of 999 999 999)
					//this could also be handle bei converting the larger number to int ans then clamping it
					//any charactery beyond 9 will be treated as a typo with only the first 9 to be considered
					if (dollarString.Length > 9) 
					{
						dollarString = dollarString[(dollarString.Length - 9)..];
					}
					int dollarValue;
					if (!int.TryParse(dollarString, out dollarValue))
					{
						dollarValue = 0;
					}
					reply.ValidatedNumericAmount = string.Concat(dollarValue, reply.ValidatedNumericAmount);
					if (dollarValue > 0)
					{
						reply.AmountInWords = string.Concat(dollarValue > 1 ? "dollars" : "dollar", reply.AmountInWords);
						//slowly iterate through the number from the back-to-front (low-to-high) in steps of one hundred.
						for (int i = 0; i < 3; i++)
						{
							int tensValue = dollarValue % 100;
							dollarValue /= 100;
							int hundredsValue = dollarValue % 10;
							dollarValue /= 10;
							if (i > 0 && (tensValue > 0 || hundredsValue > 0))
							{
								//add millions and thousends qualifier if relavent
								//thousend only relevant if there is actual value in the bracket (eg. to prevent 1 000 000 being converted to one million tousend dollars)
								//this could also be done using another array { "thousend", "million", "billion" } however due to the limit declaring another table would be a waste
								if (i == 1)
								{
									reply.AmountInWords = string.Concat("thousand ", reply.AmountInWords);
								}
								else
								{
									reply.AmountInWords = string.Concat("million ", reply.AmountInWords);
								}
							}
							//add then tens word
							if (tensValue > 0)
							{
								reply.AmountInWords = string.Concat(GetWord(tensValue), " ", reply.AmountInWords);
							}
							//add the hundreds word + hundred qualifier
							if (hundredsValue > 0)
							{
								reply.AmountInWords = string.Concat(GetWord(hundredsValue), " hundred ", reply.AmountInWords);
							}
							if (dollarValue < 1)
							{
								break;
							}
						}
					}
					else
					{
						reply.AmountInWords = string.Concat("zero dollars", reply.AmountInWords);
					}
					return Task.FromResult(reply);
				}

			}
			return Task.FromResult(new WordReply() { AmountInWords = "", ValidatedNumericAmount = "" });
		}

		private static readonly string[] baseNumbers = new string[]
		{ 
			//index 0 - 8
			"one", "two",  "three", "four", "five", "six", "seven", "eight", "nine", 
			//index 9 - 18
			"ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen",
			//index 19 - 26
			"twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
		};

		/// <summary>
		/// Convert a number between 1 and 99 to a word/word combo (a-b).
		/// </summary>
		private static string GetWord(int numericValue)
		{
			if (numericValue < 20)
			{
				return baseNumbers[numericValue - 1];
			}
			else
			{
				int baseIndex = numericValue % 10; //take the mod when dividing by ten to get the base number
				int prefixIndex = Convert.ToInt32(Math.Floor(0.1f * numericValue) + 17); //determine the multiple of 10 to determine the prefix
																						 //17 is added as 20 yields an index of 2 which in the number table equates to index 19
				if (baseIndex > 0)
				{
					return string.Concat(baseNumbers[prefixIndex], "-", baseNumbers[baseIndex - 1]);
				}
				else
				{
					return baseNumbers[prefixIndex];
				}
			}
		}
	}
}