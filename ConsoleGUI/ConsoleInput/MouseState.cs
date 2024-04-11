using ConsoleGUI.ConsoleDisplay;

namespace ConsoleGUI.ConsoleInput;

public readonly record struct MouseState
{
    public MouseState(ref readonly NativeConsole.MouseEventRecord mouseEventRecord)
    {
        Position = new Vector(mouseEventRecord.MousePosition.X, mouseEventRecord.MousePosition.Y);
        Buttons = (MouseButton) mouseEventRecord.ButtonState;
        Flags = (MouseEventFlags) mouseEventRecord.EventFlags;
        WheelState = (MouseWheelState) mouseEventRecord.ButtonState;
    }
    
    public Vector Position { get; }
    public MouseButton Buttons { get; }
    public MouseEventFlags Flags { get; }
    public MouseWheelState WheelState { get; }
}