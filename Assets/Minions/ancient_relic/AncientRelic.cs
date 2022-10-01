using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncientRelic : MonoBehaviour
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
        transform.position += Vector3.right * unitStats.speed * Time.fixedDeltaTime;
    }


    private void OnMouseDown()
    {
        GetComponent<Animator>().SetTrigger("Attack");
    }
}
