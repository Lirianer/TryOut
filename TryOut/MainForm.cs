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
    partial class MainForm : Form
    {
        private Timer timer = new Timer();

        private long startTime;
        private long interval = (long)TimeSpan.FromSeconds(1 / 120).TotalMilliseconds;

        private int gridSize = 10;
        private MainGrid mainGrid;

        private int originalWidth = 0;
        private int originalHeight = 0;

        private Graphics graphics;

        private Image backBuffer;

        private bool pause = true;

        public MainForm()
        {
            InitializeComponent();
            ResizeRedraw = false;

            randomSelector.Checked = true;
            checkDisplayDensity.Checked = true;

            // Set GridPane to DoubleBuffered instead of the entire form
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            aProp.SetValue(GridPane, true, null);
 
            Init();

            InitGraphics();

            originalWidth = Width;
            originalHeight = Height;
        }

        private void Init()
        {
            // Create the grid with specified size within the pane area
            mainGrid = new MainGrid(gridSize);
            mainGrid.GridRect = GridPane.ClientRectangle;

            mainGrid.CreateEmitters();

            if (randomSelector.Checked)
            {
                mainGrid.CreateRandomWalls();
            }

            mainGrid.DestinationAmount = 1;
            mainGrid.Percentage = (double)flowSpeed.Value / 8;

            isAC.Checked = false;
            multiplierSelector.Value = 1;
            pause = true;
            pauseAction.Text = "Unpause";
            labelDisplayMultiplier.Text = "x " + mainGrid.EmitBaseAmount;
        }

        private void InitGraphics()
        {
            // Create the backBuffer for the GridPane to prevent flickering while drawing
            backBuffer = (Image)new Bitmap(GridPane.ClientRectangle.Width, GridPane.ClientRectangle.Height);

            // Create the GridPane graphics object
            graphics = Graphics.FromImage(backBuffer);

            mainGrid.GridRect = GridPane.ClientRectangle;
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
            mainGrid.ProcessFlow();
            if (mainGrid.HasWon())
            {
                MessageBox.Show("You have Won this Map!");
                restartAction.PerformClick();
            }
        }

        private void RenderScene()
        {
            graphics.Clear(Color.Ivory);

            mainGrid.Draw(graphics);

            GridPane.BackgroundImage = backBuffer;

            totalLabel.Text = mainGrid.Total.ToString("0.###");

            Invalidate(true);
        }

        private void pauseAction_Click(object sender, EventArgs e)
        {
            if (pause)
            {
                pause = false;
                pauseAction.Text = "Pause";
            }
            else
            {
                pause = true;
                pauseAction.Text = "Unpause";
            }
        }

        private void Restart()
        {
            Init();
            InitGraphics();
            RenderScene();
        }

        private void restartAction_Click(object sender, EventArgs e)
        {
            Restart();
        }

        private void oneStepAction_Click(object sender, EventArgs e)
        {
            pause = true;
            pauseAction.Text = "Unpause";

            GameLogic();
            RenderScene();
        }

        private void buttonEmit_Click(object sender, EventArgs e)
        {
            mainGrid.Emit();

            RenderScene();
        }

        private void checkDisplayAmount_CheckedChanged(object sender, EventArgs e)
        {
            mainGrid.DisplayDensity = checkDisplayDensity.Checked;

            RenderScene();
        }

        private void checkDisplayGrid_CheckedChanged(object sender, EventArgs e)
        {
            mainGrid.DisplayGrid = checkDisplayGrid.Checked;

            RenderScene();
        }
        
        private void flowSpeed_Scroll(object sender, EventArgs e)
        {
            mainGrid.Percentage = (double)flowSpeed.Value / 8;
            displaySpeed.Text = "Speed: " + flowSpeed.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (isAC.Checked)
            {
                mainGrid.AmountMultiplier = multiplierSelector.Value * -1;
            }
            else
            {
                mainGrid.AmountMultiplier = multiplierSelector.Value;
            }
        }

        private void isAC_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1_ValueChanged(sender, e);
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridSizeSelector_ValueChanged(object sender, EventArgs e)
        {
            gridSize = (int) gridSizeSelector.Value;

            SnapFormToGrid();
            Invalidate(true);

            Restart();
        }

        private void SnapFormToGrid()
        {
            // Snap back to full pizels per cell
            int excessPixels;

            excessPixels = GridPane.Width % gridSize;
            if (excessPixels > gridSize / 2)
            {   // Make form slightly wider
                Width += (gridSize - excessPixels);
            }
            else
            {   // Make form slightly narrower
                Width -= excessPixels;
            }

            excessPixels = GridPane.Height % gridSize;
            if (excessPixels > gridSize / 2)
            {   // Make form slightly higher
                Height += (gridSize - excessPixels);
            }
            else
            {   // Make form slightly smaller
                Height -= excessPixels;
            }
        }

        private void MainForm_ResizeBegin(object sender, EventArgs e)
        {
            SuspendLayout();
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            int divWidth = Width - originalWidth;
            int divHeight = Height - originalHeight;

            // Maintain aspect ratio
            if (Math.Abs(divWidth) > Math.Abs(divHeight))
            {
                Height = originalHeight + divWidth;
                Width = originalWidth + divWidth;
            }
            else
            {
                Height = originalHeight + divHeight;
                Width = originalWidth + divHeight;
            }

            ResumeLayout(true);

            SnapFormToGrid();

            originalWidth = Width;
            originalHeight = Height;

            InitGraphics();
            
            RenderScene();
        }

        private void GridPane_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = new Point(e.X, e.Y);
            GridCell cell = mainGrid.CellAtMousePos(mousePos);

            cellLabel.Text = "Cell: X=" + cell.X.ToString() + ", Y=" + cell.Y.ToString();
            densityLabel.Text = "Density: " + cell.OldAmount.ToString("0.#######"); 
        }

        private void GridPane_MouseClick(object sender, MouseEventArgs e)
        {
            Point mousePos = new Point(e.X, e.Y);

            switch (e.Button.ToString())
            {
                case "Left":
                    if (checkMakeDestination.Checked)
                    {
                        mainGrid.SwitchDestination(mousePos);
                    }
                    else
                    {
                        mainGrid.SwitchWall(mousePos);
                    }
                    break;

                case "Right":
                    mainGrid.Emit(mousePos);
                    break;

            }

            RenderScene();
        }
    }
}
