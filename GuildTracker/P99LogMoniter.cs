using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuildTracker
{
    public sealed class P99LogMonitor :IDisposable
    {
        //  Singleton. Only one Log moniter can exist.
        private static P99LogMonitor instance = null;
        
        //  File system event driven watcher.
        private static FileSystemWatcher dirWatcher;

        //  Threading variables.
        private AutoResetEvent mResetEvent = new AutoResetEvent(false);
        private Thread logMonitorThread = null;
        private bool monitoring = false;
        private bool stopWatching = false;

        //  File that changed.
        private string detectedChangedFile;

        //  Logging events        
        public delegate void LogMonitorNewLinCaptureHandler(string text);
        public static event LogMonitorNewLinCaptureHandler OnNewLineCaptured;
        public delegate void LogMonitorNewFileCaptureHamdler(string filename);
        public static event LogMonitorNewFileCaptureHamdler OnNewFileCaptured;

        //  Time of last parsed log entry.
        private DateTime lastLogTick;

        private P99LogMonitor()
        {

        }

        public static void StartMoniteringAtLocation(string location)
        {
            P99LogMonitor.StopMonitering();
            P99LogMonitor.instance = new P99LogMonitor();

            MonitorLocation(location);
            FileReadingThread();
            P99LogMonitor.instance.logMonitorThread.Start();
        }

        private static void FileReadingThread()
        {
            // The logging thread.
            P99LogMonitor.instance.logMonitorThread = new Thread(() =>
            {
                //  Wait for a signal from the file system watcher before starting the watch loop.
                P99LogMonitor.instance.mResetEvent.WaitOne();
                StartWatching();
            });
            P99LogMonitor.instance.logMonitorThread.SetApartmentState(ApartmentState.STA);
        }

        private static void StartWatching()
        {
            while (!P99LogMonitor.instance.stopWatching)
            {
                if (!(P99LogMonitor.instance.monitoring))
                {
                    OpenLogFile();
                }
            }
        }

        private static void OpenLogFile()
        {
            //  We opened a new stream. This is likely a new play session. 
            OnNewFileCaptured?.Invoke(P99LogMonitor.instance.detectedChangedFile);

            //  Open a stream using the changed file and seek to the end.
            FileStream fs = new FileStream(P99LogMonitor.instance.detectedChangedFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            //  Start reading from the bottom of the log.
            fs.Seek(0, SeekOrigin.End);

            //  Let's read the stream.
            P99LogMonitor.instance.monitoring = true;
            using (StreamReader sr = new StreamReader(fs))
            {
                //  Will contain the log contents since last read
                MonitorLogFile(fs, sr);
            }
            fs.Close();
        }

        private static void MonitorLogFile(FileStream fs, StreamReader sr)
        {
            string s = "";
            while (P99LogMonitor.instance.monitoring && !P99LogMonitor.instance.stopWatching)
            {
                //  Read until end of file.
                while (!sr.EndOfStream)
                {
                    s = sr.ReadLine();
                    if ((s != null) && (s.Length != 0))
                    {
                        //  Fire off an event for data processing.
                        if (OnNewLineCaptured != null)
                        {
                            OnNewLineCaptured(s);
                        }
                    };
                    P99LogMonitor.instance.lastLogTick = DateTime.Now;
                }
                //  Wait for another ping before reading the file again. We don't want to mad cycle the log file when updates happen once every 2-3 seconds.                                
                P99LogMonitor.instance.mResetEvent.WaitOne();

                //  Different file was changed. Stop monitoring and restart.
                if (P99LogMonitor.instance.detectedChangedFile != fs.Name)
                    P99LogMonitor.instance.monitoring = false;
            }
        }

        private static void MonitorLocation(string location)
        {
            //  Setup a filesystem watcher at the given EQ log location.
            dirWatcher = new FileSystemWatcher(location);
            dirWatcher.EnableRaisingEvents = true;
            dirWatcher.Filter = "*.txt";
            dirWatcher.Changed += (s, e2) =>
            {
                //  Fires on change. Set the filename the change happened in.
                if (!e2.FullPath.Contains("dbg.txt"))
                {
                    if (P99LogMonitor.instance.detectedChangedFile != e2.FullPath)
                        P99LogMonitor.instance.detectedChangedFile = e2.FullPath;
                }

                //  Signal thread that there was a change.
                if (P99LogMonitor.instance.detectedChangedFile != null)
                    P99LogMonitor.instance.mResetEvent.Set();
            };
        }

        //  Clean up singleton instance.
        public static void StopMonitering()
        {
            //  Don't buffer cleaning up if there isn't an instance.
            if (P99LogMonitor.instance == null)
                return;

            P99LogMonitor.instance.monitoring = false;
            P99LogMonitor.instance.stopWatching = true;
            P99LogMonitor.instance.mResetEvent.Set();
            if (P99LogMonitor.instance.logMonitorThread != null)
                P99LogMonitor.instance.logMonitorThread.Join();
            P99LogMonitor.instance = null;

            //OnNewLineCaptured = null;
            //OnNewFileCaptured = null;
        }

        public void Dispose()
        {
            StopMonitering();
        }
    }
}
