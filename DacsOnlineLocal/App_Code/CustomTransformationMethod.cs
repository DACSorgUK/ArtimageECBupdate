using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CustomTransformationMethod
/// </summary>



/// <summary>
/// Extends the CMSTransformation partial class.
/// </summary>
public static class CustomTransformation
{
    /// <summary>
    /// Trims text values to the specified length.
    /// </summary>
    /// <param name="txtValue">Original text to be trimmed</param>
    /// <param name="leftChars">Number of characters to be returned</param>
    public static string EventPageEventEndDateTimeFormat(DateTime EventStart, DateTime EventEnd)
    {
        // Checks that text is not null
        if ((EventEnd - EventStart).TotalHours >= 24)
        {
            return EventEnd.ToString("d MMMM yyyy, h:mm tt");
        }
        else
        {
            return EventEnd.ToString("h:mm tt");
        }
    }
}


