using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DBCompare
{
    public class SyncListView : System.Windows.Forms.ListView
    {
        [DllImport("User32.dll")]
        private static extern bool SendMessage(IntPtr hwnd, UInt32 msg, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll")]
        private static extern bool ShowScrollBar(IntPtr hwnd, int wBar, bool bShow);

        [DllImport("user32.dll")]
        private static extern int SetScrollPos(IntPtr hWnd, int wBar, int nPos, bool bRedraw);

        private const int WM_HSCROLL = 0x114;

        private const int SB_HORZ = 0;
        private const int SB_VERT = 1;
        private const int SB_CTL = 2;
        private const int SB_BOTH = 3;
        private const int SB_THUMBPOSITION = 4;
        private const int SB_THUMBTRACK = 5;
        private const int SB_ENDSCROLL = 8;

        public SyncListView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // scrolled
            // 
            this.Size = new System.Drawing.Size(120, 95);
            this.ResumeLayout(false);
        }

        private readonly List<ListView> _linkedListViews = new List<ListView>();

        public void AddLinkedView(ListView listView)
        {
            if (!_linkedListViews.Contains(listView))
            {
                _linkedListViews.Add(listView);

                HideScrollBar(listView);
            }
        }

        public bool RemoveLinkedView(ListView listView)
        {
            return _linkedListViews.Remove(listView);
        }

        private void HideScrollBar(ListView listView)
        {
            //Make sure the list view is scrollable
            listView.Scrollable = true;

            //Then hide the scroll bar
            ShowScrollBar(listView.Handle, SB_BOTH, false);
        }
        /*
        protected override void WndProc(ref Message msg)
        {
            if (_linkedListViews.Count > 0)
            {
                //Look for WM_HSCROLL messages
                if (msg.Msg == WM_HSCROLL)
                {
                    foreach (ListView view in _linkedListViews)
                    {
                        SendMessage(view.Handle, WM_HSCROLL, msg.WParam, IntPtr.Zero);
                    }
                }
            }
        }
        */
        public event ScrollEventHandler HScrollEvent;


        protected override void WndProc(ref System.Windows.Forms.Message msg)
        {
            if (msg.Msg == WM_HSCROLL && HScrollEvent != null)
                HScrollEvent(this, new ScrollEventArgs(ScrollEventType.ThumbTrack, (int)msg.WParam));

            base.WndProc(ref msg);
        }

        
    }
}
