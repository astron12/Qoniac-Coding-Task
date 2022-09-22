using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Grpc.Net.Client;

namespace CodingTaskClient
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		/* Setup + UI callbacks */ 
		public MainWindow() => InitializeComponent();
		private void Send_Btn_Click(object sender, RoutedEventArgs e) => RequestConversion(Input_Tb.Text);
		private void RandomInput_Btn_Click(object sender, RoutedEventArgs e)
		{
			Random random = new();
			string targetInput = "";
			//generate up to 15 random numbers
			int inputLength = random.Next(1,15);
			for (int i = 0; i < inputLength; i++)
			{
				targetInput = string.Concat(random.Next(0, 9), targetInput);
			}
			//insert a comma randomly to generate between 0 and 4 decimal places
			targetInput = targetInput.Insert(random.Next(Math.Max(inputLength - 4, 0), inputLength), ",");

			Input_Tb.Text = targetInput;
			RequestConversion(targetInput);
		}

		/* Conversion */
		private async void RequestConversion(string targetInput)
		{
			Output_Lb.Text = "Waiting for reply...";
			using GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:7187");
			CurrencyConverter.CurrencyConverterClient client = new(channel);
			try
			{
				var reply = await client.ConvertToWordsAsync(new WordRequest { NumericAmount = targetInput }, deadline: DateTime.UtcNow.AddSeconds(4));
				if (reply.ValidatedNumericAmount == "")
				{
					Output_Lb.Text = "Invald Input";
				}
				else
				{
					Output_Lb.Text = string.Concat(reply.AmountInWords, ". (", GetDisplayFormat(reply.ValidatedNumericAmount), ")");
					Input_Tb.Text = reply.ValidatedNumericAmount;
				}
			}
			catch
			{
				Output_Lb.Text = "Request failed.";
			}
		}

		/* Misc */
		/// <summary>
		/// Format currency to be more readable when displayed and adding the dollar sign.
		/// </summary>
		private string GetDisplayFormat(string rawNumericAmount)
		{
			int length = rawNumericAmount.IndexOf(",", StringComparison.OrdinalIgnoreCase);
			if (length < 0) 
			{
				length = rawNumericAmount.Length;
			}
			//spaces at 4 and 7
			if (length >= 4)
			{
				rawNumericAmount = rawNumericAmount.Insert(length - 3, " ");
				if (length >= 7)
				{
					rawNumericAmount = rawNumericAmount.Insert(length - 6, " ");
				}
			}
			return string.Concat("$", rawNumericAmount);
		}
	}
}
