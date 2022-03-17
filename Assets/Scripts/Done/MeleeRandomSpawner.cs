using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeleeRandomSpawner : MonoBehaviour
{
    public GameObject EnemyPrefab1; //takes a Prefab of the needed enemy
    public GameObject EnemyPrefab2;
    public float radius = 1f;
    // Start is called before the first frame update
    void Start()
    {
            RandomlySpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void RandomlySpawnEnemy() //randomly chooses enemy position; only chooses one
    {
        int roll = Random.Range(1, 4); //rolls a random number between 1 and 2; including 1 and 2
        if (roll == 1)
        {
            Vector3 randomPos = Random.insideUnitCircle * radius;
            Instantiate(EnemyPrefab1, this.transform.position + randomPos, Quaternion.identity);
        }
        if (roll == 2)
        {
            Vector3 randomPos = Random.insideUnitCircle * radius;
            Instantiate(EnemyPrefab1, this.transform.position + randomPos, Quaternion.identity);
        }
        if (roll == 3)
        {
            Vector3 randomPos = Random.insideUnitCircle * radius;
            Instantiate(EnemyPrefab2, this.transform.position + randomPos, Quaternion.identity);
        }
        if (roll == 4)
        {
            Vector3 randomPos = Random.insideUnitCircle * radius;
            Instantiate(EnemyPrefab2, this.transform.position + randomPos, Quaternion.identity);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }

}
