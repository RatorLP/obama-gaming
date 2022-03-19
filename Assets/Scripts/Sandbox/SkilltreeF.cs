using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkilltreeF : MonoBehaviour
{
    GameObject dataManager;
    DDOL gC;
    public GameObject a;
    public GameObject b;
    public GameObject c;
    public GameObject ax;
    public GameObject ay;
    public GameObject bx;
    public GameObject by;
    public GameObject cx;
    public GameObject cy;
    public GameObject cz;
    public GameObject ax1;
    public GameObject axy;
    public GameObject ay1;
    public GameObject bx1;
    public GameObject bxy;
    public GameObject by1;
    public GameObject cx1;
    public GameObject cxy;
    public GameObject cy1;
    public GameObject cz1;
    public GameObject cz2;
    public GameObject abxy;
    public GameObject bcxy;
    public GameObject cz12;


    public Color32 skilledColor = new Color32(200, 255, 200, 255);
    public Color32 availableColor = new Color32(255, 255, 255, 255);
    public Color32 unavailableColor = new Color32(150, 150, 150, 255);

    public GameObject skilltree;
    public bool skilltreeEnabled;


    


    // Start is called before the first frame update
    void Start()
    {
        dataManager = GameObject.Find("DataManager");
        gC = dataManager.GetComponent<DDOL>(); //gets a reference for the "DDOL" script which is attached to the "DataManager" object
        //access global variables using: gameControler.[variableName]
        skilltree.SetActive(skilltreeEnabled);
        
    }

    void Update() {

        if (Input.GetKeyDown("e")) {
            skilltreeEnabled = !skilltreeEnabled;
            skilltree.SetActive(skilltreeEnabled);
            if(skilltreeEnabled){
                gC.PauseGame(true);
            } else {
                gC.PauseGame(false);
            }
        }
        if (gC.pause)
            UpdateColors();
    }

    public void SkillMovementSpeed()
    {
        
        if (gC.xpLevel >= 1 && !gC.enabledSkills[2])
        {
            gC.playerMovementSpeed += 2;
            gC.xpLevel -= 1;
            gC.enabledSkills[2] = true;
            c.GetComponent<Button>().interactable = false;
            c.GetComponent<Image>().color = skilledColor;

        }
    }

    public void Skill7()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[2] && !gC.enabledSkills[7])
        {
            //change variable
            gC.xpLevel -= 1;
            gC.enabledSkills[7] = true;
            cx.GetComponent<Image>().color = skilledColor;
        }
    }
    
    public void Skill8()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[2] && !gC.enabledSkills[8])
        {
            //change variable
            gC.xpLevel -= 1;
            gC.enabledSkills[8] = true;
            cy.GetComponent<Image>().color = skilledColor;
        }
    }

    public void SkillSlowEnemyMovement()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[2] && !gC.enabledSkills[9])
        {
            gC.enemySpeed -= 10;
            gC.xpLevel -= 1;
            gC.enabledSkills[9] = true;
            cz.GetComponent<Image>().color = skilledColor;
            
        }
    }

    public void Skill16()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[7] && !gC.enabledSkills[16])
        {
            //change variable
            gC.xpLevel -= 1;
            gC.enabledSkills[16] = true;
            cx1.GetComponent<Image>().color = skilledColor;
        }
    }

    public void SkillDash()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[7] && gC.enabledSkills[8] && !gC.enabledSkills[17])
        {
            gC.dash = true;
            gC.xpLevel -= 1;
            gC.enabledSkills[17] = true;
            cxy.GetComponent<Image>().color = skilledColor;
        }
    }

    public void Skill18()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[8] && !gC.enabledSkills[18])
        {
            //change variable
            gC.xpLevel -= 1;
            gC.enabledSkills[18] = true;
            cy1.GetComponent<Image>().color = skilledColor;
        }
    }

    public void SkillSlowEnemyAttackSpeed()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[9] && !gC.enabledSkills[19])
        {
            gC.enemyAttackSpeed *= 0.9f;
            gC.xpLevel -= 1;
            gC.enabledSkills[19] = true;
            cz1.GetComponent<Image>().color = skilledColor;
        }
    }

    public void SkillFreeze()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[9] && !gC.enabledSkills[20])
        {
            gC.enemyFreeze = true;
            gC.xpLevel -= 1;
            gC.enabledSkills[20] = true;
            cz2.GetComponent<Image>().color = skilledColor;
        }
    }

    public void SkillBlind()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[19] && gC.enabledSkills[20] && !gC.enabledSkills[23])
        {
            //change variable
            gC.xpLevel -= 1;
            gC.enabledSkills[23] = true;
            cz12.GetComponent<Image>().color = skilledColor;
        }
    }


    public void SkillDamage()
    {
        if (gC.xpLevel >= 1 && !gC.enabledSkills[1])
        {
            gC.playerDamage += 20;
            gC.xpLevel -= 1;
            gC.enabledSkills[1] = true;
            b.GetComponent<Image>().color = skilledColor;
        }

    }

    public void SkillFirstStrike()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[1] && !gC.enabledSkills[5])
        {
            gC.firstStrike = true;
            gC.xpLevel -= 1;
            gC.enabledSkills[5] = true;
            bx.GetComponent<Image>().color = skilledColor;
        }
    }

    public void SkillCombo()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[1] && !gC.enabledSkills[6])
        {
            gC.combo = true;
            gC.xpLevel -= 1;
            gC.enabledSkills[6] = true;
            by.GetComponent<Image>().color = skilledColor;
        }
    }

    public void SkillCrit()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[5] && !gC.enabledSkills[13])
        {
            gC.crit = 0.2f;
            gC.xpLevel -= 1;
            gC.enabledSkills[13] = true;
            bx1.GetComponent<Image>().color = skilledColor;
        }
    }

    public void SkillElectroShock()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[5] && gC.enabledSkills[6] && !gC.enabledSkills[14])
        {
            gC.shock = true;
            gC.xpLevel -= 1;
            gC.enabledSkills[14] = true;
            bxy.GetComponent<Image>().color = skilledColor;
        }
    }

    public void SkillAttackSpeed()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[6] && !gC.enabledSkills[15])
        {
            gC.attackDuration -= 0.2f;
            gC.xpLevel -= 1;
            gC.enabledSkills[15] = true;
            by1.GetComponent<Image>().color = skilledColor;
        }
    }


    public void SkillHP()
    {

        if (gC.xpLevel >= 1 && !gC.enabledSkills[0])
        { // checks if skill is available
            gC.enabledSkills[0] = true;
            gC.xpLevel -= 1;
            gC.healthGainFactor += 0.5f;
            gC.maxHealth += 20;
            gC.health += 20;
            a.GetComponent<Image>().color = skilledColor;
        }

    }

    public void SkillHealthRegen()
    {

        if (gC.xpLevel >= 1 && gC.enabledSkills[0] && !gC.enabledSkills[3])
        {
            gC.enabledSkills[3] = true;
            gC.xpLevel -= 1;
            gC.regen += 2f;
            ax.GetComponent<Image>().color = skilledColor;
        }

    }

    public void SkillArmor()
    {

        if (gC.xpLevel >= 1 && gC.enabledSkills[0] && !gC.enabledSkills[4])
        {
            gC.enabledSkills[4] = true;
            gC.xpLevel -= 1;
            gC.armor += 0.2f;
            ay.GetComponent<Image>().color = skilledColor;
        }

    }

    public void SkillShield()
    {

        if (gC.xpLevel >= 1 && gC.enabledSkills[3] && !gC.enabledSkills[10])
        {
            gC.enabledSkills[10] = true;
            gC.xpLevel -= 1;
            gC.shield = true;
            ax1.GetComponent<Image>().color = skilledColor;
        }

    }

    public void SkillLifeSaver()
    {

        if (gC.xpLevel >= 1 && gC.enabledSkills[3] && gC.enabledSkills[4] && !gC.enabledSkills[11])
        {
            gC.enabledSkills[11] = true;
            gC.xpLevel -= 1;
            gC.lifeSaver = true;
            axy.GetComponent<Image>().color = skilledColor;
        }

    }


    public void SkillThorns()
    {

        if (gC.xpLevel >= 1 && gC.enabledSkills[4] && !gC.enabledSkills[12])
        {
            gC.enabledSkills[12] = true;
            gC.xpLevel -= 1;
            gC.thorns += 0.2f;
            ay1.GetComponent<Image>().color = skilledColor;
        }

    }

    public void SkillLifeSteal()
    {

        if (gC.xpLevel >= 1 && gC.enabledSkills[11] && gC.enabledSkills[14] && !gC.enabledSkills[21])
        {
            gC.enabledSkills[21] = true;
            gC.xpLevel -= 1;
            gC.lifeSteal += 0.1f;
            abxy.GetComponent<Image>().color = skilledColor;
        }

    }


