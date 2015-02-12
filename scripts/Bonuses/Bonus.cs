using UnityEngine;
using System.Collections;

public class Bonus : MonoBehaviour {

    private int value;

    public virtual void show()
    {

    }

    public virtual void consume()
    {
        Destroy(this);
    }

    public int get()
    {
        return value;
    }

    public void set(int value)
    {
        this.value = value;
    }
}
