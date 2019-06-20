using System;
using System.Collections.Generic;
using System.Linq;
using ParkingLot.App.Models;
using Xunit;

namespace ParkingLot.App.Test
{
    public class ParkingLotManagerTest
    {
        [Fact]
        public void SetEmptyLots_Creates_Five_Empty_ParkingLot()
        {
            var parkingLotManager = new ParkingLotManager();
            parkingLotManager.SetEmptyLots(5);

            for (var i = 1; i <= 5; i++)
            {
                Assert.Equal(i, parkingLotManager.GetNextEmptyLot());
            }
        }

        [Fact]
        public void GetNextEmptyLot_Returns_Closest_Empty_Lot()
        {
            var parkingLotManager = new ParkingLotManager();
            parkingLotManager.SetEmptyLots(2);
            Assert.Equal(1, parkingLotManager.GetNextEmptyLot());
        }

        [Fact]
        public void GetNextEmptyLot_Returns_Zero_If_No_Parking_Available()
        {
            var parkingLotManager = new ParkingLotManager();
            parkingLotManager.SetEmptyLots(1);
            parkingLotManager.GetNextEmptyLot();            
            Assert.Equal(0, parkingLotManager.GetNextEmptyLot());
        }

        [Fact]
        public void GetNextEmptyLot_Returns_Closest_Empty_Lot_After_Adjusting_Car_Leaving()
        {
            var parkingLotManager = new ParkingLotManager();
            parkingLotManager.SetEmptyLots(3);

            parkingLotManager.ParkCar(new Car{RegistrationNumber = "Test-Registration-Number1", Color = "Test-Color1"} , parkingLotManager.GetNextEmptyLot());
            parkingLotManager.ParkCar(new Car{RegistrationNumber = "Test-Registration-Number2", Color = "Test-Color2"} , parkingLotManager.GetNextEmptyLot());
            parkingLotManager.ParkCar(new Car{RegistrationNumber = "Test-Registration-Number3", Color = "Test-Color3"} , parkingLotManager.GetNextEmptyLot());
            
            parkingLotManager.LeaveParking(2);
            parkingLotManager.LeaveParking(3);

            Assert.Equal(2, parkingLotManager.GetNextEmptyLot());            
        }
        
        [Fact]
        public void ParkCar_Uses_Empty_Parking_Lot()
        {
            var parkingLotManager = new ParkingLotManager();
            parkingLotManager.SetEmptyLots(3);
            parkingLotManager.ParkCar(new Car { RegistrationNumber = "Test-Registration-Number1", Color = "Test-Color1" }, parkingLotManager.GetNextEmptyLot());
            Assert.Equal(2, parkingLotManager.GetNextEmptyLot());
        }

        [Fact]
        public void ParkCar_Not_Possible_When_Parking_Lots_Are_Full()
        {
            var parkingLotManager = new ParkingLotManager();
            parkingLotManager.SetEmptyLots(3);

            parkingLotManager.ParkCar(new Car { RegistrationNumber = "Test-Registration-Number1", Color = "Test-Color1" }, parkingLotManager.GetNextEmptyLot());
            parkingLotManager.ParkCar(new Car { RegistrationNumber = "Test-Registration-Number2", Color = "Test-Color2" }, parkingLotManager.GetNextEmptyLot());
            parkingLotManager.ParkCar(new Car { RegistrationNumber = "Test-Registration-Number3", Color = "Test-Color3" }, parkingLotManager.GetNextEmptyLot());

            Assert.Equal(0, parkingLotManager.GetNextEmptyLot());
        }

        [Fact]
        public void LeaveParking_Adjusts_Parking_Lot()
        {
            var parkingLotManager = new ParkingLotManager();
            parkingLotManager.SetEmptyLots(1);
            parkingLotManager.GetNextEmptyLot();
            Assert.Equal(0, parkingLotManager.GetNextEmptyLot());

            parkingLotManager.LeaveParking(1);
            Assert.Equal(1, parkingLotManager.GetNextEmptyLot());
        }        

        [Fact]
        public void GetRegistrationNumbersByCarColor_Returns_Registration_After_Parking_A_Car()
        {
            var parkingLotManager = new ParkingLotManager();
            parkingLotManager.SetEmptyLots(3);
            var car = new Car {RegistrationNumber = "Test-Registration-Number", Color = "Test-Color"};
            parkingLotManager.ParkCar(car, 1);
            
            Assert.Equal(car.RegistrationNumber, parkingLotManager.GetRegistrationNumbersByCarColor("Test-Color").First());
        }


        [Fact]
        public void GetRegistrationNumbersByCarColor_Returns_Registrations_After_Parking_Multiple_Car()
        {
            var parkingLotManager = new ParkingLotManager();
            parkingLotManager.SetEmptyLots(3);
            var car1 = new Car {RegistrationNumber = "Test-Registration-Number1", Color = "Test-Color"};
            var car2 = new Car {RegistrationNumber = "Test-Registration-Number2", Color = "Test-Color"};
            var car3 = new Car {RegistrationNumber = "Test-Registration-Number3", Color = "Test-Color"};
            parkingLotManager.ParkCar(car1, 1);
            parkingLotManager.ParkCar(car2, 1);
            parkingLotManager.ParkCar(car3, 1);

            Assert.Equal(new List<string> { car1.RegistrationNumber, car2.RegistrationNumber, car3.RegistrationNumber }, parkingLotManager.GetRegistrationNumbersByCarColor("Test-Color"));
        }

        [Fact]
        public void GetRegistrationNumbersByCarColor_Returns_Empty_Registration_After_Leaving_Parking()
        {
            var parkingLotManager = new ParkingLotManager();
            parkingLotManager.SetEmptyLots(3);
            var car1 = new Car { RegistrationNumber = "Test-Registration-Number1", Color = "Test-Color" };            
            parkingLotManager.ParkCar(car1, 1);
            parkingLotManager.LeaveParking(1);
            
            Assert.Empty(parkingLotManager.GetRegistrationNumbersByCarColor("Test-Color"));            
        }

    }
}
