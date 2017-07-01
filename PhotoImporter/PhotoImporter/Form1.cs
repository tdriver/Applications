using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PhotoImporter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tbImportPicsTo.Text = PictureFolder.SelectedPath;
            tbImportVideosTo.Text = VideoFolder.SelectedPath;
            tbImportPicsFrom.Text = ImportPicturesFromFolder.SelectedPath;
        }

        private static Regex r = new Regex(":");

        //retrieves the datetime WITHOUT loading the whole image
        public static DateTime GetDateTakenFromImage(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (Image myImage = Image.FromStream(fs, false, false))
            {
                PropertyItem propItem = myImage.GetPropertyItem(36867);
                string dateTaken = r.Replace(Encoding.UTF8.GetString(propItem.Value), "-", 2);
                return DateTime.Parse(dateTaken);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = @"Working...";
            // process the photos in the root directory
            DirectoryInfo dir = new DirectoryInfo(tbImportPicsFrom.Text);
            ProcessDirectory(dir, tbImportPicsFrom.Text,tbImportPicsTo.Text,tbImportVideosTo.Text);

            // now all the others
            var ed = dir.EnumerateDirectories("*.*", SearchOption.AllDirectories);
            foreach (var di in ed)
            {
                ProcessDirectory(di, tbImportPicsFrom.Text, tbImportPicsTo.Text, tbImportVideosTo.Text);
            }
            label1.Text = @"Done...";
        }

        private static void ProcessDirectory(DirectoryInfo dir, string importFromFolder, string importPicturesToFolder, string importVideosToFolder)
        {
            var files = dir.EnumerateFiles();
            foreach (var fi in files)
            {
                if (fi.Extension.ToLower().Contains("png") || fi.Extension.ToLower().Contains("jpg") || fi.Extension.ToLower().Contains("gif"))
                {
                    // import it
                    string pathName;
                    if (fi.DirectoryName == null)
                    {
                        pathName = Path.Combine(importFromFolder, fi.Name);
                    }
                    else
                    {
                       pathName = Path.Combine(importFromFolder, fi.DirectoryName, fi.Name);
                    }

                    DateTime dateTaken = new DateTime(1950,01,01);
                    try
                    {
                        dateTaken = GetDateTakenFromImage(pathName);
                    }
                    catch
                    {
                        // ignored
                    }


                    // check for folder with that name, create it if it doesn't exist
                    string pictureOutputFolder = Path.Combine(importPicturesToFolder,$@"{dateTaken.Year}-{dateTaken.Month:00}-{dateTaken.Day:00}");
                    if (!Directory.Exists(pictureOutputFolder))
                    {
                        Directory.CreateDirectory(pictureOutputFolder);
                    }

                    if (!File.Exists(Path.Combine(pictureOutputFolder, fi.Name)))
                    {
                        fi.MoveTo(Path.Combine(pictureOutputFolder, fi.Name));
                    }
                }else if (fi.Extension.ToLower().Contains("mp4") || fi.Extension.ToLower().Contains("m4v") || fi.Extension.ToLower().Contains("mov") || fi.Extension.ToLower().Contains("avi") || fi.Extension.ToLower().Contains("3gp"))
                {
                    // import it
                    DateTime dateCreated = fi.LastWriteTime;

                    // check for folder with that name, create it if it doesn't exist
                    string videoOutputfolder = Path.Combine(importVideosToFolder,  $@"{dateCreated.Year}-{dateCreated.Month:00}-{dateCreated.Day:00}");
                    if (!Directory.Exists(videoOutputfolder))
                    {
                        Directory.CreateDirectory(videoOutputfolder);
                    }

                    if (!File.Exists(Path.Combine(videoOutputfolder,fi.Name)))
                    {
                        fi.MoveTo(Path.Combine(videoOutputfolder, fi.Name));
                    }
                }
            }
        }

        private void btnImportPicturesTo_Click(object sender, EventArgs e)
        {
            if (PictureFolder.ShowDialog() == DialogResult.OK)
            {
                tbImportPicsTo.Text = PictureFolder.SelectedPath;
            }
        }

        private void btnImportVideosTo_Click(object sender, EventArgs e)
        {
            if (VideoFolder.ShowDialog() == DialogResult.OK)
            {
                tbImportVideosTo.Text = VideoFolder.SelectedPath;
            }
        }

        private void btnImportPicturesFrom_Click(object sender, EventArgs e)
        {
            if (ImportPicturesFromFolder.ShowDialog() == DialogResult.OK)
            {
                tbImportPicsFrom.Text = ImportPicturesFromFolder.SelectedPath;
            }
        }
    }
}
