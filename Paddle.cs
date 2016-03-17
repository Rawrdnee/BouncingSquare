using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BouncingSquare
{
    public class Paddle
    {

        #region Private Members
        private Form _form = null;
        private PictureBox _box = null;
        private Random _rnd = null;
        #endregion
        #region Public Properties
        //Creates property of object to determine it's movement
        public Keys Key
        {
            //Sets new position of object, based on user input
            set
            {

                if (value == Keys.Left)
                {
                    Point location = _box.Location;
                    location.X -= 50;
                    if (location.X >= 0)
                    {
                        _box.Location = location;
                    }
                 else
                    {
                        location.X = 0;
                        _box.Location = location;
                    }   
                }
                else if (value == Keys.Right)
                {
                    Point location = _box.Location;
                    location.X += 50;
                    if (location.X <= _form.Width - _box.Width - 10)
                    {
                        _box.Location = location;
                    }
                    else
                    {
                        location.X = _form.Width - _box.Width - 10;
                        _box.Location = location;
                    }
                }
            }
        }
        public PictureBox Box
        {
            get { return _box; }
        }
        
        public int Location
        {
            set
            {
                Point location = _box.Location;
                location.X = value;
                _box.Location  = location;

            }
        }
        #endregion
        #region  Private Methods 

        #endregion
        #region  Public Methods 

        #endregion
        #region  Public Events 

        #endregion
        #region  Public Event Handlers 
        public Paddle(Form frm, Random rnd)
        {
            //Creates new box
            _box = new PictureBox();
            //Creates local variable from the form object
            _form = frm;
            //Accesses the random number generator
            _rnd = rnd;
            //Determines the size of the object
            Size size = new Size(200, 10);
            //Creates a variable for the width of the object
            _box.Size = size;
            int x = (_form.Width/2 - _box.Width/2);
            //Creates a variable for the height of the object
            int y = _form.Height - _box.Height*5;
            //Determines where the object will appear
            Point location = new Point(x, y);
            //Assigns a color to the object
            _box.BackColor = Color.White;
            //Adds the object
            _form.Controls.Add(_box);
            //Initializes the location of the object
            _box.Location = location;

        }
        #endregion
        #region Construction 
        
        #endregion

    }
}
