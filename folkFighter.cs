using System;

class FolkFighter
{
    private string name;
    private int health;
    private int attackPower;

    public string Name
    {
        get { return name; }
    }

    public int Health
    {
        get { return health; }
    }

    public int AttackPower
    {
        get { return attackPower; }
    }

    public FolkFighter(string name, int health, int attackPower)
    {
        this.name = name;
        this.health = health;
        this.attackPower = attackPower;
    }

    public bool StayAlive()
    {
        if (health > 0)
        {
            return true;
        }
        return false;
    }

    public void ReceiveDamage(int damage)
    {
        health = health - damage;

        if (health < 0)
        {
            health = 0;
        }
    }
}
