using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust; //

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KnockbackRegelung(Collider2D NPC)
    {
        Vector2 difference = NPC.transform.position - gameObject.transform.position;
        difference = difference.normalized * thrust; //normalized means, that the Vector has a maximum of a length of 1
        Vector3 knockback = new Vector3(difference[0], difference[1], 0);
        NPC.transform.position += knockback;
    }
}
