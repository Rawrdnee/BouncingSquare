using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BouncingSquare
{
    public class Square: IDisposable
    {
        #region Private Members
        private Guid _id = Guid.Empty;
        private Form _form = null;
        private PictureBox _box = null;
        private Timer _timer = null;
        private int _xDir = 0;
        private int _yDir = 0;
        private Random _rnd = null;
        private Paddle _paddle = null;



        #endregion
        #region Public Properties
        public Guid Id
        {
            get { return _id; }
        }
        public PictureBox Box
        {
            get { return _box; }
        }
        public int xDir
        {
            get { return _xDir; }
            set { _xDir = value; }
        }
        public int yDir
        {
            get { return _yDir; }
            set { _yDir = value; }
        }

        #endregion
        #region Public Methods

        public void SetBackGround()
        {
            _box.BackColor = Color.Black;
        }

        private void Move()
        {
            Point location = _box.Location;
            location.X += _xDir;
            location.Y += _yDir;
            _box.Location = location;
            if (location.Y >= _form.Height - _box.Height)
            {
                Dispose();
            }
            else if (location.Y <= 0)
            {
                _yDir = -_yDir;
            }
            else if (location.X >= _form.Width - _box.Width)
            {
                _xDir = -_xDir;
            }
            else if (location.X <= 0)
            {
                _xDir = -_xDir;
            }
            else if (_paddle.Box.Bounds.IntersectsWith (_box.Bounds))
            {
                _yDir = -_yDir;
                _xDir = -_xDir;
            }


        }

        #endregion
        #region Private Methods
        #endregion
        #region Event Handlers

        private void _timer_Tick(object sender, EventArgs e)
        {
            Move();
        }

        #endregion
        #region Private Members
        #endregion
        #region Constructors

        public Square(Form frm, Random rnd, Paddle paddle)
        {
            _paddle = paddle;
            _rnd = rnd;
            _form = frm;
            _box = new PictureBox();
            _box.Width = 20;
            _box.Height = 20;
            _box.BackColor = Color.FromArgb(rnd.Next(0, 256), (rnd.Next(0, 256)), (rnd.Next(0, 256)));

            Point location = new Point();

            location.X = _rnd.Next(0, _form.Width - _box.Width);
            location.Y = _rnd.Next(0, _form.Height/8 - _box.Height);
            _box.Location = location;

            _form.Controls.Add(_box);
            _timer = new Timer();
            _timer.Interval = 1;
            _timer.Enabled = true;
            _timer.Tick += _timer_Tick;
            do
            {
                _xDir = rnd.Next(-1, 1);
            } while (_xDir == 0);
            do
            {
                _yDir = rnd.Next(-30, 30);
            } while (_yDir == 0);
            }
        #endregion

        #region Idisposable Support


        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)

                {
                    _timer.Enabled = false;
                    _box.Dispose();
                    _form.Controls.Remove(_box);
                    _form = null;

                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion



    }


    }
