using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Vector2 inputVec;
    private Animator animator;
    
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

        // Set Animation Parameters
        animator.SetBool("isT", Input.GetKey(KeyCode.T));
        animator.SetBool("isF", Input.GetKey(KeyCode.F));
        animator.SetBool("isG", Input.GetKey(KeyCode.G));
        animator.SetBool("isH", Input.GetKey(KeyCode.H));
        
    }

    void FixedUpdate()
    {
        Vector2 moveVec = inputVec.normalized * Time.fixedDeltaTime * GameManager.Instance.playerMoveSpeed;
        rigid.MovePosition(rigid.position + moveVec);
    }
}
