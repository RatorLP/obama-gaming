using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionControler : MonoBehaviour
{
    //varaiable declaration
    //used for collision direction
    bool collL = false;
    bool collR = false;
    bool collU = false;
    bool collD = false;
    Vector2 collDir; //stores collision direction as a vector
    string tag; // stores the tag of the other object

    void OnCollisionEnter2D(Collision2D other) //other is the second object involved in the collision
    {

        foreach(ContactPoint2D hitPos in other.contacts)
        {
            tag = other.gameObject.tag;
            //collision point... above=(0.0, -1.0) ; below=(0.0, 1.0) ; left=(1.0, 0.0); right=(-1.0, 0.0)
            collDir = hitPos.normal;

            if (hitPos.normal[0] < -0.5){
                collR = true;
            }
            if (hitPos.normal[0] > 0.5){
                collL = true;
            }
            if (hitPos.normal[1] < -0.5){
                collU = true;
            }
            if (hitPos.normal[1] > 0.5){
                collD = true;
            }
         } 
    }

    void OnCollisionExit2D(Collision2D other) //resets all booleans after a collision
    {
        collL = false;
        collR = false;
        collU = false;
        collD = false;
        collDir = new Vector2(0.0f, 0.0f);
    }
}