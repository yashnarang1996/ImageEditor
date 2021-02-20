using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace Image_Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Image file;
        Boolean opened = false;

        void openImage()
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                file = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = file;
                opened = true;
            }
        }

        void saveImage()
        {
            if (opened)
            {
                SaveFileDialog sfd = new SaveFileDialog(); 
                sfd.Filter = "Images|*.png;*.bmp;*.jpg";
                ImageFormat format = ImageFormat.Png;
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string ext = Path.GetExtension(sfd.FileName);
                    switch (ext)
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                    }
                    pictureBox1.Image.Save(sfd.FileName, format);
                }



            }
            else { MessageBox.Show("No image loaded, first upload image "); }

        }

        void reload()
        {
            if (!opened)
            {
                // MessageBox.Show("Open an Image then apply changes");
            }
            else
            {
                if (opened)
                {
                    file = Image.FromFile(openFileDialog1.FileName);
                    pictureBox1.Image = file;
                    opened = true;
                }
            }
        }

        void filter1()
        {
            if (!opened)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {

                Image img = pictureBox1.Image;                             
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);  
                                                                        

                ImageAttributes ia = new ImageAttributes();                 
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{.393f, .349f, .272f+1.3f, 0, 0},
            new float[]{.769f, .686f+0.5f, .534f, 0, 0},
            new float[]{.189f+2.3f, .168f, .131f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);         
                Graphics g = Graphics.FromImage(bmpInverted);   
                                                            

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


                


                g.Dispose();                            
                pictureBox1.Image = bmpInverted;

            }
        }


        void filter2()
        {
            if (!opened)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {

                Image img = pictureBox1.Image;                           
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   
                                                                        

                ImageAttributes ia = new ImageAttributes();                
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{.393f, .349f+0.5f, .272f, 0, 0},
            new float[]{.769f+0.3f, .686f, .534f, 0, 0},
            new float[]{.189f, .168f, .131f+0.5f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);           
                Graphics g = Graphics.FromImage(bmpInverted);   
                                                           

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


               


                g.Dispose();                            
                pictureBox1.Image = bmpInverted;

            }
        }


        void filter3()
        {
            if (!opened)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {

                Image img = pictureBox1.Image;                            
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   
                                                                        

                ImageAttributes ia = new ImageAttributes();                
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{.393f+0.3f, .349f, .272f, 0, 0},
            new float[]{.769f, .686f+0.2f, .534f, 0, 0},
            new float[]{.189f, .168f, .131f+0.9f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);          
                Graphics g = Graphics.FromImage(bmpInverted);   
                                                           

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


               

                g.Dispose();                         
                pictureBox1.Image = bmpInverted;

            }
        }

        private static Image cropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openImage();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveImage();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reload();
            filter1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reload();
            filter2();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            reload();
            filter3();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (pictureBox1.Image != null)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox1.Image = bmp;
            }
            
            else
            {

                MessageBox.Show("No Image");

            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Image);

                bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);

                pictureBox1.Image = bmp;
            }
            else
            {

                MessageBox.Show("No Image");

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Image);

                bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);

                pictureBox1.Image = bmp;
            }
            else
            {

                MessageBox.Show("No Image");

            }
        }
    }
}
