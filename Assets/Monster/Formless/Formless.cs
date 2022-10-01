using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formless : MonoBehaviour
{
    private float moveSpeed = 10;

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
        transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;
    }

    private void OnMouseDown()
    {
        GetComponent<Animator>().SetTrigger("Attack");
    }
}
