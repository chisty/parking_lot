using System.Collections.Generic;
using System.Linq;

namespace ParkingLot.App.Models
{
    public class ParkingLotManager
    {
        private List<int> EmptyParkingLots { get; set; }
        private Dictionary<string, Car> Cars { get; set; }
        private Dictionary<string, List<string>> ColorToRegistrationsMapping { get; set; }
        private Dictionary<string, int> RegistrationToParkingLotMapping { get; set; }

        public ParkingLotManager()
        {
            EmptyParkingLots = new List<int>();
            Cars = new Dictionary<string, Car>();
            ColorToRegistrationsMapping = new Dictionary<string, List<string>>();
            RegistrationToParkingLotMapping = new Dictionary<string, int>();
        }

        public void ParkCar(Car car, int slot)
        {
            RegistrationToParkingLotMapping.Add(car.RegistrationNumber, slot);
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
            var registrationNumber = RegistrationToParkingLotMapping.FirstOrDefault(f => f.Value == slot).Key;
            RegistrationToParkingLotMapping.Remove(registrationNumber);

            var car = Cars[registrationNumber];
            Cars.Remove(registrationNumber);

            ColorToRegistrationsMapping[car.Color.ToLower()].Remove(car.RegistrationNumber);
            UpdateEmptyLot(slot);
        }

        public List<string> GetRegistrationNumbersByCarColor(string color)
        {
            if (ColorToRegistrationsMapping.ContainsKey(color.ToLower()) == false) return new List<string>();

            var registrations = ColorToRegistrationsMapping[color.ToLower()];
            return registrations;
        }

        public int GetSlotByRegistrationNumber(string registration)
        {
            if (RegistrationToParkingLotMapping.ContainsKey(registration)) return RegistrationToParkingLotMapping[registration];
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
                    if (RegistrationToParkingLotMapping.ContainsKey(registration))
                    {
                        list.Add(RegistrationToParkingLotMapping[registration]);
                    }
                }
            }

            return list;
        }

        public Dictionary<int, Car> GetCarsBySlotMapping()
        {
            var dataMap= new Dictionary<int, Car>();
            foreach (var registerToSlotKeyValue in RegistrationToParkingLotMapping)
            {
                var car = Cars[registerToSlotKeyValue.Key];
                dataMap.Add(registerToSlotKeyValue.Value, car);
            }

            return dataMap;
        }


        public void SetEmptyLots(int n)
        {
            for (var i = 1; i <= n; i++) EmptyParkingLots.Add(i);
        }

        public int GetNextEmptyLot()
        {
            var lotNumber = 0;
            if (EmptyParkingLots.Any())
            {
                lotNumber = EmptyParkingLots.First();
                EmptyParkingLots.RemoveAt(0);
            }

            return lotNumber;
        }

        private void UpdateEmptyLot(int n)
        {
            EmptyParkingLots.Add(n);
            EmptyParkingLots.Sort();
        }
    }
}
