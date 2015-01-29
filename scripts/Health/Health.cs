using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int maxHealth = 100;
    public int minHealth = 0;
    public int current = 100;
    public int unit = 1;
    public HealthHandler[] healthHandlers;

    // Death Event Handler
    public delegate void OnDeathEvent(Health health);
    public event OnDeathEvent OnDeath;

    // Health Up Event Handler
    public delegate void OnHealthUpEvent(Health health);
    public event OnHealthUpEvent OnHealthUp;

    // Health Down Event Handler
    public delegate void OnHealthDownEvent(Health health);
    public event OnHealthDownEvent OnHealthDown;

    void Awake()
    {
        foreach (HealthHandler healthHandler in healthHandlers)
        {
            healthHandler.attach(this);
        }
    }

    public int decrease(int value)
    {
        if (value >= 0) 
        {
            value = value * unit;
            if (current >= value)
            {
                current = current - value;
            }
            else
            {
                minimize();
            }
            if (OnHealthDown != null)
            {
                OnHealthDown(this);
            }
            if (isDead() && (OnDeath != null))
            {
                OnDeath(this);
            }
        }
        return get();
    }

    public int increase(int value)
    {
        if (value >= 0)
        {
            value = value * unit;
            if (maxHealth >= (current + value))
            {
                current = current + value;
                if (OnHealthUp != null)
                {
                    OnHealthUp(this);
                }
            }
            else
            {
                maximaze();
            }
        }
        return get();
    }

    public int get()
    {
        return current;
    }

    public void set(int value)
    {
        if (value >= 0)
        {
            current = value;
            if (isDead() && (OnDeath != null))
            {
                OnDeath(this);
            }
        }
    }

    public void setUnit(int value)
    {
        if (value >= 0)
        {
            unit = value;
        }
    }

    public void maximaze()
    {
        set(getMax());
    }

    public void minimize()
    {
        set(getMin());
    }

    public int getMax()
    {
        return maxHealth;
    }

    public int getMin()
    {
        return minHealth;
    }

    public void setMax(int value)
    {
        if (value > 0)
        {
            maxHealth = value;
        }
    }

    public void setMin(int value)
    {
        if (value >= 0)
        {
            minHealth = value;
        }
    }

    public bool isDead()
    {
        return (getMin() == get());
    }

    public bool isAlive()
    {
        return (getMin() < get());
    }

    public int getRemainingHealth()
    {
        return (maxHealth - current);
    }
}
