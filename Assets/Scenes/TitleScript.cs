using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().PlayMusic("Title");
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        SceneManager.LoadScene("ld51", LoadSceneMode.Single);
    }

    
}
