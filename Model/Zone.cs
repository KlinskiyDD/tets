using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGeneration.Model
{
    public class Zone
    {
        /// <summary>
        /// Название станции
        /// </summary>
        public Station CurrentStation { get; set; }

        /// <summary>
        /// Название спутника
        /// </summary>
        public Satellite CurrentSatellite { get; set; }

        /// <summary>
        /// Время вхождения в зону
        /// </summary>
        public DateTime TimeEnter { get; set; }

        /// <summary>
        /// Время выхода из зоны
        /// </summary>
        public DateTime TimeLeave { get; set; }

        /// <summary>
        /// Длина зоны покрытия.
        /// TODO: Пусть у всех будет 2000км. Точно ли такая зона покрытия будет у каждой станции?
        /// </summary>
        public const int AreaLength = 2000;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="station">Станция</param>
        /// <param name="satellite">Спутник</param>
        /// <param name="timeEnter">Время входа</param>
        /// <param name="speed">Время выхода</param>
        public Zone(Station station, Satellite satellite, DateTime timeEnter, double speed)
        {
            CurrentStation = station;
            CurrentSatellite = satellite;
            TimeEnter = timeEnter;
            TimeLeave = TimeEnter.Add(new TimeSpan(0,0, Convert.ToInt32(AreaLength / speed)));
        }
        
        /// <summary>
        /// Расчитываем зоны для одного спутника и станции на 24 часа.
        /// </summary>
        /// <param name="zone">Зона первого вхождения спутника в область видимости станции</param>
        /// <returns>Лист зон для одного спутника и одной станции за весь день.</returns>
        public static List<Zone> CalculateTimeAllDay (Zone zone)
        {
            var listZone = new List<Zone> { zone };

            var StartTime = zone.CurrentSatellite.StartTime;
            var TimeEnd = zone.CurrentSatellite.StartTime + new TimeSpan(1,0,0,0);

            while (StartTime < TimeEnd)
            {
                StartTime += zone.CurrentSatellite.OrbitalTime;
                listZone.Add(new Zone(zone.CurrentStation,zone.CurrentSatellite,StartTime, zone.CurrentSatellite.Speed));
            }

            return listZone;
        }
    }
}
