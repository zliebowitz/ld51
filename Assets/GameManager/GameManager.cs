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
    
    public TOKObjectController tokController = new TOKObjectController();
    
    public TextMeshProUGUI timer_text;
    
    // Start is called before the first frame update
    void Start()
    {
    }


    private void Awake()
    {
        cardManager.NewTurn();
    }

    // Update is called once per frame
    void Update()
    {
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
        cardManager.EndTurn();
        play = true;

        InstantiationMonster bewitchedObject = GameObject.Find("BewitchedObject").GetComponent<InstantiationMonster>();
        monsters.Add(bewitchedObject.New());

        InstantiationMonster formlessObject = GameObject.Find("FormlessObject").GetComponent<InstantiationMonster>();
        monsters.Add(formlessObject.New());

        InstantiationMonster devourerObject = GameObject.Find("DevourerObject").GetComponent<InstantiationMonster>();
        monsters.Add(devourerObject.New());

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
