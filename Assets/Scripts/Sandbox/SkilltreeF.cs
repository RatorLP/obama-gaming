using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkilltreeF : MonoBehaviour
{
    GameObject dataManager;
    DDOL gC;

    // Start is called before the first frame update
    void Start()
    {
        dataManager = GameObject.Find("DataManager");
        gC = dataManager.GetComponent<DDOL>(); //gets a reference for the "DDOL" script which is attached to the "DataManager" object
        //access global variables using: gameControler.[variableName]
    }

    public void SkillMovementSpeed()
    {
        if (gC.xpLevel >= 1 && !gC.enabledSkills[2])
        {
            gC.playerMovementSpeed += 2;
            gC.xpLevel -= 1;
            gC.enabledSkills[2] = true;
        }
    }

    public void Skill7()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[2] && !gC.enabledSkills[7])
        {
            //change variable
            gC.xpLevel -= 1;
            gC.enabledSkills[7] = true;
        }
    }
    
    public void Skill8()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[2] && !gC.enabledSkills[8])
        {
            //change variable
            gC.xpLevel -= 1;
            gC.enabledSkills[8] = true;
        }
    }

    public void SkillSlowEnemyMovement()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[2] && !gC.enabledSkills[9])
        {
            gC.enemySpeed -= 10;
            gC.xpLevel -= 1;
            gC.enabledSkills[9] = true;
        }
    }

    public void Skill16()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[7] && !gC.enabledSkills[16])
        {
            //change variable
            gC.xpLevel -= 1;
            gC.enabledSkills[16] = true;
        }
    }

    public void SkillDash()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[7] && gC.enabledSkills[8] && !gC.enabledSkills[17])
        {
            gC.dash = true;
            gC.xpLevel -= 1;
            gC.enabledSkills[17] = true;
        }
    }

    public void Skill18()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[8] && !gC.enabledSkills[18])
        {
            //change variable
            gC.xpLevel -= 1;
            gC.enabledSkills[18] = true;
        }
    }

    public void SkillSlowEnemyAttackSpeed()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[9] && !gC.enabledSkills[19])
        {
            gC.enemyAttackSpeed *= 0.9f;
            gC.xpLevel -= 1;
            gC.enabledSkills[19] = true;
        }
    }

    public void SkillFreeze()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[9] && !gC.enabledSkills[20)
        {
            gC.enemyFreeze = true;
            gC.xpLevel -= 1;
            gC.enabledSkills[20] = true;
        }
    }

    public void SkillBlind()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[19] && gC.enabledSkills[23])
        {
            //change variable
            gC.xpLevel -= 1;
            gC.enabledSkills[23] = true;
        }
    }


    public void SkillDamage()
    {
        if (gC.xpLevel >= 1 && !gC.enabledSkills[1])
        {
            gC.playerDamage += 20;
            gC.xpLevel -= 1;
            gC.enabledSkills[1] = true;
        }

    }

    public void SkillFirstStrike()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[1] && !gC.enabledSkills[5])
        {
            gC.firstStrike = true;
            gC.xpLevel -= 1;
            gC.enabledSkills[5] = true;
        }
    }

    public void SkillCombo()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[1] && !gC.enabledSkills[6])
        {
            gC.combo = true;
            gC.xpLevel -= 1;
            gC.enabledSkills[6] = true;
        }
    }

    public void SkillCrit()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[5] && !gC.enabledSkills[13])
        {
            gC.crit = 0.2;
            gC.xpLevel -= 1;
            gC.enabledSkills[13] = true;
        }
    }

    public void SkillElectroShock()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[5] && gC.enabledSkills[6] && !gC.enabledSkills[14])
        {
            gC.shock = true;
            gC.xpLevel -= 1;
            gC.enabledSkills[14] = true;
        }
    }

    public void SkillAttackSpeed()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills[6] && !gC.enabledSkills[15])
        {
            gC.attackDuration -= 0.2;
            gC.xpLevel -= 1;
            gC.enabledSkills[15] = true;
        }
    }


    public void SkillHP()
    {

        if (gC.xpLevel >= 1 && !gC.enabledSkills[0])
        { // checks if skill is available
            gC.enabledSkills[0] = true;
            gC.xpLevel -= 1;
            gC.healthGainFactor += 0.5;
        }

    }

    public void SkillHealthRegen()
    {

        //if (gC.xpLevel >= 1 && gC.enabledSkills[0] && !gC.enabledSkills[3])
        //{
            gC.enabledSkills[3] = true;
            gC.xpLevel -= 1;
            gC.regen += 2f;
       // }

    }

    public void SkillArmor()
    {

        if (gC.xpLevel >= 1 && gC.enabledSkills[0] && !gC.enabledSkills[4])
        {
            gC.enabledSkills[4] = true;
            gC.xpLevel -= 1;
            gC.armor += 0.2;
        }

    }

    public void SkillShield()
    {

        if (gC.xpLevel >= 1 && gC.enabledSkills[3] && !gC.enabledSkills[10])
        {
            gC.enabledSkills[10] = true;
            gC.xpLevel -= 1;
            gC.shield = true;
        }

    }

    public void SkillLiveSafer()
    {

        if (gC.xpLevel >= 1 && gC.enabledSkills[3] && gC.enabledSkills[4] && !gC.enabledSkills[11])
        {
            gC.enabledSkills[11] = true;
            gC.xpLevel -= 1;
            gC.liveSafer = true;
        }

    }


    public void SkillThorns()
    {

        if (gC.xpLevel >= 1 && gC.enabledSkills[4] && !gC.enabledSkills[12])
        {
            gC.enabledSkills[12] = true;
            gC.xpLevel -= 1;
            gC.thorns += 0.2;
        }

    }

    public void SkillLiveSteal()
    {

        if (gC.xpLevel >= 1 && gC.enabledSkills[11] && gC.enabledSkills[14] && !gC.enabledSkills[21])
        {
            gC.enabledSkills[21] = true;
            gC.xpLevel -= 1;
            gC.liveSteal += 0.1;
        }

    }


public void SkillFireball()
    {
        if (gC.xpLevel >= 1 && gC.enabledSkills [14] && gC.enabledSkills [17] && !gC.enabledSkills[22])
        {
            //change variable
            gC.xpLevel -= 1;
            gC.enabledSkills[22] = true;
        }
    }
}
