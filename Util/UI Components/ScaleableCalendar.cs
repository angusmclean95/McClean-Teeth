using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McClean_Teeth.Util.UI_Components
{
    public class ScalableCalendar : Control
    {
        private DateTime _displayDate = DateTime.Today;
        private DateTime? _selectedDate = DateTime.Now;

        // ===== THEME =====
        private readonly Color ThemeColor = Color.FromArgb(196, 178, 141);
        private readonly Color ThemeLight = Color.FromArgb(226, 208, 171);

        // ===== UI =====
        private Rectangle _prevButton;
        private Rectangle _nextButton;
        private Rectangle _timeRect;

        // ===== TIME =====
        private int _selectedHour = DateTime.Now.Hour;
        private int _selectedMinute = DateTime.Now.Minute;

        public DateTime SelectedDateTime =>
            new DateTime(
                SelectedDate.Value.Year,
                SelectedDate.Value.Month,
                SelectedDate.Value.Day,
                _selectedHour,
                _selectedMinute,
                0);

        public DateTime DisplayDate
        {
            get => _displayDate;
            set
            {
                // Prevent going into the past
                DateTime minMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

                if (value < minMonth)
                    value = minMonth;

                _displayDate = new DateTime(value.Year, value.Month, 1);

                Invalidate();
            }
        }

        public DateTime? SelectedDate
        {
            get => _selectedDate;
            set
            {
                if (value.HasValue && value.Value.Date < DateTime.Today)
                    return;

                _selectedDate = value;
                Invalidate();
            }
        }

        public ScalableCalendar()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;

            Font = new Font("Segoe UI", 14f);

            MinimumSize = new Size(350, 400);
            Size = new Size(700, 600);

            BackColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            g.Clear(BackColor);

            int headerHeight = Height / 10;
            int dayHeaderHeight = Height / 14;
            int footerHeight = Height / 8;

            // ===== HEADER =====

            Rectangle headerRect = new Rectangle(0, 0, Width, headerHeight);

            using (SolidBrush b = new SolidBrush(ThemeColor))
                g.FillRectangle(b, headerRect);

            _prevButton = new Rectangle(10, 10, 40, headerHeight - 20);
            _nextButton = new Rectangle(Width - 50, 10, 40, headerHeight - 20);

            using (Font navFont = new Font(Font.FontFamily, Font.Size + 4, FontStyle.Bold))
            {
                // Prev disabled when current month
                bool canGoBack =
                    _displayDate >
                    new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

                if (canGoBack)
                    g.DrawString("<", navFont, Brushes.White, _prevButton);

                g.DrawString(">", navFont, Brushes.White, _nextButton);
            }

            using (StringFormat sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            })
            {
                g.DrawString(
                    _displayDate.ToString("MMMM yyyy"),
                    Font,
                    Brushes.White,
                    headerRect,
                    sf);
            }

            // ===== DAY NAMES =====

            string[] days = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

            int cellWidth = Width / 7;

            for (int i = 0; i < 7; i++)
            {
                Rectangle rect = new Rectangle(
                    i * cellWidth,
                    headerHeight,
                    cellWidth,
                    dayHeaderHeight);

                using (SolidBrush b = new SolidBrush(ThemeLight))
                    g.FillRectangle(b, rect);

                DrawCenteredString(g, days[i], Font, Brushes.Black, rect);
            }

            // ===== GRID =====

            int gridTop = headerHeight + dayHeaderHeight;
            int gridHeight = Height - gridTop - footerHeight;

            int cellHeight = gridHeight / 6;

            DateTime firstDay =
                new DateTime(_displayDate.Year, _displayDate.Month, 1);

            int startOffset = ((int)firstDay.DayOfWeek + 6) % 7;

            int daysInMonth =
                DateTime.DaysInMonth(_displayDate.Year, _displayDate.Month);

            for (int day = 1; day <= daysInMonth; day++)
            {
                int index = startOffset + (day - 1);

                int row = index / 7;
                int col = index % 7;

                Rectangle rect = new Rectangle(
                    col * cellWidth,
                    gridTop + row * cellHeight,
                    cellWidth,
                    cellHeight);

                DateTime currentDate =
                    new DateTime(_displayDate.Year, _displayDate.Month, day);

                bool isPast = currentDate.Date < DateTime.Today;

                // Selected
                if (_selectedDate.HasValue &&
                    currentDate.Date == _selectedDate.Value.Date)
                {
                    using (SolidBrush b = new SolidBrush(ThemeColor))
                        g.FillRectangle(b, rect);
                }

                // Today
                if (currentDate.Date == DateTime.Today)
                {
                    using (Pen p = new Pen(ThemeColor, 3))
                        g.DrawRectangle(p, rect);
                }

                g.DrawRectangle(Pens.LightGray, rect);

                Brush textBrush =
                    isPast
                        ? Brushes.Gray
                        : (_selectedDate.HasValue &&
                           currentDate.Date == _selectedDate.Value.Date)
                            ? Brushes.White
                            : Brushes.Black;

                DrawCenteredString(
                    g,
                    day.ToString(),
                    Font,
                    textBrush,
                    rect);
            }

            // ===== TIME PICKER =====

            _timeRect = new Rectangle(
                20,
                Height - footerHeight,
                Width - 40,
                footerHeight - 20);

            using (SolidBrush b = new SolidBrush(ThemeLight))
                g.FillRectangle(b, _timeRect);

            string timeText =
                $"Time: {_selectedHour:00}:{_selectedMinute:00}";

            DrawCenteredString(
                g,
                timeText,
                Font,
                Brushes.Black,
                _timeRect);

            using (Font smallFont = new Font(Font.FontFamily, 10))
            {
                g.DrawString(
                    "Mouse Wheel = Change Time",
                    smallFont,
                    Brushes.DimGray,
                    10,
                    Height - 25);
            }
        }

        private void DrawCenteredString(
            Graphics g,
            string text,
            Font font,
            Brush brush,
            Rectangle rect)
        {
            using (StringFormat sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            })
            {
                g.DrawString(text, font, brush, rect, sf);
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            // ===== NAVIGATION =====

            if (_nextButton.Contains(e.Location))
            {
                DisplayDate = DisplayDate.AddMonths(1);
                return;
            }

            if (_prevButton.Contains(e.Location))
            {
                DateTime minMonth =
                    new DateTime(
                        DateTime.Today.Year,
                        DateTime.Today.Month,
                        1);

                if (_displayDate > minMonth)
                    DisplayDate = DisplayDate.AddMonths(-1);

                return;
            }

            int headerHeight = Height / 10;
            int dayHeaderHeight = Height / 14;
            int footerHeight = Height / 8;

            int gridTop = headerHeight + dayHeaderHeight;
            int gridHeight = Height - gridTop - footerHeight;

            int cellWidth = Width / 7;
            int cellHeight = gridHeight / 6;

            if (e.Y < gridTop || e.Y > gridTop + gridHeight)
                return;

            int col = e.X / cellWidth;
            int row = (e.Y - gridTop) / cellHeight;

            DateTime firstDay =
                new DateTime(_displayDate.Year, _displayDate.Month, 1);

            int startOffset = ((int)firstDay.DayOfWeek + 6) % 7;

            int clickedIndex = row * 7 + col;

            int day = clickedIndex - startOffset + 1;

            if (day < 1 ||
                day > DateTime.DaysInMonth(
                    _displayDate.Year,
                    _displayDate.Month))
                return;

            DateTime clickedDate =
                new DateTime(
                    _displayDate.Year,
                    _displayDate.Month,
                    day);

            // Block past dates
            if (clickedDate.Date < DateTime.Today)
                return;

            SelectedDate = clickedDate;
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            // Hovering time picker changes time
            if (_timeRect.Contains(PointToClient(MousePosition)))
            {
                if ((ModifierKeys & Keys.Shift) == Keys.Shift)
                {
                    _selectedHour += e.Delta > 0 ? 1 : -1;

                    if (_selectedHour > 23)
                        _selectedHour = 0;

                    if (_selectedHour < 0)
                        _selectedHour = 23;
                }
                else
                {
                    _selectedMinute += e.Delta > 0 ? 5 : -5;

                    if (_selectedMinute >= 60)
                        _selectedMinute = 0;

                    if (_selectedMinute < 0)
                        _selectedMinute = 55;
                }

                Invalidate();
            }
        }
    }
}
