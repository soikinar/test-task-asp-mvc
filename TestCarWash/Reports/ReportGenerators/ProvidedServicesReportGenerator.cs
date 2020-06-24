using System;
using System.Collections.Generic;
using System.Linq;
using TestCarWash.Content.Common;
using TestCarWash.Models;
using TestCarWash.Reports.ReportGenerators.ReportHelpers;
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
            provider.DestroyProvider();

            return savedReportPath;
        }

        public void FillReportContent(InDesign.Document reportTemplate)
        {
            var page = (InDesign.Page)reportTemplate.Pages[1];

            ReportGenerationHelper.SetNewContentInTextFrame(page, 1, PageStrings.OrganizationNameText);
            ReportGenerationHelper.SetNewContentInTextFrame(page, 7, PageStrings.OrganizationNameText);
            ReportGenerationHelper.SetNewContentInTextFrame(page, 5, currentClient.Person);

            var reportRows = ReportGenerationHelper.ConvertCollectionToContentView(currentClient.ProvidedServices);
            ReportGenerationHelper.SetNewContentInTextFrame(page, 3, reportRows);

            var totalOrderPrice = currentClient.ProvidedServices.Sum(ps => ps.TotalPrice);
            ReportGenerationHelper.SetNewContentInTextFrame(page, 1, totalOrderPrice.ToString(PageStrings.MoneyDataFormat));
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