using System;
using Practice1;

namespace Practice1
{
	public class PoliceStation : IMessageWritter
	{
		public List<PoliceCar> policeCars { get; private set; }
		public PoliceStation()
		{
			policeCars = new List<PoliceCar>();
		}

		public PoliceCar AddPoliceCar(string newPlate)
		{
            PoliceCar policeCar = new PoliceCar(newPlate, this); //Relacion de composicion
            policeCars.Add(policeCar);
			return policeCar;
		}

		public void ActUponAlarm(string infractionPlate)
		{
			Console.WriteLine(WriteMessage("Sending an alarm to all the police cars"));
            foreach (PoliceCar policeCar in policeCars)
            {
				bool currentPatrolling = policeCar.IsPatrolling();
				if (currentPatrolling)
				{
                    policeCar.PersecuteVehicle(infractionPlate);
				}
            }
        }

        public virtual string WriteMessage(string message)
        {
            return $"Police Station: {message}";
        }

        public void GetCars()
		{
            Console.WriteLine(WriteMessage("Report cars in police station:"));
            foreach (PoliceCar policeCar in policeCars)
            {
                Console.WriteLine(policeCar); //ESTO ESTÁ BIEN
            }
        }

    }
}

