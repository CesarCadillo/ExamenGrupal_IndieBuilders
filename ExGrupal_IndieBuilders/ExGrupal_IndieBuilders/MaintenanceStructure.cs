using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExGrupal_IndieBuilders
{
    public class MaintenanceStructure:Structure
    {
        private int additionalCapacity;

        public MaintenanceStructure(string name, int price, int health, int additionalCapacity, bool isPlayerTeam)
        {
            this.name = name;
            this.price = price;
            this.health = health;
            this.additionalCapacity = additionalCapacity;
            this.isPlayerTeam = isPlayerTeam;
        }

        public int GetAdditionalCapacity() => additionalCapacity;
    }
}
