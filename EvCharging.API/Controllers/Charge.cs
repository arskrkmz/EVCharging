using EvCharging.App.Interviews;
using EvCharging.App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace EvCharging.API.Controllers;

/// <summary>
/// Controller for calculating the optimal charging period. 
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class Charge : ControllerBase
{

    private readonly IChargeService _service;

    /// <summary>
    /// Constructor for Charge controller.
    /// </summary>
    /// <param name="ChargeService">The charge service dependency.</param>
    public Charge(IChargeService chargeService   )
    {
        _service= chargeService;
    }

    /// <summary>
    /// Calculates the optimal charging period. 
    /// </summary>
    /// <param name="model">Charge information data.</param>
    /// <returns>The list of Tariffs.</returns>
    /// <exception cref="Exception"></exception>
    [HttpPost]
    public IEnumerable<ResponseModel> Post(ChargeModel model)
    {
        
        // Call the ChargeService to calculate tariffs
        var datas = _service.GetCharge(model);

        // Return the list of tariffs
        return datas;
    }
}
