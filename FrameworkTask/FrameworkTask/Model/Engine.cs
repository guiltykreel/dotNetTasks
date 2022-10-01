using OpenQA.Selenium;

namespace FrameworkTask
{
    /// <summary>
    /// Should be singleton
    /// </summary>
    public class Engine
    {
        public string numberOfInstances;
        public By operatingSystemSelector;
        public By provisionModelSelector;
        public By seriesSelector;
        public By machineTypeSelector;
        public By selectGPUTypeSelector;
        public By numberOfGPUSelector;
        public By localSSDSelector;
        public By datacenterSelector;
        public By commitUsageSelector;

        public Engine(string numberOfInstances, string os, string provisionModel, string series, string machineType,
            string gpuType, string numberOfGPU, string localSSD, string datacenter, string commitUsage)
        {
            this.numberOfInstances = numberOfInstances;
            operatingSystemSelector = By.XPath($"//*[@value='{os}']");
            provisionModelSelector = By.XPath($"//*[@value='{provisionModel}']");
            seriesSelector = By.XPath($"//*[@value='{series}']");
            machineTypeSelector = By.XPath($"//*[@value='{machineType}']");
            selectGPUTypeSelector = By.XPath($"//*[@value='{gpuType}']");
            numberOfGPUSelector = By.XPath("//*[@ng-repeat = 'item in " +
                $"listingCtrl.supportedGpuNumbers[listingCtrl.computeServer.gpuType]' and @value='{numberOfGPU}']");
            localSSDSelector = By.XPath("//*[@ng-repeat='item in listingCtrl.dynamicSsd.computeServer' " +
                $"and @value='{localSSD}']");
            datacenterSelector = By.XPath("//*[@ng-repeat='item in listingCtrl.fullRegionList | " +
                $"filter:listingCtrl.inputRegionText.computeServer' and @value='{datacenter}']");
            commitUsageSelector = By.Id($"select_option_{commitUsage}");//bad case
        }
    }
}