public void SkillFireball()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[14] && gC.enabledSkills[17] && !gC.enabledSkills[22])
        {
            //change variable
            gC.xpLevel -= 1;
            gC.enabledSkills[22] = true;
            bcxy.GetComponent<Image>().color = skilledColor;
            Debug.Log("Fireball");
        }
    }

    public void UpdateColors()
    {
        if (gC.xpLevel >= 1 && !gC.enabledSkills[2]) //C MovementSpeed
        {
            c.GetComponent<Button>().interactable = true;
            c.GetComponent<Image>().color = availableColor;
        }
        if (gC.xpLevel >= 1 && gC.enabledSkills[2] && !gC.enabledSkills[7]) //CX -
        {
            cx.GetComponent<Button>().interactable = true;
            cx.GetComponent<Image>().color = availableColor;
        }
        if (gC.xpLevel >= 1 && gC.enabledSkills[2] && !gC.enabledSkills[8]) //CY -
        {
            cy.GetComponent<Button>().interactable = true;
            cy.GetComponent<Image>().color = availableColor;
        }
        if (gC.xpLevel >= 1 && gC.enabledSkills[2] && !gC.enabledSkills[9]) //CZ SlowEnemyMovement
        {
            cz.GetComponent<Button>().interactable = true;
            cz.GetComponent<Image>().color = availableColor;
        }
        if (gC.xpLevel >= 1 && gC.enabledSkills[7] && !gC.enabledSkills[16]) //CX1 -
        {
            cx1.GetComponent<Button>().interactable = true;
            cx1.GetComponent<Image>().color = availableColor;
        }
        if (gC.xpLevel >= 1 && gC.enabledSkills[7] && gC.enabledSkills[8] && !gC.enabledSkills[17]) //CXY Dash
        {
            cxy.GetComponent<Button>().interactable = true;
            cxy.GetComponent<Image>().color = availableColor;
        }
        if (gC.xpLevel >= 1 && gC.enabledSkills[8] && !gC.enabledSkills[18]) //CY1 -
        {
            cy1.GetComponent<Button>().interactable = true;
            cy1.GetComponent<Image>().color = availableColor;
        }
        if (gC.xpLevel >= 1 && gC.enabledSkills[9] && !gC.enabledSkills[19]) //CZ1 SlowEnemyAttackSpeed
        {
            cz1.GetComponent<Button>().interactable = true;
            cz1.GetComponent<Image>().color = availableColor;
        }
        if (gC.xpLevel >= 1 && gC.enabledSkills[9] && !gC.enabledSkills[20]) //CZ2 Freeze
        {
            cz2.GetComponent<Button>().interactable = true;
            cz2.GetComponent<Image>().color = availableColor;
        }
        if (gC.xpLevel >= 1 && gC.enabledSkills[19] && gC.enabledSkills[20] && !gC.enabledSkills[23]) //CZ12 Blind
        {
            cz12.GetComponent<Button>().interactable = true;
            cz12.GetComponent<Image>().color = availableColor;
        }
        if (gC.xpLevel >= 1 && !gC.enabledSkills[1]) //B Damage
        {
            b.GetComponent<Button>().interactable = true;
            b.GetComponent<Image>().color = availableColor;
        }
        if (gC.xpLevel >= 1 && gC.enabledSkills[1] && !gC.enabledSkills[5]) //BX FirstStrike
        {
            bx.GetComponent<Button>().interactable = true;
            bx.GetComponent<Image>().color = availableColor;
        }
        if (gC.xpLevel >= 1 && gC.enabledSkills[1] && !gC.enabledSkills[6]) //BY Combo
        {
            by.GetComponent<Button>().interactable = true;
            by.GetComponent<Image>().color = availableColor;
        }
        if (gC.xpLevel >= 1 && gC.enabledSkills[5] && !gC.enabledSkills[13]) //BX1 Crit
        {
            bx1.GetComponent<Button>().interactable = true;
            bx1.GetComponent<Image>().color = availableColor;
        }
        if (gC.xpLevel >= 1 && gC.enabledSkills[5] && gC.enabledSkills[6] && !gC.enabledSkills[14]) //BXY ElectroShock
        {
            bxy.GetComponent<Button>().interactable = true;
            bxy.GetComponent<Image>().color = availableColor;
        }
        if (gC.xpLevel >= 1 && gC.enabledSkills[6] && !gC.enabledSkills[15]) //BY1 AttackSpeed
        {
            by1.GetComponent<Button>().interactable = true;
            by1.GetComponent<Image>().color = availableColor;
        }
        if (gC.xpLevel >= 1 && !gC.enabledSkills[0]) //A HP
        {
            a.GetComponent<Button>().interactable = true;
            a.GetComponent<Image>().color = availableColor;
        }
        if (gC.xpLevel >= 1 && gC.enabledSkills[0] && !gC.enabledSkills[3]) //AX HealthRegen
        {
            ax.GetComponent<Button>().interactable = true;
            ax.GetComponent<Image>().color = availableColor;
        }
        if (gC.xpLevel >= 1 && gC.enabledSkills[0] && !gC.enabledSkills[4]) //AY Armor
        {
            ay.GetComponent<Button>().interactable = true;
            ay.GetComponent<Image>().color = availableColor;
        }
        if (gC.xpLevel >= 1 && gC.enabledSkills[3] && !gC.enabledSkills[10]) //AX1 Shield
        {
            ax1.GetComponent<Button>().interactable = true;
            ax1.GetComponent<Image>().color = availableColor;
        }
        if (gC.xpLevel >= 1 && gC.enabledSkills[3] && gC.enabledSkills[4] && !gC.enabledSkills[11]) //AXY LifeSaver
        {
            axy.GetComponent<Button>().interactable = true;
            axy.GetComponent<Image>().color = availableColor;
        }
        if (gC.xpLevel >= 1 && gC.enabledSkills[4] && !gC.enabledSkills[12]) //AY1 Thorns
        {
            ay1.GetComponent<Button>().interactable = true;
            ay1.GetComponent<Image>().color = availableColor;
        }
        if (gC.xpLevel >= 1 && gC.enabledSkills[11] && gC.enabledSkills[14] && !gC.enabledSkills[21]) //ABXY LifeSteal
        {
            abxy.GetComponent<Button>().interactable = true;
            abxy.GetComponent<Image>().color = availableColor;
        }
        if (gC.xpLevel >= 1 && gC.enabledSkills[14] && gC.enabledSkills[17] && !gC.enabledSkills[22]) //BCXY FireBall
        {
            bcxy.GetComponent<Button>().interactable = true;
            bcxy.GetComponent<Image>().color = availableColor;
        }
    }
}
