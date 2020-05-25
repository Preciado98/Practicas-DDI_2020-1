using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class logicapersonaje : MonoBehaviour
{

    public float velmov = 5.0f;
    public float velrot = 200.0f;
    private Animator anim;
    public float x, y;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime*velrot,0);
        transform.Translate(0,0,y*Time.deltaTime*velmov);

        anim.SetFloat("velX",x);
        anim.SetFloat("velY", y);
    }
}
