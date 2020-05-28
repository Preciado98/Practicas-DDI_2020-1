using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Threading;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool activo;
    Canvas canvas;
    
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) {
            activo = !activo;
            canvas.enabled = activo;
            Time.timeScale = (activo) ? 0 : 1f;
        }
    }
}
