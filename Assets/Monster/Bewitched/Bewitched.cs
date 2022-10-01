using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bewitched : MonoBehaviour
{
    private float moveSpeed = 5;
    private bool pauseMovement = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (!pauseMovement)
            transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;
    }

    private void OnMouseDown()
    {
        GetComponent<Animator>().SetTrigger("Attack");
    }

    public void SetPause(bool pause){
        pauseMovement = pause;
    }
}
