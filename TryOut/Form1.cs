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
        long interval = (long)TimeSpan.FromSeconds(1 / 120).TotalMilliseconds;

        MainGrid grid;

        Graphics graphics;
        Graphics imageGraphics;

        Image backBuffer;

        int clientWidth, clientHeight;

        bool pause = true;

        //Rectangle image = new Rectangle(0, 0, 40, 50);
        //Point direction = new Point(1, 2);

        public Form1()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //this.ClientSize = new Size(400, 400);
            this.blankSelector.Checked = true;
            

            clientWidth = this.ClientRectangle.Width;
            clientHeight = this.ClientRectangle.Height;

            backBuffer = (Image)new Bitmap(clientWidth, clientHeight);

            graphics = this.CreateGraphics();
            imageGraphics = Graphics.FromImage(backBuffer);

            grid = new MainGrid(imageGraphics, 1);
        }

        public void GameLoop()
        {
            timer.Start();
            RenderScene();

            while (this.Created)
            {

                startTime = timer.ElapsedMilliseconds;

                
                if (!pause)
                {
                    GameLogic();
                    RenderScene();
                    while (timer.ElapsedMilliseconds - startTime < interval) ;
                }
                Application.DoEvents();
                
            }
        }

        private void GameLogic()
        {
            grid.ProcessFlow();
            

        }

        private void RenderScene()
        {
            imageGraphics.FillRectangle(new SolidBrush(Color.White), 2, 2, 2 + (31 * 10), 2 + (31 * 10)/*this.ClientRectangle*/);

            grid.Draw();
            label1.Text = grid.Total.ToString("0.###");

           
            this.BackgroundImage = backBuffer;
            this.Invalidate();
        }

        private void pauseAction_Click(object sender, EventArgs e)
        {
            if (pause)
            {
                pause = false;
                pauseAction.Text = "Pause";
            }
            else if (!pause)
            {
                pause = true;
                pauseAction.Text = "Unpause";
            }
        }

        private void restartAction_Click(object sender, EventArgs e)
        {
            if (blankSelector.Checked)
            {
                grid = new MainGrid(imageGraphics, 1);
            }
            else if (mapSelector.Checked)
            {
                grid = new MainGrid(imageGraphics, 2);
            }
            else if (randomSelector.Checked)
            {
                grid = new MainGrid(imageGraphics, 3);
            }

            grid.percentage = (double)flowSpeed.Value / 8;

            isAC.Checked = false;
            multiplierSelector.Value = 1;
            pause = true;
            checkDisplayAmount.Checked = true;
            pauseAction.Text = "Unpause";
            labelDisplayMultiplier.Text = "* "+grid.emitAmount;

            RenderScene();
        }

        private void oneStepAction_Click(object sender, EventArgs e)
        {
            pause = true;
            pauseAction.Text = "Unpause";

            GameLogic();
            RenderScene();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            string info;

            foreach (GridCell cell in grid.grid)
            {
                if ((cell.rectangle.X < e.X && cell.rectangle.X + cell.rectangle.Width > e.X) && (cell.rectangle.Y < e.Y && cell.rectangle.Y + cell.rectangle.Width > e.Y))
                {
                    info = @"Cell: X= " + cell.X + "  Y= " + cell.Y + @"
       Creeper= " + cell.oldAmount;

                    labelCell.Text = info;
                }
            }


        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            Console.WriteLine(e.Button);

            Point mousePos = new Point();
            mousePos.X = e.X;
            mousePos.Y = e.Y;

            switch (e.Button.ToString())
            {
                case "Left":
                    if (checkMakeDestination.Checked)
                    {
                        grid.SwitchDestination(mousePos);
                    }
                    else
                    {
                        grid.SwitchWall(mousePos);
                    }
                    break;
                     
                case "Right":
                        grid.Emit(mousePos);
                    break;
                    
            }
            RenderScene();
        }

        private void buttonEmit_Click(object sender, EventArgs e)
        {
            grid.Emit();
            RenderScene();
        }

        private void checkDisplayAmount_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDisplayAmount.Checked)
            {
                foreach (GridCell cell in grid.grid)
                {
                    cell.displayAmount = true;
                }
            }

            if (!checkDisplayAmount.Checked)
            {
                foreach (GridCell cell in grid.grid)
                {
                    cell.displayAmount = false;
                }
            }

            RenderScene();
        }
        
        private void flowSpeed_Scroll(object sender, EventArgs e)
        {
            grid.percentage = (double)flowSpeed.Value / 8;
            displaySpeed.Text = "Speed: " + flowSpeed.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (isAC.Checked)
            {
                grid.amountMultiplier = multiplierSelector.Value * -1;
                grid.UpdateEmitAmount();
            }
            else if (!isAC.Checked)
            {
                grid.amountMultiplier = multiplierSelector.Value;
                grid.UpdateEmitAmount();
            }
            
        }

        private void isAC_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1_ValueChanged(sender, e);
        }


    }
}
