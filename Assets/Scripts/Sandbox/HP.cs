using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    private Slider slider;

    public float MaxHp = 100; //displays your current level in natural numbers
    public float CurrHp = 100; //displays the maxium amount of HP you can have
    public float LostHP; // damage you took, get subtracted from Hp as soon as possible
    public float GainedHp; // healing you got, gets added to Hp after damage
    private float targetProgress; 
    private float fillspeed = 1.5F; // how fast the bar moves

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

        if (LostHP != 0) //gerade bekommener damage wird von Hp abgezogen
        {
            CurrHp -= LostHP;
            LostHP = 0;
        }

        if (GainedHp != 0) //gerade bekommenes healing wird zu Hp addiert
        {
            CurrHp += GainedHp;
            GainedHp = 0;
        }

        targetProgress = (CurrHp / MaxHp ); //target progress der leisete, fürs visuelle anpassen zum Wert von CurrHP

        if (slider.value < targetProgress)  //ändert die leiste bis sie den target progress erreichhat,langsam mit jedem update durchlauf
        {
            slider.value += fillspeed * Time.deltaTime;
        }

        if (slider.value > targetProgress)  //ändert die leiste bis sie den target progress erreichhat,langsam mit jedem update durchlauf
        {
            slider.value -= fillspeed * Time.deltaTime;
        }

        if (CurrHp < 0) //If currHp goes into minus, it gets set to 0
        {
            CurrHp = 0;
        }

        if (CurrHp > MaxHp) //If currHp goes higher than MaxHp,it gets set to the value of MaxHp
        {
            CurrHp = MaxHp;
        }

    }

    //increase Exp
    public void takeDmg(float subHP)
    {
        LostHP += subHP;
    }

    public void getHealing(float addHP)
    {
        GainedHp += addHP;
    }
}
