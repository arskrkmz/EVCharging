using EvCharging.Core.Interviews;
using EvCharging.Core.Models;

namespace EvCharging.Core.Repositories;

/// <summary>
/// Repository for calculating charge datas
/// </summary>
public class ChargeRepository : IChargeRepository
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
    public Charge GetCharge(decimal batteryCapacity, int directPercentage, int desiredPercentage, decimal currentBattery, decimal chargePower)
    {

        var data = new Charge();

        // Calculate power need
        decimal directPower = batteryCapacity * directPercentage / 100 - currentBattery;
        decimal desiredPower = batteryCapacity * desiredPercentage / 100 - currentBattery - directPower;

        // Calculate needed time as hour  
        data.DirectTime = directPower > 0 ? directPower / chargePower : 0;
        data.DesiredTime = desiredPower > 0 ? desiredPower / chargePower : 0;

        return data;

    }
}
