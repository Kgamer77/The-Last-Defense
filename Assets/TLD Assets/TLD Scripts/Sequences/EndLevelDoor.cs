using StarterAssets;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EndLevelTrigger : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject TextBox;
    public GameObject DoorTrigger;

    public void EnterChoice()
    {
        ThePlayer.GetComponent<FirstPersonController>().enabled = false;
        DoorTrigger.GetComponent<BoxCollider>().enabled = true;
        StartCoroutine(ChanceToLeave());
    }

    public void EndChoice()
    {
        ThePlayer.GetComponent<FirstPersonController>().enabled = false;
        DoorTrigger.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(OutOfTime());
    }

    IEnumerator ChanceToLeave()
    {
        TextBox.GetComponent<Text>().text = "It looks like I could get that door open...";
        yield return new WaitForSeconds(2.5f);
        TextBox.GetComponent<Text>().text = "Or I can stay and fight on for glory...";
        yield return new WaitForSeconds(2.5f);
        ThePlayer.GetComponent<FirstPersonController>().enabled = true;

    }

    IEnumerator OutOfTime()
    {
        TextBox.GetComponent<Text>().text = "I can take the hordes!";
        yield return new WaitForSeconds(1.5f);
        TextBox.GetComponent<Text>().text = "FOR GLORY!!!";
        yield return new WaitForSeconds(1.5f);
        ThePlayer.GetComponent<FirstPersonController>().enabled = true;

    }



}