using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace eXoDOSGameCopier
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        // Notes: eXo would like a version that deletes contents instead.

        void ReadXML()
        {
            bool test = chkTestMode.Checked;
            var files = Directory.GetFiles(txtDest.Text);
            var subDirectory = "Data\\Platforms\\MS-DOS.xml";
            var xmlPath = Path.Combine(txtRoot.Text, subDirectory);

            string destPlatformFolder = "";
            string destGamesFolder = "";
            string destImagesFolder = "";
            string destManualsFolder = "";

            // Setup new folders 
            if (!test)
            {
                destPlatformFolder = Directory.CreateDirectory(Path.Combine(txtDest.Text, "Data\\Platforms")).FullName;
                destGamesFolder = Directory.CreateDirectory(Path.Combine(txtDest.Text, "eXoDOS\\Games")).FullName;
                //string destDosFolder = Directory.CreateDirectory(Path.Combine(txtDest.Text, "eXoDOS\\Games\\!dos")).FullName;
                destImagesFolder = Directory.CreateDirectory(Path.Combine(txtDest.Text, "Images")).FullName;
                destManualsFolder = Directory.CreateDirectory(Path.Combine(txtDest.Text, "Manuals")).FullName;
            }


            // Read XML
            XElement msDOSGames = XElement.Load(xmlPath);
            IEnumerable<XElement> games = from item in msDOSGames.Descendants("Game") select item;
            IEnumerable<XElement> additionalApps = from item in msDOSGames.Descendants("AdditionalApplication") select item;

            // Temp XML Lists
            List<XElement> gamesList = new List<XElement>();
            List<IEnumerable<XElement>> appsList = new List<IEnumerable<XElement>>();

            // Loop through each file.
            for (int i = 0; i < files.Length; i++)
            {
                string zipName = Path.GetFileNameWithoutExtension(files[i]);

                // Move zip to Games folder
                if (!test)
                    File.Move(files[i], Path.Combine(destGamesFolder, zipName + ".zip"));

                IEnumerable<XElement> gameByAppPath = from item in games where ((string)item.Element("ApplicationPath")).Contains(zipName) select item;
                if (gameByAppPath.Count() > 1)
                {
                    MessageBox.Show("Duplicate Game or ApplicationPath element for: " + zipName);
                    return;
                }
                else
                {
                    gamesList.Add(gameByAppPath.First());

                    var q = from item in gameByAppPath select new { ID = item.Element("ID").Value, RootFolder = item.Element("RootFolder").Value, ManualPath = item.Element("ManualPath").Value };
                    string ID = q.FirstOrDefault().ID;
                    string RootFolder = q.FirstOrDefault().RootFolder;
                    string manualPath = q.FirstOrDefault().ManualPath;

                    if (!test)
                        DirectoryCopy(Path.Combine(txtRoot.Text, RootFolder), Path.Combine(txtDest.Text, RootFolder), true);

                    if (!test)
                        if (!String.IsNullOrWhiteSpace(manualPath))
                            File.Copy(Path.Combine(txtRoot.Text, manualPath), Path.Combine(destManualsFolder, Path.GetFileName(manualPath)),true);

                    IEnumerable<XElement> additionalAppByID = from item in additionalApps where ((string)item.Element("GameID")) == ID select item;

                    appsList.Add(additionalAppByID);
                }
            }

            XDocument msDOSnew = new XDocument(
                new XDeclaration("1.0", null,"yes"),
                new XElement("LaunchBox", gamesList.AsEnumerable<XElement>(), appsList.AsEnumerable<IEnumerable<XElement>>()));            

            txtXMLtoWrite.Text = msDOSnew.Declaration + Environment.NewLine + msDOSnew.ToString();
            if (!test)
                File.WriteAllText(Path.Combine(destPlatformFolder, "MS-DOS.xml"), txtXMLtoWrite.Text);

            MessageBox.Show("Finished!");
        }

        private void btnRunTest_Click(object sender, EventArgs e)
        {
            txtXMLtoWrite.Text = "";            
            ReadXML();
        }

        private void btnSelectRoot_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRoot.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnSelectDest_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtDest.Text = folderBrowserDialog1.SelectedPath;
            }
        }


        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
    }
}
