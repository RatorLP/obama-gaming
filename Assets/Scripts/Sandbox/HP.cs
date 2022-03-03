using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    private Slider slider;
    GameObject dataManager; //Variable declaration
    DDOL gameController;
    public float CurrHp; //displays the maxium amount of HP you can have
    public float MaxHp = 100; //displays your current level in natural numbers
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
        if (GameObject.Find("DataManager") == null)
        { //returns if the data manager doesn't exist
            Debug.Log("dataManager not found");
            return;
        }
        dataManager = GameObject.Find("DataManager");
        gameController = dataManager.GetComponent<DDOL>(); //gets a reference for the "DDOL" script which is attached to the "DataManager" object
    }

    public void updateValues() //updates all variables automatically to ensure the script is behaving correctly
    {
        CurrHp = gameController.health;
        MaxHp = gameController.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        updateValues();
        
        if (slider == null)
        {
            Awake();
            return;
        }

        targetProgress = (CurrHp / MaxHp); //target progress der leisete, f�rs visuelle anpassen zum Wert von CurrHP

        if (slider.value < targetProgress)  //�ndert die leiste bis sie den target progress erreichhat,langsam mit jedem update durchlauf
        {
            slider.value += fillspeed * Time.deltaTime;
        }

        if (slider.value > targetProgress)  //�ndert die leiste bis sie den target progress erreichhat,langsam mit jedem update durchlauf
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

        if (CurrHp <= 0) //If Hp fals to zero, the player dies
        {
            Debug.Log("You Lost lul Cope");
            gameController.health = 100;
            SceneManager.LoadScene(1);
           
        }

    }

    


}
