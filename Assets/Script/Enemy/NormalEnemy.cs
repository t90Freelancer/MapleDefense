using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NormalEnemy : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask layerMask;
    private Animator _anim;
    private Rigidbody2D _rb;

    
    private void OnEnable()
    {
        StartCoroutine(DetectObject());
    }

    IEnumerator DetectObject()
    {
        _rb = GetComponent<Rigidbody2D>();
        while (true)
        {
            Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, layerMask);
            if (hit != null)
            {
                _rb.velocity = Vector2.zero;
            }
            else
            {
                _rb.velocity = Vector2.left * speed * Time.deltaTime;
            }
            yield return null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radius);  
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
