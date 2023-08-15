using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiemAttack : MonoBehaviour
{
    private Animator animator;
    private float delay = 0.5f;
    private bool attackBlock;
    private bool isAttack;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("quai") && isAttack)
        {
            Destroy(collision.gameObject);
        }
    }

    public void Attack()
    {
        if (attackBlock) return;
        animator.SetTrigger("attack");
        attackBlock = true;
        isAttack = true;
        Debug.Log(">>>");
        StartCoroutine(DelayAttack());

    }

    private IEnumerator DelayAttack()
    {
       yield return new WaitForSeconds(delay);
        attackBlock= false;
        isAttack= false;
    }
}
