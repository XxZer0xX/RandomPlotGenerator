namespace RandomPlotGenerator
{
    partial class RandomPlotGeneratorForm
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
            this.components = new System.ComponentModel.Container();
            this.StoryPartDirectorySelectionButton = new System.Windows.Forms.Button();
            this.OutputButton = new System.Windows.Forms.Button();
            this.SaveDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.DataSetDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.StoryCountInput = new System.Windows.Forms.TextBox();
            this.UncommonCheckBox = new System.Windows.Forms.CheckBox();
            this.TwistCheckBox = new System.Windows.Forms.CheckBox();
            this.SimpleCheckBox = new System.Windows.Forms.CheckBox();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.DirectorySelectorDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.CancelCloseButton = new System.Windows.Forms.Button();
            this.StartPauseButton = new System.Windows.Forms.Button();
            this.StoryPartToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.OutputDirectoryToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // StoryPartDirectorySelectionButton
            // 
            this.StoryPartDirectorySelectionButton.Location = new System.Drawing.Point(668, 19);
            this.StoryPartDirectorySelectionButton.Name = "StoryPartDirectorySelectionButton";
            this.StoryPartDirectorySelectionButton.Size = new System.Drawing.Size(120, 32);
            this.StoryPartDirectorySelectionButton.TabIndex = 0;
            this.StoryPartDirectorySelectionButton.Text = "Browse";
            this.StoryPartToolTip.SetToolTip(this.StoryPartDirectorySelectionButton, "Data Location");
            this.StoryPartDirectorySelectionButton.UseVisualStyleBackColor = true;
            this.StoryPartDirectorySelectionButton.Click += new System.EventHandler(this.StoryPartDirectorySelectionButton_Click);
            // 
            // OutputButton
            // 
            this.OutputButton.Location = new System.Drawing.Point(668, 64);
            this.OutputButton.Name = "OutputButton";
            this.OutputButton.Size = new System.Drawing.Size(120, 32);
            this.OutputButton.TabIndex = 1;
            this.OutputButton.Text = "Browse";
            this.OutputDirectoryToolTip.SetToolTip(this.OutputButton, "Output File Location");
            this.OutputButton.UseVisualStyleBackColor = true;
            this.OutputButton.Click += new System.EventHandler(this.Output_btn_Click);
            // 
            // SaveDirectoryTextBox
            // 
            this.SaveDirectoryTextBox.Location = new System.Drawing.Point(12, 64);
            this.SaveDirectoryTextBox.Name = "SaveDirectoryTextBox";
            this.SaveDirectoryTextBox.Size = new System.Drawing.Size(637, 26);
            this.SaveDirectoryTextBox.TabIndex = 99;
            this.SaveDirectoryTextBox.TabStop = false;
            this.SaveDirectoryTextBox.TextChanged += new System.EventHandler(this.SaveDirectoryTextBox_TextChanged);
            // 
            // DataSetDirectoryTextBox
            // 
            this.DataSetDirectoryTextBox.Location = new System.Drawing.Point(12, 19);
            this.DataSetDirectoryTextBox.Name = "DataSetDirectoryTextBox";
            this.DataSetDirectoryTextBox.Size = new System.Drawing.Size(637, 26);
            this.DataSetDirectoryTextBox.TabIndex = 99;
            this.DataSetDirectoryTextBox.TabStop = false;
            this.DataSetDirectoryTextBox.TextChanged += new System.EventHandler(this.StoryPartsDirectoryTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(12, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 22);
            this.label1.TabIndex = 99;
            this.label1.Text = "Number of Generated Stories: ";
            // 
            // StoryCountInput
            // 
            this.StoryCountInput.Location = new System.Drawing.Point(246, 121);
            this.StoryCountInput.Name = "StoryCountInput";
            this.StoryCountInput.Size = new System.Drawing.Size(71, 26);
            this.StoryCountInput.TabIndex = 2;
            this.StoryCountInput.Text = "0";
            this.StoryCountInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StoryCountInput.TextChanged += new System.EventHandler(this.StoryCountInput_TextChanged);
            // 
            // UncommonCheckBox
            // 
            this.UncommonCheckBox.AutoSize = true;
            this.UncommonCheckBox.Location = new System.Drawing.Point(484, 122);
            this.UncommonCheckBox.Name = "UncommonCheckBox";
            this.UncommonCheckBox.Size = new System.Drawing.Size(117, 24);
            this.UncommonCheckBox.TabIndex = 3;
            this.UncommonCheckBox.Text = "Uncommon";
            this.UncommonCheckBox.UseVisualStyleBackColor = true;
            this.UncommonCheckBox.Click += new System.EventHandler(this.UncommonCheckBox_Click);
            // 
            // TwistCheckBox
            // 
            this.TwistCheckBox.AutoSize = true;
            this.TwistCheckBox.Location = new System.Drawing.Point(618, 122);
            this.TwistCheckBox.Name = "TwistCheckBox";
            this.TwistCheckBox.Size = new System.Drawing.Size(71, 24);
            this.TwistCheckBox.TabIndex = 4;
            this.TwistCheckBox.Text = "Twist";
            this.TwistCheckBox.UseVisualStyleBackColor = true;
            this.TwistCheckBox.Click += new System.EventHandler(this.TwistCheckBox_Click);
            // 
            // SimpleCheckBox
            // 
            this.SimpleCheckBox.AutoSize = true;
            this.SimpleCheckBox.Checked = true;
            this.SimpleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SimpleCheckBox.Location = new System.Drawing.Point(705, 122);
            this.SimpleCheckBox.Name = "SimpleCheckBox";
            this.SimpleCheckBox.Size = new System.Drawing.Size(83, 24);
            this.SimpleCheckBox.TabIndex = 5;
            this.SimpleCheckBox.Text = "Simple";
            this.SimpleCheckBox.UseVisualStyleBackColor = true;
            this.SimpleCheckBox.Click += new System.EventHandler(this.SimpleCheckBox_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(12, 163);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(451, 38);
            this.ProgressBar.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(373, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 22);
            this.label2.TabIndex = 100;
            this.label2.Text = "Story Type:";
            // 
            // CancelCloseButton
            // 
            this.CancelCloseButton.Location = new System.Drawing.Point(668, 163);
            this.CancelCloseButton.Name = "CancelCloseButton";
            this.CancelCloseButton.Size = new System.Drawing.Size(120, 38);
            this.CancelCloseButton.TabIndex = 101;
            this.CancelCloseButton.Text = "Cancel";
            this.CancelCloseButton.UseVisualStyleBackColor = true;
            this.CancelCloseButton.Click += new System.EventHandler(this.CancelCloseButton_Click);
            // 
            // StartPauseButton
            // 
            this.StartPauseButton.Location = new System.Drawing.Point(518, 163);
            this.StartPauseButton.Name = "StartPauseButton";
            this.StartPauseButton.Size = new System.Drawing.Size(120, 38);
            this.StartPauseButton.TabIndex = 102;
            this.StartPauseButton.Text = "Start";
            this.StartPauseButton.UseVisualStyleBackColor = true;
            this.StartPauseButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // RandomPlotGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 211);
            this.Controls.Add(this.StartPauseButton);
            this.Controls.Add(this.CancelCloseButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.SimpleCheckBox);
            this.Controls.Add(this.TwistCheckBox);
            this.Controls.Add(this.UncommonCheckBox);
            this.Controls.Add(this.StoryCountInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataSetDirectoryTextBox);
            this.Controls.Add(this.SaveDirectoryTextBox);
            this.Controls.Add(this.OutputButton);
            this.Controls.Add(this.StoryPartDirectorySelectionButton);
            this.Name = "RandomPlotGeneratorForm";
            this.Text = "Random Plot Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StoryPartDirectorySelectionButton;
        private System.Windows.Forms.Button OutputButton;
        private System.Windows.Forms.TextBox SaveDirectoryTextBox;
        private System.Windows.Forms.TextBox DataSetDirectoryTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox StoryCountInput;
        private System.Windows.Forms.CheckBox UncommonCheckBox;
        private System.Windows.Forms.CheckBox TwistCheckBox;
        private System.Windows.Forms.CheckBox SimpleCheckBox;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.FolderBrowserDialog DirectorySelectorDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CancelCloseButton;
        private System.Windows.Forms.Button StartPauseButton;
        private System.Windows.Forms.ToolTip StoryPartToolTip;
        private System.Windows.Forms.ToolTip OutputDirectoryToolTip;
    }
}

