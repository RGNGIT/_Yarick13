using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Botanik
{
    public static class Database
    {
        // Типы растений
        public static List<string> Type = new List<string>();
        // Данные о служащих
        public static List<string> FIO = new List<string>();
        public static List<string> Phone = new List<string>();
        // Данные о растениях
        public static List<string> PlantName = new List<string>();
        public static List<string> PlantDate = new List<string>();
        public static List<string> TimeOfWatering = new List<string>();
        public static List<string> AmountOfWatering = new List<string>();
        public static List<string> Litres = new List<string>();
        // Данные о поливе
        public static List<string> PName = new List<string>();
        public static List<string> PTime = new List<string>();
        public static List<string> PWatr = new List<string>();
        public static List<string> PLitr = new List<string>();
    }
}
