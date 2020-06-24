namespace TestCarWash.Reports.ReportProviders
{
    /// <summary>
    /// Interface of a report provider.
    /// </summary>
    /// <typeparam name="T">Type of report file.</typeparam>
    public interface IReportProvider<out T>
    {
        /// <summary>
        /// Initializes a report provider.
        /// </summary>
        void InitializeProvider();

        /// <summary>
        /// Opens and returns a report template at the specified path.
        /// </summary>
        /// <param name="reportTemplatePath">Path to the report template.</param>
        /// <returns>Opened report template.</returns>
        T GetReportTemplate(string reportTemplatePath);

        /// <summary>
        /// Destroys a report provider.
        /// </summary>
        void DestroyProvider();
    }
}
