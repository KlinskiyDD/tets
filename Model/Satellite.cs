using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace DataGeneration.Model
{
    public class Satellite
    {
        /// <summary>
        /// Название спутника
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список доступных антенн
        /// </summary>
        public List<Antenna> ListAntennas { get; set; }

        /// <summary>
        /// Время обращения по орбите в минутах
        /// Низкие околоземные орбиты от 160 до 2000 км
        /// 
        /// 160 км - 87 мин  - 7.85 км/с
        /// 300 км - 90 мин - 7.73 км/с
        /// 560 км - 95 мин - 7.58 км/с
        /// 1110 км - 107 мин - 7.3 км/с
        /// 1690 км - 120 мин - 7.03 км/с
        /// 2000 км - 127 мин - 6.9 км/с
        /// </summary>
        public TimeSpan OrbitalTime { get; set; }

        /// <summary>
        /// Скорость спутника.
        /// </summary>
        public double Speed { get; set; }

        /// <summary>
        /// Время старта.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Id спутника</param>
        /// <param name="antennaCount">Количество антенн</param>
        public Satellite(int id, int antennaCount)
        {
            Name = $"Cпутник номер {id}";
            ListAntennas = Antenna.GetListAntennas(antennaCount);

            var random = new Random();
            switch (random.Next(0,6))
            {
                case 0:
                    OrbitalTime = new TimeSpan(0,87,0);
                    Speed = 7.85;
                    break;
                case 1:
                    OrbitalTime = new TimeSpan(0, 90, 0);
                    Speed = 7.73;
                    break;
                case 2:
                    OrbitalTime = new TimeSpan(0, 95, 0);
                    Speed = 7.58;
                    break;
                case 3:
                    OrbitalTime = new TimeSpan(0, 107, 0);
                    Speed = 7.3;
                    break;
                case 4:
                    OrbitalTime = new TimeSpan(0, 120, 0);
                    Speed = 7.03;
                    break;
                case 5:
                    OrbitalTime = new TimeSpan(0, 127, 0);
                    Speed = 6.9;
                    break;
                default:
                    break;
            }

            StartTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, random.Next(0,24), random.Next(0, 60), random.Next(0, 60));
        }
    }
}
