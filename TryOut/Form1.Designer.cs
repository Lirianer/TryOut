namespace TryOut
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.restartAction = new System.Windows.Forms.Button();
            this.oneStepAction = new System.Windows.Forms.Button();
            this.blankSelector = new System.Windows.Forms.RadioButton();
            this.mapSelector = new System.Windows.Forms.RadioButton();
            this.randomSelector = new System.Windows.Forms.RadioButton();
            this.labelCell = new System.Windows.Forms.Label();
            this.buttonEmit = new System.Windows.Forms.Button();
            this.checkDisplayAmount = new System.Windows.Forms.CheckBox();
            this.flowSpeed = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.displaySpeed = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.multiplierSelector = new System.Windows.Forms.NumericUpDown();
            this.labelDisplayMultiplier = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.flowSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiplierSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // pauseAction
            // 
            this.pauseAction.Location = new System.Drawing.Point(297, 327);
            this.pauseAction.Name = "pauseAction";
            this.pauseAction.Size = new System.Drawing.Size(75, 23);
            this.pauseAction.TabIndex = 0;
            this.pauseAction.Text = "Unpause";
            this.pauseAction.UseVisualStyleBackColor = true;
            this.pauseAction.Click += new System.EventHandler(this.pauseAction_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total:";
            // 
            // restartAction
            // 
            this.restartAction.Location = new System.Drawing.Point(12, 327);
            this.restartAction.Name = "restartAction";
            this.restartAction.Size = new System.Drawing.Size(75, 23);
            this.restartAction.TabIndex = 3;
            this.restartAction.Text = "Restart";
            this.restartAction.UseVisualStyleBackColor = true;
            this.restartAction.Click += new System.EventHandler(this.restartAction_Click);
            // 
            // oneStepAction
            // 
            this.oneStepAction.Location = new System.Drawing.Point(297, 356);
            this.oneStepAction.Name = "oneStepAction";
            this.oneStepAction.Size = new System.Drawing.Size(75, 23);
            this.oneStepAction.TabIndex = 4;
            this.oneStepAction.Text = "One-Step";
            this.oneStepAction.UseVisualStyleBackColor = true;
            this.oneStepAction.Click += new System.EventHandler(this.oneStepAction_Click);
            // 
            // blankSelector
            // 
            this.blankSelector.AutoSize = true;
            this.blankSelector.Location = new System.Drawing.Point(12, 356);
            this.blankSelector.Name = "blankSelector";
            this.blankSelector.Size = new System.Drawing.Size(52, 17);
            this.blankSelector.TabIndex = 5;
            this.blankSelector.TabStop = true;
            this.blankSelector.Text = "Blank";
            this.blankSelector.UseVisualStyleBackColor = true;
            // 
            // mapSelector
            // 
            this.mapSelector.AutoSize = true;
            this.mapSelector.Location = new System.Drawing.Point(71, 357);
            this.mapSelector.Name = "mapSelector";
            this.mapSelector.Size = new System.Drawing.Size(46, 17);
            this.mapSelector.TabIndex = 6;
            this.mapSelector.TabStop = true;
            this.mapSelector.Text = "Map";
            this.mapSelector.UseVisualStyleBackColor = true;
            // 
            // randomSelector
            // 
            this.randomSelector.AutoSize = true;
            this.randomSelector.Location = new System.Drawing.Point(124, 356);
            this.randomSelector.Name = "randomSelector";
            this.randomSelector.Size = new System.Drawing.Size(65, 17);
            this.randomSelector.TabIndex = 7;
            this.randomSelector.TabStop = true;
            this.randomSelector.Text = "Random";
            this.randomSelector.UseVisualStyleBackColor = true;
            // 
            // labelCell
            // 
            this.labelCell.AutoSize = true;
            this.labelCell.CausesValidation = false;
            this.labelCell.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.labelCell.Location = new System.Drawing.Point(344, 9);
            this.labelCell.Name = "labelCell";
            this.labelCell.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelCell.Size = new System.Drawing.Size(99, 39);
            this.labelCell.TabIndex = 9;
            this.labelCell.Text = "Cell:   X={0},  Y={1}\r\n           Creeper= \r\n";
            // 
            // buttonEmit
            // 
            this.buttonEmit.Location = new System.Drawing.Point(396, 327);
            this.buttonEmit.Name = "buttonEmit";
            this.buttonEmit.Size = new System.Drawing.Size(75, 23);
            this.buttonEmit.TabIndex = 10;
            this.buttonEmit.Text = "Emit";
            this.buttonEmit.UseVisualStyleBackColor = true;
            this.buttonEmit.Click += new System.EventHandler(this.buttonEmit_Click);
            // 
            // checkDisplayAmount
            // 
            this.checkDisplayAmount.AutoSize = true;
            this.checkDisplayAmount.Checked = true;
            this.checkDisplayAmount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkDisplayAmount.Location = new System.Drawing.Point(347, 71);
            this.checkDisplayAmount.Name = "checkDisplayAmount";
            this.checkDisplayAmount.Size = new System.Drawing.Size(124, 17);
            this.checkDisplayAmount.TabIndex = 11;
            this.checkDisplayAmount.Text = "Display Cells Amount";
            this.checkDisplayAmount.UseVisualStyleBackColor = true;
            this.checkDisplayAmount.CheckedChanged += new System.EventHandler(this.checkDisplayAmount_CheckedChanged);
            // 
            // flowSpeed
            // 
            this.flowSpeed.LargeChange = 20;
            this.flowSpeed.Location = new System.Drawing.Point(347, 120);
            this.flowSpeed.Maximum = 100;
            this.flowSpeed.Name = "flowSpeed";
            this.flowSpeed.Size = new System.Drawing.Size(171, 45);
            this.flowSpeed.SmallChange = 10;
            this.flowSpeed.TabIndex = 12;
            this.flowSpeed.Value = 40;
            this.flowSpeed.Scroll += new System.EventHandler(this.flowSpeed_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(344, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Flow Speed:";
            // 
            // displaySpeed
            // 
            this.displaySpeed.AutoSize = true;
            this.displaySpeed.Location = new System.Drawing.Point(363, 152);
            this.displaySpeed.Name = "displaySpeed";
            this.displaySpeed.Size = new System.Drawing.Size(59, 13);
            this.displaySpeed.TabIndex = 14;
            this.displaySpeed.Text = "Speed : 40";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(341, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Emit Amount:";
            // 
            // multiplierSelector
            // 
            this.multiplierSelector.Location = new System.Drawing.Point(409, 189);
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
            this.labelDisplayMultiplier.AutoSize = true;
            this.labelDisplayMultiplier.Location = new System.Drawing.Point(461, 191);
            this.labelDisplayMultiplier.Name = "labelDisplayMultiplier";
            this.labelDisplayMultiplier.Size = new System.Drawing.Size(32, 13);
            this.labelDisplayMultiplier.TabIndex = 17;
            this.labelDisplayMultiplier.Text = "* 100";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 390);
            this.Controls.Add(this.labelDisplayMultiplier);
            this.Controls.Add(this.multiplierSelector);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.displaySpeed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.flowSpeed);
            this.Controls.Add(this.checkDisplayAmount);
            this.Controls.Add(this.buttonEmit);
            this.Controls.Add(this.labelCell);
            this.Controls.Add(this.randomSelector);
            this.Controls.Add(this.mapSelector);
            this.Controls.Add(this.blankSelector);
            this.Controls.Add(this.oneStepAction);
            this.Controls.Add(this.restartAction);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pauseAction);
            this.Name = "Form1";
            this.Text = "Cosa Amorfa";
            ((System.ComponentModel.ISupportInitialize)(this.flowSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiplierSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button pauseAction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button restartAction;
        private System.Windows.Forms.Button oneStepAction;
        private System.Windows.Forms.RadioButton blankSelector;
        private System.Windows.Forms.RadioButton mapSelector;
        private System.Windows.Forms.RadioButton randomSelector;
        private System.Windows.Forms.Label labelCell;
        private System.Windows.Forms.Button buttonEmit;
        private System.Windows.Forms.CheckBox checkDisplayAmount;
        private System.Windows.Forms.TrackBar flowSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label displaySpeed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown multiplierSelector;
        private System.Windows.Forms.Label labelDisplayMultiplier;

    }
}

