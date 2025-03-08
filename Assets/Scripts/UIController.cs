using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreLabel;
    [SerializeField] SettingsPopup settingsPopup;

    private int _score;

    private void OnEnable()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
        Messenger<int>.AddListener(GameEvent.PURCHASE, OnPurchase);
    }

  

    private void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }    

    private void OnEnemyHit()
    {
        _score += 1;
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
        Messenger<int>.Broadcast(GameEvent.SCORE_CHANGED, _score);
        scoreLabel.text = _score.ToString();
        settingsPopup.Close();
    }

    // Update is called once per frame
    void Update()
    {
        //scoreLabel.text = Time.realtimeSinceStartup.ToString();
    }

    public void OnOpenSettings()
    {
        Debug.Log("Open settings....");
        settingsPopup.Open();
    }

}
