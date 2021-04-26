using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;

public class PacManController : MonoBehaviour
{
    private Rigidbody2D rb;
    //Used to move the pacman at a certain speed in the direction the user wants
    [SerializeField] private float speed = 5.0f;
    //Variables used to Store the words that the player can use to move pacman or exit the game
    [SerializeField] private string[] keywords;
    private string spokenWord = "";
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    private KeywordRecognizer kr;   // used to find out what word was spoken
    //used to remove health from pacman when he collides with the ghosts
    public static PacManController instPc;


    // Confidence Level
    private ConfidenceLevel confidenceLevel = ConfidenceLevel.Low;

    
    //used to crreate an instance of pacman
    private void Awake()
    {
        instPc = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        // how to apply that command from the spoken word to move the player horizontally or vertical
        float horizontalMovement = 0;
        float verticalMovement = 0;

        /* A switch statement used to find what words have been spoken by the player
         and use that word to either move the player or exit the game */
        switch (spokenWord)
        {
            case "Up":
                verticalMovement = 1;
                horizontalMovement = 0;
                break;
            case "North":
                verticalMovement = 1;
                horizontalMovement = 0;
                break;
            case "Down":
                verticalMovement = -1;
                horizontalMovement = 0;
                break;
            case "South":
                verticalMovement = -1;
                horizontalMovement = 0;
                break;
            case "Left":
                horizontalMovement = -1;
                verticalMovement = 0;
                break;
            case "West":
                horizontalMovement = -1;
                verticalMovement = 0;
                break;
            case "Right":
                horizontalMovement = 1;
                verticalMovement = 0;
                break;
            case "East":
                horizontalMovement = 1;
                verticalMovement = 0;
                break;
            case "Stop":
                horizontalMovement = verticalMovement = 0;
                break;
            case "Exit":
                Application.Quit();
                break;
            case "Quit":
                Application.Quit();
                break;
            default:
                break;
        }

        rb.velocity = new Vector2(horizontalMovement * speed, verticalMovement * speed);
    }
    private void OnApplicationQuit()
    {
        if (kr != null && kr.IsRunning)
        {
            kr.OnPhraseRecognized -= KR_OnPhraseRecognized;
            kr.Stop();
        }
    }

    public void Die()
    {
        //Call Game Over screen
        SceneManager.LoadScene("GameOver");
        Debug.Log("Pacman Dead");

    }
}
