using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class DeviceOperator : MonoBehaviour
{

    public float radius = 1.5f;
    private int score;

    private void Start()
    {
        score = 0;
        Messenger<int>.AddListener(GameEvent.SCORE_CHANGED, OnScoreChanged);
    }

    void OnScoreChanged(int incoming)
    {
        score = incoming;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider collider in hitColliders) 
            {
                BarrierDevice barrierDevice = collider.GetComponent<BarrierDevice>();
                if (barrierDevice != null)
                {
                    Debug.Log("Attempting Barrier Device Interaction...");
                    if (score >= barrierDevice.GetCost())
                    {
                        collider.SendMessage("Operate", SendMessageOptions.DontRequireReceiver);
                    }
                    
                }
            }
        }
    }
}
