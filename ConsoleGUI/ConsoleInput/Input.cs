using ConsoleGUI.ConsoleDisplay;

namespace ConsoleGUI.ConsoleInput;

public static class Input
{
    public static bool TreatControlCAsInput
    {
        get => Console.TreatControlCAsInput;
        set => Console.TreatControlCAsInput = value;
    }
    
    private static volatile bool _running;

    public static void Init()
    {
        SetConsoleFlags();
        
        new Thread(HandleInput).Start();
    }
    
    public static void Stop() => _running = false;

    private static void SetConsoleFlags()
    {
        if (_running) return;
        _running = true;
        
        var handle = NativeConsole.HandleIn;
        
        var mode = 0u;
        if (handle == -1 || !NativeConsole.GetConsoleMode(handle, ref mode))
        {
            throw new InvalidOperationException("Unable to set console input flags");
        }

        mode &= ~NativeConsole.EnableQuickEditMode;
        mode |= NativeConsole.EnableWindowInput;
        mode |= NativeConsole.EnableMouseInput;

        NativeConsole.SetConsoleMode(handle, mode);
    }
    
    private static void HandleInput()
    {
        try
        {
            MainLoop();
        }
        catch (Exception e)
        {
            Application.Exit(e);
        }
    }
    
    private static void MainLoop()
    {
        var handleIn = NativeConsole.GetStdHandle(NativeConsole.StdHandleIn);
        var recordArray = new[] {new NativeConsole.InputRecord()};

        while (_running)
        {
            uint numRead = 0;
            NativeConsole.ReadConsoleInput(handleIn, recordArray, 1, ref numRead);

            var record = recordArray[0];

            switch (record.EventType)
            {
                case NativeConsole.MouseEventCode:
                    HandleMouse(new MouseState(ref record.MouseEventRecord));
                    break;

                case NativeConsole.KeyEventCode:
                    HandleKeyboard(new KeyboardState(ref record.KeyEventRecord));
                    break;

                case NativeConsole.WindowBufferSizeEvent:
                    break;
            }
        }
    }

    private static void HandleMouse(MouseState mouseState)
    {
        Console.Write($"\r{mouseState}            ");
    }

    private static void HandleKeyboard(KeyboardState keyboardState)
    {
        Console.Write($"\r{keyboardState}            ");

    }
}