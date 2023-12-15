using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PraktikaDesyatov
{
    public partial class MainWindow : Window
    {
        private List<int> _attendanceList;

        public MainWindow()
        {
            InitializeComponent();

            _attendanceList = new List<int>();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            int attendance;
            if (int.TryParse(AttendanceTextBox.Text, out attendance))
            {
                _attendanceList.Add(attendance);
                DrawAttendanceGraph();
                AttendanceTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Invalid input!");
            }
        }

        private void DrawAttendanceGraph()
        {
            AttendanceGraphCanvas.Children.Clear();

            int maxAttendance = 0;
            int minAttendance = int.MaxValue;

            for (int i = 0; i < _attendanceList.Count; i++)
            {
                int day = i + 1;
                int attendance = _attendanceList[i];

                maxAttendance = Math.Max(maxAttendance, attendance);
                minAttendance = Math.Min(minAttendance, attendance);

                Rectangle rect = new Rectangle();
                rect.Width = 10;
                rect.Height = attendance * 2;
                rect.Fill = Brushes.Blue;
                Canvas.SetLeft(rect, 20 + i * 30);
                Canvas.SetBottom(rect, 20);
                AttendanceGraphCanvas.Children.Add(rect);

                TextBlock dayTextBlock = new TextBlock();
                dayTextBlock.Text = day.ToString();
                Canvas.SetLeft(dayTextBlock, 15 + i * 30);
                Canvas.SetBottom(dayTextBlock, 0);
                AttendanceGraphCanvas.Children.Add(dayTextBlock);
            }

            TextBlock maxAttendanceTextBlock = new TextBlock();
            maxAttendanceTextBlock.Text = "Max Attendance: " + maxAttendance;
            maxAttendanceTextBlock.Foreground = Brushes.Red;
            Canvas.SetLeft(maxAttendanceTextBlock, 10);
            Canvas.SetTop(maxAttendanceTextBlock, 10);
            AttendanceGraphCanvas.Children.Add(maxAttendanceTextBlock);

            TextBlock minAttendanceTextBlock = new TextBlock();
            minAttendanceTextBlock.Text = "Min Attendance: " + minAttendance;
            minAttendanceTextBlock.Foreground = Brushes.Red;
            Canvas.SetLeft(minAttendanceTextBlock, 10);
            Canvas.SetTop(minAttendanceTextBlock, 30);
            AttendanceGraphCanvas.Children.Add(minAttendanceTextBlock);
        }
    }
}