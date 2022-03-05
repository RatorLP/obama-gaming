using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkilltreeF : MonoBehaviour
{
    GameObject dataManager;
    DDOL gC;
    public Image a;
    public Image b;
    public Image c;
    public Image ax;
    public Image ay;
    public Image bx;
    public Image by;
    public Image cx;
    public Image cy;
    public Image cz;
    public Image ax1;
    public Image axy;
    public Image ay1;
    public Image bx1;
    public Image bxy;
    public Image by1;
    public Image cx1;
    public Image cxy;
    public Image cy1;
    public Image cz1;
    public Image cz2;
    public Image abxy;
    public Image bcxy;
    public Image cz12;
    
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

    }

    public void SkillMovementSpeed()
    {
        
        if (gC.xpLevel >= 1 && !gC.enabledSkills[2])
        {
            gC.playerMovementSpeed += 2;
            gC.xpLevel -= 1;
            gC.enabledSkills[2] = true;
            c.color = new Color32(0,255,0,100);
        }
    }

    public void Skill7()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[2] && !gC.enabledSkills[7])
        {
            //change variable
            gC.xpLevel -= 1;
            gC.enabledSkills[7] = true;
            cx.color = new Color32(0,255,0,100);
        }
    }
    
    public void Skill8()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[2] && !gC.enabledSkills[8])
        {
            //change variable
            gC.xpLevel -= 1;
            gC.enabledSkills[8] = true;
            cy.color = new Color32(0,255,0,100);
        }
    }

    public void SkillSlowEnemyMovement()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[2] && !gC.enabledSkills[9])
        {
            gC.enemySpeed -= 10;
            gC.xpLevel -= 1;
            gC.enabledSkills[9] = true;
            cz.color = new Color32(0,255,0,100);
        }
    }

    public void Skill16()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[7] && !gC.enabledSkills[16])
        {
            //change variable
            gC.xpLevel -= 1;
            gC.enabledSkills[16] = true;
            cx1.color = new Color32(0,255,0,100);
        }
    }

    public void SkillDash()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[7] && gC.enabledSkills[8] && !gC.enabledSkills[17])
        {
            gC.dash = true;
            gC.xpLevel -= 1;
            gC.enabledSkills[17] = true;
            cxy.color = new Color32(0,255,0,100);
        }
    }

    public void Skill18()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[8] && !gC.enabledSkills[18])
        {
            //change variable
            gC.xpLevel -= 1;
            gC.enabledSkills[18] = true;
            cy1.color = new Color32(0,255,0,100);
        }
    }

    public void SkillSlowEnemyAttackSpeed()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[9] && !gC.enabledSkills[19])
        {
            gC.enemyAttackSpeed *= 0.9f;
            gC.xpLevel -= 1;
            gC.enabledSkills[19] = true;
            cz1.color = new Color32(0,255,0,100);
        }
    }

    public void SkillFreeze()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[9] && !gC.enabledSkills[20])
        {
            gC.enemyFreeze = true;
            gC.xpLevel -= 1;
            gC.enabledSkills[20] = true;
            cz2.color = new Color32(0,255,0,100);
        }
    }

    public void SkillBlind()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[19] && gC.enabledSkills[20] && !gC.enabledSkills[23])
        {
            //change variable
            gC.xpLevel -= 1;
            gC.enabledSkills[23] = true;
            cz12.color = new Color32(0,255,0,100);
        }
    }


    public void SkillDamage()
    {
        if (gC.xpLevel >= 1 && !gC.enabledSkills[1])
        {
            gC.playerDamage += 20;
            gC.xpLevel -= 1;
            gC.enabledSkills[1] = true;
            b.color = new Color32(0,255,0,100);
        }

    }

    public void SkillFirstStrike()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[1] && !gC.enabledSkills[5])
        {
            gC.firstStrike = true;
            gC.xpLevel -= 1;
            gC.enabledSkills[5] = true;
            bx.color = new Color32(0,255,0,100);
        }
    }

    public void SkillCombo()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[1] && !gC.enabledSkills[6])
        {
            gC.combo = true;
            gC.xpLevel -= 1;
            gC.enabledSkills[6] = true;
            by.color = new Color32(0,255,0,100);
        }
    }

    public void SkillCrit()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[5] && !gC.enabledSkills[13])
        {
            gC.crit = 0.2;
            gC.xpLevel -= 1;
            gC.enabledSkills[13] = true;
            bx1.color = new Color32(0,255,0,100);
        }
    }

    public void SkillElectroShock()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[5] && gC.enabledSkills[6] && !gC.enabledSkills[14])
        {
            gC.shock = true;
            gC.xpLevel -= 1;
            gC.enabledSkills[14] = true;
            bxy.color = new Color32(0,255,0,100);
        }
    }

    public void SkillAttackSpeed()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[6] && !gC.enabledSkills[15])
        {
            gC.attackDuration -= 0.2;
            gC.xpLevel -= 1;
            gC.enabledSkills[15] = true;
            by1.color = new Color32(0,255,0,100);
        }
    }


    public void SkillHP()
    {

        if (gC.xpLevel >= 1 && !gC.enabledSkills[0])
        { // checks if skill is available
            gC.enabledSkills[0] = true;
            gC.xpLevel -= 1;
            gC.healthGainFactor += 0.5;
            a.color = new Color32(0,255,0,100);
        }

    }

    public void SkillHealthRegen()
    {

        if (gC.xpLevel >= 1 && gC.enabledSkills[0] && !gC.enabledSkills[3])
        {
            gC.enabledSkills[3] = true;
            gC.xpLevel -= 1;
            gC.regen += 2f;
            ax.color = new Color32(0,255,0,100);
        }

    }

    public void SkillArmor()
    {

        if (gC.xpLevel >= 1 && gC.enabledSkills[0] && !gC.enabledSkills[4])
        {
            gC.enabledSkills[4] = true;
            gC.xpLevel -= 1;
            gC.armor += 0.2;
            ay.color = new Color32(0,255,0,100);
        }

    }

    public void SkillShield()
    {

        if (gC.xpLevel >= 1 && gC.enabledSkills[3] && !gC.enabledSkills[10])
        {
            gC.enabledSkills[10] = true;
            gC.xpLevel -= 1;
            gC.shield = true;
            ax1.color = new Color32(0,255,0,100);
        }

    }

    public void SkillLiveSafer()
    {

        if (gC.xpLevel >= 1 && gC.enabledSkills[3] && gC.enabledSkills[4] && !gC.enabledSkills[11])
        {
            gC.enabledSkills[11] = true;
            gC.xpLevel -= 1;
            gC.liveSafer = true;
            axy.color = new Color32(0,255,0,100);
        }

    }


    public void SkillThorns()
    {

        if (gC.xpLevel >= 1 && gC.enabledSkills[4] && !gC.enabledSkills[12])
        {
            gC.enabledSkills[12] = true;
            gC.xpLevel -= 1;
            gC.thorns += 0.2;
            ay1.color = new Color32(0,255,0,100);
        }

    }

    public void SkillLiveSteal()
    {

        if (gC.xpLevel >= 1 && gC.enabledSkills[11] && gC.enabledSkills[14] && !gC.enabledSkills[21])
        {
            gC.enabledSkills[21] = true;
            gC.xpLevel -= 1;
            gC.liveSteal += 0.1;
            abxy.color = new Color32(0,255,0,100);
        }

    }


public void SkillFireball()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[14] && gC.enabledSkills[17] && !gC.enabledSkills[22])
        {
            //change variable
            gC.xpLevel -= 1;
            gC.enabledSkills[22] = true;
            bcxy.color = new Color32(0,255,0,100);
            Debug.Log("Fireball");
        }
    }
}
