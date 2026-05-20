using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace McClean_Teeth.Util.UI_Components
{
    public class Calendar : Control
    {
        private DateTime _displayDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        private DateTime? _selectedDate = DateTime.Today;

        private readonly Color ThemeColor = Color.FromArgb(196, 178, 141);
        private readonly Color ThemeLight = Color.FromArgb(226, 208, 171);

        private Rectangle _prevButton;
        private Rectangle _nextButton;

        private Rectangle _hourRect;
        private Rectangle _minuteRect;
        private Rectangle _hourUpRect;
        private Rectangle _hourDownRect;
        private Rectangle _minuteUpRect;
        private Rectangle _minuteDownRect;

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

        public Calendar()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;

            Font = new Font("Segoe UI", 14f);

            MinimumSize = new Size(350, 450);
            Size = new Size(700, 450);

            BackColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(BackColor);

            int headerHeight = Math.Max(56, Height / 10);
            int dayHeaderHeight = Math.Max(28, Height / 14);

            const int timeGap = 20;
            const int bottomPadding = 20;
            const int timeAreaHeight = 92;

            int cellWidth = Width / 7;

            Rectangle headerRect = new Rectangle(0, 0, Width, headerHeight);

            using (SolidBrush b = new SolidBrush(ThemeColor))
                g.FillRectangle(b, headerRect);

            _prevButton = new Rectangle(10, 10, 40, headerHeight - 20);
            _nextButton = new Rectangle(Width - 50, 10, 40, headerHeight - 20);

            using (Font navFont = new Font(Font.FontFamily, Font.Size + 4, FontStyle.Bold))
            {
                DateTime minMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                bool canGoBack = _displayDate > minMonth;

                if (canGoBack)
                    DrawCenteredString(g, "<", navFont, Brushes.White, _prevButton);

                DrawCenteredString(g, ">", navFont, Brushes.White, _nextButton);
            }

            DrawCenteredString(
                g,
                _displayDate.ToString("MMMM yyyy"),
                Font,
                Brushes.White,
                headerRect);

            string[] days = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

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

            DateTime firstDay = new DateTime(_displayDate.Year, _displayDate.Month, 1);
            int startOffset = ((int)firstDay.DayOfWeek + 6) % 7;
            int daysInMonth = DateTime.DaysInMonth(_displayDate.Year, _displayDate.Month);
            int rowsNeeded = Math.Max(1, (startOffset + daysInMonth + 6) / 7);

            int gridTop = headerHeight + dayHeaderHeight;
            int timeTop = Height - bottomPadding - timeAreaHeight;
            int gridBottom = timeTop - timeGap;
            int gridHeight = Math.Max(1, gridBottom - gridTop);
            int cellHeight = Math.Max(1, gridHeight / rowsNeeded);

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

                DateTime currentDate = new DateTime(_displayDate.Year, _displayDate.Month, day);
                bool isPast = currentDate.Date < DateTime.Today;
                bool isSelected =
                    _selectedDate.HasValue &&
                    currentDate.Date == _selectedDate.Value.Date;

                if (isSelected)
                {
                    using (SolidBrush b = new SolidBrush(ThemeColor))
                        g.FillRectangle(b, rect);
                }
                else if (isPast)
                {
                    using (SolidBrush b = new SolidBrush(Color.FromArgb(245, 245, 245)))
                        g.FillRectangle(b, rect);
                }

                g.DrawRectangle(Pens.LightGray, rect);

                Brush textBrush =
                    isPast
                        ? Brushes.Gray
                        : isSelected
                            ? Brushes.White
                            : Brushes.Black;

                DrawCenteredString(g, day.ToString(), Font, textBrush, rect);
            }

            int boxWidth = 90;
            int boxHeight = 40;
            int arrowHeight = 18;
            int arrowWidth = 34;
            int spacing = 16;
            int gapBetweenBoxAndArrow = 4;
            int colonWidth = 24;
            int labelWidth = 50;

            int totalWidth =
                labelWidth +
                spacing +
                boxWidth +
                colonWidth +
                boxWidth +
                spacing;

            int startX = (Width - totalWidth) / 2;
            int topY = timeTop + 8;

            Rectangle labelRect = new Rectangle(startX, topY + 18, labelWidth, boxHeight);

            int hourX = labelRect.Right + spacing;
            int minuteX = hourX + boxWidth + colonWidth;

            _hourUpRect = new Rectangle(hourX + (boxWidth - arrowWidth) / 2, topY, arrowWidth, arrowHeight);
            _hourRect = new Rectangle(hourX, _hourUpRect.Bottom + gapBetweenBoxAndArrow, boxWidth, boxHeight);
            _hourDownRect = new Rectangle(hourX + (boxWidth - arrowWidth) / 2, _hourRect.Bottom + gapBetweenBoxAndArrow, arrowWidth, arrowHeight);

            Rectangle colonRect = new Rectangle(_hourRect.Right, _hourRect.Top, colonWidth, boxHeight);

            _minuteUpRect = new Rectangle(minuteX + (boxWidth - arrowWidth) / 2, topY, arrowWidth, arrowHeight);
            _minuteRect = new Rectangle(minuteX, _minuteUpRect.Bottom + gapBetweenBoxAndArrow, boxWidth, boxHeight);
            _minuteDownRect = new Rectangle(minuteX + (boxWidth - arrowWidth) / 2, _minuteRect.Bottom + gapBetweenBoxAndArrow, arrowWidth, arrowHeight);

            DrawCenteredString(g, "Time", Font, Brushes.Black, labelRect);

            DrawArrowButton(g, _hourUpRect, true);
            DrawInputBox(g, _hourRect, _selectedHour.ToString("00"));
            DrawArrowButton(g, _hourDownRect, false);

            DrawCenteredString(g, ":", Font, Brushes.Black, colonRect);

            DrawArrowButton(g, _minuteUpRect, true);
            DrawInputBox(g, _minuteRect, _selectedMinute.ToString("00"));
            DrawArrowButton(g, _minuteDownRect, false);
        }

        private void DrawInputBox(Graphics g, Rectangle rect, string text)
        {
            using (SolidBrush b = new SolidBrush(Color.White))
                g.FillRectangle(b, rect);

            using (Pen p = new Pen(ThemeColor, 2))
                g.DrawRectangle(p, rect);

            DrawCenteredString(g, text, Font, Brushes.Black, rect);
        }

        private void DrawArrowButton(Graphics g, Rectangle rect, bool up)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(Color.FromArgb(110, 110, 110), 2.5f))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                pen.LineJoin = LineJoin.Round;

                int centerX = rect.Left + rect.Width / 2;
                int centerY = rect.Top + rect.Height / 2;
                int size = Math.Min(rect.Width, rect.Height) / 3;

                if (up)
                {
                    g.DrawLines(
                        pen,
                        new[]
                        {
                    new Point(centerX - size, centerY + size / 2),
                    new Point(centerX, centerY - size / 2),
                    new Point(centerX + size, centerY + size / 2)
                        });
                }
                else
                {
                    g.DrawLines(
                        pen,
                        new[]
                        {
                    new Point(centerX - size, centerY - size / 2),
                    new Point(centerX, centerY + size / 2),
                    new Point(centerX + size, centerY - size / 2)
                        });
                }
            }
        }

        private void DrawCenteredString(
            Graphics g,
            string text,
            Font font,
            Brush brush,
            Rectangle rect)
        {
            using (StringFormat sf = new StringFormat
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

            DateTime minMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            bool canGoBack = _displayDate > minMonth;

            if (_nextButton.Contains(e.Location))
            {
                DisplayDate = DisplayDate.AddMonths(1);
                return;
            }

            if (canGoBack && _prevButton.Contains(e.Location))
            {
                DisplayDate = DisplayDate.AddMonths(-1);
                return;
            }

            if (_hourUpRect.Contains(e.Location))
            {
                _selectedHour = (_selectedHour + 1) % 24;
                Invalidate();
                return;
            }

            if (_hourDownRect.Contains(e.Location))
            {
                _selectedHour = (_selectedHour - 1 + 24) % 24;
                Invalidate();
                return;
            }

            if (_minuteUpRect.Contains(e.Location))
            {
                _selectedMinute = (_selectedMinute + 1) % 60;
                Invalidate();
                return;
            }

            if (_minuteDownRect.Contains(e.Location))
            {
                _selectedMinute = (_selectedMinute - 1 + 60) % 60;
                Invalidate();
                return;
            }

            int headerHeight = Math.Max(56, Height / 10);
            int dayHeaderHeight = Math.Max(28, Height / 14);

            const int timeGap = 20;
            const int bottomPadding = 20;
            const int timeAreaHeight = 92;

            DateTime firstDay = new DateTime(_displayDate.Year, _displayDate.Month, 1);
            int startOffset = ((int)firstDay.DayOfWeek + 6) % 7;
            int daysInMonth = DateTime.DaysInMonth(_displayDate.Year, _displayDate.Month);
            int rowsNeeded = Math.Max(1, (startOffset + daysInMonth + 6) / 7);

            int gridTop = headerHeight + dayHeaderHeight;
            int timeTop = Height - bottomPadding - timeAreaHeight;
            int gridBottom = timeTop - timeGap;
            int gridHeight = Math.Max(1, gridBottom - gridTop);

            int cellWidth = Width / 7;
            int cellHeight = Math.Max(1, gridHeight / rowsNeeded);

            if (e.Y < gridTop || e.Y >= gridTop + (rowsNeeded * cellHeight))
                return;

            int col = e.X / cellWidth;
            int row = (e.Y - gridTop) / cellHeight;

            int clickedIndex = row * 7 + col;
            int day = clickedIndex - startOffset + 1;

            if (day < 1 || day > daysInMonth)
                return;

            DateTime clickedDate = new DateTime(_displayDate.Year, _displayDate.Month, day);

            if (clickedDate.Date < DateTime.Today)
                return;

            SelectedDate = clickedDate;
        }
    }
}