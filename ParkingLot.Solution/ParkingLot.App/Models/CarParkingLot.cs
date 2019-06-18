using System.Collections.Generic;
using System.Linq;

namespace ParkingLot.App.Models
{
    public class CarParkingLot
    {
        private List<int> EmptyLots { get; set; }
        private Dictionary<string, Car> Cars { get; set; }
        private Dictionary<string, List<string>> ColorToRegistrationsMapping { get; set; }
        private Dictionary<string, int> RegistrationToParkingSlotMapping { get; set; }

        public CarParkingLot()
        {
            EmptyLots = new List<int>();
            Cars = new Dictionary<string, Car>();
            ColorToRegistrationsMapping = new Dictionary<string, List<string>>();
            RegistrationToParkingSlotMapping = new Dictionary<string, int>();
        }

        public void ParkCar(Car car, int slot)
        {
            RegistrationToParkingSlotMapping.Add(car.RegistrationNumber, slot);
            Cars.Add(car.RegistrationNumber, car);

            if (ColorToRegistrationsMapping.ContainsKey(car.Color.ToLower()))
            {
                ColorToRegistrationsMapping[car.Color.ToLower()].Add(car.RegistrationNumber);
            }
            else
            {
                ColorToRegistrationsMapping.Add(car.Color.ToLower(), new List<string> { car.RegistrationNumber });
            }
        }

        public void LeaveParking(int slot)
        {
            var registrationNumber = RegistrationToParkingSlotMapping.FirstOrDefault(f => f.Value == slot).Key;
            RegistrationToParkingSlotMapping.Remove(registrationNumber);

            var car = Cars[registrationNumber];
            Cars.Remove(registrationNumber);

            ColorToRegistrationsMapping[car.Color.ToLower()].Remove(car.RegistrationNumber);
        }

        public List<string> GetRegistrationNumbersByCarColor(string color)
        {
            if (ColorToRegistrationsMapping.ContainsKey(color.ToLower()) == false) return new List<string>();

            var registrations = ColorToRegistrationsMapping[color.ToLower()];
            return registrations;
        }

        public int GetSlotByRegistrationNumber(string registration)
        {
            if (RegistrationToParkingSlotMapping.ContainsKey(registration)) return RegistrationToParkingSlotMapping[registration];
            return 0;
        }


        public List<int> GetSlotNumbersOfCarByColor(string color)
        {
            var list= new List<int>();
            if (ColorToRegistrationsMapping.ContainsKey(color.ToLower()))
            {
                var registrations = ColorToRegistrationsMapping[color.ToLower()];
                foreach (var registration in registrations)
                {
                    if (RegistrationToParkingSlotMapping.ContainsKey(registration))
                    {
                        list.Add(RegistrationToParkingSlotMapping[registration]);
                    }
                }
            }

            return list;
        }


        public void SetEmptyLots(int n)
        {
            for (var i = 1; i <= n; i++) EmptyLots.Add(i);
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
