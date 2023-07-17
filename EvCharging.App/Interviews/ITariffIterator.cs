using EvCharging.App.Models;

namespace EvCharging.App.Interviews;

/// <summary>
/// interface for setting tariff period
/// </summary>
internal interface ITariffIterator
{
    /// <summary>
    /// checking for list status
    /// </summary>
    /// <returns>true / false</returns>
    bool HasNext();

    /// <summary>
    /// creates and forwards the next time period
    /// </summary>
    /// <param name="startTime">Tariff period start time </param>
    /// <param name="leavingTime">Tariff period leaving time </param>
    /// <returns></returns>
    ResponseModel Next(DateTime startTime, DateTime leavingTime);
}
