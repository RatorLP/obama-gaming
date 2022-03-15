using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemRandomSpawner : MonoBehaviour
{
    public GameObject ItemPrefab1; //takes a Prefab of the needed item
    public GameObject ItemPrefab2;
    public GameObject ItemPrefab3;
    public GameObject ItemPrefab4;
    public GameObject ItemPrefab5;
    public float radius = 1; //used to make the spawn circle of the selected item
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Henrik-Gegner")) //only spawns the item at the start
        {
            RandomlySpawnItem();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomlySpawnItem() //randomly chooses item position; only chooses one
    {
        int roll = Random.Range(1, 5); //rolls a radnom number between 1 and 5; including 1 and 5
        if (roll == 1)
        {
            Vector3 randomPos = Random.insideUnitCircle * radius;
            Instantiate(ItemPrefab1, this.transform.position + randomPos, Quaternion.identity);
        }
        if (roll == 2)
        {
            Vector3 randomPos = Random.insideUnitCircle * radius;
            Instantiate(ItemPrefab2, this.transform.position + randomPos, Quaternion.identity);
        }
        if (roll == 3)
        {
            Vector3 randomPos = Random.insideUnitCircle * radius;
            Instantiate(ItemPrefab3, this.transform.position + randomPos, Quaternion.identity);
        }
        if (roll == 4)
        {
            Vector3 randomPos = Random.insideUnitCircle * radius;
            Instantiate(ItemPrefab4, this.transform.position + randomPos, Quaternion.identity);
        }
        if (roll == 5)
        {
            Vector3 randomPos = Random.insideUnitCircle * radius;
            Instantiate(ItemPrefab5, this.transform.position + randomPos, Quaternion.identity);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }
}
