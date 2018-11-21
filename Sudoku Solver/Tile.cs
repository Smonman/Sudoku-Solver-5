using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver {
	class Tile {
		public int number = 0;
		public int x;
		public int y;

		public Tile(int n, int x, int y) {
			number = n;
			this.x = x;
			this.y = y;
		}
	}
}
