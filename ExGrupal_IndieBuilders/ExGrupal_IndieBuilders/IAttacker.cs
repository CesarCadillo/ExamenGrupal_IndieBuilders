using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExGrupal_IndieBuilders
{
    public interface IAttacker
    {
        string GetName();
        int GetDamage();
        void Attack(IEntity target);
    }
}
