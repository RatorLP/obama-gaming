using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerHit, enemyHit, itemPickup, playerDeath, shoot, enemyDeath; //Sound clip names
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        //declaration of which name is which sound
        playerHit = Resources.Load<AudioClip>("PlayerHitSound");
        enemyHit = Resources.Load<AudioClip>("EnemyHitSound");
        itemPickup = Resources.Load<AudioClip>("ItemPickupSound");
        playerDeath = Resources.Load<AudioClip>("PlayerDeathSound");
        enemyDeath = Resources.Load<AudioClip>("EnemyDeathSound");
        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip) //this method takes a string as the name of the sound clip and then plays it
    {
        switch (clip)
        {
            case "PlayerHitSound":
                audioSrc.PlayOneShot(playerHit);
                break;
            case "EnemyHitSound":
                audioSrc.PlayOneShot(enemyHit);
                break;
            case "ItemPickupSound":
                audioSrc.PlayOneShot(itemPickup);
                break;
            case "PlayerDeathSound":
                audioSrc.PlayOneShot(playerDeath);
                break;
            case "ShootSound":
                audioSrc.PlayOneShot(shoot);
                break;
            case "EnemyDeathSound":
                audioSrc.PlayOneShot(enemyDeath);
                break;
        }
    }
}
