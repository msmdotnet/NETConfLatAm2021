using NorthWind.Entities.Interfaces;
using System.Diagnostics;

namespace NorthWind.Loggers
{
    public class DebugStatusLogger : IApplicationStatusLogger
    {
        public void Log(string message)
        {
            Debug.Write($"*** DSL: {message}");
        }
    }
}