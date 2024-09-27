using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExGrupal_IndieBuilders
{
    public class Enemy
    {
        public List<Unit> Units { get; private set; }
        public List<Structure> Structures { get; private set; }
        private int turnCount;
        private Random random;

        public Enemy()
        {
            Units = new List<Unit>();
            Structures = new List<Structure>();
            turnCount = 0;
            random = new Random();
        }

        public void CreateEnemies(Map map)
        {
            int enemiesToCreate = Fibonacci(turnCount);
            for (int i = 0; i < enemiesToCreate; i++)
            {
                Unit newUnit;
                double randomValue = random.NextDouble();
                if (turnCount < 10)
                {
                    if (randomValue < 0.6)
                        newUnit = new Soldier("Enemy Soldier", 0, 30, 10, 1, false);
                    else if (randomValue < 0.9)
                        newUnit = new Tank("Enemy Tank", 0, 60, 20, 2, false);
                    else
                        newUnit = new Helicopter("Enemy Helicopter", 0, 40, 30, 3, false);
                }
                else
                {
                    if (randomValue < 0.33)
                        newUnit = new Soldier("Enemy Soldier", 0, 30, 10, 1, false);
                    else if (randomValue < 0.66)
                        newUnit = new Tank("Enemy Tank", 0, 60, 20, 2, false);
                    else
                        newUnit = new Helicopter("Enemy Helicopter", 0, 40, 30, 3, false);
                }

                Units.Add(newUnit);
                map.Nodes[4].AddEntity(newUnit);
            }

            if (random.Next(100) < 30 && Structures.Count < 3)
            {
                Structure newStructure;
                if (random.Next(100) < 50)
                    newStructure = new DefenseStructure("Enemy Defense", 0, 100, 15, false);
                else
                    newStructure = new CollectionStructure("Enemy Collector", 0, 50, 20, false);

                Structures.Add(newStructure);
                map.Nodes[4].AddEntity(newStructure);
            }

            turnCount++;
        }

        private int Fibonacci(int n)
        {
            if (n <= 1) return n;
            int a = 0, b = 1;
            for (int i = 2; i <= n; i++)
            {
                int temp = a + b;
                a = b;
                b = temp;
            }
            return b;
        }

        public void DisplayEnemies()
        {
            Console.WriteLine("Enemy Units:");
            foreach (var unit in Units)
            {
                Console.WriteLine($"{unit.GetName()} - Health: {unit.GetHealth()}, Damage: {unit.GetDamage()}");
            }
        }

        public bool HasUnits()
        {
            return Units.Count > 0;
        }

        public void RemoveDeadUnits()
        {
            Units.RemoveAll(u => u.GetHealth() <= 0);
        }
    }
}
