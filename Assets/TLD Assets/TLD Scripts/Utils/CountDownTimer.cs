using System.Threading;
using UnityEngine;

public class CountDownTimer : MonoBehaviour
{
    public int duration = 60;
    public int timeRemaining = 0;
    public bool isCountingDown = false;

    public void Begin()
    {

        isCountingDown = true;
        timeRemaining = duration;
        Invoke("_tick", 1f);
    }

    private void _tick()
    {
        timeRemaining--;
        if (timeRemaining > 0)
        {
            Invoke("_tick", 1f);
        }
    }
}