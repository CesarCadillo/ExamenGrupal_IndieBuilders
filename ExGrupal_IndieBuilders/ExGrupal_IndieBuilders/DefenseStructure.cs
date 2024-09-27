using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExGrupal_IndieBuilders
{
    public class DefenseStructure:Structure,IAttacker
    {
        private int damage;

        public DefenseStructure(string name, int price, int health, int damage, bool isPlayerTeam)
        {
            this.name = name;
            this.price = price;
            this.health = health;
            this.damage = damage;
            this.isPlayerTeam = isPlayerTeam;
        }

        public int GetDamage() => damage;

        public void Attack(IEntity target)
        {
            target.TakeDamage(damage);
        }
    }
}
