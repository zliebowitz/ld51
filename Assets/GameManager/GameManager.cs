using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float targetTime = 10.0f;
    public bool play = false;
    List<GameObject> monsters = new List<GameObject>();
    List<GameObject> minions = new List<GameObject>();
    public CardManager cardManager;
    public TextMeshProUGUI turnText;
    int turn = 0;
    
    public TOKObjectController tokController = new TOKObjectController();
    
    public TextMeshProUGUI timer_text;

    public List<GameObject> monsters_to_spawn;
    
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().PlayMusic("BGM");
    }


    private void Awake()
    {
        cardManager.NewTurn();
    }

    // Update is called once per frame
    void Update()
    {
        turnText.text = "Turn: " + turn;
        if (play)
        {
            targetTime -= Time.deltaTime;
            timer_text.text = ((int)Math.Round(targetTime)).ToString();
            if (targetTime <= 0.0f)
            {
                timerEnded();
            }
        }

    }

    void timerEnded()
    {
        play = false;
        targetTime = 10.0f;
        // setPauseAll(true);
        TOKObjectController.SetPause(true);
        timer_text.text = "Play";
        cardManager.NewTurn();
    }

    public void Play()
    {
        if (play == true)
            return;
        turn += 1;
        cardManager.EndTurn();
        play = true;

        foreach (var monster in monsters_to_spawn)
        {
            Instantiate(monster, new Vector3(209f, 14.9f, 0f), Quaternion.identity);
        }

        TOKObjectController.SetPause(false);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

}
