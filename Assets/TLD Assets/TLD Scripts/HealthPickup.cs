using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPickup : MonoBehaviour
{
    
    public GameObject theHealth;
    public GameObject healthDisplayBox;

    void OnTriggerEnter(Collider other)
    {
        healthDisplayBox.SetActive(true);
        GlobalHealth.healthCount += 10;
        theHealth.SetActive(false);
    }

}