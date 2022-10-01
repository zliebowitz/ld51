using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formless : MonoBehaviour
{
    private float moveSpeed = 10;
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
