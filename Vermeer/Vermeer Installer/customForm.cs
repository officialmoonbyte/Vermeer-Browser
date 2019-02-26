using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Vermeer_Installer
{
    [DefaultEvent("Load")]
    public class customForm : Form
    {

        #region Events

        // Button Events //
        public event EventHandler MinStateChange;
        public event EventHandler MaxStateChange;
        public event EventHandler CloseStateChange;

        #endregion

        #region Variables

        // Designing Vars //
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        // Button Objects //
        public UIClose Btn_Close = new UIClose();

        //Getting the assembly loader
        private Assembly assembly = Assembly.GetExecutingAssembly();

        //Private bools
        private bool sizeAble = true;
        private bool showCloseButton = true;
        private bool showMaxButton = true;
        private bool showMinButton = true;
        private bool showTitleLabel = true;

        //All color options
        private Color headerColor = Color.White;
        private Color titleForeColor = Color.Black;
        private Color OutLineColor = Color.AliceBlue;
        Color icon_BackColor = Color.Transparent;

        //Rectangle for the border
        private Rectangle _BORDER = new Rectangle();

        //All ints for advanced settings
        int close_MinusWidthValue = 49;
        int close_Position_Y = 1;
        int max_MinusWidthFalse = 49;
        int max_MinusWidthElse = 97;
        int max_Position_Y = 1;
        int min_state1MinusWidth = 49;
        int min_state2MinusWidth = 97;
        int min_state3MinusWidth = 146;
        int Header_Rect_Height = 29;
        int min_Position_Y = 1;
        int header_Rect_X = 0;
        int header_Rect_Y = 0;

        int OutLineInt = 0;

        Point title_Location = new Point(35, 2);
        Point icon_Location = new Point(10, 2);

        Size icon_Size = new Size(18, 18);

        PictureBoxSizeMode icon_PictureBoxSizeMode = PictureBoxSizeMode.StretchImage;

        bool showicon = true;

        #endregion

        #region Properties

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("Advanced Settings")]
        public bool Showicon
        {
            get { return showicon; }
            set
            {
                showicon = value;
                this.Invalidate();
            }
        }

        new bool ShowIcon
        {
            get { return showicon; }
            set
            {
                showicon = value;
                this.Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("Advanced Settings")]
        public int HeaderHeight
        {
            get { return Header_Rect_Height; }
            set
            {
                Header_Rect_Height = value;
                this.Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("Advanced Settings")]
        public int Header_Rect_Y
        {
            get { return header_Rect_Y; }
            set
            {
                header_Rect_Y = value;
                this.Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("Advanced Settings")]
        public int Header_Rect_X
        {
            get { return header_Rect_X; }
            set
            {
                header_Rect_X = value;
                this.Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("Advanced Settings")]
        public Color Icon_BackColor
        {
            get { return icon_BackColor; }
            set
            {
                icon_BackColor = value;
                this.Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("Advanced Settings")]
        public PictureBoxSizeMode Icon_PictureBoxSizeMode
        {
            get { return icon_PictureBoxSizeMode; }
            set
            {
                icon_PictureBoxSizeMode = value;
                this.Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("Advanced Settings")]
        public Point IconLocation
        {
            get { return icon_Location; }
            set
            {
                icon_Location = value;
                this.Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("Advanced Settings")]
        public Size IconSize
        {
            get { return icon_Size; }
            set
            {
                icon_Size = value;
                this.Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("Advanced Settings")]
        public Point Title_Location
        {
            get { return title_Location; }
            set
            {
                title_Location = value;
                this.Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("Advanced Settings")]
        public int btn_Min_Position_Y
        {
            get { return min_Position_Y; }
            set
            {
                min_Position_Y = value;
                this.Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("Advanced Settings")]
        public int btn_Min_State3MinusWidth
        {
            get { return min_state3MinusWidth; }
            set
            {
                min_state3MinusWidth = value;
                this.Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("Advanced Settings")]
        public int btn_Min_State2MinusWidth
        {
            get { return min_state2MinusWidth; }
            set
            {
                min_state2MinusWidth = value;
                this.Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("Advanced Settings")]
        public int btn_Min_State1_MinusWidth
        {
            get { return min_state1MinusWidth; }
            set
            {
                min_state1MinusWidth = value;
                this.Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("Advanced Settings")]
        public int btn_Max_Position_Y
        {
            get { return max_Position_Y; }
            set
            {
                max_Position_Y = value;
                this.Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("Advanced Settings")]
        public int btn_Max_MinusWidthElse
        {
            get { return max_MinusWidthElse; }
            set
            {
                max_MinusWidthElse = value;
                this.Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("Advanced Settings")]
        public int btn_Max_MinusWidthFalse
        {
            get { return max_MinusWidthFalse; }
            set
            {
                max_MinusWidthFalse = value;
                this.Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("Advanced Settings")]
        public int btn_Close_Position_Y
        {
            get { return close_Position_Y; }
            set
            {
                close_Position_Y = value;
                this.Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("Advanced Settings")]
        public int btn_Close_MinusWidthValue
        {
            get { return close_MinusWidthValue; }
            set
            {
                close_MinusWidthValue = value;
                this.Close();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("IndieGoat Control Settings")]
        public int BorderSize
        {
            get { return OutLineInt; }
            set
            {
                OutLineInt = value;
                this.Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("IndieGoat Control Settings")]
        public bool Sizeable
        {
            get { return sizeAble; }
            set
            {
                sizeAble = value;
                this.Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("IndieGoat Control Settings")]
        public Color HeaderColor
        {
            get { return headerColor; }
            set
            {
                headerColor = value;
                this.Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("IndieGoat Control Settings")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                this.Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("IndieGoat Control Settings")]
        public Color BorderColor
        {
            get { return OutLineColor; }
            set
            {
                this.OutLineColor = value;
                this.Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("IndieGoat Control Settings")]
        public bool ShowCloseButton
        {
            get { return this.showCloseButton; }
            set
            {
                this.showCloseButton = value;
                this.Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("IndieGoat Control Settings")]
        public bool ShowMaxButton
        {
            get { return this.showMaxButton; }
            set
            {
                this.showMaxButton = value;
                this.Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("IndieGoat Control Settings")]
        public bool ShowMinButton
        {
            get { return showMinButton; }
            set
            {
                showMinButton = value;
                this.Invalidate();
            }
        }

        #region Title

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Category("IndieGoat Control Settings")]
        public bool ShowTitleLabel
        {
            get { return showTitleLabel; }
            set
            {
                showTitleLabel = value;
                this.Invalidate();
            }
        }

        #endregion

        #endregion

        #region Resize / Mouse events

        /// <summary>
        /// Used to set the window back when max is clicked
        /// </summary>
        private Size oldSize;
        private Point oldLocation;
        private void Btn_Max_Click(object sender, EventArgs e)
        {

            //Invokingevents
            onMaxButtonClicked?.Invoke(this, new EventArgs());
            MaxStateChange?.Invoke(this, new EventArgs());

            //Get the screen of the control
            Screen screen = Screen.FromControl(this);
            Size screenWorkingSize = screen.WorkingArea.Size;

            //Get the size of the screen
            if (this.Size == screenWorkingSize)
            {
                //Set the size of the form based on the screen
                if (oldSize != null) this.Size = oldSize;
                if (oldLocation != null) this.Location = oldLocation;
            }
            else
            {
                //Set the size of the form based on the screen
                oldSize = this.Size;
                oldLocation = this.Location;

                //Set the location of the screen
                this.Location = new Point(0, 0);
                this.Size = screen.WorkingArea.Size;
            }

            //Invalidate the back color
            ReinvalidateBackColor();
        }

        private void Btn_Min_Click(object sender, EventArgs e)
        {
            //Invoke button events
            onMinButtonClicked?.Invoke(this, new EventArgs());
            MinStateChange?.Invoke(this, new EventArgs());

            //Minimize the form if needed.
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {

            //Inovke the button events
            onCloseButtonClicked?.Invoke(this, new EventArgs());
            CloseStateChange?.Invoke(this, new EventArgs());

            this.Close();
        }

        #endregion

        #region Snapping

        //Snapping vars
        bool isSnapped = false;
        Size snapOldSize = new Size(0, 0);

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                MouseEvent(true);
            }
            else { MouseEvent(false); }
        }

        #endregion

        #region Control Methods

        public customForm()
        {
            /* Material Form */
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.DoubleBuffered = true;

            this.BackColor = Color.AliceBlue;
        }

        //Update's the back color to remove the old broder on resize.
        protected override void OnResizeEnd(EventArgs e) { base.OnResizeEnd(e); ReinvalidateBackColor(); }
        private void ReinvalidateBackColor() { this.BackColor = BackColor; }

        /// <summary>
        /// Used to dispose of all of the buttons and icons, and the to a GC
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Btn_Close.Dispose();
            this.Btn_Close.Click += null;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            base.OnFormClosing(e);
        }

        /// <summary>
        /// Used to dispose of all of the controls on this form
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            //Null on the button events
            onCloseButtonClicked = null;
            onMinButtonClicked = null;
            onMaxButtonClicked = null;

            //Getting all of the controls
            Control.ControlCollection coll = this.Controls;

            //Disposing of all of the controls
            foreach (Control c in coll)
            {
                c.Dispose();
            }

            base.Dispose(disposing);

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        /// <summary>
        /// Designing the form
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {

            if (!DesignMode)
            {
                /* Btn_Close */
                if (showCloseButton == false)
                {
                    this.Btn_Close.Visible = showCloseButton;
                }
                else
                {
                    this.Btn_Close.Anchor = (AnchorStyles.Right | AnchorStyles.Top);
                    this.Btn_Close.Location = new Point(this.Width - close_MinusWidthValue, close_Position_Y);
                    this.Btn_Close.Visible = showCloseButton;
                    this.Btn_Close.Click += Btn_Close_Click;
                    this.Btn_Close.X.Click += Btn_Close_Click;
                    this.Controls.Add(Btn_Close);
                }
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();

            base.OnLoad(e);
        }

        #region Design Vars
        //Design vars used in WndProc to redraw the form

        private const int HTLEFT = 10, HTRIGHT = 11, HTTOP = 12, HTTOPLEFT = 13, HTTOPRIGHT = 14, HTBOTTOM = 15, HTBOTTOMLEFT = 16, HTBOTTOMRIGHT = 17;
        const int _ = 10;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        Rectangle Left
        {
            get { return new Rectangle(0, 0, _, this.ClientSize.Height); }
        }
        Rectangle Bottom
        {
            get { return new Rectangle(0, this.ClientSize.Height - _, this.ClientSize.Width, _); }
        }
        Rectangle Right
        {
            get { return new Rectangle(this.ClientSize.Width - _, 0, _, this.ClientSize.Height); }
        }

        Rectangle TopLeft
        {
            get { return new Rectangle(0, 0, _, _); }
        }
        Rectangle TopRight
        {
            get { return new Rectangle(this.ClientSize.Width - _, 0, _, _); }
        }
        Rectangle BottomLeft
        {
            get { return new Rectangle(0, this.ClientSize.Height - _, _, _); }
        }
        Rectangle BottomRight
        {
            get { return new Rectangle(this.ClientSize.Width - _, this.ClientSize.Height - _, _, _); }
        }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            //Fill the header rectangle with the headerColor
            e.Graphics.FillRectangle(new SolidBrush(headerColor), header_Rect_X, header_Rect_Y, this.Width, Header_Rect_Height);
            _BORDER.Width = this.Width;

            if (Header_Rect_Height >= 22)
            {
                _BORDER.Height = Header_Rect_Height;
            }
            else
            {
                _BORDER.Height = 22;
            }

            base.OnPaint(e);

            //Draw the border.
            e.Graphics.DrawRectangle(new Pen(OutLineColor, OutLineInt), this.ClientRectangle);
        }

        //To move the mouse when the mouse is over the icon
        private void iCon_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseEvent(true);
            }
            else { MouseEvent(false); }
        }

        //To move the mouse when the mouse is over the title
        private void Lbl_Title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseEvent(true);
            }
            else { MouseEvent(false); }
        }

        private void MouseEvent(bool LeftDown)
        {
            if (LeftDown)
            { this.MoveFormExternal(true); }
            else { this.MoveFormExternal(false); }
        }

        #endregion

        #region Events

        public event EventHandler onCloseButtonClicked;
        public event EventHandler onMinButtonClicked;
        public event EventHandler onMaxButtonClicked;

        #endregion

        #region External Mouse Movement

        private Screen FindCurrentMonitor()
        {
            Screen screen = Screen.FromPoint(new Point(Cursor.Position.X, Cursor.Position.Y));
            return screen;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
        }

        #region MousePercent

        Decimal percentMouse = 0;
        private void CalculateMousePercent()
        {
            percentMouse = decimal.Multiply(100, decimal.Divide(this.PointToClient(MousePosition).X, this.Width));
        }
        private decimal GetUsableMousePercent()
        {
            return decimal.Divide(100, percentMouse);

        }

        #endregion

        /// <summary>
        /// This will be a test, official update will be coming soon.
        /// </summary>
        public void MoveFormExternal(bool MouseButtonLeft)
        {
            //Get the Label and Icon rectangle
            Rectangle Lbl_Title_Rect = new Rectangle();

            Lbl_Title_Rect.Location = Lbl_Title_Rect.Location;

            //Check if the button is the LeftMouseButton
            if (MouseButtonLeft)
            {
                //Get the screen size
                Screen screen = FindCurrentMonitor();
                Size screenWorkingSize = Screen.FromControl(this).Bounds.Size;
                CalculateMousePercent();

                //Set the location and size based on the screen
                if (this.Size == screenWorkingSize)
                {
                    if (oldSize != null) this.Size = oldSize;
                    Application.DoEvents();
                    this.Location = new Point(MousePosition.X - 6, MousePosition.Y - 6);
                }

                //Set the location and size based on mouse position and old size
                if (isSnapped) { if (snapOldSize != null) this.Size = snapOldSize; isSnapped = false; }

                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);

                //Get the screen size
                screen = FindCurrentMonitor();
                screenWorkingSize = Screen.FromControl(this).Bounds.Size;

                //Get cusor position
                Point cursorPosition = this.PointToClient(Cursor.Position);

                if (_BORDER.Contains(cursorPosition))
                {

                    Point cursorLocation = Cursor.Position;

                    Point formLocation = this.Location;

                    //Setting the Old Snap size and Location
                    if (cursorLocation.X == 0)
                    {
                        snapOldSize = this.Size;

                        this.Location = new Point(screen.Bounds.X, screen.Bounds.Y);
                        this.Size = new Size(screenWorkingSize.Width / 2, screenWorkingSize.Height);

                        isSnapped = true;
                    }

                    if (cursorLocation.Y == 0)
                    {
                        snapOldSize = this.Size;

                        this.Location = new Point(screen.Bounds.X, screen.Bounds.Y);
                        this.Size = new Size(screenWorkingSize.Width, screenWorkingSize.Height);

                        isSnapped = true;
                    }

                    if (cursorLocation.X + 1 == screenWorkingSize.Width)
                    {
                        snapOldSize = this.Size;

                        this.Location = new Point(screenWorkingSize.Width / 2, 0);
                        this.Size = new Size(screenWorkingSize.Width / 2, screenWorkingSize.Height);

                        isSnapped = true;
                    }
                }
            }
        }

        #endregion

        #region Resize

        //***********************************************************
        //This gives us the ability to resize the borderless from any borders instead of just the lower right corner
        protected override void WndProc(ref Message m)
        {
            const int wmNcHitTest = 0x84;
            const int htLeft = 10;
            const int htRight = 11;
            const int htBottom = 15;
            const int htBottomLeft = 16;
            const int htBottomRight = 17;

            if (m.Msg == wmNcHitTest)
            {
                Point pt = PointToClient(new Point(MousePosition.X, MousePosition.Y));
                Size clientSize = ClientSize;

                ///allow resize on the lower right corner
                if (pt.X >= clientSize.Width - 16 && pt.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr)(IsMirrored ? htBottomLeft : htBottomRight);
                    return;
                }
                ///allow resize on the lower left corner
                if (pt.X <= 16 && pt.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr)(IsMirrored ? htBottomRight : htBottomLeft);
                    return;
                }

                ///allow resize on the bottom border
                if (pt.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr)(htBottom);
                    return;
                }
                ///allow resize on the left border
                if (pt.X <= 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr)(htLeft);
                    return;
                }
                ///allow resize on the right border
                if (pt.X >= clientSize.Width - 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr)(htRight);
                    return;
                }
            }
            base.WndProc(ref m);
        }

        //***********************************************************
        //***********************************************************
        //This gives us the drop shadow behind the borderless form
        private const int CS_DROPSHADOW = 0x20000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        //***********************************************************

        #endregion

    }

    #region CloseButton

    [System.ComponentModel.ToolboxItem(false)]
    [DefaultEvent("Click")]
    public class UIClose : UserControl
    {
        #region Varables & Objects

        //Setting colors
        private Color defaultForeColor = Color.FromArgb(191, 191, 191);
        private Color defaultMousePointerEnterColor = Color.FromArgb(255, 255, 255);
        private Color defaultMousClickColor = Color.FromArgb(23, 23, 23);

        private Color defaultBackColor = Color.Transparent;
        private Color defaultMousePointerEnterBackColor = Color.FromArgb(255, 90, 90);
        private Color defaultMouseClickBackColor = Color.FromArgb(83, 29, 29);

        private Size size = new Size(48, 28);

        //Setting button text
        public Label X = new Label();

        #endregion

        public UIClose()
        {
            /* X */
            this.X.Text = "X";
            this.X.Location = new Point(16, 5);
            this.X.ForeColor = defaultForeColor;
            this.X.MouseEnter += mousePointerEnter;
            this.X.MouseLeave += mousePointerLeft;
            this.X.MouseDown += mouseDown;
            this.X.MouseUp += mouseUp;
            this.Controls.Add(X);


            /*Default Control */
            this.Size = size;
            this.BackColor = Color.Transparent;
            this.Font = new Font(this.Font.Name, 11f);
            this.MouseEnter += mousePointerEnter;
            this.MouseLeave += mousePointerLeft;
            this.MouseDown += mouseDown;
            this.MouseUp += mouseUp;
            this.DoubleBuffered = true;
        }

        private void mousePointerEnter(object sender, EventArgs e)
        {
            this.BackColor = defaultMousePointerEnterBackColor;
            X.ForeColor = defaultMousePointerEnterColor;
        }

        private void mousePointerLeft(object sender, EventArgs e)
        {
            this.BackColor = defaultBackColor;
            X.ForeColor = defaultForeColor;
        }

        private void mouseDown(object sender, EventArgs e)
        {
            this.BackColor = defaultMouseClickBackColor;
            X.ForeColor = defaultMouseClickBackColor;
        }

        private void mouseUp(object sender, EventArgs e)
        {
            try
            {
                if (ClientRectangle.Contains(PointToClient(Control.MousePosition)))
                {
                    this.BackColor = defaultMousePointerEnterBackColor;
                    X.ForeColor = defaultMousePointerEnterColor;
                }
                else
                {
                    this.BackColor = DefaultBackColor;
                    X.ForeColor = defaultForeColor;
                }
            }
            catch
            {

            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            this.Size = size;
        }

        protected override void Dispose(bool disposing)
        {
            this.MouseEnter += null;
            this.MouseLeave += null;
            this.MouseUp += null;
            this.MouseLeave += null;

            X.MouseEnter += null;
            X.MouseLeave += null;
            X.MouseUp += null;
            X.MouseLeave += null;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            base.Dispose(disposing);
        }
    }

    #endregion

}
