# Qoniac-Coding-Task
 
Solution for Qoniac Coding Task by Alexander Staufenbiel.

Created using Visual Studio 2022.

## Content:
	CodingTaskClient - WPF Application 			[Framework: .NET 6.0]
	CodingTaskServer - ASP.NET Core gRPC Server 		[Framework: .NET 6.0]


## Usage:
	1. Open Client and Server Project in Visual Studio
		- ...\Qoniac-Coding-Task\CodingTaskClient\CodingTaskClient.sln
		- ...\Qoniac-Coding-Task\CodingTaskServer\CodingTaskServer.sln
	2. Build and Start (Ctrl + F5) Client and Server
	3. Input number to be converted into the Currency Amount Textbox
	4. Press Enter when focusing the TextBox or Click the "Convert" button to send number to Server

## Notes:
	The Server will attempt to convert any input stripping all undesired characters.
	The Server will return both the number in words as well as the validated number (stripped of any undesired characters)
	The Server will only consider the first two numbers following the first comma and the first 9 numbers prior to said comma.
		- 29837498fjsd38u,3890,72h7 = 983749838,38
		- jfhkjshfk = 0
		- ,6 = 0,60
	The Client will timeout the conversion request after 4 seconds and display "Request failed." msg instead of the server response.
