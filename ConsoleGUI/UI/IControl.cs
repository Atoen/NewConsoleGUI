namespace ConsoleGUI.UI;

public interface IControl
{
    bool IsMouseOver { get; }
    bool IsFocused { get; }
    bool IsFocusable { get; }
    bool IsHitCheckVisible { get; }
    
}