using System.ComponentModel.DataAnnotations;

namespace EvCharging.App.Models;

/// <summary>
/// Model for representing a car
/// </summary>
public class CarModel
{
    /// <summary>
    /// Gets or sets the charge power of the car.
    /// </summary>
    [Range(0.01, double.MaxValue, ErrorMessage = "The value must be greater than 0.01.")]
    public decimal ChargePower { get; set; }

    /// <summary>
    /// Gets or sets the battery capacity power of the car.
    /// </summary>
    [Range(0.01, double.MaxValue, ErrorMessage = "The value must be greater than 0.01.")]
    public decimal BatteryCapacity { get; set; }

    /// <summary>
    /// Gets or sets the current battery level of the car.
    /// </summary>
    [Range(0.01, double.MaxValue, ErrorMessage = "The value must be greater than 0.01.")]
    public decimal CurrentBatteryLevel { get; set; }
}
