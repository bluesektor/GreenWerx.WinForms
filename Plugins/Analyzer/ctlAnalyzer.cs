using PluginInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GreenWerx.Data;
using GreenWerx.Data.Logging;
using GreenWerx.Data.Logging.Models;
using GreenWerx.Managers.Membership;
using GreenWerx.Managers.Plant;
using GreenWerx.Managers.Store;
using GreenWerx.Models.App;
using GreenWerx.Models.Membership;
using GreenWerx.Models.Plant;
using GreenWerx.Models.Store;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace Analyzer
{
    public partial class ctlAnalyzer : UserControl, IPlugin
    {
        #region Plugin interface properties

        private string myPluginAuthor = "greenwerx.org";
        private string myPluginDescription = "Opensource Analyzer.";
        private string myPluginVersion = "1.0.0";
        private string myPluginShortName = "Analyzer";

        private UserSession _session;
        private AppInfo _appSettings;

        void PluginInterface.IPlugin.Dispose()
        {
            //add clean up here
        }

        public string Description
        { get { return myPluginDescription; } }

        public string Author
        { get { return myPluginAuthor; } }

        public IPluginHost Host { get; set; }

        public void Initialize(UserSession session, AppInfo appSettings)
        {
            _session = session;
            _appSettings = appSettings;
        }

        protected void Run()
        {
            //not mandatory, but good for a standard interface to main.
        }

        public void ResizeControl()
        {
            //adjust windows here
        }

        public UserControl MainInterface
        { get { return this; } }

        public string Version
        { get { return myPluginVersion; } }

        public string ShortName
        {
            get
            {
                return myPluginShortName;
            }
        }

        #endregion

        public string FileToAnalyze { get; set; }

        public string FileType { get; set; }
        public ctlAnalyzer()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            Stream stmFile;
            try
            {
                openFileDialog1.Filter = "jpeg (*.jpeg)|*.jpeg;";
                openFileDialog1.FilterIndex = 1;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileToAnalyze = openFileDialog1.FileName;
                    FileType = Path.GetExtension(FileToAnalyze).Replace(".","");

                    if ((stmFile = openFileDialog1.OpenFile()) != null)
                    {
                        String strImgName = openFileDialog1.FileName;
                        
                        stmFile.Close();
                        picBox.SizeMode = PictureBoxSizeMode.StretchImage;//fits the image within the small window.
                        picBox.Image = Image.FromFile(strImgName);
                        
                            Bitmap default_image = new Bitmap(picBox.Image);
                        ProcessUsingLockbitsAndUnsafeAndParallel(default_image);
                        // SavePicFile(strImgName);
                 

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void ProcessUsingLockbitsAndUnsafeAndParallel(Bitmap processedBitmap)
        {
            int red = 234;
            int green = 101;
            int blue = 8;
            int width = processedBitmap.Width;
            int height = processedBitmap.Height;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color oldPixel = processedBitmap.GetPixel(x, y);


                    var rgb =  oldPixel.ToArgb();
                    if (oldPixel.R == red && oldPixel.G == green && oldPixel.B == blue)
                    {
                        Color newColor = Color.FromArgb(76, 255,  0); //bright green
                        processedBitmap.SetPixel(x, y, newColor);
                        //draw a circle at pixel location
                        using (Graphics grf = Graphics.FromImage(processedBitmap))
                        {
                            using (Brush brsh = new SolidBrush(ColorTranslator.FromHtml("#ff00ffff")))
                            {
                                grf.FillEllipse(brsh, x, y, 219, 219);
                            }
                        }
                    }
                }
            }
            this.picBoxResult.SizeMode = PictureBoxSizeMode.StretchImage;
            this.picBoxResult.Image = processedBitmap;
            // below if fast code
            //unsafe
            //{
            //    BitmapData bitmapData = processedBitmap.LockBits(new Rectangle(0, 0, processedBitmap.Width, processedBitmap.Height), ImageLockMode.ReadWrite, processedBitmap.PixelFormat);

            //    int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(processedBitmap.PixelFormat) / 8;
            //    int heightInPixels = bitmapData.Height;
            //    int widthInBytes = bitmapData.Width * bytesPerPixel;
            //    byte* PtrFirstPixel = (byte*)bitmapData.Scan0;

            //    Parallel.For(0, heightInPixels, y =>
            //    {
            //        byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);
            //        for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
            //        {
            //            int oldBlue = currentLine[x];
            //            int oldGreen = currentLine[x + 1];
            //            int oldRed = currentLine[x + 2];

            //            currentLine[x] = (byte)oldBlue;
            //            currentLine[x + 1] = (byte)oldGreen;
            //            currentLine[x + 2] = (byte)oldRed;
            //        }
            //    });
            //    processedBitmap.UnlockBits(bitmapData);
            //}
        }
    }
}
