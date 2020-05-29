using System;
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
    public GameObject slashPrefrab;

    bool movePrevent;

    CircleCollider2D attackCollider;

    void Awake()
    {
        Assert.IsNotNull(initialMap);
        Assert.IsNotNull(slashPrefrab);
    }

    // Start is called before the first frame update
    void Start(){
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        attackCollider = transform.GetChild(0).GetComponent<CircleCollider2D>();
        attackCollider.enabled = false;

        Camera.main.GetComponent<MainCamara>().SetBound(initialMap);
    }

    // Update is called once per frame
    void Update(){

        Movements();

        Animation();

        SwortAttack();

        PreventMovement();

    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + mov * speed * Time.deltaTime);
    }

    void Movements()
    {
        mov = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
            );
    }

    void Animation() {
        if (mov != Vector2.zero)
        {
            anim.SetFloat("movX", mov.x);
            anim.SetFloat("movY", mov.y);
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }
    }

    void SwortAttack() {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        bool attacking = stateInfo.IsName("Lego_Attack");

        if (Input.GetKeyDown("space") && !attacking)
        {
            anim.SetTrigger("attacking");
        }

        if (mov != Vector2.zero) attackCollider.offset = new Vector2(mov.x / 2, mov.y / 2);

        if (attacking)
        {
            float playbackTime = stateInfo.normalizedTime;

            if (playbackTime > 0.33 && playbackTime < 0.66) attackCollider.enabled = true;
            else attackCollider.enabled = false;
        }
    }

    void PreventMovement() {
        if (movePrevent) {
            mov = Vector2.zero;
        }
    }

}
