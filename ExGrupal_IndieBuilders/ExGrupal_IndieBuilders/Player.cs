using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExGrupal_IndieBuilders
{
    public class Player
    {
        public int Money { get; private set; }
        public List<Structure> Structures { get; private set; }
        public List<Unit> Units { get; private set; }
        private int buildCapacity;

        public Player(int initialMoney, int initialBuildCapacity)
        {
            Money = initialMoney;
            Structures = new List<Structure>();
            Units = new List<Unit>();
            buildCapacity = initialBuildCapacity;
        }

        public void AddMoney(int amount)
        {
            Money += amount;
        }

        public bool CreateStructure(string type, Map map)
        {
            if (Structures.Count >= buildCapacity)
            {
                Console.WriteLine("¡Build capacity is at max, you cannot build more structures!\n");
                return false;
            }

            Structure newStructure = null;
            switch (type.ToLower())
            {
                case "collection":
                    newStructure = new CollectionStructure("Collector", 100, 50, 20, true);
                    break;
                case "maintenance":
                    newStructure = new MaintenanceStructure("Maintainer", 150, 75, 2, true);
                    break;
                case "defense":
                    newStructure = new DefenseStructure("Defender", 200, 100, 15, true);
                    break;
                default:
                    Console.WriteLine("Invalid structure type.\n");
                    return false;
            }

            if (newStructure.GetPrice() > Money)
            {
                Console.WriteLine("Not enough money to build this structure.\n");
                return false;
            }

            Money -= newStructure.GetPrice();
            Structures.Add(newStructure);
            map.Nodes[0].AddEntity(newStructure);
            Console.WriteLine($"{newStructure.GetName()} built successfully.\n");
            return true;
        }

        public bool CreateUnit(string type, Map map)
        {
            Unit newUnit = null;
            switch (type.ToLower())
            {
                case "soldier":
                    newUnit = new Soldier("Player Soldier", 50, 30, 10, 1, true);
                    break;
                case "tank":
                    newUnit = new Tank("Player Tank", 100, 60, 20, 2, true);
                    break;
                case "helicopter":
                    newUnit = new Helicopter("Player Helicopter", 150, 40, 30, 3, true);
                    break;
                default:
                    Console.WriteLine("Invalid unit type.");
                    return false;
            }

            if (newUnit.GetPrice() > Money)
            {
                Console.WriteLine("Not enough money to create this unit.\n");
                return false;
            }

            Money -= newUnit.GetPrice();
            Units.Add(newUnit);
            map.Nodes[0].AddEntity(newUnit);
            Console.WriteLine($"{newUnit.GetName()} created successfully.\n");
            return true;
        }

        public void CollectMoney()
        {
            foreach (var structure in Structures)
            {
                if (structure is CollectionStructure collectionStructure)
                {
                    AddMoney(collectionStructure.CollectMoney());
                }
            }
        }

        public void IncreaseBuildCapacity()
        {
            foreach (var structure in Structures)
            {
                if (structure is MaintenanceStructure maintenanceStructure)
                {
                    buildCapacity += maintenanceStructure.GetAdditionalCapacity();
                }
            }
        }

        public void DisplayStructures()
        {
            Console.WriteLine("Player Structures:\n");
            foreach (var structure in Structures)
            {
                Console.WriteLine($"{structure.GetName()} - Health: {structure.GetHealth()}\n");
            }
        }

        public void DisplayUnits()
        {
            Console.WriteLine("Player Units:\n");
            foreach (var unit in Units)
            {
                Console.WriteLine($"{unit.GetName()} - Health: {unit.GetHealth()}, Damage: {unit.GetDamage()}\n");
            }
        }
    }
}
