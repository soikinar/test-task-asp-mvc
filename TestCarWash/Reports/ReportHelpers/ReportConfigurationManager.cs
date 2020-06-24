using System.Configuration;
using System.IO;
using System.Web;

namespace TestCarWash.Reports.ReportHelpers
{
    /// <summary>
    /// Configuration manager for report generation process.
    /// </summary>
    public static class ReportConfigurationManager
    {
        // Configuration keys
        private const string ReportTemplateRelativePathConfigKey = "ReportTemplateRelativePath";
        private const string ReportTemplateFileNameConfigKey = "ReportTemplateFileName";
        private const string ResultReportsRelativePathConfigKey = "ResultReportsRelativePath";

        // Configuration values
        private static readonly string ReportTemplateRelativePathConfigValue =
            ConfigurationManager.AppSettings[ReportTemplateRelativePathConfigKey];

        private static readonly string ReportTemplateFileNameConfigValue =
            ConfigurationManager.AppSettings[ReportTemplateFileNameConfigKey];

        private static readonly string ResultReportsRelativePathConfigValue =
            ConfigurationManager.AppSettings[ResultReportsRelativePathConfigKey];

        /// <summary>
        /// Gets absolute path to report template file.
        /// </summary>
        /// <returns>Path to report template file.</returns>
        public static string GetAbsolutePathToReportTemplateFile()
        {
            var relativePathToReportTemplateFile = Path.Combine(ReportTemplateRelativePathConfigValue, ReportTemplateFileNameConfigValue);
            return Path.GetFullPath(Path.Combine(HttpRuntime.AppDomainAppPath, relativePathToReportTemplateFile));
        }

        /// <summary>
        /// Gets absolute path to the report result folder.
        /// </summary>
        /// <returns>Absolute path to the report result folder.</returns>
        public static string GetAbsolutePathToResultReportFolder()
        {
            return Path.GetFullPath(Path.Combine(HttpRuntime.AppDomainAppPath, ResultReportsRelativePathConfigValue));
        }

        /// <summary>
        /// Gets absolute path to the report result file.
        /// </summary>
        /// <param name="resultReportFileName">File name of result report.</param>
        /// <returns>Absolute path to the report result file.</returns>
        public static string GetAbsolutePathToResultReportFile(string resultReportFileName)
        {
            var absolutePathToResultReportFolder = GetAbsolutePathToResultReportFolder();
            return Path.Combine(absolutePathToResultReportFolder, resultReportFileName);
        }
    }
}