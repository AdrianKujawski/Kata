using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SoundTest
{
    class Mp3Player : IDisposable
    {
        public bool Repeat { get; set; }

        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand,
            StringBuilder strReturn, int iReturnLenght, IntPtr hwndCallback);


        public Mp3Player(string fileName)
        {
            const string FORMAT = @"open ""{0}"" type mpegvideo alias MediaFile";
            string command = string.Format(FORMAT, fileName);
            mciSendString(command, null, 0, IntPtr.Zero);
        }

        public void Play()
        {
	        string command = "play MediaFile";
	        mciSendString(command, null, 0, IntPtr.Zero);

        }

        public void Stop()
        {
            string command = "stop MediaFile";
            mciSendString(command, null, 0, IntPtr.Zero);

        }

        public void Dispose()
        {
            string command = "close MediaFile";
            mciSendString(command, null, 0, IntPtr.Zero);
        }
    }
}
