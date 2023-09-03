using ParkingSystemCore.Enums;
using ParkingSystemCore;

namespace ParkingSystemUnitTests
{
    public class ParkigSpaceTests
    {
        [Fact]
        public void Park_Test_Success()
        {
            // Init 
            ParkigSpace parkigSpace = new ParkigSpace(new Dictionary<SlotTypeEnum, int>()
            {
                { SlotTypeEnum.SMALL, 2 },
                { SlotTypeEnum.MEDIUM, 2 },
                { SlotTypeEnum.LARGE, 2 },
            });

            Assert.True(parkigSpace.Park(VehicleTypeEnum.HATCHBACK));
            Assert.True(parkigSpace.Park(VehicleTypeEnum.HATCHBACK));
            Assert.True(parkigSpace.Park(VehicleTypeEnum.HATCHBACK));

            Assert.True(parkigSpace.Park(VehicleTypeEnum.Sedan));            
            Assert.True(parkigSpace.Park(VehicleTypeEnum.Sedan));            

            Assert.True(parkigSpace.Park(VehicleTypeEnum.SUV));
            Assert.False(parkigSpace.Park(VehicleTypeEnum.SUV));
        }

        [Fact]
        public void Park_Test_MEDIUM_Space()
        {
            // Init 
            ParkigSpace parkigSpace = new ParkigSpace(new Dictionary<SlotTypeEnum, int>()
            {
                { SlotTypeEnum.SMALL, 2 },
                { SlotTypeEnum.MEDIUM, 2 },
                { SlotTypeEnum.LARGE, 2 },
            });

            Assert.True(parkigSpace.Park(VehicleTypeEnum.HATCHBACK));
            Assert.True(parkigSpace.Park(VehicleTypeEnum.HATCHBACK));
            
            Assert.True(parkigSpace.Park(VehicleTypeEnum.HATCHBACK));
            Assert.True(parkigSpace.Park(VehicleTypeEnum.HATCHBACK));

            Assert.True(parkigSpace.Park(VehicleTypeEnum.Sedan));            
        }

        [Fact]
        public void Park_Test_No_LARGE_Space()
        {
            // Init 
            ParkigSpace parkigSpace = new ParkigSpace(new Dictionary<SlotTypeEnum, int>()
            {
                { SlotTypeEnum.SMALL, 2 },
                { SlotTypeEnum.MEDIUM, 2 },
                { SlotTypeEnum.LARGE, 2 },
            });

            Assert.True(parkigSpace.Park(VehicleTypeEnum.HATCHBACK));
            Assert.True(parkigSpace.Park(VehicleTypeEnum.HATCHBACK));

            Assert.True(parkigSpace.Park(VehicleTypeEnum.HATCHBACK));
            Assert.True(parkigSpace.Park(VehicleTypeEnum.HATCHBACK));

            Assert.True(parkigSpace.Park(VehicleTypeEnum.HATCHBACK));
            Assert.True(parkigSpace.Park(VehicleTypeEnum.HATCHBACK));

            Assert.False(parkigSpace.Park(VehicleTypeEnum.Sedan));
            Assert.False(parkigSpace.Park(VehicleTypeEnum.SUV));
        }

        [Fact]
        public void Park_Test_No_MDEIUM_Space()
        {
            // Init 
            ParkigSpace parkigSpace = new ParkigSpace(new Dictionary<SlotTypeEnum, int>()
            {
                { SlotTypeEnum.SMALL, 2 },
                { SlotTypeEnum.MEDIUM, 2 },
                { SlotTypeEnum.LARGE, 2 },
            });

            Assert.True(parkigSpace.Park(VehicleTypeEnum.HATCHBACK));
            Assert.True(parkigSpace.Park(VehicleTypeEnum.HATCHBACK));            

            Assert.True(parkigSpace.Park(VehicleTypeEnum.SUV));
            Assert.True(parkigSpace.Park(VehicleTypeEnum.SUV));

            Assert.True(parkigSpace.Park(VehicleTypeEnum.Sedan));
            Assert.True(parkigSpace.Park(VehicleTypeEnum.Sedan));

            Assert.False(parkigSpace.Park(VehicleTypeEnum.Sedan));
            Assert.False(parkigSpace.Park(VehicleTypeEnum.HATCHBACK));
            Assert.False(parkigSpace.Park(VehicleTypeEnum.SUV));
        }

        [Fact]
        public void Park_Test_OnlySMALL()
        {
            // Init 
            ParkigSpace parkigSpace = new ParkigSpace(new Dictionary<SlotTypeEnum, int>()
            {
                { SlotTypeEnum.SMALL, 3 }
            });

            Assert.True(parkigSpace.Park(VehicleTypeEnum.HATCHBACK));
            Assert.True(parkigSpace.Park(VehicleTypeEnum.HATCHBACK));
            Assert.True(parkigSpace.Park(VehicleTypeEnum.HATCHBACK));            
            
            Assert.False(parkigSpace.Park(VehicleTypeEnum.HATCHBACK));
            Assert.False(parkigSpace.Park(VehicleTypeEnum.Sedan));            
            Assert.False(parkigSpace.Park(VehicleTypeEnum.SUV));
        }

        [Fact]
        public void Park_Test_Remove()
        {
            // Init 
            ParkigSpace parkigSpace = new ParkigSpace(new Dictionary<SlotTypeEnum, int>()
            {
                { SlotTypeEnum.SMALL, 2 }
            });

            Assert.True(parkigSpace.Park(VehicleTypeEnum.HATCHBACK));
            Assert.True(parkigSpace.Park(VehicleTypeEnum.HATCHBACK));
            Assert.False(parkigSpace.Park(VehicleTypeEnum.HATCHBACK));

            Assert.True(parkigSpace.Remove(VehicleTypeEnum.HATCHBACK));
            Assert.True(parkigSpace.Park(VehicleTypeEnum.HATCHBACK));
        }

        [Fact]
        public void Park_Test_Remove_MEDIUM()
        {
            // Init 
            ParkigSpace parkigSpace = new ParkigSpace(new Dictionary<SlotTypeEnum, int>()
            {
                { SlotTypeEnum.SMALL, 2 },
                { SlotTypeEnum.MEDIUM, 2 },
                { SlotTypeEnum.LARGE, 2 }
            });

            Assert.True(parkigSpace.Park(VehicleTypeEnum.HATCHBACK));
            Assert.True(parkigSpace.Park(VehicleTypeEnum.HATCHBACK));

            Assert.True(parkigSpace.Park(VehicleTypeEnum.Sedan));
            Assert.True(parkigSpace.Park(VehicleTypeEnum.Sedan));

            Assert.True(parkigSpace.Park(VehicleTypeEnum.SUV));
            Assert.True(parkigSpace.Park(VehicleTypeEnum.SUV));

            Assert.True(parkigSpace.Remove(VehicleTypeEnum.Sedan));

            Assert.False(parkigSpace.Park(VehicleTypeEnum.SUV));
            Assert.True(parkigSpace.Park(VehicleTypeEnum.Sedan));
        }
    }
}