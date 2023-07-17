using System.ComponentModel.DataAnnotations;

namespace EvCharging.App.Models;

/// <summary>
/// Model for representing a user setting
/// </summary>
public class UserSettingsModel
{
    /// <summary>
    /// Initialize with necessary data
    /// </summary>
    public UserSettingsModel()
    {
        Tariffs = new List<TariffModel>();
    }

    /// <summary>
    /// Gets or sets the desired charge percent.
    /// </summary>
    [Range(0, 100)]
    public int DesiredStateOfCharge { get; set; }

    /// <summary>
    /// Gets or sets the leaving time charge percent.
    /// </summary>
    public TimeSpan LeavingTime { get; set; }

    /// <summary>
    /// Gets or sets the direct charge percent.
    /// </summary>
    [Range(0,100)]
    public int DirectChargingPercentage { get; set; }

    /// <summary>
    /// Gets or sets the tariff period infos.
    /// </summary>
    public List<TariffModel> Tariffs { get; set; }
}
