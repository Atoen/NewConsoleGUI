namespace ConsoleGUI.ConsoleDisplay;

public readonly record struct RefreshRate
{
    public FrameRate FrameRate { get; }
    public TimeSpan FrameTime { get; }

    public RefreshRate(TimeSpan frameTime)
    {
        FrameTime = frameTime;
        FrameRate = FrameRate.FromFrameTime(frameTime);
    }
    
    public RefreshRate(FrameRate frameRate)
    {
        FrameRate = frameRate;
        FrameTime = TimeSpan.FromMilliseconds(1000 / frameRate);
    }

    public static implicit operator RefreshRate(FrameRate frameRate) => new(frameRate);

    public static implicit operator RefreshRate(TimeSpan frameTime) => new(frameTime);
}

public readonly record struct FrameRate(double Value)
{
    public double Value { get; } =
        Value < 0
            ? throw new ArgumentOutOfRangeException(nameof(Value))
            : Value;
    public static FrameRate FromFrameTime(TimeSpan frameTime) => new(1000 / frameTime.TotalMilliseconds);

    public static implicit operator double(FrameRate frameRate) => frameRate.Value;

    public static explicit operator FrameRate(double value) => new(value);
}