using System.Drawing;

namespace ConsoleGUI.UI;

public interface IText
{
    string Content { get; }
    int Length { get; }
    
    Color Foreground { get; set; }
    Color Background { get; set; }
}