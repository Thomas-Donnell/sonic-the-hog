// ITimeProvider.cs
public interface ITimeProvider
{
    float DeltaTime { get; }
}

// MockTimeProvider.cs
public class MockTimeProvider : ITimeProvider
{
    public float DeltaTime { get; set; } // We can set this in tests
}
