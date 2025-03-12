using UnityEngine;
using UnityEngine.UI;

public class BuyDamageUp : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
    public GameObject PlayerGun;
    public GameObject SceneController;
    public int price = 75;
    public int timesUpgraded = 0;
    public float InteractDistance = 0;
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
            ActionText.GetComponent<Text>().text = $"Upgrade Gun Damage\n\t{price} points";
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
                    timesUpgraded++;
                    price = 100 * (timesUpgraded + UnityEngine.Random.Range(0,timesUpgraded) ) / SceneController.GetComponent<SceneController>().GetWave();
                    PlayerGun.GetComponent<FirePistol>().DamageAmount += Mathf.RoundToInt(Mathf.Pow(2, timesUpgraded)) / timesUpgraded;
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
