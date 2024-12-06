

namespace XEConverterTests.Utilities
{
    public static class SetUp
    {
        // Get the root directory of the project
        public static string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

        // Combine the project path with the Drivers folder
        public static string chromeDriverPath = Path.Combine(projectPath, "Drivers");

        // Add a method to get the full path of chromedriver.exe
        public static string GetChromeDriverPath()
        {
            return Path.Combine(chromeDriverPath, "chromedriver.exe");
        }
    }
}
