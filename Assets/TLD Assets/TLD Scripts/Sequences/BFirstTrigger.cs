using StarterAssets;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BFirstTrigger : MonoBehaviour
{

    public GameObject ThePlayer;
    public GameObject TextBox;
    public GameObject TheMarker1;
    public GameObject TheMarker2;
    public GameObject TheMarker3;

    void OnTriggerEnter()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        ThePlayer.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(ScenePlayer());
    }

    IEnumerator ScenePlayer()
    {
        TextBox.GetComponent<Text>().text = "Look a weapon on the table and ammo on the floor. Grab it.";
        yield return new WaitForSeconds(2.5f);
        TextBox.GetComponent<Text>().text = " ";
        ThePlayer.GetComponent<FirstPersonController>().enabled = true;
        TheMarker1.SetActive(true);
        TheMarker2.SetActive(true);
        TheMarker3.SetActive(true);

    }

}