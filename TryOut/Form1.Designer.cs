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
            this.checkAmountDisplay = new System.Windows.Forms.CheckBox();
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
            // checkAmountDisplay
            // 
            this.checkAmountDisplay.AutoSize = true;
            this.checkAmountDisplay.Location = new System.Drawing.Point(347, 52);
            this.checkAmountDisplay.Name = "checkAmountDisplay";
            this.checkAmountDisplay.Size = new System.Drawing.Size(124, 17);
            this.checkAmountDisplay.TabIndex = 10;
            this.checkAmountDisplay.Text = "Display Cells Amount";
            this.checkAmountDisplay.UseVisualStyleBackColor = true;
            this.checkAmountDisplay.CheckedChanged += new System.EventHandler(this.checkAmountDisplay_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 390);
            this.Controls.Add(this.checkAmountDisplay);
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
        private System.Windows.Forms.CheckBox checkAmountDisplay;

    }
}

