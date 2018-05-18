using TechTalk.SpecFlow;

namespace HomeCinema.Tests.Acceptance.Common.Steps
{
    [Binding]
    public class ExportExcelStepsSteps
    {
        private readonly ScenarioContext _context;
        public ExportExcelStepsSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Given(@"I am viewing following records as search result :")]
        public void GivenIAmViewingFollowingRecordsAsSearchResult(Table table)
        {
        }
        
        [When(@"I request for export to excel")]
        public void WhenIRequestForExportToExcel()
        {
        }
        
        [Then(@"I should be given an excel file matching the data")]
        public void ThenIShouldBeGivenAnExcelFileMatchingTheData()
        {
        }
    }
}
