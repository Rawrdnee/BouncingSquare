using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BouncingSquare
{
    public partial class BouncingBall : Form
    {
        Paddle paddle = null;
        Random rnd = new Random();

        List<Square> squares = new List<Square>();

        public BouncingBall()
        {
            InitializeComponent();
            this.KeyDown += BouncingBall_KeyDown;
            this.Load += BouncingBall_Load1;
            this.MouseMove += BouncingBall_MouseMove;
            Cursor.Hide();
            
        }

        private void BouncingBall_MouseMove(object sender, MouseEventArgs e)
        {
            paddle.Location = e.Location.X;
        }

        private void BouncingBall_Load1(object sender, EventArgs e)
        {
            paddle = new Paddle(this, rnd);

        }

        private void BouncingBall_Load(object sender, EventArgs e)
        {

        }
        private void BouncingBall_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Application.Exit();
            }
            else if (e.KeyData == Keys.N)
                
            {
                if (squares.Count < 6)
                {
                    Square square = new Square(this, rnd, paddle);
                    squares.Add(square);
                    square.score += Square_score;
                }
            }
            else if (e.KeyData == Keys.Left || e.KeyData == Keys.Right)
            {
                paddle.Key = e.KeyData; 
            }
        }

        private void Square_score(object sender, ScoreEventArgs e)
        {
            int score = Convert.ToInt32(lblScore.Text);
            score += e.Points;
            lblScore.Text = score.ToString();

            if (e.Points <= 0)
            {
                Square sq = (Square)sender;
                Guid id = sq.Id;

                for (int i = 0; i < squares.Count; i++)
                {
                    if (squares[i].Id == id)
                    {
                        squares.RemoveAt(i);
                        break;
                    }
                }
            
            }
        }
    }
}

