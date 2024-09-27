using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExGrupal_IndieBuilders
{
    public abstract class Unit: IEntity, IAttacker
    {
        protected string name;
        protected int price;
        protected int health;
        protected int damage;
        protected int speed;
        protected bool isPlayerTeam;

        public string GetName() => name;
        public int GetPrice() => price;
        public int GetHealth() => health;
        public bool IsPlayerTeam() => isPlayerTeam;
        public void SetHealth(int health) => this.health = health;
        public void TakeDamage(int damage) => health = Math.Max(0, health - damage);
        public int GetDamage() => damage;
        public abstract void Attack(IEntity target);
    }
}
