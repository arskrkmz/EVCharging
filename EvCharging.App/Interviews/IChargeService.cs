using EvCharging.App.Models;

namespace EvCharging.App.Interviews;

/// <summary>
/// interface for calculating charge datas
/// </summary>
public interface IChargeService
{
    /// <summary>
    /// Calculates the optimal charging period. 
    /// </summary>
    /// <param name="model">Charge information data.</param>
    /// <returns>The list of Tariffs.</returns>
    List<ResponseModel> GetCharge(ChargeModel model);

}
