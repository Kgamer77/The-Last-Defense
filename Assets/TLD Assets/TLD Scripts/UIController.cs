using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Text scoreLabel;
    [SerializeField] Text timerLabel;

    private int _score;
    private CountDownTimer timer;


    private void OnDisable()
    {
        Messenger<int>.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    private void OnEnemyHit(int amount)
    {
        _score += amount;
        //Messenger<int>.Broadcast(GameEvent.SCORE_CHANGED, _score);
        scoreLabel.text = _score.ToString();
    }

    private void OnPurchase(int price)
    {
        _score -= price;
        //Messenger<int>.Broadcast(GameEvent.SCORE_CHANGED, _score);
        scoreLabel.text = _score.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        Messenger<int>.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
        Messenger<int>.AddListener(GameEvent.PURCHASE, OnPurchase);
        _score = 100;
        timer = GetComponent<CountDownTimer>();
        //Messenger<int>.Broadcast(GameEvent.SCORE_CHANGED, _score);
        scoreLabel.text = _score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //scoreLabel.text = Time.realtimeSinceStartup.ToString();
        if (timer.timeRemaining == 0)
        {
            timerLabel.text = $"Zombies {GetComponent<SceneController>().curEnemiesCount}";
        }
        else
        {
            if (timer.timeRemaining < 10)
                timerLabel.text = $"Next Wave: 00:0{timer.timeRemaining}";
            else
                timerLabel.text = $"Next Wave: 00:{timer.timeRemaining}";
        }

    }

    public void OnOpenSettings()
    {
        Debug.Log("Open settings....");
    }

    public int GetScore()
    {
        return _score;
    }
}
