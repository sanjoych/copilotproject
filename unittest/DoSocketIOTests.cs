using System;
using Xunit;

public class DoSocketIOTests
{
    [Fact]
    public void SendAndReceive_ReturnsError_OnUnreachableHost()
    {
        // Use an IP/port that's very likely unreachable to trigger the catch path.
        string result = DoSocketIO.SendAndReceive("192.0.2.1", 65000, "Hello");

        Assert.NotNull(result);
        Assert.StartsWith("Error:", result);
    }
}
