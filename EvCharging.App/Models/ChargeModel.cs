using System.ComponentModel.DataAnnotations;

namespace EvCharging.App.Models;

/// <summary>
/// Model for representing a charge setting
/// </summary>
public class ChargeModel
{
    /// <summary>
    /// Initialize with necessary data
    /// </summary>
    public ChargeModel()
    {
        UserSettings = new UserSettingsModel();
        CarData = new CarModel();
    }

    /// <summary>
    /// Gets or sets the start time of the charge.
    /// </summary>
    public DateTime StartingTime { get; set; }

    /// <summary>
    /// Gets or sets the user settings of the charge.
    /// </summary>
    public UserSettingsModel UserSettings { get; set; }

    /// <summary>
    /// Gets or sets the car settings of the charge.
    /// </summary>
    public CarModel CarData { get; set; }
}
