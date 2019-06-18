using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot.App.Models
{
    public class ParkingLot
    {
        private List<int> EmptyLots { get; set; }
        private Dictionary<string, Car> Cars { get; set; }
        private Dictionary<string, List<string>> ColorToRegistrationsMapping { get; set; }
        private Dictionary<string, int> RegistrationToParkingSlotMapping { get; set; }

        public ParkingLot()
        {
            EmptyLots= new List<int>();
            Cars= new Dictionary<string, Car>();
            ColorToRegistrationsMapping = new Dictionary<string, List<string>>();
            RegistrationToParkingSlotMapping= new Dictionary<string, int>();
        }

        public void ParkCar(Car car, int slot)
        {
            RegistrationToParkingSlotMapping.Add(car.RegistrationNumber, slot);
            Cars.Add(car.RegistrationNumber, car);

            if (ColorToRegistrationsMapping.ContainsKey(car.Color))
            {
                ColorToRegistrationsMapping[car.Color].Add(car.RegistrationNumber);
            }
            else
            {
                ColorToRegistrationsMapping.Add(car.Color, new List<string> {car.RegistrationNumber});
            }
        }

        public void LeaveParking(int slot)
        {
            var registrationNumber = RegistrationToParkingSlotMapping.FirstOrDefault(f => f.Value == slot).Key;
            RegistrationToParkingSlotMapping.Remove(registrationNumber);

            var car = Cars[registrationNumber];
            Cars.Remove(registrationNumber);

            ColorToRegistrationsMapping[car.Color].Remove(car.RegistrationNumber);
        }


        public void SetEmptyLots(int n)
        {
            for(var i=1; i<=n; i++) EmptyLots.Add(i);
        }

        public int GetNextEmptyLot()
        {
            var lotNumber = 0;
            if (EmptyLots.Any())
            {
                lotNumber = EmptyLots.First();
                EmptyLots.RemoveAt(0);                
            }

            return lotNumber;
        }

        public void UpdateEmptyLot(int n)
        {
            EmptyLots.Add(n);
            EmptyLots.Sort();
        }
    }
}
