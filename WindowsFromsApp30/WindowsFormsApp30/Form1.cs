using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp30
{
    public partial class Form1 : Form
        
    {
        
        Pen pRed = new Pen(Color.Red, 3);
        Brush bBrown = new SolidBrush(Color.Brown);

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Width = this.Width;
            pictureBox1.Height = this.Height - 85;
            panel1.Width = this.Width;
            button1.Click += button1_Click;
            colorDialog1.FullOpen = true;
            colorDialog1.Color = this.BackColor;
        }

        Point tempPoint;
        Boolean tempClick = false;
        Pen pen = new Pen(Color.Red, 2);


        private void Form1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Width = this.Width;
            pictureBox1.Height = this.Height - 85;
            panel1.Width = this.Width;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = $"X:{e.X}; Y:{e.Y}";
        }

        
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (tempClick == false)
            {
                tempClick = true;
                tempPoint.X = e.X;
                tempPoint.Y = e.Y;
            }
            else
            {
                if (radioButton1.Checked == true)
                {
                    tempClick = false;
                    Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    pictureBox1.Image = bmp;
                    Graphics g = Graphics.FromImage(bmp);

                    g.DrawLine(pen, tempPoint.X, tempPoint.Y, e.X, e.Y);

                   
                }
                else if (radioButton2.Checked == true)
                {
                    tempClick = false;
                    Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    pictureBox1.Image = bmp;
                    Graphics g = Graphics.FromImage(bmp);

                    int w = Math.Abs(e.X - tempPoint.X);
                    int h = Math.Abs(e.Y - tempPoint.Y);


                    g.FillEllipse(bBrown, tempPoint.X, tempPoint.Y, w, h);
                    g.DrawEllipse(pRed, tempPoint.X, tempPoint.Y, w, h);
                }
                else if (radioButton3.Checked == true)
                {
                    tempClick = false;
                    Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    pictureBox1.Image = bmp;
                    Graphics g = Graphics.FromImage(bmp);
                   // int t = Math.Abs(e.X - tempPoint.X);
                    //int j = Math.Abs(e.Y - tempPoint.Y);
                    //int y = Math.Abs(e.S - tempPoint.S);
                    //int l = Math.Abs(e.H - tempPoint.H);
                    g.FillRectangle(bBrown, tempPoint.X, tempPoint.Y, 200,100);
                    //g.DrawEllipse(pRed,x,y,t,j );
                    g.DrawRectangle( pRed, tempPoint.X, tempPoint.Y, 200, 100);
                }
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            
            pen.Color = colorDialog1.Color;
           
            pRed.Color = colorDialog1.Color;
            BackColor = colorDialog1.Color;








        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            bBrown = new SolidBrush(colorDialog1.Color);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Сохранить карнтинку как....";
                sfd.OverwritePrompt = true;
                sfd.CheckPathExists = true;
                sfd.Filter = "Image Files(*.BMP|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|" + "" +
                    "Image Files(*.PNG)|*.PNG|All files(*.*)|*.*";
                sfd.ShowHelp = true;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBox1.Image.Save(sfd.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|" + "" +
                    "Image Files(*.PNG)|*.PNG|All files(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(ofd.FileName);
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть выбраннок изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           // PictureBox pictureBox2 =new PictureBox
            //{
//Size=pictureBox1.Size,Location=new Point(0,0),BackColor=Color.Transparent,Image=Resources.neddedImage
           // }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
