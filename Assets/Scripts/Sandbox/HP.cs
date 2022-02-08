using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    private Slider slider;

    public float MaxHp = 100; //displays your current level in natural numbers
    public float CurrHp = 100; //displays the maxium amount of HP you can have
    public float GainedDmg;
    private float targetProgress;
    private float fillspeed = 0.5F; // how fast the bar moves

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>(); //der slider, also die HP bar
    }


    // Start is called before the first frame update
    void Start()
    {

        if (slider == null)
        {
            Debug.Log("No slider found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (slider == null)
        {
            Awake();
            return;
        }

        if (GainedDmg != 0) //gerade bekommener damage wird von Hp abgezogen
        {
            CurrHp -= GainedDmg;
            GainedDmg = 0;
        }

        targetProgress = (MaxHp / CurrHp);

        if (slider.value < targetProgress)  //füllt die leiste bis sie den target progress erreichhat,langsam mit jedem update durchlauf
        {
            slider.value += fillspeed * Time.deltaTime;
        }

        if (slider.value > targetProgress)  //füllt die leiste bis sie den target progress erreichhat,langsam mit jedem update durchlauf
        {
            slider.value += fillspeed * Time.deltaTime;
        }

    }

    //increase Exp
    public void takeDmg(float addDmg)
    {
        GainedDmg += addDmg;
    }
}
