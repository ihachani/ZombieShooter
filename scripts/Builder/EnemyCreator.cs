using UnityEngine;
using System.Collections;

public class EnemyCreator : MonoBehaviour {

    public GameObject spawner;
    public float frequency = 2f;
    public Cloner[] enemyPrefabs;

    void Start()
    {
        StartCoroutine(buildEnemy(frequency));
    }


    IEnumerator buildEnemy(float perdiod)
    {
        while (true)
        {
            GameObject currentEnemy = createEnemy();
            yield return new WaitForSeconds(perdiod);
        }        
    }

    GameObject createEnemy()
    {
        int selection = (new System.Random()).Next(0, enemyPrefabs.Length);
        Cloner enemyCloner = enemyPrefabs[selection];
        return enemyCloner.clone(gameObject);
    }

}
