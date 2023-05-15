using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLP_Win
{
	internal class ScanEngine
	{
		private static CancellationTokenSource _cancellationTokenSource;
		private const string QUARANTINE_FOLDER = @"C:\TEMP\QUARANTINE\";

		/// <summary>
		/// Starte den System-Scan
		/// </summary>
		/// <param name="rulesets">Liste mit </param>
		/// <returns></returns>
		public static async Task Scan(frmMain frmMain, List<Ruleset> rulesets, List<string> extensions) //, TextBox loggerBox, ToolStripStatusLabel toolStripStatusLabel)
		{
			_cancellationTokenSource = new CancellationTokenSource();

			if (frmMain.ScanButton.Text == "System Scan")
			{
				frmMain.ScanButton.Text = "Stop Scan";
				frmMain.ScanButton.BackColor = System.Drawing.Color.Salmon;


				if (rulesets != null && extensions != null)
				{
					try
					{
						await Task.Run(() =>
						{
							// Alle Laufwerke durchsuchen
							foreach (DriveInfo drive in DriveInfo.GetDrives())
							{
								if (drive.IsReady)
								{
									// Nach Dateierweiterung suchen
									foreach (string extension in extensions)
									{
										SearchFiles(frmMain, drive.RootDirectory, extension, rulesets);

										// Überprüfung, ob der Task abgebrochen werden soll
										CheckCancelledTask();
									}
								}
								// Überprüfung, ob der Task abgebrochen werden soll
								CheckCancelledTask();

							}
						}, _cancellationTokenSource.Token);

						frmMain.LoggerBox = $"{Environment.NewLine}Scan beendet{Environment.NewLine}";
						frmMain.ScanButton.Text = "System Scan";
						frmMain.ScanButton.BackColor = System.Drawing.Color.PaleGreen;
						frmMain.ToolStripLabel = "";

					}
					catch (OperationCanceledException)
					{
					}
				}
			}
			else if (frmMain.ScanButton.Text == "Stop Scan")
			{
				frmMain.ScanButton.Text = "System Scan";
				frmMain.ScanButton.BackColor = System.Drawing.Color.PaleGreen;
				ScanEngine.Stop();
			}
		}

		/// <summary>
		/// Löst den Stopp des Tasks aus
		/// </summary>
		private static void CheckCancelledTask()
		{
			try
			{
				if (_cancellationTokenSource.Token.IsCancellationRequested)
				{
					_cancellationTokenSource.Token.ThrowIfCancellationRequested();
				}
			}
			catch (OperationCanceledException)
			{
				// Task unterbrochen
			}
		}

		private static void SearchFiles(frmMain frmMain, DirectoryInfo directory, string fileExtension, List<Ruleset> rulesets)// TextBox loggerBox, ToolStripStatusLabel toolStripStatusLabel)
		{

			// Überspringe Quarantäne-Ordner
			if (directory.FullName == QUARANTINE_FOLDER)
			{
				return;
			}

			// Durchsuche alle Dateien in diesem Verzeichnis
			try
			{


				foreach (FileInfo file in directory.GetFiles("*." + fileExtension))
				{
					//PRIO: Anhand des Rulesets Aktionen durchführen
					//StatusLabel(toolStripStatusLabel, file.FullName);
					frmMain.ToolStripLabel = file.FullName;


					foreach (Ruleset ruleset in rulesets)
					{
						if (ruleset.If.ToLower() == "datei-inhalt" && ruleset.SelectionType.ToLower() == "enthält")
						{
							bool quarantine = false;

							// Öffne und lese den Inhalt der Datei
							try
							{
								if (fileExtension == "txt")
								{
									using (StreamReader reader = file.OpenText())
									{
										string content = reader.ReadToEnd().ToLower();

										/// Falls: "Datei-Inhalt", "Datei-Name"
										/// Auswahl für "enthält", "enthält nicht", "REGEX"
										/// Dann: "Notifizieren", "In Quarantäne verschieben", "Monitoren und Loggen"

										if (content.Contains(ruleset.Condition.ToLower()))
										{
											if (ruleset.Then.ToLower() == "in quarantäne verschieben")
											{
												quarantine = true;
											}
											else if (ruleset.Then.ToLower() == "loggen")
											{
												frmMain.LoggerBox = $"{Environment.NewLine}Passende Datei zum Ruleset \"{ruleset.If} {ruleset.SelectionType} {ruleset.Condition}\" gefunden:{Environment.NewLine}{file.FullName}{Environment.NewLine}";
												//Logger(loggerBox, $"{Environment.NewLine}Passende Datei zum Ruleset \"{ruleset.If} {ruleset.SelectionType} {ruleset.Condition}\" gefunden:{Environment.NewLine}{file.FullName}{Environment.NewLine}");
											}
											else if (ruleset.Then.ToLower() == "notifizieren")
											{
												Toast.ToastMessage("Datei gefunden", $"Passende Datei zum Ruleset \"{ruleset.If} {ruleset.SelectionType} {ruleset.Condition}\":{Environment.NewLine}{file.FullName}");
											}
										}

										//AnalyzeContent(content, ruleset);
									}
								}
								else if (new[] { "doc", "docx" }.Contains(fileExtension))
								{
									using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(file.FullName, false))
									{
										Body body = wordDocument.MainDocumentPart.Document.Body;

										foreach (DocumentFormat.OpenXml.OpenXmlElement paragraph in body.Elements())
										{
											string text = paragraph.InnerText;
											Console.WriteLine(text);
										}
									}
								}
							}
							catch (IOException)
							{
								// Datei durch andere Anwendung geöffnet
								throw;
							}
							if (quarantine)
							{
								Directory.CreateDirectory(QUARANTINE_FOLDER);
								File.Move(file.FullName, Path.Combine(QUARANTINE_FOLDER, file.Name));
								string text = "Verdächtige Datei in Quarantäne verschoben";
								Toast.ToastMessage("Quarantäne", text);
								frmMain.LoggerBox = $"{Environment.NewLine}{file.FullName} wurde in die Quarantäne verschoben!{Environment.NewLine}";
								//Logger(loggerBox, $"{Environment.NewLine}{file.FullName} wurde in die Quarantäne verschoben!{Environment.NewLine}");
							}
						}
					}

					// Überprüfung, ob der Task abgebrochen werden soll
					CheckCancelledTask();
				}

				// Durchsuche alle Unterverzeichnisse
				foreach (DirectoryInfo subDirectory in directory.GetDirectories())
				{
					SearchFiles(frmMain, subDirectory, fileExtension, rulesets); //, loggerBox, toolStripStatusLabel);

					// Überprüfung, ob der Task abgebrochen werden soll
					CheckCancelledTask();
				}
			}
			catch (UnauthorizedAccessException)
			{
				//Logger(loggerBox, $"{Environment.NewLine}Es konnte nicht auf den Ordner {directory} zugegriffen werden.{Environment.NewLine}");
			}
			catch (Exception ex)
			{
				frmMain.LoggerBox = $"{Environment.NewLine}{ex.Message}{Environment.NewLine}";
				//Logger(loggerBox, $"{Environment.NewLine}{ex.Message}{Environment.NewLine}");
			}
		}

		/// <summary>
		/// Stoppe den System-Scan
		/// </summary>
		public static void Stop()
		{
			_cancellationTokenSource?.Cancel();
		}

		private static void Logger(TextBox loggerBox, string message)
		{
			loggerBox.Invoke((MethodInvoker)(() => { loggerBox.Text += message; }));
		}

		private static void StatusLabel(ToolStripStatusLabel toolStripStatusLabel, string message)
		{
			toolStripStatusLabel.Text = message;
		}
	}
}
