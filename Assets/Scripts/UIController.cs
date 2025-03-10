using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreLabel;
    [SerializeField] SettingsPopup settingsPopup;
    [SerializeField] TMP_Text timerLabel;

    private int _score;
    private CountDownTimer timer;

    private void OnEnable()
    {
        Messenger<int>.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
        Messenger<int>.AddListener(GameEvent.PURCHASE, OnPurchase);
    }

  

    private void OnDisable()
    {
        Messenger<int>.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }    

    private void OnEnemyHit(int amount)
    {
        _score += amount;
        Messenger<int>.Broadcast(GameEvent.SCORE_CHANGED, _score);
        scoreLabel.text = _score.ToString();
    }

    private void OnPurchase(int price)
    {
        _score -= price;
        Messenger<int>.Broadcast(GameEvent.SCORE_CHANGED, _score);
        scoreLabel.text = _score.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        _score = 100;
        timer = GetComponent<CountDownTimer>();
        Messenger<int>.Broadcast(GameEvent.SCORE_CHANGED, _score);
        scoreLabel.text = _score.ToString();
        settingsPopup.Close();
    }

    // Update is called once per frame
    void Update()
    {
        //scoreLabel.text = Time.realtimeSinceStartup.ToString();
        if (timer.timeRemaining == 0)
        {
            timerLabel.text = "";
        }
        else
        {
            timerLabel.text = "Next Wave: " + timer.timeRemaining.ToString();
        }

    }

    public void OnOpenSettings()
    {
        Debug.Log("Open settings....");
        settingsPopup.Open();
    }

}
