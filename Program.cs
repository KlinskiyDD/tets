// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices.ComTypes;
using System.Text.Json;
using DataGeneration;
using DataGeneration.Model;


var random = new Random();

var stations = Factory.GetStation(5, 2);
var satellites = Factory.GetSatellite(3, 1);

//Сортируем станции по расположению на экваторе.
stations.Sort(delegate(Station c1, Station c2) { return c1.Location.CompareTo(c2.Location); });

var zones = Factory.GetInitialZone(satellites, stations);


//Расчет зон для всех спутников в течение дня.
var result = new List<Zone>();
foreach (var zone in zones)
{
    result.AddRange(Zone.CalculateTimeAllDay(zone));
}



string jsonZone = JsonSerializer.Serialize(result);
File.WriteAllText(@"Zone.json", jsonZone);




//foreach (var g in result)
//{
//    Console.WriteLine($"{g.CurrentSatellite.Name} достиг станцию {g.CurrentStation.Name} в {g.TimeEnter.ToString("HH:mm:ss")} и покинул ее в {g.TimeLeave.ToString("HH:mm:ss")}");
//}

//Console.Read();

