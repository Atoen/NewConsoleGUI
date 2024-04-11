using System.Diagnostics;
using System.Text;

namespace ConsoleGUI.ConsoleDisplay;

public static class Display
{
    public static Vector Size => Vector.Zero;
    public static DisplayMode Mode { get; private set; }

    public static RefreshRate RefreshRate { get; set; } = new FrameRate(20);

    private static IRenderer _renderer = default!;

    private static volatile bool _running;

    public static void Init(DisplayMode displayMode)
    {
        if (_running) return;
        _running = true;
        
        Console.Clear();
        Console.CursorVisible = false;
        Console.OutputEncoding = Encoding.UTF8;

        Mode = displayMode == DisplayMode.Auto ? GetDisplayMode() : displayMode;
        
        new Thread(Start).Start();
    }

    public static void Stop() => _running = false;

    private static void Start()
    {
        try
        {
            Loop();
        }
        catch (Exception e)
        {
            Application.Exit(e);
        }
    }

    private static void Loop()
    {
        while (_running)
        {
            var start = Stopwatch.GetTimestamp();

            var elapsed = Stopwatch.GetElapsedTime(start);
            var sleepTime = RefreshRate.FrameTime - elapsed;
            
            if (sleepTime > TimeSpan.Zero) Thread.Sleep(sleepTime);
        }
    }
    
    
    private static DisplayMode GetDisplayMode()
    {
        var handle = NativeConsole.HandleOut;

        var mode = 0u;
        if (handle == -1 || !NativeConsole.GetConsoleMode(handle, ref mode))
        { 
            return DisplayMode.Native;
        }

        NativeConsole.SetConsoleMode(handle, mode | 4U);
        return DisplayMode.Ansi;
    }
}