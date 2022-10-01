using System.Reflection;
using System.Resources;

namespace FrameworkTask
{
    public class TestDataReader
    {
        private static ResourceManager resourceManager;

        public TestDataReader()
        {
            resourceManager = new ResourceManager($"FrameworkTask.Properties." +
                $"{Environment.GetEnvironmentVariable("Env")}",
                    Assembly.GetExecutingAssembly());
        }
        public string GetTestData(string key)
        {
            return resourceManager.GetString(key);
        }
    }
}
