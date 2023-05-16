using GemBox.Document;
using System;
using System.IO;

namespace DLP_Win.playground // Note: actual namespace depends on the project name.
{
	internal class Grabber
	{
		private static void Start()
		{
			// licence for GemBox
			ComponentInfo.SetLicense("FREE-LIMITED-KEY");

			Console.WriteLine("Enter the path of the file:");
			string filePath = Console.ReadLine();

			Console.WriteLine("Enter the name to compare:");
			string compareName = Console.ReadLine();

			Console.WriteLine("Enter the string to compare:");
			string compareString = Console.ReadLine();

			try
			{
				bool authorResult = CompareAuthorToName(filePath, compareName);
				bool contentResult = CompareFileContentToString(filePath, compareString);


				if (authorResult)
				{
					Console.WriteLine("Author matches the given name.");
				}
				else
				{
					Console.WriteLine("Author does not match the given name.");
				}

				if (contentResult)
				{
					Console.WriteLine("File content matches the given string.");
				}
				else
				{
					Console.WriteLine("File content does not match the given string.");
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
			}

			Console.WriteLine("Press any key to exit.");
			Console.ReadKey();
		}

		private static bool CompareFileContentToString(string filePath, string compareString)
		{
			// Check if the file exists
			if (File.Exists(filePath))
			{
				// Load Word document from file's path.
				DocumentModel document = DocumentModel.Load(filePath);

				// Get Word document's plain text.
				string text = document.Content.ToString();

				// Check if the file content contains the given string
				return text.Contains(compareString);

			}
			else
			{
				throw new FileNotFoundException("File does not exist.");
			}
		}

		private static bool CompareAuthorToName(string filePath, string compareName)
		{
			// Check if the file exists
			if (File.Exists(filePath))
			{
				// Read the author metadata using FileInfo and GetAccessControl method
				FileInfo fileInfo = new FileInfo(filePath);
				System.Security.AccessControl.FileSecurity fileSecurity = fileInfo.GetAccessControl();
				System.Security.Principal.IdentityReference author = fileSecurity.GetOwner(typeof(System.Security.Principal.NTAccount));

				// Extract the name from the author object
				string extractedName = ExtractUserName(author.ToString());

				// Compare the author name with the given name
				return extractedName.Equals(compareName, StringComparison.OrdinalIgnoreCase);
			}
			else
			{
				throw new FileNotFoundException("File does not exist.");
			}
		}

		private static string ExtractUserName(string ntAccount)
		{
			int index = ntAccount.IndexOf('\\');
			if (index >= 0)
			{
				return ntAccount.Substring(index + 1);
			}
			else
			{
				index = ntAccount.IndexOf('@');
				if (index >= 0)
				{
					return ntAccount.Substring(0, index);
				}
			}

			return ntAccount;
		}
	}
}