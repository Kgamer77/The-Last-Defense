using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PickUpPistol : MonoBehaviour
{

    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject FakePistol;
    public GameObject RealPistol;
    public GameObject GuideArrow1;
    public GameObject GuideArrow2;
    public GameObject GuideArrow3;
    public GameObject ExtraCross;
    public GameObject TheJumpScareTrigger;
    public GameObject ShopPistol;
    public GameObject ShopAmmo;
    public GameObject ShopHealth;
    public GameObject ShopTable;



    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 3.5)
        {
            ExtraCross.SetActive(true);
            ActionText.GetComponent<Text>().text = "Pick Up Pistol";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 3.5)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                FakePistol.SetActive(false);
                RealPistol.SetActive(true);
                ExtraCross.SetActive(false);
                GuideArrow1.SetActive(false);
                GuideArrow2.SetActive(false);
                GuideArrow3.SetActive(false);
                TheJumpScareTrigger.SetActive(true);
                ShopTable.SetActive(true);
                ShopPistol.transform.position += new Vector3(0,4f,0);
                ShopAmmo.transform.position += new Vector3(0,4f,0);
                ShopHealth.transform.position += new Vector3(0,4f,0);
                ShopPistol.GetComponent<BoxCollider>().enabled = true;
                ShopPistol.GetComponent<BuyDamageUp>().InteractDistance = 3.5f;
                ShopAmmo.GetComponent<BoxCollider>().enabled = true;
                ShopHealth.GetComponent<BoxCollider>().enabled = true;

            }
        }
    }

    void OnMouseExit()
    {
        ExtraCross.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }
}