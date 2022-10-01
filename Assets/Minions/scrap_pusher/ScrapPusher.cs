using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapPusher : MonoBehaviour
{
    public UnitStats unitStats; //populate in the inspector.
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
        if (!TOKObjectController.GetPause())
            transform.position += Vector3.right * unitStats.speed * Time.fixedDeltaTime;
    }


    private void OnMouseDown()
    {
        GetComponent<Animator>().SetTrigger("Attack");
    }
}
