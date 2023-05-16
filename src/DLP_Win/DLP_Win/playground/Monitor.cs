using System;
using System.IO;
using System.Security.Principal;


namespace DLP_Win.playground
{


	internal class Monitor
	{
		private static void Start()
		{
			Console.WriteLine("Enter the path to monitor:");
			string path = Console.ReadLine();

			Console.WriteLine("Enter the username to compare to the author:");
			string compareName = Console.ReadLine();

			if (!Directory.Exists(path))
			{
				Console.WriteLine($"The path {path} does not exist.");
				return;
			}

			using (FileSystemWatcher watcher = new FileSystemWatcher(path))
			{
				watcher.NotifyFilter = NotifyFilters.LastAccess
													 | NotifyFilters.LastWrite
													 | NotifyFilters.FileName
													 | NotifyFilters.DirectoryName;

				watcher.Changed += (source, e) => OnChanged(source, e, compareName);
				watcher.Created += (source, e) => OnChanged(source, e, compareName);
				watcher.Deleted += (source, e) => OnChanged(source, e, compareName);
				watcher.Renamed += (source, e) => OnRenamed(source, e, compareName);

				watcher.EnableRaisingEvents = true;

				Console.WriteLine("Press 'q' to quit the sample.");
				while (Console.Read() != 'q') ;
			}
		}

		private static void OnChanged(object source, FileSystemEventArgs e, string compareName)
		{
			Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
			if (CompareAuthorToName(e.FullPath, compareName))
			{
				Console.WriteLine("The author of the change matches the provided username.");
			}
			else
			{
				Console.WriteLine("The author of the change does not match the provided username.");
			}
		}

		private static void OnRenamed(object source, RenamedEventArgs e, string compareName)
		{
			Console.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");
			if (CompareAuthorToName(e.FullPath, compareName))
			{
				Console.WriteLine("The author of the change matches the provided username.");
			}
			else
			{
				Console.WriteLine("The author of the change does not match the provided username.");
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
				IdentityReference author = fileSecurity.GetOwner(typeof(NTAccount));

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

		// Extracts the username from the NTAccount string
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