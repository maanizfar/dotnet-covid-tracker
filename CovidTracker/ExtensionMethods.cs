
namespace CovidTracker.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static string CommaSeparated(this int number)
        {
            return number.ToString("N0");
        }
    }
}
