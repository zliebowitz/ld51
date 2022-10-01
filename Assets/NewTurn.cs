using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTurn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check for mouse click 
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                    //Our custom method. 
                    if(raycastHit.transform.gameObject.name == "New Turn")
                    {
                        GameObject go = GameObject.Find("CardManager");
                        go.GetComponent<CardManager>().NewTurn();
                    }

                }
            }
        }
    }
}
