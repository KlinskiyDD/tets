using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataGeneration.Model
{
    public class Antenna
    {
        /// <summary>
        /// ID антенны
        /// </summary>
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        /// <summary>
        /// Скорость передачи данных
        /// </summary>
        [JsonPropertyName("TransferRate")]
        public double TransferRate { get; set; }

        /// <summary>
        /// Ограничения
        /// </summary>
        public AntennaType Type;

        [JsonPropertyName("Type")]
        public string StringType => Type.ToString();

        /// <summary>
        /// Конструктор антенн
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        public Antenna(int id, int type)
        {
            Id = id;
            Type = (AntennaType)type;
        }

        /// <summary>
        /// Генератор антенн.
        /// </summary>
        /// <param name="antennasCount">Количество антенн</param>
        /// <returns>Лист антенн</returns>
        public static List<Antenna> GetListAntennas(int antennasCount)
        {
            var result = new List<Antenna>();
            var random = new Random();

            for (var i = 0; i < antennasCount; i++)
            {
                var newAntenna = new Antenna(i, random.Next(0, 4));

                if (result.All(x => x.Type != newAntenna.Type)) 
                    result.Add(newAntenna);
            }

            return result;
        }
    }

    public enum AntennaType
    {
        FirstType = 0,
        SecondType = 1,
        ThirdType = 2,
        FourthType = 3,
    }
}
