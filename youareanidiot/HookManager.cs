using System;
using System.Windows.Forms;

namespace Gma.UserActivityMonitor
{
    public static partial class HookManager
    {
        //################################################################
        #region Mouse events

        private static event MouseEventHandler s_MouseMove;


        public static event MouseEventHandler MouseMove
        {
            add
            {
                EnsureSubscribedToGlobalMouseEvents();
                s_MouseMove += value;
            }

            remove
            {
                s_MouseMove -= value;
                TryUnsubscribeFromGlobalMouseEvents();
            }
        }

        private static event EventHandler<MouseEventExtArgs> s_MouseMoveExt;


        public static event EventHandler<MouseEventExtArgs> MouseMoveExt
        {
            add
            {
                EnsureSubscribedToGlobalMouseEvents();
                s_MouseMoveExt += value;
            }

            remove
            {

                s_MouseMoveExt -= value;
                TryUnsubscribeFromGlobalMouseEvents();
            }
        }

        private static event MouseEventHandler s_MouseClick;


        public static event MouseEventHandler MouseClick
        {
            add
            {
                EnsureSubscribedToGlobalMouseEvents();
                s_MouseClick += value;
            }
            remove
            {
                s_MouseClick -= value;
                TryUnsubscribeFromGlobalMouseEvents();
            }
        }

        private static event EventHandler<MouseEventExtArgs> s_MouseClickExt;


        public static event EventHandler<MouseEventExtArgs> MouseClickExt
        {
            add
            {
                EnsureSubscribedToGlobalMouseEvents();
                s_MouseClickExt += value;
            }
            remove
            {
                s_MouseClickExt -= value;
                TryUnsubscribeFromGlobalMouseEvents();
            }
        }

        private static event MouseEventHandler s_MouseDown;

        /// <summary>
        /// Occurs when the mouse a mouse button is pressed. 
        /// </summary>
        public static event MouseEventHandler MouseDown
        {
            add
            {
                EnsureSubscribedToGlobalMouseEvents();
                s_MouseDown += value;
            }
            remove
            {
                s_MouseDown -= value;
                TryUnsubscribeFromGlobalMouseEvents();
            }
        }

        private static event MouseEventHandler s_MouseUp;

        /// <summary>
        /// Occurs when a mouse button is released. 
        /// </summary>
        public static event MouseEventHandler MouseUp
        {
            add
            {
                EnsureSubscribedToGlobalMouseEvents();
                s_MouseUp += value;
            }
            remove
            {
                s_MouseUp -= value;
                TryUnsubscribeFromGlobalMouseEvents();
            }
        }

        private static event MouseEventHandler s_MouseWheel;

        /// <summary>
        /// Occurs when the mouse wheel moves. 
        /// </summary>
        public static event MouseEventHandler MouseWheel
        {
            add
            {
                EnsureSubscribedToGlobalMouseEvents();
                s_MouseWheel += value;
            }
            remove
            {
                s_MouseWheel -= value;
                TryUnsubscribeFromGlobalMouseEvents();
            }
        }


        private static event MouseEventHandler s_MouseDoubleClick;


        public static event MouseEventHandler MouseDoubleClick
        {
            add
            {
                EnsureSubscribedToGlobalMouseEvents();
                if (s_MouseDoubleClick == null)
                {
                    //We create a timer to monitor interval between two clicks
                    s_DoubleClickTimer = new Timer
                    {
                        //This interval will be set to the value we retrive from windows. This is a windows setting from contro planel.
                        Interval = GetDoubleClickTime(),
                        //We do not start timer yet. It will be start when the click occures.
                        Enabled = false
                    };
                    //We define the callback function for the timer
                    s_DoubleClickTimer.Tick += DoubleClickTimeElapsed;
                    //We start to monitor mouse up event.
                    MouseUp += OnMouseUp;
                }
                s_MouseDoubleClick += value;
            }
            remove
            {
                if (s_MouseDoubleClick != null)
                {
                    s_MouseDoubleClick -= value;
                    if (s_MouseDoubleClick == null)
                    {
                        //Stop monitoring mouse up
                        MouseUp -= OnMouseUp;
                        //Dispose the timer
                        s_DoubleClickTimer.Tick -= DoubleClickTimeElapsed;
                        s_DoubleClickTimer = null;
                    }
                }
                TryUnsubscribeFromGlobalMouseEvents();
            }
        }


        private static MouseButtons s_PrevClickedButton;

        private static Timer s_DoubleClickTimer;

        private static void DoubleClickTimeElapsed(object sender, EventArgs e)
        {
            //Timer is alapsed and no second click ocuured
            s_DoubleClickTimer.Enabled = false;
            s_PrevClickedButton = MouseButtons.None;
        }


        private static void OnMouseUp(object sender, MouseEventArgs e)
        {
            //This should not heppen
            if (e.Clicks < 1) { return; }
            //If the secon click heppened on the same button
            if (e.Button.Equals(s_PrevClickedButton))
            {
                if (s_MouseDoubleClick != null)
                {
                    //Fire double click
                    s_MouseDoubleClick.Invoke(null, e);
                }
                //Stop timer
                s_DoubleClickTimer.Enabled = false;
                s_PrevClickedButton = MouseButtons.None;
            }
            else
            {
                //If it was the firts click start the timer
                s_DoubleClickTimer.Enabled = true;
                s_PrevClickedButton = e.Button;
            }
        }
        #endregion

        //################################################################
        #region Keyboard events

        private static event KeyPressEventHandler s_KeyPress;


        public static event KeyPressEventHandler KeyPress
        {
            add
            {
                EnsureSubscribedToGlobalKeyboardEvents();
                s_KeyPress += value;
            }
            remove
            {
                s_KeyPress -= value;
                TryUnsubscribeFromGlobalKeyboardEvents();
            }
        }

        private static event KeyEventHandler s_KeyUp;


        public static event KeyEventHandler KeyUp
        {
            add
            {
                EnsureSubscribedToGlobalKeyboardEvents();
                s_KeyUp += value;
            }
            remove
            {
                s_KeyUp -= value;
                TryUnsubscribeFromGlobalKeyboardEvents();
            }
        }

        private static event KeyEventHandler s_KeyDown;


        public static event KeyEventHandler KeyDown
        {
            add
            {
                EnsureSubscribedToGlobalKeyboardEvents();
                s_KeyDown += value;
            }
            remove
            {
                s_KeyDown -= value;
                TryUnsubscribeFromGlobalKeyboardEvents();
            }
        }


        #endregion
    }
}
