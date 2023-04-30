using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGeneration.Model
{
    public class Station
    {
        /// <summary>
        /// Название станции
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список доступных антенн
        /// </summary>
        public List<Antenna> Antennas { get; set; }

        /// <summary>
        /// Расположение станции.
        /// Для теста все станции будут расположены на диаметре экватора от 0 до 12756 км
        /// </summary>
        public int Location { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Ид станции</param>
        /// <param name="location">Расположение станции</param>
        /// <param name="AntennaCount">Количество антенн</param>
        public Station(int id, int location, int AntennaCount)
        {
            Name = $"Станция номер {id}";
            Antennas = Antenna.GetListAntennas(AntennaCount);
            Location = location;
        }
    }
}
