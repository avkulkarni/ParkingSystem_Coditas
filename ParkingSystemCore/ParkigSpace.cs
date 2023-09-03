using ParkingSystemCore.Enums;
using ParkingSystemCore.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystemCore
{
    /// <summary>
    /// Class to park on remove vehicles
    /// </summary>
    public class ParkigSpace
    {
        // Add new slots here
        HashSet<Slot> _slots = new HashSet<Slot>();

        HashSet<IVehicle> _parkedVehicles = new HashSet<IVehicle>();
        
        public ParkigSpace(Dictionary<SlotTypeEnum, int> spaceConfiguration)
        {
            if (spaceConfiguration == null || spaceConfiguration.Count == 0)
            {
                throw new Exception("spaceConfiguration is required !!");
            }

            foreach (var item in spaceConfiguration)
            {
                _slots.Add(new Slot(item.Key, item.Value));
            }
        }

        private static IVehicle GetVehicle(VehicleTypeEnum vehicleType)
        {
            IVehicle vehicle = null;
            switch (vehicleType)
            {
                case VehicleTypeEnum.HATCHBACK:
                    vehicle = new Hatchback();
                    break;
                case VehicleTypeEnum.Sedan:
                    vehicle = new Sedan();
                    break;
                case VehicleTypeEnum.SUV:
                    vehicle = new SUV();
                    break;
                default:
                    break;
            }
            return vehicle;
        }

        /// <summary>
        /// Parks the give vehicleType
        /// </summary>
        /// <param name="vehicleType">VehicleType Enum</param>
        /// <returns>true if successfully parked; false if no space available for given type.</returns>
        public bool Park(VehicleTypeEnum vehicleType)
        {
            IVehicle vehicle = GetVehicle(vehicleType);

            foreach (var vSlot in vehicle.SlotTypes)
            {
                Slot? slot = _slots.Where(s => s.SType == vSlot).FirstOrDefault();
                if (slot != null)
                {
                    if (slot.IsSpaceAvailable())
                    {
                        if (slot.Park())
                        {
                            vehicle.AssignedSlot = slot;
                            _parkedVehicles.Add(vehicle);
                            return true;
                        }
                    }
                    continue;
                }
            }
            return false;
        }

        /// <summary>
        /// Removes vehicle from parking
        /// </summary>
        /// <param name="vehicleType">VehicleType Enum</param>
        /// <returns>true if vehicle removed succesfully; false if vehicle type is not parked.</returns>
        public bool Remove(VehicleTypeEnum vehicleType)
        {
            // Check from parked vehicles
            IVehicle? vehicle = _parkedVehicles.Where(v => v.VehicleType == vehicleType).FirstOrDefault();

            if (vehicle != null)
            {
                foreach (var vSlot in vehicle.SlotTypes)
                {
                    Slot? slot = _slots.Where(s => s.SType == vSlot).FirstOrDefault();
                    if (slot != null)
                    {
                        if (slot.Remove())
                        {
                            _parkedVehicles.Remove(vehicle);
                            return true;
                        }
                        continue;
                    }
                }
            }

            return false;
        }

        public void PrintAvaialbleSlots()
        {
            foreach (var slot in _slots)
            {
                Console.WriteLine($"SlotType={slot.SType} SlotLimt={slot.SlotLimt} OccupiedSpace={slot.OccupiedSpace} FreeSpace={slot.FreeSpace} ");
            }
        }
    }
}
