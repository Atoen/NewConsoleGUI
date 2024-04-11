namespace ConsoleGUI.ConsoleInput;

[Flags]
public enum MouseButton : byte
{
    None = 0,
    Left = 1,
    Right = 2,
    Middle = 4
}

[Flags]
public enum MouseEventFlags : byte
{
    Moved = 1,
    DoubleClicked = 2,
    Wheeled = 4,
    HorizontalWheeled = 8
}

public enum MouseWheelState : ulong
{
    Up = 0xff880000,
    AnsiUp = 0xff800000,
    Down = 0x780000,
    AnsiDown = 0x800000
}

[Flags]
public enum KeyModifiers : byte
{
    None = 0,
    RightAlt = 1,
    LeftAlt = 2,
    RightControl = 4,
    LeftControl = 8,
    Shift = 16
}