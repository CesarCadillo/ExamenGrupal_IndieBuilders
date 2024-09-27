namespace ExGrupal_IndieBuilders
{
    public interface IEntity
    {
        string GetName();
        int GetPrice();
        int GetHealth();
        bool IsPlayerTeam();
        void SetHealth(int health);
        void TakeDamage(int damage);
    }
}
