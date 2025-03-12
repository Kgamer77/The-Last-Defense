using UnityEngine;
using UnityEngine.UI;

public class BuyAmmo : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
    public GameObject SceneController;
    public int price = 50;
    public float InteractDistance = 3.5f;
    public bool CanAfford = true;


    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (!CanAfford) { return; }
        if (TheDistance <= InteractDistance)
        {
            ActionText.GetComponent<Text>().color = Color.white;
            ExtraCross.SetActive(true);
            ActionText.GetComponent<Text>().text = $"Buy 5 Ammo\n\t{price} points";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= InteractDistance)
            {
                if (SceneController.GetComponent<UIController>().GetScore() >= price)
                {
                    Messenger<int>.Broadcast(GameEvent.PURCHASE, price);
                    GlobalAmmo.ammoCount += 5;
                }
                else 
                {
                    ActionText.GetComponent<Text>().text = $"Come back with more points!";
                    ActionText.GetComponent<Text>().color = Color.red;
                    CanAfford = false;
                }
            }
        }
    }

    void OnMouseExit()
    {
        ExtraCross.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        CanAfford = true;
    }
}
