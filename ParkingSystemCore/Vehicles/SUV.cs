using ParkingSystemCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystemCore.Vehicles
{
    internal class SUV : IVehicle
    {
        List<SlotTypeEnum> slotTypes = new List<SlotTypeEnum>() { SlotTypeEnum.LARGE };
        public VehicleTypeEnum VehicleType { get => VehicleTypeEnum.SUV; }
        public List<SlotTypeEnum> SlotTypes { get => slotTypes; }
        public Slot AssignedSlot { get; set; }
    }
}
