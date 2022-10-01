using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        // Bewitched monster = GameObject.Find("Bewitched").GetComponent<Bewitched>();
        // InstantiationBewitched obj = new InstantiationBewitched();
        InstantiationMonster bewitchedObject = GameObject.Find("BewitchedObject").GetComponent<InstantiationMonster>();
        bewitchedObject.New();

        InstantiationMonster formlessObject = GameObject.Find("FormlessObject").GetComponent<InstantiationMonster>();
        formlessObject.New();

        InstantiationMonster devourerObject = GameObject.Find("DevourerObject").GetComponent<InstantiationMonster>();
        devourerObject.New();
    }
}
