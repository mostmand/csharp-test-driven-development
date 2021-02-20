using System;

namespace TestDrivenDevelopment
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}