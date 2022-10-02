using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public Color defaultColor = Color.black;
    public Color lightningColor = Color.white;
    public int duration = 4000; ///> milliseconds

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
    }

    // Update is called once per frame
    void Update()
    {
        int normalizedTime = ((int) Mathf.Floor(1000.0f * Time.time)) % 4000;
        if (
            (normalizedTime > 3000 && normalizedTime < 3100)
            || (normalizedTime > 3200 && normalizedTime < 3300)
            )
        {
            cam.backgroundColor = lightningColor;
        }
        else
        {
            cam.backgroundColor = defaultColor;
        }
    }
}
