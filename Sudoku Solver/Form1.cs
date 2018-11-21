using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace Sudoku_Solver {
	public partial class Form_Splash : Form {
		public Form_Splash() {
			InitializeComponent();
		}

		BackgroundWorker bw = new BackgroundWorker();
		Main main = new Main();

		private void Form_Splash_Load(object sender, EventArgs e) {
			bw.DoWork += new DoWorkEventHandler(SplashTime);
			bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(SplashOver);
			bw.RunWorkerAsync();
		}

		private void SplashTime(object sender, DoWorkEventArgs e) {
			Thread.Sleep(500);
			main.InstantateUserInputFields();
		}

		private void SplashOver(object sender, RunWorkerCompletedEventArgs e) {
			this.Hide();
			main.Closed += (s, args) => this.Close(); //close this form when the main form is closed
			main.Show();
			bw.Dispose();
		}
	}
}
