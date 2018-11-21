using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku_Solver {
	public partial class Main : Form {
		public Main() {
			InitializeComponent();
		}

		const int userInputFieldsSpace = 3;
		const int userInputFieldWidth = 40;
		const int userInputFieldFontSize = 20;
		int userInputFieldsTotalWidth;
		int userInputFieldsTotalHeight;

		NumericUpDown[,] userInputFields;
		Tile[,] originalInput = new Tile[9, 9];
		Tile[,] sudoku = new Tile[9, 9];
		List<Tile> emptyTiles = new List<Tile>();


		public void InstantateUserInputFields() {
			userInputFields = new NumericUpDown[9, 9];
			for(int y = 0; y < 9; y++) {
				for(int x = 0; x < 9; x++) {
					var num = new NumericUpDown();
					userInputFields[x, y] = num;
					num.Minimum = 0;
					num.Maximum = 9;
					num.Value = 0;
					num.Increment = 1;
					num.DecimalPlaces = 0;
					num.TextAlign = HorizontalAlignment.Center;
					num.Font = new Font("Microsoft Sans Serif", userInputFieldFontSize); // it is not possible to set the height directly you need to set the font size instead
					num.Width = userInputFieldWidth;
					num.BackColor = SystemColors.Control;
					num.BorderStyle = BorderStyle.FixedSingle;

					userInputFieldsTotalWidth = num.Width * 9 + (9 * userInputFieldsSpace) + 20;
					userInputFieldsTotalHeight = num.Height * 9 + (9 * userInputFieldsSpace) + 20;

					int additionalSpaceX = 0;
					if(x > 2 && x <= 5) {
						additionalSpaceX = 9;
					} else if(x > 5) {
						additionalSpaceX = 19;
					}

					int additionalSpaceY = 0;
					if(y > 2 && y <= 5) {
						additionalSpaceY = 9;
					} else if(y > 5) {
						additionalSpaceY = 19;
					}

					num.Location = new Point((x * (num.Width + userInputFieldsSpace)) + additionalSpaceX + (panel_gridBackround.Width - userInputFieldsTotalWidth) / 2, (y * (num.Height + userInputFieldsSpace)) + additionalSpaceY + (panel_gridBackround.Height - userInputFieldsTotalHeight) / 2);
					panel_gridBackround.Controls.Add(num);
				}
			}
		}

		void ReadInput() {
			emptyTiles.Clear();
			for(int y = 0; y < 9; y++) {
				for(int x = 0; x < 9; x++) {
					var t = new Tile((int)userInputFields[x, y].Value, x, y);
					sudoku[x, y] = t;
					originalInput[x, y] = new Tile((int)userInputFields[x, y].Value, x, y);
					if(t.number == 0) {
						emptyTiles.Add(t);
					}
				}
			}
		}

		void UpdateUserInputFields() {
			for(int y = 0; y < 9; y++) {
				for(int x = 0; x < 9; x++) {
					userInputFields[x, y].Invoke(new MethodInvoker(() => userInputFields[x, y].Value = sudoku[x, y].number));
					//userInputFields[x, y].Value = sudoku[x, y].number;
				}
			}
		}

		void Solve() {
			int index = 0;
			int step = 0;
			Tile cur;

			panel_gridBackround.Invoke(new MethodInvoker(() => panel_gridBackround.Enabled = false));

			while(!isFinished()) {
				step++;
				StartPosition:;
				UpdateUserInputFields();
				cur = emptyTiles[index];
				do {
					if(cur.number < 9) {
						cur.number++;
					} else {
						cur.number = 0;
						index--;
						goto StartPosition; //Ich habe keine einfache Lösung ohne GOTO auf die Schnelle gefunden.
					}
				} while(!CheckIfOkay(cur));
				index++;
				if(index > emptyTiles.Count) {
					break;
				}
			}
			UpdateUserInputFields();

			panel_gridBackround.Invoke(new MethodInvoker(() => panel_gridBackround.Enabled = true));

			Console.WriteLine("Finished");
			Console.WriteLine("Steps: " + step);
		} //not used

		bool isFinished() {
			int sum = 0;
			for(int i = 0; i < 9; i++) {
				for(int j = 0; j < 9; j++) {
					if(sudoku[i, j].number > 0) {
						sum += sudoku[i, j].number;
					} else {
						return false;
					}
				}
			}
			if(sum == 45 * 9) {
				return true;
			} else {
				return false;
			}
		}

		bool CheckIfOkay(Tile t) {
			int startX = 0;
			int endX = 0;
			int startY = 0;
			int endY = 0;


			//row
			for(int i = 0; i < 9; i++) {
				if(sudoku[i, t.y].number == t.number && sudoku[i, t.y] != t) {
					return false;
				}
			}

			//col
			for(int j = 0; j < 9; j++) {
				if(sudoku[t.x, j].number == t.number && sudoku[t.x, j] != t) {
					return false;
				}
			}

			//box
			if(t.x <= 2) {
				startX = 0;
				endX = 2;
			} else if(t.x <= 5) {
				startX = 3;
				endX = 5;
			} else {
				startX = 6;
				endX = 8;
			}

			if(t.y <= 2) {
				startY = 0;
				endY = 2;
			} else if(t.y <= 5) {
				startY = 3;
				endY = 5;
			} else {
				startY = 6;
				endY = 8;
			}

			for(int i = startX; i <= endX; i++) {
				for(int j = startY; j <= endY; j++) {
					if(sudoku[i, j].number == t.number && sudoku[t.x, j] != t) {
						return false;
					}
				}
			}

			return true;
		}

		private void button_solve_Click(object sender, EventArgs e) {
			ReadInput();
			UpdateUserInputFields();
			button_solve.Enabled = false;
			button_stop.Enabled = true;
			button_clear.Enabled = false;
			backgroundWorker_sudokuSolver.RunWorkerAsync();
		}

		private void backgroundWorker_sudokuSolver_DoWork(object sender, DoWorkEventArgs e) {
			BackgroundWorker bw = (BackgroundWorker)sender;

			Console.WriteLine(emptyTiles.Count);

			int index = 0;
			int step = 0;
			Tile cur;

			panel_gridBackround.Invoke(new MethodInvoker(() => panel_gridBackround.Enabled = false));

			while(!isFinished()) {

				if(bw.CancellationPending) {
					e.Cancel = true;
					return;
				}

				StartPosition:;
				UpdateUserInputFields();
				cur = emptyTiles[index];
				Console.WriteLine(String.Format("s: \t{0}, i:\t{1}, x:\t{2}, y:\t{3}", step, index, cur.x, cur.y));
				do {
					if(cur.number < 9) {
						cur.number++;
					} else {
						cur.number = 0;
						index--;
						goto StartPosition; //Ich habe keine einfache Lösung ohne GOTO auf die Schnelle gefunden.
					}
				} while(!CheckIfOkay(cur));
				index++;
				step++;
				if(index > emptyTiles.Count) {
					break;
				}
			}
		}

		private void button_stop_Click(object sender, EventArgs e) {
			backgroundWorker_sudokuSolver.CancelAsync();
			UpdateUserInputFields();
		}

		private void backgroundWorker_sudokuSolver_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			UpdateUserInputFields();
			panel_gridBackround.Invoke(new MethodInvoker(() => panel_gridBackround.Enabled = true));
			Console.WriteLine("Finished");
			button_solve.Enabled = true;
			button_stop.Enabled = false;
			button_clear.Enabled = true;
		}

		void Clear() {
			emptyTiles.Clear();
			for(int y = 0; y < 9; y++) {
				for(int x = 0; x < 9; x++) {
					sudoku[x, y] = originalInput[x, y];
				}
			}
			UpdateUserInputFields();
		}

		private void button_clear_Click(object sender, EventArgs e) {
			Clear();
		}

		private void Main_Load(object sender, EventArgs e) {
			button_solve.Enabled = true;
			button_stop.Enabled = false;
			button_clear.Enabled = true;
		}
	}
}
