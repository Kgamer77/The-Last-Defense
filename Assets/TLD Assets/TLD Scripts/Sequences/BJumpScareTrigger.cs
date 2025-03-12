using System.Collections;
using UnityEngine;

public class BZJumpTrigger : MonoBehaviour
{

    public AudioSource DoorBang;
    public AudioSource DoorJumpScareMusic;
    public GameObject TheZombie;
    public GameObject TheDoor;
    public AudioSource AmbMusic;


    void OnTriggerEnter()
    {
        GetComponent<BoxCollider>().enabled = false;
        TheDoor.GetComponent<Animation>().Play("JumpScareDoorAnim");
        DoorBang.Play();
        TheZombie.SetActive(true);
        StartCoroutine(PlayJumpMusic());
    }

    IEnumerator PlayJumpMusic()
    {
        yield return new WaitForSeconds(0.5f);
        AmbMusic.Stop();
        DoorJumpScareMusic.Play();
    }



}