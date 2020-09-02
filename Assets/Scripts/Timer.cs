using UnityEngine;

public class Timer : MonoBehaviour
{
    float totalTime;
    float elapsedTime;
    bool started;
    bool isRunning;

    public Timer(float time)
    {
        totalTime = time;
    }

    public bool Finished
    {
        get { return started && !isRunning; }
    }

    public float Duration
    {
        set
        {
            if (!isRunning)
            {
                totalTime = value;
            }
        }
    }

    public void Run()
    {
        if (totalTime > 0)
        {
            started = true;
            isRunning = true;
            elapsedTime = 0;
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (started && isRunning)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= totalTime)
            {
                isRunning = false;
            }
        }

    }
}
