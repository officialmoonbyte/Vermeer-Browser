using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Vermeer_Installer
{
    [DefaultEvent("PercentChange")]
    public class CustomProgressbar : UserControl
    {
        #region Vars

        int _min = 0;
        int _max = 100;
        int _value = 0;

        #region Colors

        Color _BarColor = Color.FromArgb(6, 176, 37);
        Color _BorderColor = Color.FromArgb(188, 188, 188);
        Color _BackColor = Color.FromArgb(230, 230, 230);

        #endregion

        #endregion

        #region Properties

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("Void Settings")]
        public int Minimum
        {
            get { return _min; }
            set
            {
                if (value < 0) { _min = 0; }
                if (value > _min) { _min = value; _min = value; }
                if (_value < _min) { _value = _min; }
                this.Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("Void Settings")]
        public int Maximum
        {
            get { return _max; }
            set
            {
                if (value < _min) { _min = value; }
                _max = value;
                if (_value > _max) { _value = _max; }
                this.Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("Void Settings")]
        public int Value
        {
            get { return _value; }
            set
            {
                int oldValue = _value;
                if (value < _min) { _value = _min; }
                else if (value > _max) { _value = _max; }
                else { _value = value; }

                float percent;
                Rectangle newValueRect = this.ClientRectangle;
                Rectangle oldValueRect = this.ClientRectangle;

                percent = (float)(_value - _min) / (float)(_max - _min);
                newValueRect.Width = (int)((float)newValueRect.Width * percent);
                percent = (float)(oldValue - _min) / (float)(_max - _min);
                oldValueRect.Width = (int)((float)oldValueRect.Width * percent);
                Rectangle updateRect = new Rectangle();

                if (newValueRect.Width > oldValueRect.Width)
                {
                    updateRect.X = oldValueRect.Size.Width;
                    updateRect.Width = newValueRect.Width - oldValueRect.Width;
                }
                else
                {
                    updateRect.X = newValueRect.Size.Width;
                    updateRect.Width = oldValueRect.Width - newValueRect.Width;
                }

                updateRect.Height = this.Height;

                this.Invalidate(updateRect);

                PercentChange?.Invoke(value, new EventArgs());
            }
        }

        #region Color Properties

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("Indie Goat Settings")]
        public Color ProgressBarColor
        {
            get { return _BarColor; }
            set
            {
                _BarColor = value;
                this.Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("Indie Goat Settings")]
        public Color BorderColor
        {
            get { return _BorderColor; }
            set
            {
                _BorderColor = value;
                this.Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("Indie Goat Settings")]
        public override Color BackColor
        {
            get { return _BackColor; }
            set
            {
                this._BackColor = value;
                this.Invalidate();
            }
        }


        #endregion

        #endregion

        #region Event's

        public event EventHandler PercentChange;

        #endregion

        #region Required

        //Set the style and the size of the progress bar
        public CustomProgressbar()
        {
            this.SetStyle(ControlStyles.DoubleBuffer |
   ControlStyles.UserPaint |
   ControlStyles.AllPaintingInWmPaint,
   true);
            this.Size = new Size(120, 23);
        }

        #endregion 

        #region Override Method's

        /// <summary>
        /// On resize, invalidate the control
        /// </summary>
        protected override void OnResize(EventArgs e)
        {
            this.Invalidate();
        }

        /// <summary>
        /// Overide the paint for custom painting
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //Initialize the graphics and brush
            Graphics g = e.Graphics;
            SolidBrush brush = new SolidBrush(_BarColor);

            //Get the percent of the value filled up
            float percent = (float)(_value - _min) / (float)(_max - _min);

            //Initialize the rectangle
            Rectangle rect = this.ClientRectangle;
            rect.Width = (int)((float)rect.Width * percent);

            //Fill the percentage rectangle
            g.FillRectangle(brush, rect);

            //Draw the border with the paint graphics
            DrawBorder(g);

            //Dispose of the brush
            brush.Dispose();
        }

        //Draw the border 
        private void DrawBorder(Graphics g)
        {
            ControlPaint.DrawBorder(g, this.ClientRectangle, _BorderColor, ButtonBorderStyle.Solid);
        }

        #endregion
    }
}
