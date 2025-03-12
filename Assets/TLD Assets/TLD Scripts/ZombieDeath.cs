using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeath : MonoBehaviour
{
    public int MaxEnemyHealth = 10;
    public int EnemyHealth = 10;
    public GameObject TheEnemy;
    public int StatusCheck;
    public AudioSource JumpScareMusic;
    public AudioSource AmbMusic;
    public int scoreValue = 0;
    public GameObject thePlayer;
    public GameObject ammoBox;
    public GameObject healthPack;
    int lastDamage = 0;

    void DamageZombie (int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
        lastDamage = DamageAmount;
    }


    void Update()
    {
        if (EnemyHealth <= 0 && StatusCheck == 0)
        {
            this.GetComponent<ZombieAI>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            StatusCheck = 2;
            TheEnemy.GetComponent<Animation>().Stop("walk");
            TheEnemy.GetComponent<Animation>().Play("back_fall");
            //if (JumpScareMusic != null)
                //JumpScareMusic.Stop();
            if (AmbMusic != null)
                AmbMusic.Play();

            Messenger<int>.Broadcast(GameEvent.ENEMY_HIT, scoreValue);
            Messenger.Broadcast(GameEvent.ENEMY_KILLED);
            StartCoroutine(Die());
            //Messenger<int>.Broadcast(GameEvent.SCORE_CHANGED, scoreValue);

        }
    }

    private void DropItem()
    {
        int plrHP = thePlayer.GetComponent<GlobalHealth>().internalHealth;
        if (GlobalAmmo.ammoCount != 10 && UnityEngine.Random.Range(0, 3) <= 3)
        {
            GameObject ammoCrate = Instantiate(ammoBox) as GameObject;
            //ammoCrate.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            ammoCrate.transform.position = transform.position;
            ammoCrate.GetComponent<AmmoPickup>().ammoAmount = UnityEngine.Random.Range(2 * MaxEnemyHealth / lastDamage, 3 * MaxEnemyHealth / lastDamage);
        }
        else if (GlobalAmmo.ammoCount < 5 && UnityEngine.Random.Range(0, 3) == 3)
        {

        }


    }

    IEnumerator Die()
    {
        Destroy(gameObject);
        DropItem();
        yield return new WaitForSeconds(0.5f);
    }
}