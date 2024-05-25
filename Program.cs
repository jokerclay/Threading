using System;
using System.Threading;
using System.Timers;

ServerClass serverObject = new ServerClass();

serverObject.testdata = "adfas";

// Thread InstanceCaller = new Thread(serverObject.InstanceMethod);
//
// InstanceCaller.Start();
//
// Console.WriteLine("Main thread are calling this line after " +
//         "start a new thread  InstanceCaller thread"
//         );
//
// Thread StaticCaller = new Thread(
//         new ThreadStart(ServerClass.StaticMethod));
// StaticCaller.Start();

Thread t = new Thread(new ThreadStart(serverObject.printData));
t.Start();

System.Timers.Timer aTimer;

void SetTimer()
{
    // Create a timer with a two second interval.
    aTimer = new System.Timers.Timer(2000);
    // Hook up the Elapsed event for the timer. 
    aTimer.Elapsed += OnTimedEvent;
    aTimer.AutoReset = true;
    aTimer.Enabled = true;
}

void OnTimedEvent(Object source, ElapsedEventArgs e)
{
    Console.WriteLine("Main Thread is running ... {0:HH:mm:ss.fff}",
            e.SignalTime);
}

SetTimer();


Console.WriteLine("\nPress the Enter key to exit the application...\n");
Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
Console.ReadLine();
aTimer.Stop();
aTimer.Dispose();

Console.WriteLine("Terminating the application...");


public class ServerClass
{
    public string testdata {get;set;} = string.Empty;

    // The method that will be called when the thread is started.
    public void InstanceMethod()
    {

        Console.WriteLine(
                " -------------  threading 1 ------------- begin ");
        Console.WriteLine(
                "ServerClass.InstanceMethod is running on another thread.");

        // Pause for a moment to provide a delay to make
        // threads more apparent.
        Thread.Sleep(3000);
        Console.WriteLine(
                " -------------  threading 1 ------------- end ");
    }

    public static void StaticMethod()
    {

        Console.WriteLine(
                " -------------  threading 2 ------------- begin ");
        Console.WriteLine(
                "ServerClass.StaticMethod is running on another thread.");

        // Pause for a moment to provide a delay to make
        // threads more apparent.
        Thread.Sleep(15000);
        Console.WriteLine(
                " -------------  threading 2 ------------- end ");
    }

    public void printData()
    {

        Console.WriteLine(
                " -------------  threading 3 ------------- begin ");
        Console.WriteLine("---->" + testdata );
        // Pause for a moment to provide a delay to make
        // threads more apparent.
        Thread.Sleep(15000);
        Console.WriteLine(
                " -------------  threading 3 ------------- end ");
    }
}

