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
}