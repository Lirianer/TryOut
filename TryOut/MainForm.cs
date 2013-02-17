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

            // Set control defaults
            isAC.Checked = false;
            randomSelector.Checked = true;
            checkDisplayDensity.Checked = true;
            multiplierSelector.Value = 1;

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

            mainGrid.DestinationAmount = 5;
            mainGrid.Percentage = (double)flowSpeed.Value / 8;
            mainGrid.DisplayDensity = checkDisplayDensity.Checked;
            mainGrid.DisplayGrid = checkDisplayGrid.Checked;
            mainGrid.AmountMultiplier = GetMultiplier();

            pause = true;
            pauseAction.Text = "Unpause";
            densityLabel.Text = "";
            SetMuliplierText();
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
            if (mainGrid.Total < -0.001)
            {
                totalLabel.BackColor = Color.LightGreen;
            }
            else
            {
                if (mainGrid.Total > 0.001)
                {
                    totalLabel.BackColor = Color.LightBlue;
                }
                else
                {
                    totalLabel.BackColor = BackColor;
                }
            }

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
            mainGrid.AmountMultiplier = GetMultiplier();
            SetMuliplierText();
        }

        private decimal GetMultiplier()
        {
            decimal amountMultiplier = multiplierSelector.Value;

            if (isAC.Checked)
            {
                amountMultiplier *= -1;
            }

            return amountMultiplier;
        }

        private void SetMuliplierText()
        {
            labelDisplayMultiplier.Text = "x " + mainGrid.EmitBaseAmount + " = " +
                (mainGrid.EmitBaseAmount * (double)multiplierSelector.Value).ToString("0.#");

            if (isAC.Checked)
            {
                labelDisplayMultiplier.BackColor = Color.LightGreen;
            }
            else
            {
                labelDisplayMultiplier.BackColor = Color.LightBlue;
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

            Restart();
        }

        private void SnapFormToGrid()
        {
            // Snap back to full pizels per cell
            int excessPixels = GridPane.Width % gridSize;

            if (excessPixels > gridSize / 2 &&
                (Height + gridSize - excessPixels) <= Screen.PrimaryScreen.WorkingArea.Height)
            {   // Make form slightly larger
                Width += (gridSize - excessPixels);
                Height += (gridSize - excessPixels);
            }
            else
            {   // Make form slightly smaller
                Width -= excessPixels;
                Height -= excessPixels;
            }
        }

        protected override void WndProc(ref Message m)
        {   // Override maximize event
            if (m.Msg == 0x0112 &&              // WM_SYSCOMMAND
                m.WParam == new IntPtr(0xF030)) // Maximize event: SC_MAXIMIZE from Winuser.h
            {
                SuspendLayout();
                Height = Screen.PrimaryScreen.WorkingArea.Height;
                AdjustSize();
            }
            else
            {   // Continue processing
                base.WndProc(ref m);
            }
        }

        private void FitToScreen()
        {
            int divSize;
            int divWidth = Width - originalWidth;
            int divHeight = Height - originalHeight;

            // Maintain aspect ratio
            if (Math.Abs(divHeight) > Math.Abs(divWidth))
            {
                divSize = divHeight;
            }
            else
            {
                divSize = divWidth;
            }

            // Adjust size to fit the working area (desktop minus taskbar)
            Rectangle screenSize = new Rectangle(new Point(0,0), Screen.PrimaryScreen.WorkingArea.Size);
            int screenHeight = screenSize.Height;
            int screenWidth = screenSize.Width;

            divSize = Math.Min(divSize, screenSize.Height - originalHeight);

            // Set new form size
            Height = originalHeight + divSize;
            Width = originalWidth + divSize;

            // Reposition the form to make it entirely visible
            Point pos = new Point();
            pos.X = Math.Min(Location.X, screenWidth - Width);
            pos.Y = Math.Min(Location.Y, screenHeight - Height);
            Location = pos;
        }

        private void AdjustSize()
        {
            FitToScreen();

            ResumeLayout(true);

            SnapFormToGrid();

            originalWidth = Width;
            originalHeight = Height;

            InitGraphics();

            RenderScene();
        }

        private void MainForm_ResizeBegin(object sender, EventArgs e)
        {
            SuspendLayout();
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            AdjustSize();
        }

        private void GridPane_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = new Point(e.X, e.Y);
            GridCell cell = mainGrid.CellAtMousePos(mousePos);

            cellLabel.Text = "Cell: X=" + cell.X.ToString() + ", Y=" + cell.Y.ToString();
            densityLabel.Text = Math.Abs(cell.OldAmount).ToString("0.#######");
            if (cell.OldAmount < -0.0000001)
            {
                densityLabel.BackColor = Color.LightGreen;
            }
            else
            {
                if (cell.OldAmount > 0.0000001)
                {
                    densityLabel.BackColor = Color.LightBlue;
                }
                else
                {
                    densityLabel.BackColor = BackColor;
                }
            }
        }

        private void GridPane_MouseClick(object sender, MouseEventArgs e)
        {
            Point mousePos = new Point(e.X, e.Y);

            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (checkMakeDestination.Checked)
                    {
                        mainGrid.SwitchDestination(mousePos);
                    }
                    else
                    {
                        mainGrid.SwitchWall(mousePos);
                    }
                break;

                case MouseButtons.Right:
                    mainGrid.Emit(mousePos);
                break;
            }

            RenderScene();
        }
    }
}
