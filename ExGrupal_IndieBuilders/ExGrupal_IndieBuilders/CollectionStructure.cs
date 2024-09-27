using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExGrupal_IndieBuilders
{
    public class CollectionStructure:Structure
    {
        private int moneyPerTurn;

        public CollectionStructure(string name, int price, int health, int moneyPerTurn, bool isPlayerTeam)
        {
            this.name = name;
            this.price = price;
            this.health = health;
            this.moneyPerTurn = moneyPerTurn;
            this.isPlayerTeam = isPlayerTeam;
        }

        public int CollectMoney() => moneyPerTurn;
    }
}
