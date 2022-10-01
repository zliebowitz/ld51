using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formless : MonoBehaviour
{
    public UnitStats unitStats; //populate in the inspector.
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
            transform.position += Vector3.left * unitStats.speed * Time.fixedDeltaTime;
    }

    private void OnMouseDown()
    {
        GetComponent<Animator>().SetTrigger("Attack");
    }

    public void SetPause(bool pause){
        pauseMovement = pause;
    }
}
