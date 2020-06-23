using System;

namespace TestCarWash.Reports.ReportProviders
{
    /// <summary>
    /// Adobe InDesign Report Provider.
    /// </summary>
    public class InDesignReportProvider : IReportProvider<InDesign.Document>
    {
        private const InDesign.idSaveOptions QuitSaveOptions = InDesign.idSaveOptions.idNo;
        private const string InDesignProgId = "InDesign.Application";

        private InDesign.Application application;

        public void InitializeProvider()
        {
            var appType = Type.GetTypeFromProgID(InDesignProgId);
            application = appType != null ? (InDesign.Application) Activator.CreateInstance(appType) : null;
        }

        public InDesign.Document GetReportTemplate(string reportTemplatePath)
        {
            return (InDesign.Document)application.Open(reportTemplatePath);
        }

        public void DestroyProvider()
        {
            application.Quit(QuitSaveOptions);
        }
    }
}
