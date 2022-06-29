using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomwWorkUnificationTroops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            database.PerformTask();
            Console.ReadLine(); 
        }
    }

    class Database
    {
        private List<Soldier> _solrersSquadOne = new List<Soldier>()
        {
            new Soldier("Евгений", "Жыкавец", "Анатольевичь","рядовой"),
            new Soldier("Евгений", "Быкавец", "Анатольевичь","рядовой"),
            new Soldier("Анатолий", "Самойлов", "Петрович","рядовой"),
            new Soldier("Илья", "Лебедев", "Анатольевичь","рядовой"),
            new Soldier("Анатолий", "Лебедев", "Анатольевичь","сержант"),
        };
        private List<Soldier> _solrersSquadTwo = new List<Soldier>()
        {
            new Soldier("Николай", "Бажанов", "Дмитриевичь","рядовой"),
            new Soldier("Евгений", "Сыкавец", "Анатольевичь","рядовой"),
            new Soldier("Анатолий", "Самойлов", "Петрович","рядовой"),
            new Soldier("Илья", "Лебедев", "Анатольевичь","рядовой"),
        };

        public void PerformTask()
        {
            MoveSelectedSoldiers();
            ShowInfo(_solrersSquadTwo);
        }

        private void MoveSelectedSoldiers()
        {
            var soldiers = _solrersSquadOne.Where(soldier => soldier.Surname.Contains("Б"));
            _solrersSquadTwo = _solrersSquadTwo.Union(soldiers).ToList();
            _solrersSquadOne = _solrersSquadTwo.Except(soldiers).ToList();
        }

        private void ShowInfo(List<Soldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                soldier.ShowInfo();
            }
        }
    }

    class Soldier
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Patronymic { get; private set; }
        public string Rang { get; private set; }

        public Soldier(string name, string surname, string patronymic, string rang)
        {
            Name = name;    
            Surname = surname;
            Patronymic = patronymic;
            Rang = rang;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"ФИО - {Surname} {Name}  {Patronymic}, звание - {Rang}");
        }
    }
}
