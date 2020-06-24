using System.Collections.Generic;
using System.Linq;

namespace TestCarWash.Reports.ReportGenerators.ReportHelpers
{
    /// <summary>
    /// Helper for report content generation.
    /// </summary>
    public static class ReportGenerationHelper
    {
        public static string ConvertCollectionToContentView<T>(IEnumerable<T> collection)
        {
            var rows = collection.Select(item => item.ToString()).ToList();
            return string.Join("\n", rows);
        }

        public static void SetNewContentInTextFrame(InDesign.Page page, int textFrameNumber, string content)
        {
            var textFrame = (InDesign.TextFrame)page.TextFrames[textFrameNumber];
            textFrame.Contents = content;
        }
    }
}