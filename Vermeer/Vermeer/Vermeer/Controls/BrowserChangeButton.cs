using Moonbyte.Vermeer.bin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace Vermeer.Controls
{

    #region EventClasses

    #region OnChromeChange

    public class OnChromeChange : EventArgs
    {

    }

    #endregion OnChromeChange

    #region OnFirefoxChange

    public class OnFirefoxChange : EventArgs
    {

    }

    #endregion OnFirefoxChange

    #endregion EventClasses

    public class BrowserChangeButton : UserControl
    {

        #region Vars

        //Delete after added

        public enum States { Chrome, Firefox, Changing, Startup }
        public enum AnimatingStates { Chrome, Firefox, Changing, empty }

        //Keep

        Rectangle chromeIconRect = new Rectangle(4, 4, 24, 24);
        Rectangle firefoxIconRect = new Rectangle(6, 6, 20, 20);

        List<Rectangle> LoadingRectangles = new List<Rectangle>();
        public States state = States.Startup;
        public AnimatingStates aStates = AnimatingStates.empty;
        Image Chrome_Icon;
        Image Firefox_Icon;

        bool MouseOver = false;
        bool LogEvents = true;

        #region Colors

        private Color _BackgroundColor = Color.White;
        private Color _BorderColor = Color.FromArgb(140, 140, 140);
        private Color _LoadingEllipseColor = Color.FromArgb(65, 65, 65);
        private Color _BackgroundEllipseColor = Color.FromArgb(235, 235, 235);

        #endregion Colors

        #endregion Vars

        #region Properties

        //To be added

        #endregion Properties

        #region Events

        public EventHandler<OnChromeChange> onChromeChange;
        public EventHandler<OnFirefoxChange> onFirefoxChange;

        #endregion Events

        #region Animation Vars

        public enum AnimationState { ChromeToChanging, FirefoxToChanging, ChangingToChrome, ChangingToFirefox }

        bool IsAnimating = false;
        Rectangle AnimatingRectangle;
        int FPS = 14;

        #endregion AnimationVars

        #region Initialization

        public BrowserChangeButton()
        {
            Chrome_Icon = Image.FromFile(Path.Combine(Application.StartupPath, "resources", "chrome_logo.png"));
            Firefox_Icon = Image.FromFile(Path.Combine(Application.StartupPath, "resources", "firefox_logo.png"));

            this.Size = new Size(32, 32);
            this.DoubleBuffered = true;

            LogEvent("CHANGEBUTTON", "Initialized ChangedButton");
        }

        #endregion Initialization

        #region MouseEvents

        private void StartTimer()
        {
            int count = 0; Timer testTimer = new Timer();
            testTimer.Interval = 5000;
            testTimer.Tick += (obj, args) =>
            {
                bool log = false;
                if (IsAnimating) { return; }
                if (this.state == States.Chrome)
                {
                    onFirefoxChange?.Invoke(this, GenerateFirefoxChangeArgs());
                    LogEvent("CHANGEBUTTON", "Invoked onFirefoxChange");
                    Animate(AnimationState.ChromeToChanging);
                    log = true;
                }
                if (this.state == States.Firefox)
                {
                    onChromeChange?.Invoke(this, GenerateChromeChangeArgs());
                    LogEvent("CHANGEBUTTON", "Invoked onChromeChange");
                    Animate(AnimationState.FirefoxToChanging);
                    log = true;
                }
                
                if (log)
                {
                    count++;
                    long Memory = GC.GetTotalMemory(true);
                    vermeer.ApplicationLogger.AddToLog("BENCHMARK", "Changed browser : " + count + " times");
                    vermeer.ApplicationLogger.AddToLog("BENCHMARK", "Memory Used : " + Memory);
                }
            };
            testTimer.Start();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (IsAnimating) { return; }
            if (this.state == States.Chrome)
            {
                onFirefoxChange?.Invoke(this, GenerateFirefoxChangeArgs());
                LogEvent("CHANGEBUTTON", "Invoked onFirefoxChange");
                Animate(AnimationState.ChromeToChanging);
            }
            if (this.state == States.Firefox)
            {
                onChromeChange?.Invoke(this, GenerateChromeChangeArgs());
                LogEvent("CHANGEBUTTON", "Invoked onChromeChange");
                Animate(AnimationState.FirefoxToChanging);
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            MouseOver = true;
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            MouseOver = false;
            this.Invalidate();
        }

        #endregion MouseEvents

        #region Generate Event Args

        #region Firefox

        private OnFirefoxChange GenerateFirefoxChangeArgs()
        {
            OnFirefoxChange _return = new OnFirefoxChange();

            return _return;
        }

        #endregion Firefox

        #region Chrome

        private OnChromeChange GenerateChromeChangeArgs()
        {
            OnChromeChange _return = new OnChromeChange();

            return _return;
        }

        #endregion Chrome

        #endregion Generate Event Args

        #region Animation Methods

        public void Animate(AnimationState state)
        {
            if (state == AnimationState.ChromeToChanging) { LogEvent("CHANGEBUTTON", "Minimizing Chrome Icon"); MinimizeChrome(); }
            if (state == AnimationState.FirefoxToChanging) { LogEvent("CHANGEBUTTON", "Minimizing Firefox Icon"); MinimizeFirefox(); }
        }

        #region ChangeToChrome

        public void ChangeToChrome()
        {
            if (this.state == States.Changing)
            {
                this.state = States.Chrome;
                LogEvent("CHANGEBUTTON", "Changed states to chrome via Public ChangeToChrome");
            }
            else if (!IsAnimating)
            {
                this.state = States.Chrome;
                BringUpChrome();
                LogEvent("CHANGEBUTTON", "Changed states to chrome via Public ChangeToChrome -!IsAnimating check");
            }
        }

        #endregion ChangeToChrome

        #region ChangeToFirefox

        public void ChangeToFirefox()
        {
            if (this.state == States.Changing)
            {
                this.state = States.Firefox;
                LogEvent("CHANGEBUTTON", "Changed states to Firefox via Public ChangeToFirefox");
            }
            else if (!IsAnimating)
            {
               this.state = States.Firefox;
               BringUpFirefox();
               LogEvent("CHANGEBUTTON", "Changed states to Firefox via Public ChangeToFirefox -!IsAnimating check");
            }
        }

        #endregion ChangeToFirefox

        #region StartLoadingAnimation

        int workingOn = 0;
        private void StartLoadingAnimation()
        {
            Timer wave1Loading = new Timer();
            Timer wave2Loading = new Timer();

            this.state = States.Changing;
            this.aStates = AnimatingStates.Changing;

            int wave1Tick = 0;
            wave1Loading.Interval = FPS;
            wave1Loading.Tick += (obj, args) =>
            {
                wave1Tick++;

                if (wave1Tick < 30) return;
                Rectangle workingRect;
                try { workingRect = LoadingRectangles[workingOn]; }
                catch { AddLoadingRectangle(workingOn); workingRect = LoadingRectangles[workingOn]; }

                int add = 2;

                workingRect.X += add;
                LoadingRectangles[workingOn] = workingRect;

                int checkX = (this.Width - workingRect.Width) / 2 - 2; if (workingRect.X > checkX)
                {
                    workingRect.X = checkX;
                    Rectangle ogRect = LoadingRectangles[0];

                    ogRect.Size = new Size(ogRect.Width + 1, ogRect.Height + 1);
                    ogRect.Location = new Point((this.Width - ogRect.Width) / 2, (this.Height - ogRect.Height) / 2);

                    LoadingRectangles[0] = ogRect;
                    workingOn++;
                }

                if (workingOn > 8)
                {
                    workingOn = 8; wave1Tick = 0; wave1Loading.Stop(); wave2Loading.Start();
                }

                this.Invalidate();
            };

            int wave2tick = 0;
            int lastItemWorked = -1; wave2Loading.Interval = FPS;
            wave2Loading.Tick += (obj, args) =>
            {
                wave2tick++;
                if (wave2tick < 30) return;

                Rectangle workingRect = LoadingRectangles[workingOn];
                if (lastItemWorked == -1) { lastItemWorked = workingOn + 1; }

                if (lastItemWorked != workingOn)
                {
                    Rectangle ogRect = LoadingRectangles[0];

                    ogRect.Size = new Size(ogRect.Width - 1, ogRect.Height - 1);
                    ogRect.Location = new Point((this.Width - ogRect.Width) / 2, (this.Height - ogRect.Height) / 2);

                    LoadingRectangles[0] = ogRect;
                    lastItemWorked = workingOn;
                }

                int add = 2;
                workingRect.X += add;
                LoadingRectangles[workingOn] = workingRect;

                if (workingRect.X > 34) { workingOn--; }

                if (workingOn == -1)
                {
                    if (this.state == States.Changing) { LoadingRectangles.Clear(); lastItemWorked = -1; workingOn = 0; wave2tick = 0; wave2Loading.Stop(); wave1Loading.Start(); return; }
                    else
                    {
                        //Animate other things
                        LoadingRectangles.Clear(); lastItemWorked = -1; workingOn = 0; wave2tick = 0; this.aStates = AnimatingStates.empty;
                        wave2Loading.Stop();

                        if (this.state == States.Chrome) { BringUpChrome(); }
                        else if (this.state == States.Firefox) { BringUpFirefox(); }
                    }
                }

                this.Invalidate();

            };

            wave1Loading.Start();

        }

        private void AddLoadingRectangle(int Index)
        {
            Size size = new Size(5, 5);
            Point point = new Point(-6, (this.Height - size.Height) / 2);
            LoadingRectangles.Add(new Rectangle(point, size));
        }

        #endregion StartLoadingAnimation

        #region MinimizeChrome

        private void MinimizeChrome()
        {
            IsAnimating = true;
            this.aStates = AnimatingStates.Chrome;
            AnimatingRectangle = chromeIconRect;

            Timer timer = new Timer();
            timer.Interval = FPS;

            int timerTick = 0; timer.Tick += (obj, args) =>
            {
                int calc = 0; if (timerTick > 0) { calc = timerTick / 2; }

                int add = 0;
                if (calc != 0 && calc < 3) add = 1;
                if (calc > 3 && calc < 6) add = 2;
                if (calc > 6) add = 4;

                AnimatingRectangle.Size = new Size(AnimatingRectangle.Width - add, AnimatingRectangle.Height - add);
                AnimatingRectangle.Location = new Point((32 - AnimatingRectangle.Width) / 2, (32 - AnimatingRectangle.Height) / 2);
                timerTick++;
                this.Invalidate();

                if (AnimatingRectangle.Width == 0 && aStates == AnimatingStates.Chrome) { timer.Stop(); this.Invalidate(); StartLoadingAnimation(); return; }
                else if (AnimatingRectangle.Width == 0) { timer.Stop(); this.Invalidate(); return; }
            };

            timer.Start();
        }

        #endregion MinimizeChrome

        #region BringUpChrome

        private void BringUpChrome()
        {
            IsAnimating = true;
            this.aStates = AnimatingStates.Chrome;
            AnimatingRectangle = new Rectangle(0, 0, 0, 0);

            Timer timer = new Timer();
            timer.Interval = FPS;

            int timerTick = 0; timer.Tick += (obj, args) =>
            {
                int calc = 0; if (timerTick > 0) { calc = timerTick / 2; }

                int add = 0;
                if (calc != 0 && calc < 3) add = 1;
                if (calc > 3 && calc < 6) add = 2;
                if (calc > 6) add = 4;

                AnimatingRectangle.Size = new Size(AnimatingRectangle.Width + add, AnimatingRectangle.Height + add);
                AnimatingRectangle.Location = new Point((32 - AnimatingRectangle.Width) / 2, (32 - AnimatingRectangle.Height) / 2);
                if (AnimatingRectangle.Width >= chromeIconRect.Width)
                {
                    timer.Stop();
                    IsAnimating = false;

                    this.aStates = AnimatingStates.empty;
                    this.state = States.Chrome;

                    this.Invalidate();

                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    return;
                }
                timerTick++;
                this.Invalidate();
            };

            timer.Start();
        }

        #endregion BringUpChrome

        #region MinimizeFirefox

        private void MinimizeFirefox()
        {
            IsAnimating = true;
            this.aStates = AnimatingStates.Firefox;
            AnimatingRectangle = firefoxIconRect;

            Timer timer = new Timer();
            timer.Interval = FPS;

            int timerTick = 0; timer.Tick += (obj, args) =>
            {
                int calc = 0; if (timerTick > 0) { calc = timerTick / 2; }

                int add = 0;
                if (calc != 0 && calc < 3) add = 1;
                if (calc > 3 && calc < 6) add = 2;
                if (calc > 6) add = 4;

                AnimatingRectangle.Size = new Size(AnimatingRectangle.Width - add, AnimatingRectangle.Height - add);
                AnimatingRectangle.Location = new Point((32 - AnimatingRectangle.Width) / 2, (32 - AnimatingRectangle.Height) / 2);

                timerTick++;
                this.Invalidate();

                if (AnimatingRectangle.Width == 0 && aStates == AnimatingStates.Firefox) { timer.Stop(); this.Invalidate(); StartLoadingAnimation(); return; }
                else if (AnimatingRectangle.Width == 0) { timer.Stop(); this.Invalidate(); return; }
            };

            timer.Start();
        }

        #endregion MinimizeFirefox

        #region BringUpFirefox

        private void BringUpFirefox()
        {
            IsAnimating = true;
            this.aStates = AnimatingStates.Firefox;
            AnimatingRectangle = new Rectangle(0, 0, 0, 0);

            Timer timer = new Timer();
            timer.Interval = FPS;

            int timerTick = 0; timer.Tick += (obj, args) =>
            {
                int calc = 0; if (timerTick > 0) { calc = timerTick / 2; }

                int add = 0;
                if (calc != 0 && calc < 3) add = 1;
                if (calc > 3 && calc < 6) add = 2;
                if (calc > 6) add = 4;

                AnimatingRectangle.Size = new Size(AnimatingRectangle.Width + add, AnimatingRectangle.Height + add);
                AnimatingRectangle.Location = new Point((32 - AnimatingRectangle.Width) / 2, (32 - AnimatingRectangle.Height) / 2);
                if (AnimatingRectangle.Width >= firefoxIconRect.Width)
                {
                    timer.Stop();
                    IsAnimating = false;

                    this.aStates = AnimatingStates.empty;
                    this.state = States.Firefox;

                    this.Invalidate();

                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    return;
                }
                timerTick++;
                this.Invalidate();
            };

            timer.Start();
        }

        #endregion BringUpFirefox

        #endregion Animation Methods

        #region OnPaint

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            if (MouseOver) { _BackgroundEllipseColor = Color.FromArgb(188, 188, 188); }
            else { _BackgroundEllipseColor = _BackgroundColor; }

            g.Clear(_BackgroundColor);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.FillEllipse(new SolidBrush(_BackgroundEllipseColor), new Rectangle(2, 2, 28, 28));

            if (!IsAnimating)
            {
                if (state == States.Chrome)
                { g.DrawImage(Chrome_Icon, chromeIconRect); }
                else if (state == States.Firefox)
                { //g.DrawImage(Firefox_Icon, firefoxIconRect); 
                }
            }
            else
            {
                if (aStates == AnimatingStates.Chrome)
                { g.DrawImage(Chrome_Icon, AnimatingRectangle); }
                if (aStates == AnimatingStates.Firefox)
                { g.DrawImage(Firefox_Icon, AnimatingRectangle); }
                if (aStates == AnimatingStates.Changing)
                {
                    foreach (Rectangle rect in LoadingRectangles)
                    { g.FillEllipse(new SolidBrush(_LoadingEllipseColor), rect); }
                }
            }

            //g.DrawEllipse(new Pen(new SolidBrush(_BackgroundColor), 15), new Rectangle(-8, -8, 47, 47));
            g.DrawEllipse(new Pen(new SolidBrush(_BackgroundColor), 15), new Rectangle(-4, -4, 40, 40));
            //g.DrawEllipse(new Pen(new SolidBrush(_BorderColor), 1), new Rectangle(0, 0, 31, 31));

            g.SmoothingMode = SmoothingMode.Default;
            g.CompositingQuality = CompositingQuality.Default;
            g.InterpolationMode = InterpolationMode.Default;
        }

        #endregion OnPaint

        #region Logging

        private void LogEvent(string Header, string Value)
        {
            if (!LogEvents) { return; }
            vermeer.ApplicationLogger.AddToLog(Header, Value);
        }

        #endregion Logging

    }
}