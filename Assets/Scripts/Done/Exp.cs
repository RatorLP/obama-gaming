using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exp : MonoBehaviour
{
    private Slider slider;

    public float CurrExp; //displays the whole amount of Exp you have
    public int CurrLvl; //displays your current level in natural numbers
    public float ToNextLvl; //amount of experience you need to reach the next level, in complete. when you need for example 20 experience for lvl 2 and another 30 experience for 3 it would say 50, because, just like CurrExp, it looks at your whole Exp
    public float GainedExp; //experience you gained just recently in a room and gets added to CurrExp as soon as possible. Enemys add a value to this when they are killed.
    public float ToNextLvlStart; //the starting variable to change ToNextLvl in Beziehung zu Currlvl
    public float ToNextLvlGrow; //the growing variable to change ToNextLvl in Beziehung zu Currlvl
    public float fillspeed; // how fast the bar fills
    public float targetProgress;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>(); //der slider, also die Exp bar
    }


    // Start is called before the first frame update
    void Start()
    {
        CurrExp = 0;
        CurrLvl = 1;
        fillspeed = 0.5F;
        ToNextLvlGrow = 1.2F;
        ToNextLvlStart = 10;
        ToNextLvl = (Mathf.Pow(CurrLvl, ToNextLvlGrow)) * ToNextLvlStart;
    }

    // Update is called once per frame
    void Update()
    {

        if (GainedExp != 0) //gerade bekommene Exp wird zur gesamten geaddet
        {
            CurrExp += GainedExp;
            GainedExp = 0;
        }

        ToNextLvl = (Mathf.Pow(CurrLvl, ToNextLvlGrow)) * ToNextLvlStart;   //updatet ToNextLvl

        targetProgress = ((ToNextLvl - ((Mathf.Pow((CurrLvl-1), ToNextLvlGrow)) * ToNextLvlStart) - (ToNextLvl - CurrExp)) / (ToNextLvl - ((Mathf.Pow((CurrLvl-1), ToNextLvlGrow)) * ToNextLvlStart))); //erzeugt die prozentzahl z.b 0,58 von wie viel die exp bar gefüllt sein soll
       
        if (slider.value < targetProgress)  //füllt die leiste bis sie den target progress erreichhat,langsam mit jedem update durchlauf
        {
            slider.value += fillspeed * Time.deltaTime;
        }


        if (CurrExp >= ToNextLvl)       // aktiviert sich alles wenn ein neues level erreicht wird
        {
            if (slider.value == 1)  //aktiviert isch erst nachdem die Exp bar auch wirklich voll ist für smoothe visuals
            {
                CurrLvl++;      // erhöht das level
                slider.value = 0;   //resettet die bar um das neue level anzuzeigen
            } 
            else    //füllt die Exp bar bei lvlup erst komplett bevor sie resettet wird um das neue leve anzuzeigen
            {
                slider.value += fillspeed * Time.deltaTime;
            }
        }
    }

    //increase Exp
    public void gainExp(float addExp)
    {
        GainedExp += addExp;
    }
}
