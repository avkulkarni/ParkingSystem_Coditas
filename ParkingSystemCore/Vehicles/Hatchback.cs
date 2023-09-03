using ParkingSystemCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystemCore.Vehicles
{
    internal class Hatchback : IVehicle
    {
        List<SlotTypeEnum> slotTypes = new List<SlotTypeEnum>() { SlotTypeEnum.SMALL, SlotTypeEnum.MEDIUM, SlotTypeEnum.LARGE };
        public VehicleTypeEnum VehicleType { get => VehicleTypeEnum.HATCHBACK; }
        public List<SlotTypeEnum> SlotTypes { get => slotTypes; }
        public Slot AssignedSlot { get; set; }
    }
}
