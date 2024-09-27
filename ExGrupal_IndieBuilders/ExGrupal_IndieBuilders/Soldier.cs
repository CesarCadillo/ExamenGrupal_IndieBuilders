using System;

public class Soldier : Unit
{
    public Soldier(string name, int price, int health, int damage, int speed, bool isPlayerTeam)
    {
        this.name = name;
        this.price = price;
        this.health = health;
        this.damage = damage;
        this.speed = speed;
        this.isPlayerTeam = isPlayerTeam;
    }
    public override void Attack(IEntity target)
    {
        if (target.IsPlayerTeam() != this.IsPlayerTeam() && (target is Helicopter  target is Structure))
        {
            target.TakeDamage(damage);
        }
    }
}