using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechCaster : MonoBehaviour
{
    private float moveSpeed = 5;

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
        transform.position += Vector3.right * moveSpeed * Time.fixedDeltaTime;
    }


    private void OnMouseDown()
    {
        GetComponent<Animator>().SetTrigger("Attack");
    }
}
