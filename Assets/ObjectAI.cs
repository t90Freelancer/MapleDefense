using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAI : MonoBehaviour
{
    //Move   
    [SerializeField] public float speed;
    [SerializeField] private bool moveLeft;
    [SerializeField] private bool isEnemy;
    private ObjectStat _objectstat;
    private Rigidbody2D rb;
    private bool canMove;
    private bool canAttack;
    
    //Detect Object
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layerMask;

    //Animator
    private Animator _anim;

    //Damage
    [SerializeField] public int damage;

    //Check
    private bool isHit;



    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _objectstat = GetComponent<ObjectStat>();

    }
        
    private IEnumerator DetectObject()
    {
        while (true)
        {                     
            Collider2D hit = Physics2D.OverlapCircle(transform.position, radius,layerMask);
            if (hit != null)
            {
                canMove = false;
                if (gameObject.CompareTag("Hero"))
                {
                    _anim.SetBool("isMoving", false);
                }
                Attack();
            }
            else
            {
                if (gameObject.CompareTag("Hero"))
                {
                _anim.SetBool("isMoving", true);
                }                
                canMove = true;
            }
            yield return null;          
        }
    }

    private void Attack()
    {
        if(canAttack && _objectstat.hp>0)
        {
            _anim.SetTrigger("Attack");
            rb.velocity = Vector2.zero;
            canAttack = false;
            StartCoroutine(CanAttackAgain(1f));
        }
    }     

    private void OnEnable()
    {
        canMove = true;
        canAttack = true;
        isHit = false;
        _objectstat= GetComponent<ObjectStat>();    
        _anim = GetComponent <Animator>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DetectObject());
    }
        

    IEnumerator CanAttackAgain(float time)
    {
        yield return new WaitForSeconds(time);
        canAttack = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }    

    public void ObjectTakeHit()
    {
        isHit = true;
        rb.velocity = Vector2.zero;
    }

    public void HitFinish()
    {
        isHit = false;
    }


    public void MoveToDir()
    {
        if (canMove && !isHit && _objectstat.hp>0)
        {
            if (!isEnemy)
            {
            _anim.SetBool("isMoving", true);
            }
            if (moveLeft)
            {
                rb.velocity = Vector2.left * speed * Time.deltaTime;
            }
            else
            {
                rb.velocity = Vector2.right * speed * Time.deltaTime;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }       
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            MoveToDir();
        }
    }    
}
