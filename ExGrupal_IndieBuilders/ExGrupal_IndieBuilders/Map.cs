using System;
using System.Collections.Generic;
using System.Linq;

namespace ExGrupal_IndieBuilders
{
    public class Map
    {
        public List<Node> Nodes { get; private set; }

        public Map()
        {
            Nodes = new List<Node>
        {
            new Node(isPlayerBase: true),
            new Node(),
            new Node(),
            new Node(),
            new Node(isEnemyBase: true)
        };
        }

        public void MoveUnits()
        {            
            for (int i = 0; i < Nodes.Count - 1; i++)
            {
                var playerUnitsToMove = Nodes[i].Entities.OfType<Unit>().Where(u => u.IsPlayerTeam()).ToList();
                foreach (var unit in playerUnitsToMove)
                {
                    Nodes[i].RemoveEntity(unit);
                    Nodes[i + 1].AddEntity(unit);
                }
            }

            for (int i = Nodes.Count - 1; i > 0; i--)
            {
                var enemyUnitsToMove = Nodes[i].Entities.OfType<Unit>().Where(u => !u.IsPlayerTeam()).ToList();
                foreach (var unit in enemyUnitsToMove)
                {
                    Nodes[i].RemoveEntity(unit);
                    Nodes[i - 1].AddEntity(unit);
                }
            }

            foreach (var node in Nodes)
            {
                node.ResolveCombat();
            }
        }

        public void DisplayMap()
        {
            for (int i = 0; i < Nodes.Count; i++)
            {
                Console.Write($"Node {i + 1}: ");
                if (Nodes[i].IsPlayerBase)
                    Console.Write("[Player Base] ");
                else if (Nodes[i].IsEnemyBase)
                    Console.Write("[Enemy Base] ");

                foreach (var entity in Nodes[i].Entities)
                {
                    Console.Write($"{entity.GetName()} ({entity.GetHealth()} HP) ");
                }
                Console.WriteLine();
            }
        }
    }
}
