namespace Editor
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
			this.label1 = new System.Windows.Forms.Label();
			this.ddlGames = new System.Windows.Forms.ComboBox();
			this.btnChooseGame = new System.Windows.Forms.Button();
			this.ddlCommand = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lstActions = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Game";
			// 
			// ddlGames
			// 
			this.ddlGames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlGames.FormattingEnabled = true;
			this.ddlGames.Location = new System.Drawing.Point(55, 13);
			this.ddlGames.Name = "ddlGames";
			this.ddlGames.Size = new System.Drawing.Size(223, 21);
			this.ddlGames.TabIndex = 1;
			// 
			// btnChooseGame
			// 
			this.btnChooseGame.Location = new System.Drawing.Point(284, 13);
			this.btnChooseGame.Name = "btnChooseGame";
			this.btnChooseGame.Size = new System.Drawing.Size(75, 23);
			this.btnChooseGame.TabIndex = 2;
			this.btnChooseGame.Text = "Choose";
			this.btnChooseGame.UseVisualStyleBackColor = true;
			this.btnChooseGame.Click += new System.EventHandler(this.btnChooseGame_Click);
			// 
			// ddlCommand
			// 
			this.ddlCommand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlCommand.FormattingEnabled = true;
			this.ddlCommand.Location = new System.Drawing.Point(79, 69);
			this.ddlCommand.Name = "ddlCommand";
			this.ddlCommand.Size = new System.Drawing.Size(199, 21);
			this.ddlCommand.TabIndex = 3;
			this.ddlCommand.SelectedIndexChanged += new System.EventHandler(this.ddlCommand_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 69);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Commands";
			// 
			// lstActions
			// 
			this.lstActions.FormattingEnabled = true;
			this.lstActions.Location = new System.Drawing.Point(295, 89);
			this.lstActions.Name = "lstActions";
			this.lstActions.Size = new System.Drawing.Size(154, 186);
			this.lstActions.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(292, 69);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Actions";
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(329, 183);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(8, 4);
			this.listBox1.TabIndex = 5;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(729, 434);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.lstActions);
			this.Controls.Add(this.ddlCommand);
			this.Controls.Add(this.btnChooseGame);
			this.Controls.Add(this.ddlGames);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox ddlGames;
		private System.Windows.Forms.Button btnChooseGame;
		private System.Windows.Forms.ComboBox ddlCommand;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox lstActions;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox listBox1;
	}
}

