using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TryOut.Grid;

namespace TryOut
{
    partial class Form1 : Form
    {
        Timer timer = new Timer();

        long startTime;
        long interval = (long)TimeSpan.FromSeconds(1 / 30).TotalMilliseconds;

        MainGrid grid;

        Graphics graphics;
        Graphics imageGraphics;

        Image backBuffer;
        Image blackScreen;

        int clientWidth, clientHeight;

        //Rectangle image = new Rectangle(0, 0, 40, 50);
        //Point direction = new Point(1, 2);

        public Form1()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ClientSize = new Size(300, 300);

            clientWidth = this.ClientRectangle.Width;
            clientHeight = this.ClientRectangle.Height;

            backBuffer = (Image)new Bitmap(clientWidth, clientHeight);

            graphics = this.CreateGraphics();
            imageGraphics = Graphics.FromImage(backBuffer);

            grid = new MainGrid(imageGraphics);
        }

        public void GameLoop()
        {
            timer.Start();

            while (this.Created)
            {
                startTime = timer.ElapsedMilliseconds;
                GameLogic();
                RenderScene();
                Application.DoEvents();
                while (timer.ElapsedMilliseconds - startTime < interval) ;
            }
        }

        private void GameLogic()
        {
           /* image.X += direction.X;
            image.Y += direction.Y;

            if (image.X < 0)
            {
                image.X = 0;
                direction.X *= -1;
            }

            if (image.Y < 0)
            {
                image.Y = 0;
                direction.Y *= -1;
            }

            if (image.X + image.Width > clientWidth)
            {
                image.X = clientWidth - image.Width;
                direction.X *= -1;
            }

            if (image.Y + image.Height > clientHeight)
            {
                image.Y = clientHeight - image.Height;
                direction.Y *= -1;
            }
            */
        }

        private void RenderScene()
        {
            imageGraphics.FillRectangle(new SolidBrush(Color.White),
                this.ClientRectangle);

            grid.Draw();
           
            this.BackgroundImage = backBuffer;
            this.Invalidate();
        }
    }
}
