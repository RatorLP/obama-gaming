using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Math;

public class EnemyTest : MonoBehaviour
{

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.position = new Vector3(3*Mathf.Sin(Time.time), 0, 0);
    }
}
