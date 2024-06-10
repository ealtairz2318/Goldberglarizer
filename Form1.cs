using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Ionic.Zip;



namespace Goldbergalizer
{
    public partial class Golderberg_Alizer_Form : Form
    {

        public Golderberg_Alizer_Form()
        {
            InitializeComponent();

        }
        private void GameFolder_Btn_Finder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()) // Finds the Folder
            {
                folderBrowserDialog.Description = "Select the Game folder(s)";
                folderBrowserDialog.ShowNewFolderButton = false;

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    GameFolder_text_box.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }
        private void Goldberg_Files_Updater(object sender, EventArgs e)
        {
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filesDirectory = Path.Combine(appDirectory, "Files");
            // Ensure the directory exists
            if (!Directory.Exists(filesDirectory))
            {
                Directory.CreateDirectory(filesDirectory);
            }

            string[] specificFiles = { "steam_api.dll", "steam_api64.dll" }; // Replace with actual file names

            // Check if all specific files exist in the "Files" directory
            bool allFilesExist = specificFiles.All(file => File.Exists(Path.Combine(filesDirectory, file)));

            if (!allFilesExist)
            {
                string url = "https://gitlab.com/Mr_Goldberg/goldberg_emulator/-/jobs/4247811310/artifacts/download";
                string destinationPath = Path.Combine(filesDirectory, "file.zip"); // Replace with your file name

                using (WebClient client = new WebClient())
                {
                    try
                    {
                        client.DownloadFile(url, destinationPath);
                        MessageBox.Show("Goldberg Files Succsfully Downloaded", "Download Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Unzip and extract specific files
                        UnzipAndExtractSpecificFiles(destinationPath, filesDirectory, specificFiles);
                    }
                    catch (Exception ex)
                    {
                        string errorMessage = $"An error occurred: {ex.Message}";
                        Console.WriteLine(errorMessage);
                        MessageBox.Show(errorMessage, "Cannot Connect and Download Goldberg Files", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(1); // Exit the application with an error code
                    }
                }
            }
            OnLoadText();
        } // Updates and Downloads Current Goldberg Builds
        public static void UnzipAndExtractSpecificFiles(string zipFilePath, string extractPath, string[] specificFiles)
        {
            // Ensure the extraction directory exists
            if (!Directory.Exists(extractPath))
            {
                Directory.CreateDirectory(extractPath);
            }

            try
            {
                // Extract specific files from the ZIP archive
                using (ZipFile zip = ZipFile.Read(zipFilePath))
                {
                    foreach (ZipEntry entry in zip)
                    {
                        if (Array.Exists(specificFiles, fileName => fileName.Equals(entry.FileName, StringComparison.OrdinalIgnoreCase)))
                        {
                            entry.Extract(extractPath, ExtractExistingFileAction.OverwriteSilently);
                        }
                    }
                }

                // Delete the ZIP file after extraction
                File.Delete(zipFilePath);
                Console.WriteLine("Extraction complete and ZIP file deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during extraction: {ex.Message}");
            }
        } // Unzips and find the necessary files
        public void Goldbergalarize(object sender, EventArgs e)
        {
            string gameFolderPath = GameFolder_text_box.Text;

            // Check if the game folder path is provided
            if (string.IsNullOrWhiteSpace(gameFolderPath) || !Directory.Exists(gameFolderPath))
            {
                MessageBox.Show("Please provide a valid game folder path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string filesDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files");
            string[] specificFiles = { "steam_api.dll", "steam_api64.dll" };

            try
            {
                // Get all folders and subfolders in the game folder
                string[] folders = Directory.GetDirectories(gameFolderPath, "*", SearchOption.AllDirectories);

                bool filesUpdated = false;
                StringBuilder updatedFolders = new StringBuilder();

                // Iterate through each folder
                foreach (string folder in folders)
                {
                    // Check if either of the files exist in the folder
                    bool fileExists = specificFiles.Any(file => File.Exists(Path.Combine(folder, file)));

                    if (fileExists)
                    {
                        // Copy files from "Files" folder to the current folder
                        foreach (string file in specificFiles)
                        {
                            string sourceFilePath = Path.Combine(filesDirectory, file);
                            string destinationFilePath = Path.Combine(folder, file);

                            // Check if the source and destination files are different
                            if (File.Exists(sourceFilePath) && (!File.Exists(destinationFilePath) || !FilesAreEqual(sourceFilePath, destinationFilePath)))
                            {
                                File.Copy(sourceFilePath, destinationFilePath, true);
                                filesUpdated = true;
                                updatedFolders.AppendLine(folder);
                            }
                        }
                    }
                }

                if (filesUpdated)
                {
                    MessageBox.Show($"Files updated successfully in the following folders:\n\n{updatedFolders}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No files were updated.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ExitingFunctions(); 
        } // Compares and Updates Existing Steam Games
        private bool FilesAreEqual(string filePath1, string filePath2) // Helper method to compare file contents
        {
            byte[] file1 = File.ReadAllBytes(filePath1);
            byte[] file2 = File.ReadAllBytes(filePath2);

            return file1.SequenceEqual(file2);
        }
        public void OnLoadText()
        {
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filesDirectory = Path.Combine(appDirectory, "Files");
            string cacheFilePath = Path.Combine(filesDirectory, "Path.txt");

            try
            {
                // Check if the cache file exists
                if (File.Exists(cacheFilePath))
                {
                    // Read the folder path from the cache file
                    string folderPath = File.ReadAllText(cacheFilePath);

                    // Populate the GameFolder_text_box with the cached folder path
                    GameFolder_text_box.Text = folderPath;
                    Console.WriteLine("Cached folder path loaded successfully.");
                }
                else
                {
                    Console.WriteLine("No cached folder path found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading cached folder path: {ex.Message}");
            }
        }
        private void OnExitCaching(object sender, FormClosingEventArgs e)
        {
            ExitingFunctions();
        }
        public void ExitingFunctions()
        {
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filesDirectory = Path.Combine(appDirectory, "Files");
            string cacheFilePath = Path.Combine(filesDirectory, "Path.txt");

            try
            {
                // Get the folder path from the GameFolder_text_box
                string folderPath = GameFolder_text_box.Text;

                // Write the folder path to the cache file
                File.WriteAllText(cacheFilePath, folderPath);
                Console.WriteLine("Folder path cached successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while caching folder path: {ex.Message}");
            }
        }// Events when closing the application 
        public void UpdateEmulator(object sender, EventArgs e)
        {
            // Get the directory where the application is located
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filesDirectory = Path.Combine(appDirectory, "Files");

            // Check if the "Files" directory exists
            if (Directory.Exists(filesDirectory))
            {
                try
                {
                    // Delete the "Files" directory and all its contents
                    Directory.Delete(filesDirectory, true);
                    Console.WriteLine("Files folder deleted successfully.");
                }
                catch (Exception ex)
                {
                    // If an error occurs during deletion, log the error message
                    Console.WriteLine($"Error deleting Files folder: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Files folder does not exist.");
            }

            Goldberg_Files_Updater(this,EventArgs.Empty);
        } // Updates Emulator to Latest
    }
}
