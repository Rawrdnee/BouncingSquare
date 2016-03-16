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
            paddle.Location = e.Location;
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
                Square square = new Square(this, rnd, paddle);
                
            }
            else if (e.KeyData == Keys.Left || e.KeyData == Keys.Right)
            {
                paddle.Key = e.KeyData; 
            }
        }
             
   }
}

