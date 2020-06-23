using System;

namespace TestCarWash.Reports.ReportProviders
{
    public class InDesignReportProvider
    {
        public InDesign.Application CreateInstance()
        {
            var appType = Type.GetTypeFromProgID("InDesign.Application");
            if (appType != null)
            {
                var application = (InDesign.Application)Activator.CreateInstance(appType);
                return application;
            }
            return null;
        }

        public InDesign.Document GetReportTemplate(InDesign.Application application, string reportTemplatePath)
        {
            var document = (InDesign.Document)application.Open(reportTemplatePath);
            return document;
        }
    }
}
