using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //Variables used to initialize and update the timer UI
    public Text time;
    public float timeValue = 120;
    public bool timerIsRunning = false;
    public Text timeText;

    private void Start()
    {
        //The timer will be automatically started on game launch
        timerIsRunning = true;
    }

    void Update()
    {
        /*As long as the game is running the timer will always go down
         If the timer reaches 0 - game is over - player won*/
        if (timerIsRunning)
        {
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
                DisplayTime(timeValue);
            }
            else
            {
                Debug.Log("YOU HAVE WON!");
                timeValue = 0;
                timerIsRunning = false;
                SceneManager.LoadScene("WinScreen");
            }
        }
    }

    //Method used to show the time on screen
    void DisplayTime(float diplayTime)
    {
        diplayTime += 1;

        float minutes = Mathf.FloorToInt(diplayTime / 60);
        float seconds = Mathf.FloorToInt(diplayTime % 60);

        time.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}