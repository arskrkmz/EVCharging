using EvCharging.App.Interviews;
using EvCharging.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvCharging.Core.Collections;

/// <summary>
/// Collection for setting tariff period
/// </summary>
internal class TariffCollection : ITariffIterator
{
    private readonly TariffModel[] _tariffs;
    private int _currentIndex;

   
    /// <summary>
    ///  Constructor for TariffCollection.
    /// </summary>
    /// <param name="tariffs">The charge tariff periods</param>
    public TariffCollection(TariffModel[] tariffs)
    {
        _tariffs = tariffs;
        _currentIndex = 0;
    }

    /// <summary>
    /// checking for list status
    /// </summary>
    /// <returns>true / false</returns>
    public bool HasNext()
    {
        return _currentIndex < _tariffs.Length;
    }

    /// <summary>
    /// creates and forwards the next time period
    /// </summary>
    /// <param name="startTime">Tariff period start time </param>
    /// <param name="leavingTime">Tariff period leaving time </param>
    /// <returns></returns>
    public ResponseModel Next(DateTime startTime, DateTime leavingTime)
    {
        // getting the next time period
        var tariff = _tariffs[_currentIndex];

        // setting a new tariff period
        var data = new ResponseModel()
        {
            StartTime = startTime.Date.Add(tariff.StartTime),
            EndTime = startTime.Date.Add(tariff.EndTime)
        };

        // checking start time and leaving time statuses
        if (data.StartTime > data.EndTime)
            data.EndTime = data.EndTime.AddDays(1);

        if (startTime > data.StartTime)
            data.StartTime = startTime;

        if (data.EndTime > leavingTime)
            data.EndTime = leavingTime;

        // If the start time is equal to the end time, skip to the next tariff period
        if (startTime.Date == leavingTime.Date)
            _currentIndex++;

        
        return data;
    }

}
