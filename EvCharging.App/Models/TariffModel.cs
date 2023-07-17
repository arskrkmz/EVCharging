using System.ComponentModel.DataAnnotations;

namespace EvCharging.App.Models;

/// <summary>
/// Model for representing a tariff info for charging periods
/// </summary>
public class TariffModel
{
    /// <summary>
    /// Gets or sets the start time of the charging period.
    /// </summary>
    public TimeSpan StartTime { get; set; }

    /// <summary>
    /// Gets or sets the end time of the charging period.
    /// </summary>
    public TimeSpan EndTime { get; set; }

    /// <summary>
    /// Gets or sets the energy price of the charging period.
    /// </summary>
    public decimal EnergyPrice { get; set; }
}
