using System;
public class HealthSystem
{
    public event EventHandler OnHealthChange;
    private int health;
    public int healthMax;
    public HealthSystem(int healthMax)
    {
        this.healthMax = healthMax;
        health = healthMax;
    }
    public float GetHealthPercent()
    {
        return (float)health / healthMax;
    }
    public int GetHealth()
    {
        return health;
    }
    public void Damage(int dmgAmount)
    {
        health -= dmgAmount;
        if (health < 0)
        {
            health = 0;

        }
        if(OnHealthChange!=null)
        {
            OnHealthChange(this, EventArgs.Empty);
        }
    }
    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health > healthMax)
        {
            health = healthMax;
        }
        if(OnHealthChange != null)
        {
            OnHealthChange(this, EventArgs.Empty);
        }
    }
}
    
    
