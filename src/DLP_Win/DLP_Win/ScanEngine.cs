using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLP_Win
{
    internal class ScanEngine
    {
        private static CancellationTokenSource _scannerCancellationTokenSource;
        private static CancellationTokenSource _monitorCancellationTokenSource;
        private static readonly Form _form;
        private static string QUARANTINE_FOLDER = $"{Application.StartupPath}\\QUARANTINE";

        public static async Task Monitor()
        {
            _monitorCancellationTokenSource = new CancellationTokenSource();

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
                            //foreach (string extension in extensions)
                            //{
                            //	SearchFiles(frmMain, drive.RootDirectory, extension, rulesets);

                            //	// Überprüfung, ob der Task abgebrochen werden soll
                            //	CheckCancelledTask();
                            //}
                            string compareName = "BK-Soft\\Work1";
                            using (FileSystemWatcher watcher = new FileSystemWatcher(drive.RootDirectory.FullName, "*.txt"))
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

                                //Console.WriteLine("Press 'q' to quit the sample.");
                                //while (Console.Read() != 'q') ;
                            }
                        }
                        // Überprüfung, ob der Task abgebrochen werden soll
                        CheckCancelledMonitorTask();

                    }
                }, _monitorCancellationTokenSource.Token);

            }
            catch (TaskCanceledException)
            {
                //Monitor abgebrochen
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

        /// <summary>
        /// Starte den System-Scan
        /// </summary>
        /// <param name="rulesets">Liste mit </param>
        /// <returns></returns>
        public static async Task Scan(frmMain frmMain, List<Ruleset> rulesets, List<string> extensions)
        {
            _scannerCancellationTokenSource = new CancellationTokenSource();

            if (frmMain.ScanButton.Text == "System Scan")
            {
                frmMain.ScanButton.Text = "Stop Scan";
                frmMain.ScanButton.BackColor = System.Drawing.Color.Salmon;

                if (rulesets != null && extensions != null)
                {

                    await Task.Run(() =>
                    {
                        try
                        {
                            // Alle Laufwerke durchsuchen
                            foreach (DriveInfo drive in DriveInfo.GetDrives())
                            {
                                if (drive.IsReady)
                                {
                                    // Nach Dateierweiterung suchen
                                    foreach (string extension in extensions)
                                    {
                                        // Überprüfung, ob der Task abgebrochen werden soll
                                        CheckCancelledScannerTask();

                                        SearchFiles(frmMain, drive.RootDirectory, extension, rulesets);
                                    }
                                }
                            }
                        }

                        catch (TaskCanceledException)
                        {
                            frmMain.Invoke(() =>
                                {
                                    // Task wurde abgebrochen
                                    frmMain.LoggerBox = $"{Environment.NewLine}Scan abgebrochen{Environment.NewLine}";
                                    frmMain.ScanButton.Text = "System Scan";
                                    frmMain.ScanButton.BackColor = System.Drawing.Color.PaleGreen;
                                    frmMain.ToolStripLabel = "";
                                });
                        }
                    }, _scannerCancellationTokenSource.Token);

                    frmMain.Invoke(() =>
                    {
                        frmMain.LoggerBox = $"{Environment.NewLine}Scan beendet{Environment.NewLine}";
                        frmMain.ScanButton.Text = "System Scan";
                        frmMain.ScanButton.BackColor = System.Drawing.Color.PaleGreen;
                        frmMain.ToolStripLabel = "";
                    });

                }
            }

            else if (frmMain.ScanButton.Text == "Stop Scan")
            {
                frmMain.ScanButton.Text = "System Scan";
                frmMain.ScanButton.BackColor = System.Drawing.Color.PaleGreen;
                ScanEngine.StopScan();
            }
        }

        /// <summary>
        /// Löst den Stopp des Tasks aus
        /// </summary>
        private static void CheckCancelledScannerTask()
        {
            if (_scannerCancellationTokenSource.Token.IsCancellationRequested)
            {
                //_scannerCancellationTokenSource.Token.ThrowIfCancellationRequested();				
                throw new TaskCanceledException();
            }

        }

        /// <summary>
        /// Löst den Stopp des Tasks aus
        /// </summary>
        private static void CheckCancelledMonitorTask()
        {
            if (_monitorCancellationTokenSource.Token.IsCancellationRequested)
            {
                //_scannerCancellationTokenSource.Token.ThrowIfCancellationRequested();				
                throw new TaskCanceledException();
            }

        }

        private static void SearchFiles(frmMain frmMain, DirectoryInfo directory, string fileExtension, List<Ruleset> rulesets)// TextBox loggerBox, ToolStripStatusLabel toolStripStatusLabel)
        {

            // Überspringe Quarantäne-Ordner
            if (directory.FullName.ToLower() == QUARANTINE_FOLDER.ToLower())
            {
                //MessageBox.Show($"{directory.FullName}:{QUARANTINE_FOLDER}");
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
                        bool quarantine = false;
                        if (ruleset.If.ToLower() == "datei-name" && ruleset.SelectionType.ToLower() == "enthält")
                        {
                            if (ruleset.Condition.Contains(file.Name.Split('.')[0]))
                            {
                                if (ruleset.Then.ToLower() == "in quarantäne verschieben")
                                {
                                    quarantine = true;

                                }
                                else if (ruleset.Then.ToLower() == "loggen")
                                {
                                    FileSecurity fileSecurity = file.GetAccessControl();
                                    IdentityReference author = fileSecurity.GetOwner(typeof(NTAccount));

                                    frmMain.LoggerBox = $"Passende Datei zum Ruleset \"{ruleset.If} {ruleset.SelectionType} {ruleset.Condition}\" gefunden:" +
                                                    $"{Environment.NewLine}{file.FullName}" +
                                                    $"{Environment.NewLine}Autor: {author}{Environment.NewLine}";
                                    //Logger(loggerBox, $"{Environment.NewLine}Passende Datei zum Ruleset \"{ruleset.If} {ruleset.SelectionType} {ruleset.Condition}\" gefunden:{Environment.NewLine}{file.FullName}{Environment.NewLine}");
                                }
                                else if (ruleset.Then.ToLower() == "notifizieren")
                                {
                                    FileSecurity fileSecurity = file.GetAccessControl();
                                    IdentityReference author = fileSecurity.GetOwner(typeof(NTAccount));

                                    Toast.ToastMessage("Datei gefunden", $"Passende Datei zum Ruleset \"{ruleset.If} {ruleset.SelectionType} {ruleset.Condition}\":{Environment.NewLine}{file.FullName}");
                                    frmMain.LoggerBox = $"Passende Datei zum Ruleset \"{ruleset.If} {ruleset.SelectionType} {ruleset.Condition}\" gefunden:" +
                                                    $"{Environment.NewLine}{file.FullName}" +
                                                    $"{Environment.NewLine}Autor: {author}{Environment.NewLine}";
                                }
                            }
                        }
                        if (ruleset.If.ToLower() == "datei-inhalt" && ruleset.SelectionType.ToLower() == "enthält")
                        {

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
                                                FileSecurity fileSecurity = file.GetAccessControl();
                                                IdentityReference author = fileSecurity.GetOwner(typeof(NTAccount));
                                                frmMain.LoggerBox = $"{Environment.NewLine}{DateTime.Now} - Passende Datei zum Ruleset \"{ruleset.If} {ruleset.SelectionType} {ruleset.Condition}\" gefunden:" +
                                                    $"{Environment.NewLine}{file.FullName}" +
                                                    $"{Environment.NewLine}Autor: {author}{Environment.NewLine}";
                                                //Logger(loggerBox, $"{Environment.NewLine}Passende Datei zum Ruleset \"{ruleset.If} {ruleset.SelectionType} {ruleset.Condition}\" gefunden:{Environment.NewLine}{file.FullName}{Environment.NewLine}");
                                            }
                                            else if (ruleset.Then.ToLower() == "notifizieren")
                                            {
                                                FileSecurity fileSecurity = file.GetAccessControl();
                                                IdentityReference author = fileSecurity.GetOwner(typeof(NTAccount));
                                                frmMain.LoggerBox = $"{Environment.NewLine}{DateTime.Now} - Passende Datei zum Ruleset \"{ruleset.If} {ruleset.SelectionType} {ruleset.Condition}\" gefunden:" +
                                                    $"{Environment.NewLine}{file.FullName}" +
                                                    $"{Environment.NewLine}Autor: {author}{Environment.NewLine}";
                                                Toast.ToastMessage("Datei gefunden",
                                                    $"{DateTime.Now} - Passende Datei zum Ruleset \"{ruleset.If} {ruleset.SelectionType} {ruleset.Condition}\" gefunden:" +
                                                    $"{Environment.NewLine}{file.FullName}" +
                                                    $"{Environment.NewLine}Autor: {author}{Environment.NewLine}");
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
                        }
                        if (quarantine)
                        {
                            Directory.CreateDirectory(QUARANTINE_FOLDER);

                            FileSecurity fileSecurity = file.GetAccessControl();
                            IdentityReference author = fileSecurity.GetOwner(typeof(NTAccount));
                            File.Move(file.FullName, Path.Combine(QUARANTINE_FOLDER, file.Name));
                            string text = $"Verdächtige Datei {file.Name} von Autor {author} in Quarantäne verschoben";
                            Toast.ToastMessage("Quarantäne", text);
                            frmMain.LoggerBox = $"{Environment.NewLine}{DateTime.Now} - Verdächtige Datei zum Ruleset \"{ruleset.If} {ruleset.SelectionType} {ruleset.Condition}\" gefunden:" +
                                                    $"{Environment.NewLine}{file.FullName} in Quarantäne verschoben" +
                                                    $"{Environment.NewLine}Autor: {author}{Environment.NewLine}";

                            //Logger(loggerBox, $"{Environment.NewLine}{file.FullName} wurde in die Quarantäne verschoben!{Environment.NewLine}");
                        }
                    }

                    // Überprüfung, ob der Task abgebrochen werden soll
                    CheckCancelledScannerTask();
                }

                // Durchsuche alle Unterverzeichnisse
                foreach (DirectoryInfo subDirectory in directory.GetDirectories())
                {
                    SearchFiles(frmMain, subDirectory, fileExtension, rulesets); //, loggerBox, toolStripStatusLabel);

                    // Überprüfung, ob der Task abgebrochen werden soll
                    //CheckCancelledTask();
                    if (_scannerCancellationTokenSource.Token.IsCancellationRequested)
                    {
                        //_scannerCancellationTokenSource.Token.ThrowIfCancellationRequested();				
                        throw new TaskCanceledException();
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                //Logger(loggerBox, $"{Environment.NewLine}Es konnte nicht auf den Ordner {directory} zugegriffen werden.{Environment.NewLine}");
            }
            catch (TaskCanceledException)
            {
                // Scannen unterbrochen						
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
        public static void StopScan()
        {
            _scannerCancellationTokenSource?.Cancel();
        }

        /// <summary>
        /// Stoppe den System-Monitor
        /// </summary>
        public static void StopMonitor()
        {
            _monitorCancellationTokenSource?.Cancel();
        }

        private static void StatusLabel(ToolStripStatusLabel toolStripStatusLabel, string message)
        {
            toolStripStatusLabel.Text = message;
        }

        private static bool CompareAuthorToName(string filePath, string compareName)
        {
            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Read the author metadata using FileInfo and GetAccessControl method
                FileInfo fileInfo = new FileInfo(filePath);
                FileSecurity fileSecurity = fileInfo.GetAccessControl();
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
