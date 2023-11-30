using DataMunging.Utils;

namespace DataMunging.Client
{
    public class DataFinder
	{
		public string FindSmallestTemperatureDay()
		{
			var data =	FileReader.ParseWeatherData("weather.dat");
            var result = data.MinBy(x => x.AgainstOrMin).Name;
            return result;
        }

        public string FindTeamName()
        {
            var data = FileReader.ParseFootballData("football.dat");
			var result = data.MinBy(x => Math.Abs(x.ForOrMax - x.AgainstOrMin)).Name;
			return result;
        }
    }
}