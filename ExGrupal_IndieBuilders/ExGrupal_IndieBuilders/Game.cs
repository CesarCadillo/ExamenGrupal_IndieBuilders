using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExGrupal_IndieBuilders
{
    public class Game
    {
        private Player player;
        private Enemy enemy;
        private Map map;
        private int turn;

        public Game()
        {
            player = new Player(500, 5);
            enemy = new Enemy();
            map = new Map();
            turn = 1;
        }

        public void Start()
        {
            Console.WriteLine("Welcome to the strategy game!");
            Console.WriteLine("You must place your first structure to start the game.");
            CreateStructure();

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Turn {turn}");
                Console.WriteLine($"Player Money: {player.Money}");

                player.CollectMoney();
                player.IncreaseBuildCapacity();

                map.DisplayMap();

                if (CheckGameOver())
                    break;

                ShowMenu();

                EnemyTurn();
                turn++;
            }
        }

        private void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\nChoose an action:");
                Console.WriteLine("1. View structures");
                Console.WriteLine("2. View units");
                Console.WriteLine("3. Create structure");
                Console.WriteLine("4. Create unit");
                Console.WriteLine("5. View enemies");
                Console.WriteLine("6. View map");
                Console.WriteLine("7. End turn");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        player.DisplayStructures();
                        break;
                    case "2":
                        player.DisplayUnits();
                        break;
                    case "3":
                        CreateStructure();
                        return;
                    case "4":
                        CreateUnit();
                        return;
                    case "5":
                        enemy.DisplayEnemies();
                        break;
                    case "6":
                        map.DisplayMap();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void CreateStructure()
        {
            Console.WriteLine("Choose structure type (collection/maintenance/defense):");
            string structureType = Console.ReadLine().ToLower();
            if (player.CreateStructure(structureType, map))
            {
                Console.WriteLine("Structure created. Turn ends.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Failed to create structure. Try again.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                CreateStructure();
            }
        }

        private void CreateUnit()
        {
            Console.WriteLine("Choose unit type (soldier/tank/helicopter):");
            string unitType = Console.ReadLine().ToLower();
            if (player.CreateUnit(unitType, map))
            {
                Console.WriteLine("Unit created. Turn ends.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Failed to create unit. Try again.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                ShowMenu();
            }
        }

        private void EnemyTurn()
        {
            enemy.CreateEnemies(map);
            map.MoveUnits();
        }

        private bool CheckGameOver()
        {
            bool playerHasEntities = map.Nodes.Any(node => node.Entities.Any(e => !(e is Soldier || e is Tank || e is Helicopter)));

            if (!playerHasEntities)
            {
                Console.WriteLine($"Game Over! You survived for {turn} turns.");
                Console.ReadLine();
                return true;
            }

            if (map.Nodes[4].Entities.Exists(e => e is Unit && !(e is Soldier || e is Tank || e is Helicopter)))
            {
                Console.WriteLine($"Congratulations! You won in {turn} turns.");
                Console.ReadLine();
                return true;
            }

            return false;
        }
    }
}
