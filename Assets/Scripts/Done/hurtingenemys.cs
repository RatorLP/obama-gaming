using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtingenemys : MonoBehaviour
{
    public float MaxHp; //displays the maxium amount of HP you can have
    float CurrHp; //displays your current amount HP in natural numbers

    // Start is called before the first frame update
    void Start()
    {
        CurrHp = MaxHp;
    }

    public void TakeDmg(float gotteddmg)
    {
        CurrHp -= gotteddmg; 

        if (CurrHp <= 0)// destroys the Enemy if it's health reaches zero
        {
            Destroy(this.gameObject);
        }
    }
}
