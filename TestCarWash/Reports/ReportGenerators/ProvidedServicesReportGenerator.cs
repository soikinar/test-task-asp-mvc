using System;
using System.Collections.Generic;
using System.Linq;
using TestCarWash.Content.Common;
using TestCarWash.Models;
using TestCarWash.Reports.ReportHelpers;
using TestCarWash.Reports.ReportProviders;

namespace TestCarWash.Reports.ReportGenerators
{
    /// <summary>
    /// Report generator for provided services.
    /// </summary>
    public class ProvidedServicesReportGenerator : IReportGenerator<InDesign.Document>
    {
        private readonly IReportProvider<InDesign.Document> provider;
        private readonly string resultReportFileName = $"ResultReport_{DateTime.Now:ddMMyyyy_HHmmss}.pdf";

        // info for report contents
        private readonly Client currentClient;
        private readonly DateTime currentServiceDate;
        private readonly IEnumerable<ProvidedService> currentProvidedServices;

        public ProvidedServicesReportGenerator(
            IReportProvider<InDesign.Document> provider,
            Client currentClient,
            DateTime currentServiceDate)
        {
            this.provider = provider;
            this.currentClient = currentClient;
            this.currentServiceDate = currentServiceDate;
            currentProvidedServices = currentClient.ProvidedServices.Where(ps => ps.ServiceDate == currentServiceDate);
        }

        public string CreateReportFromTemplate()
        {
            var templatePath = ReportConfigurationManager.GetAbsolutePathToReportTemplateFile();
            provider.InitializeProvider();
            var reportTemplate = provider.GetReportTemplate(templatePath);
            FillReportContent(reportTemplate);
            var savedReportPath = SaveReport(reportTemplate);
            provider.DestroyProvider();
            return savedReportPath;
        }

        public void FillReportContent(InDesign.Document reportTemplate)
        {
            FillHeader(reportTemplate);
            FillMainReportInfo(reportTemplate);
            FillFooter(reportTemplate);
        }

        public void FillHeader(InDesign.Document reportTemplate)
        {
            var page = ReportGenerationHelper.GetPageByNumber(reportTemplate, 1);
            var headerContent = PageStrings.OrganizationNameText;
            ReportGenerationHelper.SetNewContentInTextFrame(page, 10, headerContent);
        }

        public void FillFooter(InDesign.Document reportTemplate)
        {
            var page = ReportGenerationHelper.GetPageByNumber(reportTemplate, 1);
            var footerContent = $"{PageStrings.OrganizationNameText}, {string.Format(PageStrings.DateDisplayDataFormat, DateTime.Today)}";
            ReportGenerationHelper.SetNewContentInTextFrame(page, 5, footerContent);
        }

        private void FillMainReportInfo(InDesign.Document reportTemplate)
        {
            var page = ReportGenerationHelper.GetPageByNumber(reportTemplate, 1);
            FillClientInfo(page);
            FillProvidedServiceList(page);
            FillTotalPrice(page);
            FillServiceDate(page);
        }

        private string SaveReport(InDesign.Document reportTemplate)
        {
            const int pdfTypeCode = 1952403524; // it's number code from InDesign Server Scripting Guide (VBScript)

            var resultReportPath = ReportConfigurationManager.GetAbsolutePathToResultReportFile(resultReportFileName);
            reportTemplate.Export(pdfTypeCode, resultReportPath);
            return resultReportPath;
        }

        private void FillClientInfo(InDesign.Page page)
        {
            var clientNameContent = currentClient.Person;
            ReportGenerationHelper.SetNewContentInTextFrame(page, 8, clientNameContent);
        }

        private void FillProvidedServiceList(InDesign.Page page)
        {
            var reportRows = ReportGenerationHelper.ConvertCollectionToContentView(currentProvidedServices);
            ReportGenerationHelper.SetNewContentInTextFrame(page, 6, reportRows);
        }

        private void FillTotalPrice(InDesign.Page page)
        {
            var totalPrice = currentProvidedServices.Sum(ps => ps.TotalPrice);
            var totalPriceContent = string.Format(PageStrings.MoneyDisplayDataFormat, totalPrice);
            ReportGenerationHelper.SetNewContentInTextFrame(page, 4, totalPriceContent);

        }

        private void FillServiceDate(InDesign.Page page)
        {
            var serviceDateContent = string.Format(PageStrings.DateDisplayDataFormat, currentServiceDate);
            ReportGenerationHelper.SetNewContentInTextFrame(page, 3, serviceDateContent);
        }
    }
}