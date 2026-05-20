using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class SmoothPanel : Panel
{
    private const int SB_HORZ = 0;
    private const int SB_VERT = 1;

    [DllImport("user32.dll")]
    private static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);

    public SmoothPanel()
    {
        this.AutoScroll = true;

        // Reduce flicker
        this.DoubleBuffered = true;

        this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                      ControlStyles.UserPaint |
                      ControlStyles.OptimizedDoubleBuffer,
                      true);

        this.UpdateStyles();
    }

    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);

        // Hide scrollbars
        ShowScrollBar(this.Handle, SB_HORZ, false);
        ShowScrollBar(this.Handle, SB_VERT, false);
    }

    protected override void OnLayout(LayoutEventArgs levent)
    {
        base.OnLayout(levent);

        // Add 25px extra scrollable space at the bottom
        this.AutoScrollMinSize = new Size(0, GetContentHeight() + 25);
    }

   /*
    * calculating the height of all components so that a 25px padding is added at the bottom
    */
    private int GetContentHeight()
    {
        int max = 0;

        foreach (Control c in this.Controls)
        {
            max = Math.Max(max, c.Bottom);
        }

        return max;
    }
}