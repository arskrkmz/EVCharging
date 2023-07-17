namespace EvCharging.Core.Models;
public class Charge
{
    /// <summary>
    /// Needed direct charge time as hour
    /// </summary>
    public decimal DirectTime { get; set; }
    /// <summary>
    /// Needed desired charge time as hour
    /// </summary>
    public decimal DesiredTime { get; set; }
}
