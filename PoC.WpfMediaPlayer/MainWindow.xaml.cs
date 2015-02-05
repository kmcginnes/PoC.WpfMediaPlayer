using System;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Win32;

namespace PoC.WpfMediaPlayer
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (mePlayer.Source != null)
            {
                if (mePlayer.NaturalDuration.HasTimeSpan)
                    lblStatus.Content = String.Format("{0} / {1}", mePlayer.Position.ToString(@"mm\:ss"),
                        mePlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
            }
            else
                lblStatus.Content = "No file selected...";
        }

        void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            mePlayer.Play();
        }

        void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mePlayer.Pause();
        }

        void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mePlayer.Stop();
        }

        void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            mePlayer.Pause();

            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Video files (*.ts)|*.ts|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = @"C:\";
            var confirm = openFileDialog.ShowDialog();
            if (confirm.HasValue && confirm.Value)
            {
                var uri = new Uri(openFileDialog.FileName, UriKind.Absolute);
                mePlayer.Source = uri;
            }
        }
    }
}
