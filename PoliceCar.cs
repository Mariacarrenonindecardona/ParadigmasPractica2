namespace Practice1
{
    public class PoliceCar : VehicleWithPlate
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car";
        private bool isPatrolling;
        private bool isPersecuting;
        private SpeedRadar? speedRadar;
        private PoliceStation station;

        public PoliceCar(string plate, PoliceStation station, SpeedRadar? speedRadar = null) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            isPersecuting = false;
            this.speedRadar = speedRadar;
            this.station = station;
        }

        public void UseRadar(VehicleWithPlate vehicle)
        {
            if (isPatrolling && speedRadar != null)
            {   
                speedRadar.TriggerRadar(vehicle);
                bool speeding = speedRadar.GetLastReading();
                if (speeding)
                { 
                    Console.WriteLine(WriteMessage($"Triggered radar. Result: Catched above legal speed"));
                    station.ActUponAlarm(vehicle.GetPlate());
                }
                else
                {
                    Console.WriteLine(WriteMessage($"Triggered radar. Result: Driving legally"));
                }

            }
            else if (speedRadar == null)
            {
                Console.WriteLine(WriteMessage($"has no radar."));

            }
            else
            {
                Console.WriteLine(WriteMessage($"has no active radar."));
            }
        }

        public bool IsPatrolling()
        {
            return isPatrolling;
        }

        public void SetIsPerseuting(bool newState)
        {
            isPersecuting = newState;
        }


        public void StartPatrolling()
        {
            if (!isPatrolling)
            {
                isPatrolling = true;
                Console.WriteLine(WriteMessage("started patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already patrolling."));
            }
        }

        public void EndPatrolling()
        {
            if (isPatrolling)
            {
                isPatrolling = false;
                isPersecuting = false;
                Console.WriteLine(WriteMessage("stopped patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("was not patrolling."));
            }
        }

        public void PrintRadarHistory()
        {
            Console.WriteLine(WriteMessage("Report radar speed history:"));
            if (speedRadar != null)
            { 
                foreach (float speed in speedRadar.SpeedHistory)
                {
                    Console.WriteLine(speed);
                }
            }
            else
            {
                Console.WriteLine("This car doesn't have a radar");
            }

        }

        public void PersecuteVehicle(string infractionPlate)
        {
            if (isPersecuting)
            {
                Console.WriteLine(WriteMessage("Already persecuting."));
            }
            else
            { 
                Console.WriteLine(WriteMessage($"Persecuting vehicle with plate: {infractionPlate}"));
                SetIsPerseuting(true);
            }
        }
    }
}