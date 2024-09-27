using System;

public class Helicopter : Unit
{
    public Helicopter(string name, int price, int health, int damage, int speed, bool isPlayerTeam)
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
        if (target is Tank || target is Structure)
        {
            target.TakeDamage(damage);
        }
    }
}