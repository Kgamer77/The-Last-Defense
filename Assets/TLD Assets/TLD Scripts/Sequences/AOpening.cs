using UnityEngine;
using UnityEngine.UI;
using System.Collections;




public class AOpening : MonoBehaviour
{

    public GameObject ThePlayer;
    public GameObject FadeScreenIn;
    public GameObject TextBox;

    void Start()
    {
        ThePlayer.GetComponent<StarterAssets.FirstPersonController>().enabled = false;
        StartCoroutine(ScenePlayer());
    }

    IEnumerator ScenePlayer()
    {
        yield return new WaitForSeconds(2.5f);
        FadeScreenIn.SetActive(false);
        TextBox.GetComponent<Text>().text = "What's that noise? ";
        yield return new WaitForSeconds(1.5f);
        TextBox.GetComponent<Text>().text = "I should go check it out.";
        yield return new WaitForSeconds(1.5f);
        TextBox.GetComponent<Text>().text = " ";
        ThePlayer.GetComponent<StarterAssets.FirstPersonController>().enabled = true;

    }

}