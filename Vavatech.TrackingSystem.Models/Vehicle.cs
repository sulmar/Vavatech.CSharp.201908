using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Vavatech.TrackingSystem.Models
{
    public class Vehicle : BaseEntity
    {
        public string Name { get; set; }

        public VehicleStatus Status { get; set; }

        //public bool Light { get; set; }
        //public bool Doors { get; set; }
        //public bool Klima { get; set; }
        //public bool Engine { get; set; }


        public Vehicle()
        {
            Status = VehicleStatus.Engine | VehicleStatus.Lights | VehicleStatus.Klima;

            if (Status.HasFlag(VehicleStatus.Lights))
            {

            }
        }
    }

    [Flags]
    public enum VehicleStatus
    {
        Lights = 1,
        Doors  = 2,
        Klima  = 4,
        Engine = 8
    }
}
