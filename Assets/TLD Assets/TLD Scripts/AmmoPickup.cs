using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoPickup : MonoBehaviour
{

    public GameObject theAmmo;
    public GameObject ammoDisplayBox;
    public int ammoAmount = 10;

    void OnTriggerEnter(Collider other)
    {
        ammoDisplayBox.SetActive(true);
        GlobalAmmo.ammoCount += ammoAmount;
        theAmmo.SetActive(false);
    }

}