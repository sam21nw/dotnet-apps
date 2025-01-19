using System.Globalization;
using static System.Console;

partial class Program
{
    private static void ConfigureConsole(string culture = "en-US",
bool useComputerCulture = false)
    {
        // To enable Unicode characters like Euro symbol in the console.
        OutputEncoding = System.Text.Encoding.UTF8;
        if (!useComputerCulture)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
        }
        WriteLine($"CurrentCulture: {CultureInfo.CurrentCulture.
        DisplayName}");
    }
    private static void WriteLineInColor(string text, ConsoleColor color)
    {
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = color;
        WriteLine(text);
        ForegroundColor = previousColor;
    }
    private static void SectionTitle(string title)
    {

        WriteLine("------------------------------------------");
        WriteLineInColor($"*** {title} ***", ConsoleColor.DarkYellow);
        WriteLine("------------------------------------------");
    }
    private static void Fail(string message)
    {
        WriteLineInColor($"Fail > {message}", ConsoleColor.Red);
    }
    private static void Info(string message)
    {
        WriteLineInColor($"Info > {message}", ConsoleColor.Cyan);
    }
}
