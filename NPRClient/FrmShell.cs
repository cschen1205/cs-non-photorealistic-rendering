using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NPRClient
{
    using System.IO;
    using Net;
    public partial class FrmShell : Form
    {
        private string mCurrentImageName;
        private string mTempImageName;
        private Random mRandEngine = new Random();

        public FrmShell()
        {
            InitializeComponent();
            mTempImageName = Path.Combine(Application.StartupPath, "tmp.jpg");
        }

        private void DoCrop_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mCurrentImageName)) return;

            Image fullSizeImg = Image.FromFile(mCurrentImageName);
            
            int height = 480;
            int width = fullSizeImg.Width * height / fullSizeImg.Height;
            Image thumbnailImg = new Bitmap(fullSizeImg, width, height);
            Graphics g = Graphics.FromImage(thumbnailImg);

            g.FillRectangle(Brushes.White, 0, 0, width, height);
            g.DrawImage(fullSizeImg, 0, 0, width, height);

            int remaining_left = width - 320;
            if (remaining_left >= 0)
            {
                int left = mRandEngine.Next() % remaining_left;
                thumbnailImg = cropImage(thumbnailImg, new Rectangle(left, 0, 320, height));
            }

            try
            {
                //thumbnailImg.Save(mTempImageName, fullSizeImg.RawFormat);
                picImg.Image = thumbnailImg;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DoStretch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mCurrentImageName)) return;

            Image fullSizeImg = Image.FromFile(mCurrentImageName);
            int width = 320;
            int height = 480;
          
            Image thumbnailImg = new Bitmap(fullSizeImg, width, height);
            Graphics g = Graphics.FromImage(thumbnailImg);

            g.FillRectangle(Brushes.White, 0, 0, width, height);
            g.DrawImage(fullSizeImg, 0, 0, width, height);

            try
            {
                //thumbnailImg.Save(mTempImageName, fullSizeImg.RawFormat);
                picImg.Image = thumbnailImg;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DoSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mCurrentImageName)) return;

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "JPEG Files (*.jpg)|*.jpg|All Files|*.*";
            string current_dir = Directory.GetCurrentDirectory();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string filename = dlg.FileName;
                Directory.SetCurrentDirectory(current_dir);
                if (picImg.Image != null)
                {
                    picImg.Image.Save(filename);
                }
            }
            else
            {
                Directory.SetCurrentDirectory(current_dir);
            }
        }

        private static Image cropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            Bitmap bmpCrop = bmpImage.Clone(cropArea,
            bmpImage.PixelFormat);
            return (Image)(bmpCrop);
        }

        private void DoOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|All Files|*.*";
            string current_dir = Directory.GetCurrentDirectory();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Directory.SetCurrentDirectory(current_dir);
                string filename=dlg.FileName;
                mCurrentImageName = filename;

                picImg.Image = Image.FromFile(mCurrentImageName);
            }
            else
            {
                Directory.SetCurrentDirectory(current_dir);
            }
        }

        private void tsbUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mCurrentImageName))
            {
                return;
            }

            Image img = picImg.Image;

            string filename=DateTime.Now.ToString("yyyyMMddHHmmss");
            string filename_ext = string.Format("{0}.jpg", filename);

            string tmp_folder=Path.Combine(Application.StartupPath, "tmp");
            string tmp_thumb_folder=Path.Combine(tmp_folder, "thumb");

            if (!Directory.Exists(tmp_folder))
            {
                Directory.CreateDirectory(tmp_folder);
            }

            if(!Directory.Exists(tmp_thumb_folder))
            {
                Directory.CreateDirectory(tmp_thumb_folder);
            }

            string filepath = Path.Combine(tmp_folder, filename_ext);

            img.Save(filepath);

            StringBuilder sb=new StringBuilder();
            string url = string.Format("handle_data_upload.php?dst={0}&thumb=no", ClientUtil.UrlEncode(filename_ext));
            string message = ClientUtil.PostUpload(filepath, "http://www.czcodezone.com/npr/", url);
            sb.AppendLine(message);

            //Image fullSizeImg = img;
            //int width = 80;
            //int height = 120;

            //Image thumbnailImg = new Bitmap(fullSizeImg, width, height);
            //Graphics g = Graphics.FromImage(thumbnailImg);

            //g.FillRectangle(Brushes.White, 0, 0, width, height);
            //g.DrawImage(fullSizeImg, 0, 0, width, height);

            //string thumb_filepath=Path.Combine(tmp_thumb_folder, filename_ext);

            //thumbnailImg.Save(thumb_filepath);

            //url = string.Format("handle_data_upload.php?dst={0}&thumb=yes", ClientUtil.UrlEncode(filename_ext));
            //message = ClientUtil.PostUpload(thumb_filepath, "http://www.czcodezone.com/npr/", url);
            //sb.AppendLine(message);

            MessageBox.Show(sb.ToString());
        }
    }
}
