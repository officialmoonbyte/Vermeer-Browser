using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Vermeer.Vermeer.Controls
{
    public class DefaultSearchBar : UserControl
    {

        #region Vars

        Color backColor = Color.White;
        Color RectangleBackColor = Color.FromArgb(248, 248, 248);
        Color RectangleMouseOver = Color.FromArgb(238, 238, 238);
        Color borderColor = Color.FromArgb(248, 248, 248);
        Color borderColorOnMouseOver = Color.FromArgb(238, 238, 238);
        Color borderColorOnSelected = Color.FromArgb(0, 120, 215);

        public SecureButton secureButton;
        public BaseTextbox baseTextBox;

        #endregion

        #region States

        public enum States { Default, MouseOver, Selected }
        public bool IsSecure { get { return secureButton.SecureLogo; } set { secureButton.SecureLogo = value; this.Invalidate(); secureButton.Invalidate(); } }
        public States SearchbarState = States.Default;

        #endregion

        #region Properties

        public string GetURL { get { return baseTextBox.Text; } set { baseTextBox.Text = value; } }

        #endregion

        #region OnStartup

        public DefaultSearchBar()
        {
            this.Size = new Size(600, 27);

            secureButton = new SecureButton();
            secureButton.Location = new Point(10, 1);
            secureButton.MouseEnter += (obj, args) => { if (this.SearchbarState != States.Selected) { this.SearchbarState = States.MouseOver; this.Invalidate(); } secureButton.eOnMouseEnter(); };
            secureButton.MouseLeave += (obj, args) => { if (this.SearchbarState != States.Selected) { this.SearchbarState = States.Default; this.Invalidate(); } secureButton.eOnMouseLeave(); };
            this.Controls.Add(secureButton);

            this.SetStyle(ControlStyles.Selectable, true);
            TabStop = true;

            // ** BaseTextBox

            baseTextBox = new BaseTextbox(backColor, new Font("Segoe UI", 11));
            baseTextBox.Location = new Point(secureButton.Width + 12, 4);
            baseTextBox.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            baseTextBox.MouseEnter += (obj, args) => { if (this.SearchbarState != States.Selected) { this.SearchbarState = States.MouseOver; this.Invalidate(); } };
            baseTextBox.MouseLeave += (obj, args) => { if (this.SearchbarState != States.Selected) { this.SearchbarState = States.Default; this.Invalidate(); } };
            baseTextBox.Width = this.Width - (secureButton.Width + 14 + 10);

            baseTextBox.GotFocus += (obj, args) =>
            {
                this.SearchbarState = States.Selected; this.Invalidate();
            };
            baseTextBox.LostFocus += (obj, args) =>
            {
                if (this.ClientRectangle.Contains(this.PointToClient(MousePosition)))
                {
                    this.SearchbarState = States.MouseOver;
                }
                else { this.SearchbarState = States.Default; }
                this.Invalidate();
            };
            this.Controls.Add(baseTextBox);

            this.DoubleBuffered = true;
        }

        #endregion

        #region OnPaint

        protected override void OnPaint(PaintEventArgs e)
        {
            Color BackgroundColor = Color.White;
            Color _BorderColor = Color.White;
            if (this.SearchbarState == States.Default)
            {
                BackgroundColor = RectangleBackColor;
                _BorderColor = borderColor;
            }
            else if (this.SearchbarState == States.MouseOver)
            {
                BackgroundColor = RectangleMouseOver;
                _BorderColor = borderColorOnMouseOver;
            }
            else if (this.SearchbarState == States.Selected)
            {
                BackgroundColor = RectangleMouseOver;
                _BorderColor = borderColorOnSelected;
            }

            //Draws background color
            e.Graphics.Clear(Color.White);

            //Updating controls backcolor
            baseTextBox.BackColor = BackgroundColor;
            secureButton.BackgroundColor = BackgroundColor;

            //Draws border and back
            using (GraphicsPath path = _getRoundRectangle(this.ClientRectangle))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                //draws background
                using (SolidBrush brush = new SolidBrush(BackgroundColor))
                { e.Graphics.FillPath(brush, path); }
                //drwas border
                using (Pen pen = new Pen(new SolidBrush(_BorderColor), 1))
                { e.Graphics.DrawPath(pen, path); }

                e.Graphics.SmoothingMode = SmoothingMode.Default;
            }
            base.OnPaint(e);

        }

        #endregion

        #region Rounded Rectangle

        private GraphicsPath _getRoundRectangle(Rectangle rectangle)
        {
            int cornerRadius = 25; // change this value according to your needs
            int diminisher = 1;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rectangle.X, rectangle.Y, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(rectangle.X + rectangle.Width - cornerRadius - diminisher, rectangle.Y, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(rectangle.X + rectangle.Width - cornerRadius - diminisher, rectangle.Y + rectangle.Height - cornerRadius - diminisher, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(rectangle.X, rectangle.Y + rectangle.Height - cornerRadius - diminisher, cornerRadius, cornerRadius, 90, 90);
            path.CloseAllFigures();
            return path;
        }

        #endregion

        #region Selectable Events

        protected override void OnMouseEnter(EventArgs e)
        {
            if (this.SearchbarState != States.Selected) { this.SearchbarState = States.MouseOver; this.Invalidate(); }

            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            if (this.SearchbarState != States.Selected) { this.SearchbarState = States.Default; this.Invalidate(); }

            base.OnMouseLeave(e);
        }
        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Up || keyData == Keys.Down) return true;
            if (keyData == Keys.Left || keyData == Keys.Right) return true;
            return base.IsInputKey(keyData);
        }

        #endregion
    }

    #region SecureButton

    public class SecureButton : UserControl
    {

        #region Vars

        public Color BackgroundColor { get { return backColor; } set { backColor = value; this.Invalidate(); } }

        public Color backColor = Color.White;
        Color DrawColor = Color.FromArgb(48, 48, 48);
        Color OnMouseOverColor = Color.FromArgb(220, 220, 220);
        Color LockColor = Color.FromArgb(18, 188, 0);
        States buttonState = States.Default;

        bool isLoading = false;

        bool secureLogo = false;

        enum States { Default, MouseOver }

        #endregion

        #region Properties

        public bool SecureLogo { get { return secureLogo; } set { secureLogo = value; this.Invalidate(); } }
        public bool IsLoading { get { return isLoading; } set { isLoading = value; this.Invalidate(); } }

        #endregion

        #region OnStartup

        public SecureButton()
        {
            this.Size = new Size(47, 25);
            this.DoubleBuffered = true;
        }

        #endregion

        #region OnPaint

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (buttonState == States.Default)
            { e.Graphics.Clear(backColor); }
            else if (buttonState == States.MouseOver)
            { e.Graphics.Clear(OnMouseOverColor); }
            else { e.Graphics.Clear(backColor); }

            //Setting smoothing mode to smooth
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // ** Information Icon ** //
            Rectangle leftRectangle = new Rectangle(4, 3, 18, 18);
            e.Graphics.DrawEllipse(new Pen(new SolidBrush(DrawColor), 1), leftRectangle);

            Point i_line1 = new Point(13, 18);
            Point i_line2 = new Point(13, 11);

            Point i_line3 = new Point(13, 9);
            Point i_line4 = new Point(13, 7);

            e.Graphics.DrawLine(new Pen(new SolidBrush(DrawColor), 2), i_line1, i_line2);
            e.Graphics.DrawLine(new Pen(new SolidBrush(DrawColor), 2), i_line3, i_line4);

            //Resetting smoothing mode
            e.Graphics.SmoothingMode = SmoothingMode.None;

            // ** Lock ** //
            if (secureLogo)
            {
                this.Width = 47;

                Rectangle rightElipseRectangle = new Rectangle(31, 5, 7, 12);
                Rectangle bottomRightRectangle = new Rectangle(28, 11, 14, 9);
                e.Graphics.FillRectangle(new SolidBrush(LockColor), bottomRightRectangle);

                //Setting smoothing mode
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                e.Graphics.DrawEllipse(new Pen(new SolidBrush(LockColor), 2), rightElipseRectangle);

                //Setting smoothing mode
                e.Graphics.SmoothingMode = SmoothingMode.Default;
            }
            else { this.Width = 27; }
        }

        #endregion

        #region MouseEvents

        protected override void OnMouseEnter(EventArgs e)
        { eOnMouseEnter(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e)
        { eOnMouseLeave(); base.OnMouseLeave(e); }
        public void eOnMouseEnter()
        { this.buttonState = States.MouseOver; this.Invalidate(); }
        public void eOnMouseLeave()
        { this.buttonState = States.Default; this.Invalidate(); }

        #endregion

        #region OnClick

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }

        #endregion
    }

    #endregion

    #region Base Textbox

    public class BaseTextbox : TextBox
    {
        public BaseTextbox(Color BackColor, Font font)
        {
            this.BackColor = BackColor;
            this.Font = font;
            this.Multiline = false;
            this.BorderStyle = BorderStyle.None;

        }

    }

    #endregion
}
