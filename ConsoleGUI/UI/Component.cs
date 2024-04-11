using System.Runtime.CompilerServices;

namespace ConsoleGUI.UI;

public delegate void PropertyChangedDelegate<in T>(T oldValue, T newValue);

public class Component
{
    public bool Enabled
    {
        get => _enabled;
        private set => SetField(ref _enabled, value);
    }

    public ZIndex ZIndex
    {
        get => _zIndex;
        set => SetField(ref _zIndex, value);
    }

    public Vector Size
    {
        get => _size;
        set => SetField(ref _size, value);
    }

    public int Width
    {
        get => Size.X;
        set => SetField(ref _size, (value, Height));
    }

    public int Height
    {
        get => Size.Y;
        set => SetField(ref _size, (Width, value));
    }

    public Vector Position
    {
        get => _position;
        set => SetField(ref _position, value);
    }
    
    private bool _enabled = true;
    private ZIndex _zIndex;
    private Vector _size;
    private Vector _position;
    
    protected void SetField<T>(ref T field, T value,
        PropertyChangedDelegate<T>? onChanged = null,
        [CallerMemberName] string? propertyName = default)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return;

        var oldValue = field;
        field = value;

        onChanged?.Invoke(oldValue, value);
    }
}