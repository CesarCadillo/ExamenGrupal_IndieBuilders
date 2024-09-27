using System;

namespace ExGrupal_IndieBuilders
{
    public class Structure : IEntity
    {
        protected string name;
        protected int price;
        protected int health;
        protected bool isPlayerTeam;

        public string GetName() => name;
        public int GetPrice() => price;
        public int GetHealth() => health;
        public bool IsPlayerTeam() => isPlayerTeam;
        public void SetHealth(int health) => this.health = health;
        public void TakeDamage(int damage) => health = Math.Max(0, health - damage);
    }
}
