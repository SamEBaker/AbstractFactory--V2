using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MotorBikeFactory : IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        switch (requirements.luckyNum)
        {
            case 4:
                return new Become2();
            case 5:
                return new Skull();
            case 6:
            case 7:
            case 8:
                return new Help();
            case 9:
                return new Dice();
            default:
                return new Become2();

        }
    }
}
