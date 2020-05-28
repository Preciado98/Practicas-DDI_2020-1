using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
using UnityEngine.Assertions;

public class Playermov : MonoBehaviour{
    
    public float speed = 4f;
    Animator anim;
    Rigidbody2D rb2d;
    Vector2 mov;

    public GameObject initialMap;

    void Awake()
    {
        Assert.IsNotNull(initialMap);
    }

    // Start is called before the first frame update
    void Start(){
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        Camera.main.GetComponent<MainCamara>().SetBound(initialMap);
    }

    // Update is called once per frame
    void Update(){

        mov = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
            );

        if (mov != Vector2.zero)
        {
            anim.SetFloat("movX", mov.x);
            anim.SetFloat("movY", mov.y);
            anim.SetBool("walking",true);
        }
        else {
            anim.SetBool("walking",false);
        }
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + mov * speed * Time.deltaTime);
    }

}
