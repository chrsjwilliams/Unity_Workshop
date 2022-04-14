using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;

    [SerializeField] float elapsedTime = 0;
    [SerializeField] float startTime = 10;

    [SerializeField] UnityEvent OnTimerOver;

    bool timeOver = false;
    bool canStartTimer = false;

    [SerializeField] Color almostDone;

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = startTime;
        string time = elapsedTime.ToString("0");
        timerText.text = time;
    }

    public void ResetTimer(float t)
    {
        startTime = t;
        elapsedTime = t;
        timeOver = false;
    }

    public void ToggleTimer()
    {
        canStartTimer = !canStartTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canStartTimer) return;

        if (elapsedTime > 0)
        {
            elapsedTime -= 1 * Time.deltaTime;

            if(elapsedTime < (startTime * 0.1f))
            {
                timerText.color = almostDone;
            }
            else if(elapsedTime < (startTime * 0.5f))
            {
                timerText.color = Color.yellow;
            }
            else
            {
                timerText.color = Color.white;
            }

            string time = elapsedTime.ToString("0");
            //Debug.Log("Time: " + time);
            timerText.text = time;
        }
        else if(elapsedTime <= 0 && !timeOver)
        {
            timeOver = true;
            // calling our unity event
            if (OnTimerOver != null)
            {
                OnTimerOver.Invoke();
            }
        }
    }
}
