namespace ConsoleGUI.UI;

public interface IRenderable
{
    void Render();
    void Clear();
    
    bool ShouldRender { get; }
    
    ZIndex ZIndex { get; }
}