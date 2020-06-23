namespace TestCarWash.Reports.ReportGenerators
{
    /// <summary>
    /// Interface of a report generator.
    /// </summary>
    public interface IReportGenerator
    {
        /// <summary>
        /// Creates report from template and returns its path.
        /// </summary>
        /// <returns>Path to the created report.</returns>
        string CreateReportFromTemplate();

        /// <summary>
        /// Fills content of report.
        /// </summary>
        /// <param name="reportTemplate"></param>
        void FillReportContent(InDesign.Document reportTemplate);
    }
}
