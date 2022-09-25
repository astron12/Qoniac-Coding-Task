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
		private void Input_Tb_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter) //QoL auto convert when user presses enter when inputting input.
			{
				Keyboard.ClearFocus();
				RequestConversion(Input_Tb.Text);
			}
		}
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
			//correspnding to the server addresses as specified in the server launchSettings.json (applicationUrl, second value)
			using GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:7187");
			CurrencyConverter.CurrencyConverterClient client = new(channel);
			try
			{
				//send input to server and timeout connection after 4 seconds of the server not responding when run locally for debugging this should be enough time for the server to respond.
				var reply = await client.ConvertToWordsAsync(new WordRequest { NumericAmount = targetInput }, deadline: DateTime.UtcNow.AddSeconds(4));
				if (reply.ValidatedNumericAmount == "")
				{
					Output_Lb.Text = "Invald Input";
				}
				else
				{
					//show to converted amount and the formatted (to make it more readable) validated numeric return 
					Output_Lb.Text = string.Concat(reply.AmountInWords, ". (", GetDisplayFormat(reply.ValidatedNumericAmount), ")");
					//override the user input with the validate numeric amount
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
