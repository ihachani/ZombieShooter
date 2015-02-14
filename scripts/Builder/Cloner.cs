using UnityEngine;
using System.Collections;

public class Cloner : MonoBehaviour {

    public virtual GameObject clone(GameObject parent)
    {
        GameObject clone = Instantiate(gameObject) as GameObject;
        clone.transform.SetParent(parent.transform);
        return clone;
    }
}
