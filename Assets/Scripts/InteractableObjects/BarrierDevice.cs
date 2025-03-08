using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierDevice : MonoBehaviour
{
    [SerializeField] GameObject barrierPrefab;

    private GameObject barrier;
    private ushort tier;
    private int cost;

    // Start is called before the first frame update
    private void Start()
    {
        cost = 30;
    }

    void Operate()
    {
        Debug.Log("BarrierDevice Operating");
        if (barrier == null)
        {
            barrier = Instantiate(barrierPrefab) as GameObject;
            barrier.transform.position = transform.position;
            barrier.transform.localScale = transform.localScale;
            Messenger<int>.Broadcast(GameEvent.PURCHASE, cost);
        }    
    }

    public int GetCost()
    {
        return cost;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
