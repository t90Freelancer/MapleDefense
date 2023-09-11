using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnim : MonoBehaviour
{
    public enum HeroState
    {
        moving,
        attack
    }

    private Animator anim;
    private Rigidbody2D rb;
    public HeroState state;

    void Start()
    {
        state = HeroState.moving;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }       

    private void setAnim()
    {

        if (state == HeroState.moving)
        {
            if (rb.velocity.magnitude != 0)
            {
                anim.SetBool("isMoving", true);
            }
            else
            {
                anim.SetBool("isMoving", false);
            }
        }else if(state == HeroState.attack)
        {
            anim.SetTrigger("Attack");
        }
    }
    // Update is called once per frame
    void Update()
    {
        setAnim();
    }
}
