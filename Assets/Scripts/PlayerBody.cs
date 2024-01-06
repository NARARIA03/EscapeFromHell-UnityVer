using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    private Vector2 inputVec;
    private Rigidbody2D rigid;
    private SpriteRenderer spriter;
    private Animator animator;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

        // Set Animation Parameters
        animator.SetFloat("moveAbsX", MathF.Abs(inputVec.x));
        animator.SetFloat("moveAbsY", MathF.Abs(inputVec.y));

    }

    void FixedUpdate()
    {
        Vector2 moveVec = inputVec.normalized * Time.fixedDeltaTime * GameManager.Instance.playerMoveSpeed;
        rigid.MovePosition(rigid.position + moveVec);
    }

    void LateUpdate()
    {
        spriter.flipX = (inputVec.x < -0.01f);
    }
}
