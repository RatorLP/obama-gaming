using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RangedRandomSpawner : MonoBehaviour
{
    public GameObject RangedEnemyPrefab1; //takes a Prefab of the needed enemy
    public GameObject RangedEnemyPrefab2;
    public float radius = 1f;
    // Start is called before the first frame update
    void Start()
    {
            RandomlySpawnEnemy(); //randomly spawn one ranged enemy
    }

    // Update is called once per frame
    void Update()
    {

    }
    void RandomlySpawnEnemy() //randomly chooses enemy position; only chooses one
    {
        int roll = Random.Range(1, 4); //rolls a random number between 1 and 4; including 1 and 4
        if (roll == 1)
        {
            Vector3 randomPos = Random.insideUnitCircle * radius;
            Instantiate(RangedEnemyPrefab1, this.transform.position + randomPos, Quaternion.identity);
        }
        else if (roll == 2)
        {
            Vector3 randomPos = Random.insideUnitCircle * radius;
            Instantiate(RangedEnemyPrefab1, this.transform.position + randomPos, Quaternion.identity);
        }
        else if (roll == 3)
        {
            Vector3 randomPos = Random.insideUnitCircle * radius;
            Instantiate(RangedEnemyPrefab2, this.transform.position + randomPos, Quaternion.identity);
        }
        else if (roll == 4)
        {
            Vector3 randomPos = Random.insideUnitCircle * radius;
            Instantiate(RangedEnemyPrefab2, this.transform.position + randomPos, Quaternion.identity);
        }
    }
    private void OnDrawGizmos() //draws spawn range (only for testing purposes)
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }

}
