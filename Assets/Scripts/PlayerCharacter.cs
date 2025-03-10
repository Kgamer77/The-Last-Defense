using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int health;
    private int damage;
    private int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        damage = 1;
        maxHealth = 10;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hurt(int incomingDamage)
    {
        health -= incomingDamage;
        Debug.Log($"Health: {health}");
    }

    // Needed for other scripts that require the health value
    public int getHealth() 
    {
        return health;
    }

    public int getDamage()
    {
        return damage;
    }
}
