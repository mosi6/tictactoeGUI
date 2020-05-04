using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace tictactoe
{
    public partial class Form1 : Form
    {
        private static string pressed = "";
        private static bool jp = false;
        private static bool sp = true;
        public Form1()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
        }
        private void InitializeBackgroundWorker()
        {
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.ProgressChanged +=new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
        }
        private void startAsyncButton_Click(object sender,
            EventArgs e)
        {
            

            // Disable the Start button until 
            // the asynchronous operation is done.
            b_start.Enabled = false;
            button00.Text = "";
            button01.Text = "";
            button02.Text = "";
            button10.Text = "";
            button11.Text = "";
            button12.Text = "";
            button20.Text = "";
            button21.Text = "";
            button22.Text = "";
            button00.Enabled = true;
            button01.Enabled = true;
            button02.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button20.Enabled = true;
            button21.Enabled = true;
            button22.Enabled = true;
            sp = false;
            labelR.Text = "";
            // Enable the Cancel button while 
            // the asynchronous operation runs.
            string[] str = new string[] { "u", "c" };
            // Start the asynchronous operation.
            backgroundWorker1.RunWorkerAsync(str);
        }
        private void backgroundWorker1_DoWork(object sender,
            DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            // Assign the result of the computation
            // to the Result property of the DoWorkEventArgs
            // object. This is will be available to the 
            // RunWorkerCompleted eventhandler.
            e.Result=ttt((string[])e.Argument,worker,e);
        }
        private void backgroundWorker1_RunWorkerCompleted(
            object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                // Finally, handle the case where the operation 
                // succeeded.
                labelR.Text = e.Result.ToString();
                sp = true;
                button00.Enabled = false;
                button01.Enabled = false;
                button02.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button20.Enabled = false;
                button21.Enabled = false;
                button22.Enabled = false;
            }


            // Enable the Start button.
            b_start.Enabled = true;
          
        }
        private void backgroundWorker1_ProgressChanged(object sender,
            ProgressChangedEventArgs e)
        {
            button00.Text = "yo";
        }
        private void button00_Click(object sender, EventArgs e)
        {
            if (!sp)
            {
                pressed = "00";
                jp = true;
            }
        }
        private void button01_Click(object sender, EventArgs e)
        {
            if (!sp)
            {
                pressed = "01";
                jp = true;
            }
        }
        private void button02_Click(object sender, EventArgs e)
        {
            if (!sp)
            {
                pressed = "02";
                jp = true;
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (!sp)
            {
                pressed = "10";
                jp = true;
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (!sp)
            {
                pressed = "11";
                jp = true;
            }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            if (!sp)
            {
                pressed = "12";
                jp = true;
            }
        }
        private void button20_Click(object sender, EventArgs e)
        {
            if (!sp)
            {
                pressed = "20";
                jp = true;
            }
        }
        private void button21_Click(object sender, EventArgs e)
        {
            if (!sp)
            {
                pressed = "21";
                jp = true;
            }
        }
        private void button22_Click(object sender, EventArgs e)
        {
            if (!sp)
            {
                pressed = "22";
                jp = true;
            }
        }
        string get_pressed()
        {

             if (jp)
             {
                    jp = false;
                    return pressed;
             }
            return "null";
        }
        private void About(object sender, EventArgs e)
        {
            MessageBox.Show("# Tic-Tac-Toe Documentation\n\nThis program is a tic-tac-toe game. It includes an minimax-based artificial intelligence.\n\nWhen it's your turn, make your move by clicking the cell you want to mark.The computer plays automatically.\n\nTo win the game you need to have fully marked a row, column, or diagonal.\n\n\n## License\n\nCopyright (C) 2020  Daniel Kaufman\nGUI version and Logo by Miguel Oppenheim\nThis project is licensed under the GNU General Public License version 3. The license can be found at http://www.gnu.org/licenses/gpl-3.0.html.");
        }



        void prntbrd(int i,int j,string x)
        {
            if (InvokeRequired)
            {
                // Dispatch to correct thread, use BeginInvoke if you don't need
                // caller thread until operation completes
                Invoke(new MethodInvoker(() => prntbrd(i,j,x)));
            }
            else
            {
                if (i == 0)
                {
                    if (j == 0)
                    {
                        button00.Text = x;
                        
                    }
                    if (j == 1)
                    {
                        button01.Text = x;
                        
                    }
                    if (j == 2)
                    {
                        button02.Text = x;
                        
                    }
                }
                if (i == 1)
                {
                    if (j == 0)
                    {
                        button10.Text = x;
                        
                    }
                    if (j == 1)
                    {
                        button11.Text = x;
                        
                    }
                    if (j == 2)
                    {
                        button12.Text = x;
                        
                    }
                }
                if (i == 2)
                {
                    if (j == 0)
                    {
                        button20.Text = x;
                        
                    }
                    if (j == 1)
                    {
                        button21.Text = x;
                        
                    }
                    if (j == 2)
                    {
                        button22.Text = x;
                        
                    }
                }
            }
        }



    
        char player0 = 'x';
        char player1 = 'o';
        char blank = ' ';
        char outcomePos = '+';
        char outcomeNeg = '-';
        char outcomeZero = '*';
        char rowBound = '-';
        char colBound = '|';
        char corner = '+';
        string[][,] cellNames = new string[][,] { new string[,] { { "00" } }, new string[,] { { "00", "01" }, { "10", "11" } }, new string[,] { { "00", "01", "02" }, { "10", "11", "12" }, { "20", "21", "22" } }, new string[,] { { "00", "01", "02", "03" }, { "10", "11", "12", "13" }, { "20", "21", "22", "23" }, { "30", "31", "32", "33" } } };
        int WinScore(int winner)
        {
            int score = 0;
            switch (winner)
            {
                case -1:
                    score = -1;
                    break;
                case 1:
                    score = 1;
                    break;
            }
            return score;
        }
        int Evaluate(int[,] board)
        {
            for (int iOrient = 0; iOrient < 2; iOrient++)
            {
                int winner;
                for (int iStrip = 0; iStrip < board.GetLength(iOrient); iStrip++)
                {
                    int[] ijCell = new int[2];
                    ijCell[iOrient] = iStrip;
                    ijCell[(1 + iOrient) % 2] = 0;
                    winner = board[ijCell[0], ijCell[1]];
                    for (ijCell[(1 + iOrient) % 2] = 1; ijCell[(1 + iOrient) % 2] < board.GetLength((1 + iOrient) % 2) && board[ijCell[0], ijCell[1]] == winner; ijCell[(1 + iOrient) % 2]++) ;
                    if (ijCell[(1 + iOrient) % 2] == board.GetLength((1 + iOrient) % 2))
                    {
                        return WinScore(winner);
                    }
                }
                winner = board[0, (board.GetLength(0) - 1) * iOrient];
                int iPlace;
                for (iPlace = 0; iPlace < board.GetLength(0) && board[iPlace, (board.GetLength(0) - 1) * iOrient + iPlace * (int)Math.Pow(-1, iOrient)] == winner; iPlace++) ;
                if (iPlace == board.GetLength(0))
                {
                    return WinScore(winner);
                }
            }
            return 0;
        }
        int[] MiniMax(int[,] board, int player, int turn)
        {
            int result = Evaluate(board);
            if (result != 0 || turn == board.GetLength(0) * board.GetLength(1))
            {
                return new int[3] { -1, -1, result };
            }
            int iExtremum = 0, jExtremum = 0;
            int optiSign = WinScore(player) > 0 ? 1 : -1;
            int extremum = Int32.MinValue * optiSign;
            for (int iCell = 0; iCell < board.GetLength(0); iCell++)
            {
                for (int jCell = 0; jCell < board.GetLength(1); jCell++)
                {
                    if (board[iCell, jCell] != 0)
                    {
                        continue;
                    }
                    board[iCell, jCell] = player;
                    int outcome = MiniMax(board, -player, turn + 1)[2];
                    board[iCell, jCell] = 0;
                    if (outcome * optiSign > extremum * optiSign)
                    {
                        iExtremum = iCell;
                        jExtremum = jCell;
                        extremum = outcome;
                    }
                }
            }
            return new int[3] { iExtremum, jExtremum, extremum };
        }
        int[] MiniMaxVis(int[,] board, int player, int turn)
        {
            int iExtremum = 0, jExtremum = 0;
            int optiSign = WinScore(player) > 0 ? 1 : -1;
            int extremum = Int32.MinValue * optiSign;
            int[] ret = new int[2 + board.GetLength(0) * board.GetLength(1)];
            for (int iCell = 0; iCell < board.GetLength(0); iCell++)
            {
                for (int jCell = 0; jCell < board.GetLength(1); jCell++)
                {
                    if (board[iCell, jCell] != 0)
                    {
                        continue;
                    }
                    board[iCell, jCell] = player;
                    int outcome = MiniMax(board, -player, turn + 1)[2];
                    ret[iCell * board.GetLength(1) + jCell + 2] = outcome;
                    board[iCell, jCell] = 0;
                    if (outcome * optiSign > extremum * optiSign)
                    {
                        iExtremum = iCell;
                        jExtremum = jCell;
                        extremum = outcome;
                    }
                }
            }
            ret[0] = iExtremum;
            ret[1] = jExtremum;
            return ret;
        }

         void Print(int[,] board, BackgroundWorker worker, DoWorkEventArgs e)
        {
            
            for (int iCell = 0; iCell < board.GetLength(0); iCell++)
            {
                for (int jCell = 0; jCell < board.GetLength(0); jCell++)
                {
                    if (board[iCell, jCell] == 1)
                    {
                        prntbrd(iCell, jCell, "X");
                    }
                    else if (board[iCell, jCell] == -1)
                    {
                        prntbrd(iCell, jCell, "O");
                    }
                }
            }
        }
        int[] GetCell(int[,] board)
        {
            string[,] names = cellNames[board.GetLength(0) - 1];
            while (true)
            {
                string name = get_pressed();
                if (name != "null") {
                    for (int iCell = 0; iCell < board.GetLength(0); iCell++)
                    {
                        for (int jCell = 0; jCell < board.GetLength(1); jCell++)
                        {
                            if (board[iCell, jCell] == 0 && names[iCell, jCell] == name)
                            {
                                return new int[2] { iCell, jCell };
                            }
                        }
                    }
                }
            }
        }
        public string ttt(string[] args, BackgroundWorker worker, DoWorkEventArgs e)
        {
            
            bool[] isPlayerUser = new bool[2];
            for (int iPlayerType = 0; iPlayerType < 2; iPlayerType++)
            {
                if (args[iPlayerType] == "u")
                {
                    isPlayerUser[iPlayerType] = true;
                }
                else if (args[iPlayerType] == "c")
                {
                    isPlayerUser[iPlayerType] = false;
                }
            }
            int[] scoresViews = new int[2];
            int boardSize = 3;
            int[,] board = new int[boardSize, boardSize];
            int boardArea = boardSize * boardSize;
            int player = 1;
            int winner = 0;

            for (int turn = 0; turn < boardArea && winner == 0; turn++, player *= -1, winner = Evaluate(board))
            {

                int iPlayer = player == 1 ? 0 : 1;
                int[] nextMove = null;
                if (scoresViews[iPlayer] == 2)
                {
                    nextMove = MiniMaxVis(board, player, turn);

                }
                int[] ijCell = null;
                if (isPlayerUser[iPlayer])
                {
                    ijCell = GetCell(board);
                }
                else
                {

                }
                if (scoresViews[iPlayer] == 1)
                {
                    nextMove = MiniMaxVis(board, player, turn);


                }
                if (!isPlayerUser[iPlayer])
                {
                    if (scoresViews[iPlayer] == 0)
                    {
                        nextMove = MiniMax(board, player, turn);
                    }
                    ijCell = new int[2] { nextMove[0], nextMove[1] };
                }
                board[ijCell[0], ijCell[1]] = player;
                Print(board,worker,e);
            }
                return winner != 0 ? (winner == 1 ? player0 : player1) + " Wins" : "Draw";
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

