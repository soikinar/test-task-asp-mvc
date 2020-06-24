namespace TestCarWash.Reports.ReportGenerators
{
    /// <summary>
    /// Interface of a report generator.
    /// </summary>
    /// <typeparam name="T">Type of report file.</typeparam>
    public interface IReportGenerator<in T>
    {
        /// <summary>
        /// Creates report from template and returns its path.
        /// </summary>
        /// <returns>Path to the created report.</returns>
        string CreateReportFromTemplate();

        /// <summary>
        /// Fills all content of report.
        /// </summary>
        /// <param name="reportTemplate">Type of report template file.</param>
        void FillReportContent(T reportTemplate);

        /// <summary>
        /// Fills a header of report content.
        /// </summary>
        /// <param name="reportTemplate">Type of report template file.</param>
        void FillHeader(T reportTemplate);

        /// <summary>
        /// Fills a footer of report content.
        /// </summary>
        /// <param name="reportTemplate">Type of report template file.</param>
        void FillFooter(T reportTemplate);
    }
}
