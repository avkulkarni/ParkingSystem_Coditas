using ParkingSystemCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystemCore
{
    internal interface IVehicle
    {
        public VehicleTypeEnum VehicleType { get; }
        public List<SlotTypeEnum> SlotTypes { get; }
        public Slot AssignedSlot { get; set; }
    }
}
