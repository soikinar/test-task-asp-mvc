using System;
using InDesign;
using TestCarWash.Reports.ReportProviders;

namespace TestCarWash.Reports.ReportGenerators
{
    public class ReportGenerator
    {
        private InDesignReportProvider reportProvider;

        public ReportGenerator(InDesignReportProvider reportProvider)
        {
            this.reportProvider = reportProvider;
        }

        public void CreateReport()
        {
            var templatePath = @"C:\RenData\Repos\test-task-asp-mvc\TestCarWash\Reports\ReportTemplates\ReportTemplate.indd";
            var resultReportPath = $@"C:\RenData\Repos\test-task-asp-mvc\TestCarWash\Reports\ResultReports\ResultReport_{DateTime.Now:ddMMyyyy_HHmmss}.pdf";
            var appInstance = reportProvider.CreateInstance();
            var reportTemplate = reportProvider.GetReportTemplate(appInstance, templatePath);

            var mainPage = (Page)reportTemplate.Pages[1];
            var textFrame = (TextFrame)mainPage.TextFrames[1];
            textFrame.Contents = "My first report!!!!";
            var pdfTypeCode = 1952403524; // it's number code from InDesign Server Scripting Guide (VBScript)
            reportTemplate.Export(pdfTypeCode, resultReportPath);

            //reportTemplate.Close(idSaveOptions.idNo);
            
            appInstance.Quit(idSaveOptions.idNo);
        }
    }
}