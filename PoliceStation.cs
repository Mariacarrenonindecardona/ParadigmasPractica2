using System;
using Practice1;

namespace Practice1
{
	public class PoliceStation
	{
		public List<PoliceCar> policeCars { get; private set; }
		public PoliceStation()
		{
		}

		public PoliceCar AddPoliceCar(string newPlate)
		{
            PoliceCar policeCar = new PoliceCar(newPlate, this); //Relacion de composicion
            policeCars.Add(policeCar);
			return policeCar;
		}

		public void ActUponAlarm(string infractionPlate)
		{
            foreach (PoliceCar policeCar in policeCars)
            {
				bool currentPatrolling = policeCar.IsPatrolling();
				if (currentPatrolling)
				{
					policeCar.PersecuteCar(infractionPlate);
				}
            }
        }
	}
}

