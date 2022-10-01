namespace FrameworkTask
{
    public class EngineCreator
    {
        private string numberOfInstances = "numberOfInstances";
        private string os = "os";
        private string provisionModel = "provisionModel";
        private string series = "series";
        private string machineType = "machineType";
        private string gpuType = "gpuType";
        private string numberOfGPU = "numberOfGPU";
        private string localSSD = "localSSD";
        private string datacenter = "datacenter";
        private string commitUsage = "commitUsage";
        private TestDataReader testDataReader = new TestDataReader();

        public Engine CreateNewEngine()
        {
            return new Engine(testDataReader.GetTestData(numberOfInstances), testDataReader.GetTestData(os),
                testDataReader.GetTestData(provisionModel), testDataReader.GetTestData(series),
                testDataReader.GetTestData(machineType), testDataReader.GetTestData(gpuType),
                testDataReader.GetTestData(numberOfGPU), testDataReader.GetTestData(localSSD),
                testDataReader.GetTestData(datacenter), testDataReader.GetTestData(commitUsage));
        }
    }
}
