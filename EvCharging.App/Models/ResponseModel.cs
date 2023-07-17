using System.ComponentModel.DataAnnotations;

namespace EvCharging.App.Models;

/// <summary>
/// Model for representing a response for charging periods
/// </summary>
public class ResponseModel
{
    /// <summary>
    /// Gets or sets the start time of the charging period.
    /// </summary>
    public DateTime StartTime { get; set; }

    /// <summary>
    /// Gets or sets the end time of the charging period.
    /// </summary> 
    public DateTime EndTime { get; set; }

    /// <summary>
    /// Gets or sets the charging status of the charging period.
    /// </summary>
    public bool IsCharging { get; set; }
}
