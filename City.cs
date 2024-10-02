using System;
namespace Practice1
{
	public class City
	{
		private PoliceStation? policeStation = null;
		private string cityName;


        public City(string cityName)
		{
			this.cityName = cityName;
		}

		public void AddPoliceStation(PoliceStation policeStation)
		{
			this.policeStation = policeStation;
            Console.WriteLine(WriteMessage("You have"));
        }
        public string WriteMessage(string message)
        {
            return $"{this}: {message}";
        }

        public override string ToString()
        {
            return $"{cityName}";
        }
    }
}

