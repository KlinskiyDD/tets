using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGeneration.Model;

namespace DataGeneration
{
    public static class Factory
    {
        /// <summary>
        /// Генерирует список земных станций.
        /// Все станции будут рандомно расположены на длине экватора. 
        /// </summary>
        /// <param name="CountStation">Количество сгенерируемых станций станций</param>
        /// <param name="AntenaCount">Количество антен у каждой станции</param>
        /// <returns>Лист земных станций</returns>
        public static List<Station> GetStation(int CountStation, int AntenaCount)
        {
            var random = new Random();
            List<Station> stations = new List<Station>();

            for (int i = 0; i < CountStation; i++)
            {
                stations.Add(new Station(i, random.Next(0, 12756), AntenaCount));
            }
            return stations;
        }

        /// <summary>
        /// Генерирует список спутников.
        /// </summary>
        /// <param name="CountSatellite">Количество спутников</param>
        /// <param name="AntenasCount">Количество антен</param>
        /// <returns>Лист спутников</returns>
        public static List<Satellite> GetSatellite(int CountSatellite, int AntenasCount)
        {
            List<Satellite> satellites = new List<Satellite>();

            for (int i = 0; i < CountSatellite; i++)
            {
                satellites.Add(new Satellite(i, AntenasCount));
            }

            return satellites;
        }

        /// <summary>
        /// Генерирует зоны первого вхождения для каждого спутника по всем станциям
        /// </summary>
        /// <param name="satellites">Список спутников</param>
        /// <param name="stations">Список станций</param>
        /// <returns>Лист зон</returns>
        public static List<Zone> GetInitialZone(List<Satellite> satellites, List<Station> stations)
        {
            List<Zone> zones = new List<Zone>();

            foreach (var satellite in satellites)
            {
                foreach (var station in stations)
                {
                    satellite.StartTime = satellite.StartTime.Add(new TimeSpan(0, 0, Convert.ToInt32(station.Location / satellite.Speed)));
                    zones.Add(new Zone(station, satellite, satellite.StartTime, satellite.Speed));
                }
            }

            return zones;
        }
    }
}
