using ConsoleGUI.ConsoleDisplay;

namespace ConsoleGUI.ConsoleInput;

public readonly record struct KeyboardState
{
    public KeyboardState(ref readonly NativeConsole.KeyEventRecord keyEventRecord)
    {
        Pressed = keyEventRecord.KeyDown;
        Char = keyEventRecord.UnicodeChar;
        Modifiers = (KeyModifiers) keyEventRecord.ControlKeyState;
        Key = (ConsoleKey) keyEventRecord.VirtualKeyCode;
    }

    public ConsoleKey Key { get; }
    public char Char { get; }
    public bool Pressed { get; }
    public KeyModifiers Modifiers { get; }
}