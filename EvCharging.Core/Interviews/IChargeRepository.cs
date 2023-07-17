using EvCharging.Core.Models;

namespace EvCharging.Core.Interviews;

/// <summary>
/// Interface for the charge repository.
/// </summary>
public interface IChargeRepository
{
    /// <summary>
    /// Calculate charging needs (Direct and Resired) 
    /// </summary>
    /// <param name="batteryCapacity">Battery energy capacity</param>
    /// <param name="directPercentage">Direct charge percentage to be reached</param>
    /// <param name="desiredPercentage">Desired charge percentage to be reached</param>
    /// <param name="currentBattery">Current battery power</param>
    /// <param name="chargePower">Hourly charging power</param>
    /// <returns>The calculating charging data</returns>
    Charge GetCharge(decimal batteryCapacity, int directPercentage, int desiredPercentage,  decimal currentBattery, decimal chargePower);
}
