﻿using Car_Rental.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Interfaces;

public interface IVehicle
{
    string RegNO { get;}
    string Make { get;}
    int Odometer { get;}
    double KmCost  { get;}
    int DayCost { get;}
    VehicleTypes Type { get;}
    VehicleStatuses Status { get; }
}
