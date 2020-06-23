using System;
using TestCarWash.Models;
using TestCarWash.Reports.ReportProviders;

namespace TestCarWash.Reports.ReportGenerators
{
    /// <summary>
    /// Report generator for provided services.
    /// </summary>
    public class ProvidedServicesReportGenerator : IReportGenerator
    {
        private readonly IReportProvider<InDesign.Document> provider;
        private readonly Client currentClient;

        public ProvidedServicesReportGenerator(IReportProvider<InDesign.Document> provider, Client currentClient)
        {
            this.provider = provider;
            this.currentClient = currentClient;
        }

        public string CreateReportFromTemplate()
        {
            var templatePath = @"C:\RenData\Repos\test-task-asp-mvc\TestCarWash\Reports\ReportTemplates\ReportTemplate.indd";

            provider.InitializeProvider();
            var reportTemplate = provider.GetReportTemplate(templatePath);
            
            FillReportContent(reportTemplate);
            
            var savedReportPath = SaveReport(reportTemplate);

            return savedReportPath;
        }

        public void FillReportContent(InDesign.Document reportTemplate)
        {
            var mainPage = (InDesign.Page)reportTemplate.Pages[1];
            var textFrame = (InDesign.TextFrame)mainPage.TextFrames[1];
            // usage currentClient
            textFrame.Contents = "My first report!!!!";
        }

        private string SaveReport(InDesign.Document reportTemplate)
        {
            var resultReportPath = $@"C:\RenData\Repos\test-task-asp-mvc\TestCarWash\Reports\ResultReports\ResultReport_{DateTime.Now:ddMMyyyy_HHmmss}.pdf";
            const int pdfTypeCode = 1952403524; // it's number code from InDesign Server Scripting Guide (VBScript)
            
            reportTemplate.Export(pdfTypeCode, resultReportPath);
            return resultReportPath;
        }
    }
}