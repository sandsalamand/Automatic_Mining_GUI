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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SaveCommand = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// exeTextBox
			// 
			this.exeTextBox.Location = new System.Drawing.Point(45, 98);
			this.exeTextBox.Multiline = true;
			this.exeTextBox.Name = "exeTextBox";
			this.exeTextBox.Size = new System.Drawing.Size(525, 202);
			this.exeTextBox.TabIndex = 0;
			// 
			// optionsTextBox
			// 
			this.optionsTextBox.Location = new System.Drawing.Point(827, 98);
			this.optionsTextBox.Multiline = true;
			this.optionsTextBox.Name = "optionsTextBox";
			this.optionsTextBox.Size = new System.Drawing.Size(529, 202);
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
			this.runButton.Click += new System.EventHandler(this.runButton_Click);
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(636, 339);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(112, 95);
			this.saveButton.TabIndex = 3;
			this.saveButton.Text = "Save Times";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveTime_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(197, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(198, 37);
			this.label1.TabIndex = 5;
			this.label1.Text = "Miner .exe Path";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(1005, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(199, 37);
			this.label2.TabIndex = 6;
			this.label2.Text = ".exe Arguments";
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
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.runButton);
			this.Controls.Add(this.optionsTextBox);
			this.Controls.Add(this.exeTextBox);
			this.Name = "Form1";
			this.Text = "Mining Automation";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox exeTextBox;
		private System.Windows.Forms.TextBox optionsTextBox;
		private System.Windows.Forms.Button runButton;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button SaveCommand;
	}
}

