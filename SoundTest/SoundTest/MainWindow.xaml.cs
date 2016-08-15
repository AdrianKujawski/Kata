using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Forms;


namespace SoundTest
{
    public partial class MainWindow : Window
    {
        private Mp3Player _mp3Player;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void open_button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dlgOpen = new System.Windows.Forms.OpenFileDialog();
            
                dlgOpen.Filter = "Mp3 File|*.mp3";
                dlgOpen.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

                if (dlgOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (_mp3Player != null)
                        _mp3Player.Dispose();

                    _mp3Player = new Mp3Player(dlgOpen.FileName);
                    _mp3Player.Repeat = true;
                }
            
        }

        private void play_button_Click(object sender, RoutedEventArgs e)
        {
			if (_mp3Player != null)
				_mp3Player.Play();

		}

        private void stop_button_Click(object sender, RoutedEventArgs e)
        {
            if (_mp3Player != null)
                _mp3Player.Stop();
        }

        private void button_delete_Click(object sender, RoutedEventArgs e)
        {
            if (_mp3Player != null)
                _mp3Player.Dispose();
        }
    }
}
