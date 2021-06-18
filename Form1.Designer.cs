namespace Mining_App_Core
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.exeTextBox = new System.Windows.Forms.TextBox();
			this.optionsTextBox = new System.Windows.Forms.TextBox();
			this.runButton = new System.Windows.Forms.Button();
			this.saveButton = new System.Windows.Forms.Button();
			this.openTrackBar = new System.Windows.Forms.TrackBar();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.openValueDisplay = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.openAMPM = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.closeValueDisplay = new System.Windows.Forms.Label();
			this.closeAMPM = new System.Windows.Forms.Label();
			this.closeTrackBar = new System.Windows.Forms.TrackBar();
			this.SaveCommand = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.openTrackBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.closeTrackBar)).BeginInit();
			this.SuspendLayout();
			// 
			// exeTextBox
			// 
			this.exeTextBox.Location = new System.Drawing.Point(45, 98);
			this.exeTextBox.Multiline = true;
			this.exeTextBox.Name = "exeTextBox";
			this.exeTextBox.Size = new System.Drawing.Size(525, 103);
			this.exeTextBox.TabIndex = 0;
			// 
			// optionsTextBox
			// 
			this.optionsTextBox.Location = new System.Drawing.Point(827, 98);
			this.optionsTextBox.Multiline = true;
			this.optionsTextBox.Name = "optionsTextBox";
			this.optionsTextBox.Size = new System.Drawing.Size(529, 145);
			this.optionsTextBox.TabIndex = 1;
			// 
			// runButton
			// 
			this.runButton.Location = new System.Drawing.Point(636, 480);
			this.runButton.Name = "runButton";
			this.runButton.Size = new System.Drawing.Size(112, 64);
			this.runButton.TabIndex = 2;
			this.runButton.Text = "Run";
			this.runButton.UseVisualStyleBackColor = true;
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(636, 339);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(112, 95);
			this.saveButton.TabIndex = 3;
			this.saveButton.Text = "Save Times";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// openTrackBar
			// 
			this.openTrackBar.LargeChange = 1;
			this.openTrackBar.Location = new System.Drawing.Point(62, 480);
			this.openTrackBar.Maximum = 24;
			this.openTrackBar.Name = "openTrackBar";
			this.openTrackBar.Size = new System.Drawing.Size(508, 69);
			this.openTrackBar.TabIndex = 4;
			this.openTrackBar.Scroll += new System.EventHandler(this.openTrackBar_Scroll);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(216, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(213, 37);
			this.label1.TabIndex = 5;
			this.label1.Text = "Mining .exe Path";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(983, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(199, 37);
			this.label2.TabIndex = 6;
			this.label2.Text = ".exe Arguments";
			// 
			// openValueDisplay
			// 
			this.openValueDisplay.AutoSize = true;
			this.openValueDisplay.Location = new System.Drawing.Point(243, 397);
			this.openValueDisplay.Name = "openValueDisplay";
			this.openValueDisplay.Size = new System.Drawing.Size(32, 37);
			this.openValueDisplay.TabIndex = 7;
			this.openValueDisplay.Text = "0";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(243, 329);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(147, 37);
			this.label4.TabIndex = 8;
			this.label4.Text = "Open Time";
			// 
			// openAMPM
			// 
			this.openAMPM.AutoSize = true;
			this.openAMPM.Location = new System.Drawing.Point(333, 397);
			this.openAMPM.Name = "openAMPM";
			this.openAMPM.Size = new System.Drawing.Size(70, 37);
			this.openAMPM.TabIndex = 9;
			this.openAMPM.Text = "A.M.";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(1019, 339);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(147, 37);
			this.label3.TabIndex = 11;
			this.label3.Text = "Close Time";
			// 
			// closeValueDisplay
			// 
			this.closeValueDisplay.AutoSize = true;
			this.closeValueDisplay.Location = new System.Drawing.Point(1019, 397);
			this.closeValueDisplay.Name = "closeValueDisplay";
			this.closeValueDisplay.Size = new System.Drawing.Size(32, 37);
			this.closeValueDisplay.TabIndex = 12;
			this.closeValueDisplay.Text = "0";
			// 
			// closeAMPM
			// 
			this.closeAMPM.AutoSize = true;
			this.closeAMPM.Location = new System.Drawing.Point(1114, 397);
			this.closeAMPM.Name = "closeAMPM";
			this.closeAMPM.Size = new System.Drawing.Size(68, 37);
			this.closeAMPM.TabIndex = 13;
			this.closeAMPM.Text = "P.M.";
			// 
			// closeTrackBar
			// 
			this.closeTrackBar.LargeChange = 1;
			this.closeTrackBar.Location = new System.Drawing.Point(813, 475);
			this.closeTrackBar.Maximum = 24;
			this.closeTrackBar.Name = "closeTrackBar";
			this.closeTrackBar.Size = new System.Drawing.Size(543, 69);
			this.closeTrackBar.TabIndex = 14;
			this.closeTrackBar.Scroll += new System.EventHandler(this.closeTrackBar_Scroll);
			// 
			// SaveCommand
			// 
			this.SaveCommand.Location = new System.Drawing.Point(619, 98);
			this.SaveCommand.Name = "SaveCommand";
			this.SaveCommand.Size = new System.Drawing.Size(159, 103);
			this.SaveCommand.TabIndex = 15;
			this.SaveCommand.Text = "Save Command";
			this.SaveCommand.UseVisualStyleBackColor = true;
			this.SaveCommand.Click += new System.EventHandler(this.SaveCommand_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1417, 832);
			this.Controls.Add(this.SaveCommand);
			this.Controls.Add(this.closeTrackBar);
			this.Controls.Add(this.closeAMPM);
			this.Controls.Add(this.closeValueDisplay);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.openAMPM);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.openValueDisplay);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.openTrackBar);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.runButton);
			this.Controls.Add(this.optionsTextBox);
			this.Controls.Add(this.exeTextBox);
			this.Name = "Form1";
			this.Text = "Mining Automation";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.openTrackBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.closeTrackBar)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox exeTextBox;
		private System.Windows.Forms.TextBox optionsTextBox;
		private System.Windows.Forms.Button runButton;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.TrackBar openTrackBar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label openValueDisplay;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label openAMPM;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label closeValueDisplay;
		private System.Windows.Forms.Label closeAMPM;
		private System.Windows.Forms.TrackBar closeTrackBar;
		private System.Windows.Forms.Button SaveCommand;
	}
}

