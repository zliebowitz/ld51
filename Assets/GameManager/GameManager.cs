using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float targetTime = 10.0f;
    public bool play = false;
    List<GameObject> monsters = new List<GameObject>();
    List<GameObject> minions = new List<GameObject>();

    public TOKObjectController tokController = new TOKObjectController();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (play)
        {
            targetTime -= Time.deltaTime;
            if (targetTime <= 0.0f)
            {
                timerEnded();
                Debug.Log("timerEnd");
            }
        }

    }

    void timerEnded()
    {
        play = false;
        targetTime = 10.0f;
        // setPauseAll(true);
        TOKObjectController.SetPause(true);
    }

    void OnGUI()
    {
        // int minutes = Mathf.FloorToInt(timer / 60F);
        // int seconds = Mathf.FloorToInt(timer - minutes * 60);
        // string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        // GUI.Label(new Rect(10, 10, 250, 100), niceTime);

    }

    public void Play()
    {
        play = true;

        InstantiationMonster bewitchedObject = GameObject.Find("BewitchedObject").GetComponent<InstantiationMonster>();
        monsters.Add(bewitchedObject.New());

        InstantiationMonster formlessObject = GameObject.Find("FormlessObject").GetComponent<InstantiationMonster>();
        monsters.Add(formlessObject.New());

        InstantiationMonster devourerObject = GameObject.Find("DevourerObject").GetComponent<InstantiationMonster>();
        monsters.Add(devourerObject.New());
        
        
        InstantiationMinion tamedObject = GameObject.Find("TamedObject").GetComponent<InstantiationMinion>();
        minions.Add(tamedObject.New());

        InstantiationMinion scapPusherObject = GameObject.Find("ScapPusherObject").GetComponent<InstantiationMinion>();
        minions.Add(scapPusherObject.New());

        InstantiationMinion ancientRelicObject = GameObject.Find("AncientRelicObject").GetComponent<InstantiationMinion>();
        minions.Add(ancientRelicObject.New());

        InstantiationMinion mechCasterObject = GameObject.Find("MechCasterObject").GetComponent<InstantiationMinion>();
        minions.Add(mechCasterObject.New());

        TOKObjectController.SetPause(false);
    }

}
