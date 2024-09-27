namespace ExGrupal_IndieBuilders
{
    public interface IAttacker
    {
        string GetName();
        int GetDamage();
        void Attack(IEntity target);
    }
}
