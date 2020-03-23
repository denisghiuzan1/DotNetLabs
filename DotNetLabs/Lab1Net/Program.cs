using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

namespace Lab1Net
{
    public class Program
    {
        private static readonly List<string> actionsList = new List<string>();
        private static int number;
        private static Thread newThread;
        private static string mainThreadName;
        private static BackgroundWorker backgroundWorker;

        public static void Main()
        {
            MultiThreading();
            BackgroungW();
            Console.ReadLine();
            InfoDisplay infoDisplay = new InfoDisplay();
            Info info = new Info();

            Info.InfoDelegate del = new Info.InfoDelegate(infoDisplay.InfoChanged);
            info.InfoChanged += del;

            info.SetInfo = "changed";

            info.InfoChanged -= del;
        }

        private static void BackgroungW()
        {
            number = Convert.ToInt32(Console.ReadLine());
            backgroundWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            backgroundWorker.DoWork += Background_do;

            backgroundWorker.ProgressChanged += bw_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += bw_RunWorkerCompleted;
            backgroundWorker.RunWorkerAsync("Background worker");

            Console.WriteLine("Press Enter in the next 5 seconds to cancel");
            Console.ReadLine();

            if (backgroundWorker.IsBusy) backgroundWorker.CancelAsync();
            Console.ReadLine();


        }

        private static void Background_do(object sender, DoWorkEventArgs e)
        {

            var smallerPrime = Prime.GetBiggestSmallerPrimeNumberLazy(number);

            Console.WriteLine(smallerPrime);
        }

        static void bw_RunWorkerCompleted(object sender,
            RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                Console.WriteLine("You canceled!");
            else if (e.Error != null)
                Console.WriteLine("Worker exception: " +
                                  e.Error.ToString());
            else
                Console.WriteLine("Complete: " + e.Result);
        }
        static void bw_ProgressChanged(object sender,
            ProgressChangedEventArgs e)
        {
            Console.WriteLine("Reached " + e.ProgressPercentage +
                              "%");
        }

        private static void MultiThreading()
        {
            Console.WriteLine("Insert a number or zero to exit:");
            number = Convert.ToInt32(Console.ReadLine());

            Thread.CurrentThread.Name = "main thread";
            mainThreadName = Thread.CurrentThread.Name;
            newThread = new Thread(Background_do) { Name = "new thread" };
            newThread.Start();

            Go();
            ThreadInterruptedException exception = new ThreadInterruptedException();
            newThread.Join();
            Console.WriteLine("#############");
            foreach (var action in actionsList) Console.WriteLine(action);

            Console.ReadKey();
        }

        public static void Background_do()
        {
            var timeStamp = DateTime.Now;
            if (newThread.IsAlive)
            {
                actionsList.Add($"Iesire temporara thread {mainThreadName}, {timeStamp}");
            }

            timeStamp = DateTime.Now;
            actionsList.Add($"Start thread: {newThread.Name}, {timeStamp} Numar natural dat: {number}");
            var smallerPrime = Prime.GetBiggestSmallerPrimeNumberLazy(number);

            timeStamp = DateTime.Now;
            actionsList.Add($"End thread: {newThread.Name}, {timeStamp}, Numar prim: {smallerPrime}");
        }

        public static void Go()
        {
            Thread.Sleep(1000);
            Console.WriteLine("4");
            var timeStamp = DateTime.Now;
            if (Thread.CurrentThread.IsAlive)
            {
                actionsList.Add($"Iesire temporara thread {newThread.Name}, {timeStamp}");
            }
            timeStamp = DateTime.Now;
            actionsList.Add($"Start thread: {mainThreadName}, {timeStamp}, Numar natural dat: {number}");
            Console.WriteLine("5");
            var smallerPrime = Prime.GetBiggestSmallerPrimeNumber(number);
            timeStamp = DateTime.Now;
            actionsList.Add($"End thread: {mainThreadName}, {timeStamp}, Numar prim: {smallerPrime}");
            Console.WriteLine("6");
        }
    }
}