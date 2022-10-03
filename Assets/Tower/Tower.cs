using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public UnitStats unitStats; //populate in the inspector.

    
    private float shakeDuration = 1f;
    private float shakeTime = 0.0f;
    private float originalX;


    // Start is called before the first frame update
    void Start()
    {
        originalX = transform.position.x;
        shakeTime = shakeDuration;
    }

    // Update is called once per frame
    void Update()
    {
        var updatePosition = transform.position;
        if (shakeTime < shakeDuration)
        {
            shakeTime += Time.deltaTime;
            updatePosition.x = originalX + Mathf.Sin(shakeTime*10.0f) * 1f;
        }

        // Then assign a new vector3
        transform.position = updatePosition;
    }

    public void Hit(int damage)
    {
        shakeTime = 0;
        unitStats.health -= damage;
        if (unitStats.health < 0)
        {
            GameObject loser = GameObject.Find("GameManager").transform.Find("LoseScreen").gameObject;
            loser.SetActive(true);
            loser.transform.Find("Defeat").gameObject.GetComponent<Animator>().SetTrigger("Lose");
        }
        
    }
}
