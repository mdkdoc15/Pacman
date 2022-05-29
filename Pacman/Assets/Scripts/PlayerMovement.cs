using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float mMoveSpeed = 5f;
    private Rigidbody2D mRb;
    private Vector2 mMoveVec;

    private void Awake()
    {
        mRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
        mMoveVec.x = Input.GetAxisRaw("Horizontal");
        mMoveVec.y = Input.GetAxisRaw("Vertical");
        mMoveVec = mMoveVec.normalized;
    }

    private void FixedUpdate()
    {
        mRb.MovePosition(mRb.position + mMoveVec * mMoveSpeed * Time.fixedDeltaTime); 
    }
}
