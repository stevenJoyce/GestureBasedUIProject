using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;

public class MenuController : MonoBehaviour
{
    //Variables used to Store the start or exit the game
    [SerializeField] private string[] keywords;
    private KeywordRecognizer kr;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    private string spokenWord = "";
    // Confidence Level
    private ConfidenceLevel confidenceLevel = ConfidenceLevel.Low;

    void Start()
    {
        if (keywords != null)
        {
            kr = new KeywordRecognizer(keywords, confidenceLevel);
            kr.OnPhraseRecognized += KR_OnPhraseRecognized;
            kr.Start();
            Debug.Log("KR Started");
        }
    }

    private void KR_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        spokenWord = args.text;
        Debug.Log("You said " + spokenWord);
    }

    void Update()
    {
        /* A switch statement used to find what words have been spoken by the player
        and use that word to either start the game or exit the game */
        switch (spokenWord)
        {
            case "Play":
                SceneManager.LoadScene("Game");
                break;
            case "Start":
                SceneManager.LoadScene("Game");
                break;
            case "Launch":
                SceneManager.LoadScene("Game");
                break;
            case "Exit":
                Application.Quit();
                break;
            case "Quit":
                Application.Quit();
                break;
            case "Leave":
                Application.Quit();
                break;
            default:
                break;
        }
    }

    private void OnApplicationQuit()
    {
        if (kr != null && kr.IsRunning)
        {
            kr.OnPhraseRecognized -= KR_OnPhraseRecognized;
            kr.Stop();
        }
    }

}
