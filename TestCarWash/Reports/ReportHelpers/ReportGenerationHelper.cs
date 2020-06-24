using System.Collections.Generic;
using System.Linq;

namespace TestCarWash.Reports.ReportHelpers
{
    /// <summary>
    /// Helper for report content generation.
    /// </summary>
    public static class ReportGenerationHelper
    {
        /// <summary>
        /// Converts IEnumerable collection to report content string view.
        /// </summary>
        /// <typeparam name="T">Type of collection elements.</typeparam>
        /// <param name="collection">IEnumerable collection.</param>
        /// <returns>String information for report content.</returns>
        public static string ConvertCollectionToContentView<T>(IEnumerable<T> collection)
        {
            var rows = collection.Select(item => item.ToString()).ToList();
            return string.Join("\r\n", rows);
        }

        /// <summary>
        /// Sets new content for the specified text frame.
        /// </summary>
        /// <param name="page">InDesign Page that contains the text frame.</param>
        /// <param name="textFrameNumber">Number of text frame.</param>
        /// <param name="content">String content to insert.</param>
        public static void SetNewContentInTextFrame(InDesign.Page page, int textFrameNumber, string content)
        {
            var textFrame = (InDesign.TextFrame)page.TextFrames[textFrameNumber];
            textFrame.Contents = content;
        }

        /// <summary>
        /// Get InDesign page by its number.
        /// </summary>
        /// <param name="document">InDesign document that contains the page.</param>
        /// <param name="pageNumber">Number of page.</param>
        /// <returns>InDesign page.</returns>
        public static InDesign.Page GetPageByNumber(InDesign.Document document, int pageNumber)
        {
            return (InDesign.Page)document.Pages[pageNumber];
        }
    }
}