namespace Sudoku_Solver {
	partial class Main {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.tableLayoutPanel_background = new System.Windows.Forms.TableLayoutPanel();
			this.panel_gridBackround = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button_solve = new System.Windows.Forms.Button();
			this.button_stop = new System.Windows.Forms.Button();
			this.backgroundWorker_sudokuSolver = new System.ComponentModel.BackgroundWorker();
			this.button_clear = new System.Windows.Forms.Button();
			this.tableLayoutPanel_background.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel_background
			// 
			this.tableLayoutPanel_background.ColumnCount = 1;
			this.tableLayoutPanel_background.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel_background.Controls.Add(this.panel_gridBackround, 0, 0);
			this.tableLayoutPanel_background.Controls.Add(this.panel1, 0, 1);
			this.tableLayoutPanel_background.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel_background.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel_background.Name = "tableLayoutPanel_background";
			this.tableLayoutPanel_background.RowCount = 2;
			this.tableLayoutPanel_background.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel_background.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			this.tableLayoutPanel_background.Size = new System.Drawing.Size(542, 634);
			this.tableLayoutPanel_background.TabIndex = 0;
			// 
			// panel_gridBackround
			// 
			this.panel_gridBackround.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_gridBackround.Location = new System.Drawing.Point(3, 3);
			this.panel_gridBackround.Name = "panel_gridBackround";
			this.panel_gridBackround.Size = new System.Drawing.Size(536, 508);
			this.panel_gridBackround.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button_clear);
			this.panel1.Controls.Add(this.button_stop);
			this.panel1.Controls.Add(this.button_solve);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 517);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(536, 114);
			this.panel1.TabIndex = 1;
			// 
			// button_solve
			// 
			this.button_solve.Location = new System.Drawing.Point(9, 3);
			this.button_solve.Name = "button_solve";
			this.button_solve.Size = new System.Drawing.Size(75, 23);
			this.button_solve.TabIndex = 0;
			this.button_solve.Text = "Solve";
			this.button_solve.UseVisualStyleBackColor = true;
			this.button_solve.Click += new System.EventHandler(this.button_solve_Click);
			// 
			// button_stop
			// 
			this.button_stop.Location = new System.Drawing.Point(90, 3);
			this.button_stop.Name = "button_stop";
			this.button_stop.Size = new System.Drawing.Size(75, 23);
			this.button_stop.TabIndex = 1;
			this.button_stop.Text = "Stop";
			this.button_stop.UseVisualStyleBackColor = true;
			this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
			// 
			// backgroundWorker_sudokuSolver
			// 
			this.backgroundWorker_sudokuSolver.WorkerSupportsCancellation = true;
			this.backgroundWorker_sudokuSolver.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_sudokuSolver_DoWork);
			this.backgroundWorker_sudokuSolver.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_sudokuSolver_RunWorkerCompleted);
			// 
			// button_clear
			// 
			this.button_clear.Location = new System.Drawing.Point(171, 3);
			this.button_clear.Name = "button_clear";
			this.button_clear.Size = new System.Drawing.Size(75, 23);
			this.button_clear.TabIndex = 2;
			this.button_clear.Text = "Clear";
			this.button_clear.UseVisualStyleBackColor = true;
			this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(542, 634);
			this.Controls.Add(this.tableLayoutPanel_background);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Main";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Main";
			this.Load += new System.EventHandler(this.Main_Load);
			this.tableLayoutPanel_background.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_background;
		private System.Windows.Forms.Panel panel_gridBackround;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button_solve;
		private System.Windows.Forms.Button button_stop;
		private System.ComponentModel.BackgroundWorker backgroundWorker_sudokuSolver;
		private System.Windows.Forms.Button button_clear;
	}
}