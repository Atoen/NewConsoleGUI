using ConsoleGUI.ConsoleDisplay;
using ConsoleGUI.ConsoleInput;

namespace ConsoleGUI;

public static class Application
{
    public const string DefaultTitle = "GUI App";
    
    public static void Start(string title = "", DisplayMode displayMode = DisplayMode.Auto)
    {
        Console.Title = title != string.Empty ? title : DefaultTitle;
        Display.Init(displayMode);
        Input.Init();
    }

    static Application()
    {
        Console.CancelKeyPress += delegate
        {
            Environment.Exit(Environment.ExitCode);
        };

        AppDomain.CurrentDomain.ProcessExit += delegate
        {

        };
    }

    public static void Exit(Exception? exception = null)
    {
        try
        {
            Display.Stop();
            Input.Stop();
        }
        finally
        {
            Console.Clear();

            if (exception is not null)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
