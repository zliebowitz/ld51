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
    public GameObject selectScreen;
    public int turns_between_card_offers = 3;
	public int turns_between_mana_increases = 3;
	int waveBalance = 0;
    float timeToSpawn = 0;
    
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
			
			if (timeToSpawn >= targetTime)
			{
				
				int formlessCost = 9;
				int formlessGroup = 50;
				int bewitchedCost = 65;
				int devourerCost = 140;
				int groupCost = 300;
				
				float spawnX = 360f;
				float spawnY = UnityEngine.Random.Range(-5f, 10f);
				
				
				int groupToSpawn = UnityEngine.Random.Range(0, 5);
				if (groupToSpawn >= 4)
				{
					if (waveBalance >= groupCost)
					{
						Instantiate(monsters_to_spawn[0], new Vector3(spawnX, spawnY, 0f), Quaternion.identity);
						Instantiate(monsters_to_spawn[0], new Vector3(spawnX, spawnY, 0f), Quaternion.identity);
						Instantiate(monsters_to_spawn[1], new Vector3(spawnX, spawnY, 0f), Quaternion.identity);
						Instantiate(monsters_to_spawn[1], new Vector3(spawnX, spawnY, 0f), Quaternion.identity);
						Instantiate(monsters_to_spawn[2], new Vector3(spawnX, spawnY, 0f), Quaternion.identity);
						Instantiate(monsters_to_spawn[2], new Vector3(spawnX, spawnY, 0f), Quaternion.identity);
						waveBalance -= groupCost;
					}
					else
					{
						groupToSpawn -= 1;
					}
				}
				if (groupToSpawn == 3)
				{
					if (waveBalance >= devourerCost)
					{
						Instantiate(monsters_to_spawn[2], new Vector3(spawnX, spawnY, 0f), Quaternion.identity);
						waveBalance -= devourerCost;
					}
					else
					{
						groupToSpawn -= 1;
					}
				}
				if (groupToSpawn == 2)
				{
					if (waveBalance >= bewitchedCost)
					{
						Instantiate(monsters_to_spawn[1], new Vector3(spawnX, spawnY, 0f), Quaternion.identity);
						waveBalance -= bewitchedCost;
					}
					else
					{
						groupToSpawn -= 1;
					}
				}
				if (groupToSpawn == 1)
				{
					if (waveBalance >= formlessGroup)
					{
						Instantiate(monsters_to_spawn[0], new Vector3(spawnX, spawnY, 0f), Quaternion.identity);
						spawnX += UnityEngine.Random.Range(5f, 15f);
						spawnY = UnityEngine.Random.Range(-5f, 10f);
						Instantiate(monsters_to_spawn[0], new Vector3(spawnX, spawnY, 0f), Quaternion.identity);
						spawnX += UnityEngine.Random.Range(5f, 15f);
						spawnY = UnityEngine.Random.Range(-5f, 10f);
						Instantiate(monsters_to_spawn[0], new Vector3(spawnX, spawnY, 0f), Quaternion.identity);
						waveBalance -= formlessGroup;
					}
					else
					{
						groupToSpawn -= 1;
					}
				}
				if (groupToSpawn == 0)
				{
					if (waveBalance >= formlessCost)
					{
						Instantiate(monsters_to_spawn[0], new Vector3(359f, spawnY, 0f), Quaternion.identity);
						waveBalance -= formlessCost;
					}
				}
				
				// This abomination takes the largest of three random numbers.
				timeToSpawn = UnityEngine.Random.Range(0.5f, targetTime);
				float timeToSpawnSecondary = UnityEngine.Random.Range(0.0f, targetTime);
				if (timeToSpawn < timeToSpawnSecondary)
				{
					timeToSpawn = timeToSpawnSecondary;
				}
				timeToSpawnSecondary = UnityEngine.Random.Range(0.0f, targetTime);
				if (timeToSpawn < timeToSpawnSecondary)
				{
					timeToSpawn = timeToSpawnSecondary;
				}
			}
			print(waveBalance);
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
		if (turn % turns_between_card_offers == 0)
        {
			cardManager.AddMoreMana();
        }
			if (turn % turns_between_card_offers == 0)
        {
            OfferCards();
            return;
        }

        ResumePlaying();
    }

    public void PostCardOffered(Card c)
    {
        // callback function, ignores card purposefully ...
        selectScreen.SetActive(false);
        ResumePlaying();
    }

    void ResumePlaying()
    {
        // horribly named function ...
        // basically we need two entry points so we made a function ...
        play = true;

        /*foreach (var monster in monsters_to_spawn)
        {
            Instantiate(monster, new Vector3(209f, 14.9f, 0f), Quaternion.identity);
        }*/

        TOKObjectController.SetPause(false);
		
		waveBalance += (int)(Math.Pow(turn, 1.35) * 10) + 2;
		
		timeToSpawn = targetTime;
		
    }

    void OfferCards()
    {
        selectScreen.SetActive(true);
        cardManager.OfferCards();
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
