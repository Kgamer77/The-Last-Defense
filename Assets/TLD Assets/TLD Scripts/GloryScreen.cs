using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;
using JetBrains.Annotations;


public class GloryScreen : MonoBehaviour
{


    public string LevelName;




    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            SceneManager.LoadScene(6);
        }

    }



}
