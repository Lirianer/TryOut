namespace TryOut
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pauseAction = new System.Windows.Forms.Button();
            this.totalLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.restartAction = new System.Windows.Forms.Button();
            this.oneStepAction = new System.Windows.Forms.Button();
            this.blankSelector = new System.Windows.Forms.RadioButton();
            this.randomSelector = new System.Windows.Forms.RadioButton();
            this.cellLabel = new System.Windows.Forms.Label();
            this.buttonEmit = new System.Windows.Forms.Button();
            this.checkDisplayDensity = new System.Windows.Forms.CheckBox();
            this.flowSpeed = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.displaySpeed = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.multiplierSelector = new System.Windows.Forms.NumericUpDown();
            this.labelDisplayMultiplier = new System.Windows.Forms.Label();
            this.isAC = new System.Windows.Forms.CheckBox();
            this.checkMakeDestination = new System.Windows.Forms.CheckBox();
            this.GridPane = new System.Windows.Forms.Panel();
            this.gridSizeSelector = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.quitButton = new System.Windows.Forms.Button();
            this.checkDisplayGrid = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.densityLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.flowSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiplierSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSizeSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // pauseAction
            // 
            this.pauseAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pauseAction.Location = new System.Drawing.Point(494, 108);
            this.pauseAction.Name = "pauseAction";
            this.pauseAction.Size = new System.Drawing.Size(75, 23);
            this.pauseAction.TabIndex = 0;
            this.pauseAction.Text = "Unpause";
            this.pauseAction.UseVisualStyleBackColor = true;
            this.pauseAction.Click += new System.EventHandler(this.pauseAction_Click);
            // 
            // totalLabel
            // 
            this.totalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(535, 441);
            this.totalLabel.MinimumSize = new System.Drawing.Size(0, 20);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(53, 20);
            this.totalLabel.TabIndex = 1;
            this.totalLabel.Text = "totalLabel";
            this.totalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(487, 446);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total:";
            // 
            // restartAction
            // 
            this.restartAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.restartAction.Location = new System.Drawing.Point(634, 393);
            this.restartAction.Name = "restartAction";
            this.restartAction.Size = new System.Drawing.Size(75, 23);
            this.restartAction.TabIndex = 3;
            this.restartAction.Text = "Restart";
            this.restartAction.UseVisualStyleBackColor = true;
            this.restartAction.Click += new System.EventHandler(this.restartAction_Click);
            // 
            // oneStepAction
            // 
            this.oneStepAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.oneStepAction.Location = new System.Drawing.Point(494, 137);
            this.oneStepAction.Name = "oneStepAction";
            this.oneStepAction.Size = new System.Drawing.Size(75, 23);
            this.oneStepAction.TabIndex = 4;
            this.oneStepAction.Text = "One-Step";
            this.oneStepAction.UseVisualStyleBackColor = true;
            this.oneStepAction.Click += new System.EventHandler(this.oneStepAction_Click);
            // 
            // blankSelector
            // 
            this.blankSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.blankSelector.AutoSize = true;
            this.blankSelector.Location = new System.Drawing.Point(634, 345);
            this.blankSelector.Name = "blankSelector";
            this.blankSelector.Size = new System.Drawing.Size(52, 17);
            this.blankSelector.TabIndex = 5;
            this.blankSelector.Text = "Blank";
            this.blankSelector.UseVisualStyleBackColor = true;
            // 
            // randomSelector
            // 
            this.randomSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.randomSelector.AutoSize = true;
            this.randomSelector.Checked = true;
            this.randomSelector.Location = new System.Drawing.Point(634, 370);
            this.randomSelector.Name = "randomSelector";
            this.randomSelector.Size = new System.Drawing.Size(65, 17);
            this.randomSelector.TabIndex = 7;
            this.randomSelector.TabStop = true;
            this.randomSelector.Text = "Random";
            this.randomSelector.UseVisualStyleBackColor = true;
            // 
            // cellLabel
            // 
            this.cellLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cellLabel.AutoSize = true;
            this.cellLabel.CausesValidation = false;
            this.cellLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cellLabel.Location = new System.Drawing.Point(491, 398);
            this.cellLabel.Name = "cellLabel";
            this.cellLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cellLabel.Size = new System.Drawing.Size(99, 13);
            this.cellLabel.TabIndex = 9;
            this.cellLabel.Text = "Cell:   X={0},  Y={1}";
            // 
            // buttonEmit
            // 
            this.buttonEmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEmit.Location = new System.Drawing.Point(490, 296);
            this.buttonEmit.Name = "buttonEmit";
            this.buttonEmit.Size = new System.Drawing.Size(75, 23);
            this.buttonEmit.TabIndex = 10;
            this.buttonEmit.Text = "Emit";
            this.buttonEmit.UseVisualStyleBackColor = true;
            this.buttonEmit.Click += new System.EventHandler(this.buttonEmit_Click);
            // 
            // checkDisplayDensity
            // 
            this.checkDisplayDensity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkDisplayDensity.AutoSize = true;
            this.checkDisplayDensity.Checked = true;
            this.checkDisplayDensity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkDisplayDensity.Location = new System.Drawing.Point(490, 346);
            this.checkDisplayDensity.Name = "checkDisplayDensity";
            this.checkDisplayDensity.Size = new System.Drawing.Size(133, 17);
            this.checkDisplayDensity.TabIndex = 11;
            this.checkDisplayDensity.Text = "Display density per cell";
            this.checkDisplayDensity.UseVisualStyleBackColor = true;
            this.checkDisplayDensity.CheckedChanged += new System.EventHandler(this.checkDisplayAmount_CheckedChanged);
            // 
            // flowSpeed
            // 
            this.flowSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowSpeed.LargeChange = 20;
            this.flowSpeed.Location = new System.Drawing.Point(654, 31);
            this.flowSpeed.Maximum = 100;
            this.flowSpeed.Minimum = 1;
            this.flowSpeed.Name = "flowSpeed";
            this.flowSpeed.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.flowSpeed.Size = new System.Drawing.Size(45, 153);
            this.flowSpeed.SmallChange = 5;
            this.flowSpeed.TabIndex = 12;
            this.flowSpeed.Value = 40;
            this.flowSpeed.Scroll += new System.EventHandler(this.flowSpeed_Scroll);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(631, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Flow Speed:";
            // 
            // displaySpeed
            // 
            this.displaySpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.displaySpeed.AutoSize = true;
            this.displaySpeed.Location = new System.Drawing.Point(640, 187);
            this.displaySpeed.Name = "displaySpeed";
            this.displaySpeed.Size = new System.Drawing.Size(59, 13);
            this.displaySpeed.TabIndex = 14;
            this.displaySpeed.Text = "Speed : 40";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(486, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Emit Amount:";
            // 
            // multiplierSelector
            // 
            this.multiplierSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.multiplierSelector.Location = new System.Drawing.Point(561, 219);
            this.multiplierSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.multiplierSelector.Name = "multiplierSelector";
            this.multiplierSelector.Size = new System.Drawing.Size(46, 20);
            this.multiplierSelector.TabIndex = 16;
            this.multiplierSelector.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.multiplierSelector.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // labelDisplayMultiplier
            // 
            this.labelDisplayMultiplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDisplayMultiplier.AutoSize = true;
            this.labelDisplayMultiplier.Location = new System.Drawing.Point(613, 219);
            this.labelDisplayMultiplier.MinimumSize = new System.Drawing.Size(0, 20);
            this.labelDisplayMultiplier.Name = "labelDisplayMultiplier";
            this.labelDisplayMultiplier.Size = new System.Drawing.Size(52, 20);
            this.labelDisplayMultiplier.TabIndex = 17;
            this.labelDisplayMultiplier.Text = "multLabel";
            this.labelDisplayMultiplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // isAC
            // 
            this.isAC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.isAC.AutoSize = true;
            this.isAC.Location = new System.Drawing.Point(490, 250);
            this.isAC.Name = "isAC";
            this.isAC.Size = new System.Drawing.Size(114, 17);
            this.isAC.TabIndex = 18;
            this.isAC.Text = "Make Anti-Creeper";
            this.isAC.UseVisualStyleBackColor = true;
            this.isAC.CheckedChanged += new System.EventHandler(this.isAC_CheckedChanged);
            // 
            // checkMakeDestination
            // 
            this.checkMakeDestination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkMakeDestination.AutoSize = true;
            this.checkMakeDestination.Location = new System.Drawing.Point(490, 273);
            this.checkMakeDestination.Name = "checkMakeDestination";
            this.checkMakeDestination.Size = new System.Drawing.Size(129, 17);
            this.checkMakeDestination.TabIndex = 19;
            this.checkMakeDestination.Text = "Make Destination Cell";
            this.checkMakeDestination.UseVisualStyleBackColor = true;
            // 
            // GridPane
            // 
            this.GridPane.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GridPane.BackColor = System.Drawing.Color.Ivory;
            this.GridPane.Location = new System.Drawing.Point(0, 0);
            this.GridPane.Name = "GridPane";
            this.GridPane.Size = new System.Drawing.Size(480, 480);
            this.GridPane.TabIndex = 20;
            this.GridPane.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GridPane_MouseClick);
            this.GridPane.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GridPane_MouseMove);
            // 
            // gridSizeSelector
            // 
            this.gridSizeSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSizeSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridSizeSelector.Location = new System.Drawing.Point(549, 19);
            this.gridSizeSelector.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.gridSizeSelector.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.gridSizeSelector.Name = "gridSizeSelector";
            this.gridSizeSelector.Size = new System.Drawing.Size(46, 31);
            this.gridSizeSelector.TabIndex = 21;
            this.gridSizeSelector.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.gridSizeSelector.ValueChanged += new System.EventHandler(this.gridSizeSelector_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(491, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Grid Size:";
            // 
            // quitButton
            // 
            this.quitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.quitButton.Location = new System.Drawing.Point(634, 446);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(75, 23);
            this.quitButton.TabIndex = 24;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // checkDisplayGrid
            // 
            this.checkDisplayGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkDisplayGrid.AutoSize = true;
            this.checkDisplayGrid.Checked = true;
            this.checkDisplayGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkDisplayGrid.Location = new System.Drawing.Point(489, 371);
            this.checkDisplayGrid.Name = "checkDisplayGrid";
            this.checkDisplayGrid.Size = new System.Drawing.Size(80, 17);
            this.checkDisplayGrid.TabIndex = 25;
            this.checkDisplayGrid.Text = "Display grid";
            this.checkDisplayGrid.UseVisualStyleBackColor = true;
            this.checkDisplayGrid.CheckedChanged += new System.EventHandler(this.checkDisplayGrid_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.CausesValidation = false;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(490, 422);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Density:";
            // 
            // densityLabel
            // 
            this.densityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.densityLabel.AutoSize = true;
            this.densityLabel.Location = new System.Drawing.Point(535, 418);
            this.densityLabel.MinimumSize = new System.Drawing.Size(0, 20);
            this.densityLabel.Name = "densityLabel";
            this.densityLabel.Size = new System.Drawing.Size(66, 20);
            this.densityLabel.TabIndex = 27;
            this.densityLabel.Text = "densityLabel";
            this.densityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 480);
            this.Controls.Add(this.densityLabel);
            this.Controls.Add(this.checkDisplayGrid);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gridSizeSelector);
            this.Controls.Add(this.GridPane);
            this.Controls.Add(this.checkMakeDestination);
            this.Controls.Add(this.isAC);
            this.Controls.Add(this.labelDisplayMultiplier);
            this.Controls.Add(this.multiplierSelector);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.displaySpeed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.flowSpeed);
            this.Controls.Add(this.checkDisplayDensity);
            this.Controls.Add(this.buttonEmit);
            this.Controls.Add(this.cellLabel);
            this.Controls.Add(this.randomSelector);
            this.Controls.Add(this.blankSelector);
            this.Controls.Add(this.oneStepAction);
            this.Controls.Add(this.restartAction);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.pauseAction);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(733, 516);
            this.Name = "MainForm";
            this.Text = "Cosa Amorfa";
            this.ResizeBegin += new System.EventHandler(this.MainForm_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.flowSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiplierSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSizeSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button pauseAction;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button restartAction;
        private System.Windows.Forms.Button oneStepAction;
        private System.Windows.Forms.RadioButton blankSelector;
        private System.Windows.Forms.RadioButton randomSelector;
        private System.Windows.Forms.Label cellLabel;
        private System.Windows.Forms.Button buttonEmit;
        private System.Windows.Forms.CheckBox checkDisplayDensity;
        private System.Windows.Forms.TrackBar flowSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label displaySpeed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown multiplierSelector;
        private System.Windows.Forms.Label labelDisplayMultiplier;
        private System.Windows.Forms.CheckBox isAC;
        private System.Windows.Forms.CheckBox checkMakeDestination;
        private System.Windows.Forms.Panel GridPane;
        private System.Windows.Forms.NumericUpDown gridSizeSelector;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.CheckBox checkDisplayGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label densityLabel;

    }
}

