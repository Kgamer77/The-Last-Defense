using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GlobalHealth : MonoBehaviour
{

    public static int healthCount = 20;
    public GameObject healthDisplay;
    public int internalHealth;


    // Update is called once per frame

    void Update()
    {
       
        
        internalHealth = healthCount;
        healthDisplay.GetComponent<Text>().text = "" + internalHealth;


        if (healthCount <= 0)
        {
            SceneManager.LoadScene(3);

        }
    }
}
