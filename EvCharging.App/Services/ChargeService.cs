using EvCharging.Core.Collections;
using EvCharging.App.Interviews;
using EvCharging.App.Models;
using EvCharging.Core.Interviews;


namespace EvCharging.App.Services;

/// <summary>
/// service for calculating charge datas
/// </summary>
public class ChargeService : IChargeService
{
    private readonly IChargeRepository _repository;

    /// <summary>
    /// Constructor for chargeService.
    /// </summary>
    /// <param name="carRepository"> The charge repository dependency.</param>
    public ChargeService(IChargeRepository carRepository)
    {
        _repository = carRepository;
    }

    /// <summary>
    /// Calculates the optimal charging period. 
    /// </summary>
    /// <param name="model">Charge information data.</param>
    /// <returns>The list of Tariffs.</returns>
    public List<ResponseModel> GetCharge(ChargeModel model)
    {

        List<ResponseModel> responses = new List<ResponseModel>();

        // Set starttime and leaving time
        DateTime startTime = model.StartingTime;
        DateTime leavingTime = model.StartingTime.Add(model.UserSettings.LeavingTime);

        // Calculating charging needs ( Direct and Resired ) 
        var chargeTime = _repository.GetCharge(
                                                model.CarData.BatteryCapacity, 
                                                model.UserSettings.DirectChargingPercentage,
                                                model.UserSettings.DesiredStateOfCharge,
                                                model.CarData.CurrentBatteryLevel,
                                                model.CarData.ChargePower );

        // Checks if it needs direct charging
        if (chargeTime.DirectTime > 0)
        {
            // Adding direct charging period
            responses.Add(new ResponseModel()
            {
                StartTime = startTime,
                EndTime = startTime.AddHours((double)chargeTime.DirectTime),
                IsCharging = true
            });

            // Adding direct charge time to start time for desired charging periods calculating
            startTime = startTime.AddHours((double)chargeTime.DirectTime);
        }

        // Created tariff collector object and set sorted charging period information at price values
        TariffCollection tariffCollection = new TariffCollection(model.UserSettings.Tariffs
                                                                    .OrderBy(x=>x.EnergyPrice)
                                                                    .ToArray());
        ITariffIterator tariffIterator = (ITariffIterator) tariffCollection;

        // Calculating all periods starting from the most affordable period.
        while (tariffIterator.HasNext())
        {

            DateTime currentTime = startTime;
            // Day-controlled to scan all days between start time and leave time
            while (currentTime.Date <= leavingTime.Date)
            {
                // Get period data for current date
                var rs = tariffIterator.Next(currentTime, leavingTime);

                
                #region all date control processes
                // Last date-controlled
                if (rs.StartTime < rs.EndTime)
                {

                    // checking if it needs charging
                    if (chargeTime.DesiredTime > 0)
                        rs.IsCharging = true;

                    // calculating the hour interval of the period
                    var periodCharge = (decimal)(rs.EndTime - rs.StartTime).TotalHours;

                    // checking if the time interval is more or less than the remaining need
                    if (periodCharge > chargeTime.DesiredTime && rs.IsCharging)
                    {
                        // Adding required charge period to response list
                        responses.Add(new ResponseModel()
                        {
                            StartTime = rs.StartTime,
                            EndTime = rs.EndTime.AddHours(-(double)(periodCharge - chargeTime.DesiredTime)),
                            IsCharging = true
                        });

                        // Adding remaining time to response list
                        responses.Add(new ResponseModel()
                        {
                            StartTime = rs.StartTime.AddHours((double)chargeTime.DesiredTime),
                            EndTime = rs.EndTime
                        });


                    }
                    else
                        responses.Add(rs);

                    // Subtracting added time from requested time
                    chargeTime.DesiredTime -= periodCharge;

                }
                #endregion


                // increase the day
                currentTime = currentTime.Date.AddDays(1);


            }
        }

        // Sort the resulting charge time by time and sending it back
        return responses.OrderBy(x=>x.StartTime).ToList();
    }
}
