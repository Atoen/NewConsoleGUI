using System.Drawing;

namespace ConsoleGUI.UI;

public interface IVisual
{
    Color DefaultColor { get; }
    Color HighlightedColor { get; }
    Color PressedColor { get; }
    Color DisabledColor { get; }
    Color CurrentColor { get; }
    
    Vector Padding { get; }
    Vector Margin { get; }
    Vector MarginSize { get; }
}