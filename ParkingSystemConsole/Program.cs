using System;
using ParkingSystemCore;
using ParkingSystemCore.Enums;

namespace ParkingSystema_Coditas
{
    internal class Program
    {
        // Init 
        static ParkigSpace _parkigSpace = new ParkigSpace(new Dictionary<SlotTypeEnum, int>()
        {
            { SlotTypeEnum.SMALL, 5 },
            { SlotTypeEnum.MEDIUM, 3 },
            { SlotTypeEnum.LARGE, 2 },
        });

        static void Main(string[] args)
        {
            int enrtyType = 0;
            do
            {
                enrtyType = GetEntryTypeFromMainMenu();
                switch (enrtyType)
                {
                    case 1:
                        AddCarSelection();
                        break;
                    case 2:
                        RemoveCarSelection();
                        break;
                    case 3:
                        ShowSpaceAvailability();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Not a valid selection. Please try again !");
                        break;
                }

                Console.ResetColor();
                Console.WriteLine("======================================");
            } while (enrtyType != 0);
        }

        static void AddCarSelection()
        {
            VehicleTypeEnum? vehicleType = GetVehicleETypeFromMenu();
            if (vehicleType == null) return;

            bool isVehicleAdded = _parkigSpace.Park((VehicleTypeEnum)vehicleType);
            if (isVehicleAdded)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Vehicle added successfully for type {vehicleType} !");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Vehicle parking space NOT available for type {vehicleType}:-( Please come back later or try other type of vehicle.");
            }
        }

        static void RemoveCarSelection()
        {
            VehicleTypeEnum? vehicleType = GetVehicleETypeFromMenu();
            if (vehicleType == null) return;

            bool isVehicleRemnoved = _parkigSpace.Remove((VehicleTypeEnum)vehicleType);

            if (isVehicleRemnoved)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Vehicle parking space freed successfully for type {vehicleType}!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"No vehicles in the space for type {vehicleType}. Try again with another type!");
            }
        }

        static void ShowSpaceAvailability()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            _parkigSpace.PrintAvaialbleSlots();
            Console.ResetColor();
        }
        
        static int GetEntryTypeFromMainMenu()
        {
            int enrtyType;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("====== MAIN SELECTION MENU ==========");
            Console.WriteLine("1. Add Vehicle");
            Console.WriteLine("2. Remove Vehicle");
            Console.WriteLine("3. Show Space Availability");
            Console.WriteLine("0. Exit");
            Console.ResetColor();
            Console.Write("Select an option : ");
            string enrtyTypeStr = Console.ReadLine();

            if (string.IsNullOrEmpty(enrtyTypeStr))
                enrtyType = 3;
            else
            {
                enrtyType = int.TryParse(enrtyTypeStr, out enrtyType) ? enrtyType : 3;
            }

            Console.ResetColor();
            return enrtyType;
        }

        static VehicleTypeEnum? GetVehicleETypeFromMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            VehicleTypeEnum? vehicleType = null;            
            Console.WriteLine("---- Select Vehicle Type -------- ");
            Console.WriteLine("1. Hatchback");
            Console.WriteLine("2. Sedan/Compact SUV");
            Console.WriteLine("3. SUV/Large cars");
            //Console.WriteLine("4. Two Wheelers");
            //Console.WriteLine("5. Trucks");
            Console.WriteLine("0. Go back to MAIN Menu");
            Console.Write("Select Vehicle Type : ");
            string vehicleTypeStr = Console.ReadLine();

            if (string.IsNullOrEmpty(vehicleTypeStr))
                vehicleType = 0;
            else
            {
                switch (vehicleTypeStr)
                {
                    case "1":
                        vehicleType = VehicleTypeEnum.HATCHBACK;
                        break;
                    case "2":                    
                        vehicleType = VehicleTypeEnum.Sedan;
                        break;
                    case "3":
                        vehicleType = VehicleTypeEnum.SUV;
                        break;                   
                    default:
                        Console.WriteLine("Not a valid type selection !");
                        break;
                }
            }
            Console.ResetColor();
            return vehicleType;
        }

    }
}