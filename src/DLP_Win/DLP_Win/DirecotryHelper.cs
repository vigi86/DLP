using System.Collections.Generic;
using System.IO;

namespace DLP_Win
{
	internal class DirecotryHelper
	{

		public List<string> getDrives()
		{
			DriveInfo[] allDrives = DriveInfo.GetDrives();
			List<string> drives = new List<string>();
			foreach (DriveInfo drive in allDrives)
			{

				if (drive.DriveType == DriveType.Fixed || drive.DriveType == DriveType.Removable)
				{
					//string[] files = Directory.GetFiles(drive.RootDirectory.FullName, "*", SearchOption.AllDirectories);

					//foreach (string file in files)
					//{
					//    // do something with the file
					//}
					drives.Add(drive.RootDirectory.FullName);
				}
			}

			return drives;
		}
	}
}
