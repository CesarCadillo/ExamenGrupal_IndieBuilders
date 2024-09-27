using System;
using System.Collections.Generic;
using System.Linq;

namespace ExGrupal_IndieBuilders
{
    public class Node
    {
        public List<IEntity> Entities { get; private set; }
        public bool IsPlayerBase { get; private set; }
        public bool IsEnemyBase { get; private set; }

        public Node(bool isPlayerBase = false, bool isEnemyBase = false)
        {
            Entities = new List<IEntity>();
            IsPlayerBase = isPlayerBase;
            IsEnemyBase = isEnemyBase;
        }

        public void AddEntity(IEntity entity)
        {
            Entities.Add(entity);
        }

        public void RemoveEntity(IEntity entity)
        {
            Entities.Remove(entity);
        }

        public void ResolveCombat()
        {
            List<IEntity> playerEntities = Entities.FindAll(e => e.IsPlayerTeam());
            List<IEntity> enemyEntities = Entities.FindAll(e => !e.IsPlayerTeam());

            while (playerEntities.Count > 0 && enemyEntities.Count > 0)
            {
                // Player attack 
                foreach (var attacker in playerEntities.OfType<IAttacker>().ToList())
                {
                    if (enemyEntities.Count == 0) break;

                    var target = enemyEntities.FirstOrDefault(e => e is Unit) ?? enemyEntities.FirstOrDefault(e => e is DefenseStructure) ?? enemyEntities.First();
                    attacker.Attack(target);
                    Console.WriteLine($"{attacker.GetName()} attacks {target.GetName()} for {attacker.GetDamage()} damage.");
                    if (target.GetHealth() <= 0)
                    {
                        Console.WriteLine($"{target.GetName()} has been destroyed.");
                        enemyEntities.Remove(target);
                        Entities.Remove(target);
                    }
                }

                // Enemy attack
                foreach (var attacker in enemyEntities.OfType<IAttacker>().ToList())
                {
                    if (playerEntities.Count == 0) break;

                    var target = playerEntities.FirstOrDefault(e => e is Unit) ?? playerEntities.FirstOrDefault(e => e is DefenseStructure) ?? playerEntities.First();
                    attacker.Attack(target);
                    Console.WriteLine($"{attacker.GetName()} attacks {target.GetName()} for {attacker.GetDamage()} damage.");
                    if (target.GetHealth() <= 0)
                    {
                        Console.WriteLine($"{target.GetName()} has been destroyed.");
                        playerEntities.Remove(target);
                        Entities.Remove(target);
                    }
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
