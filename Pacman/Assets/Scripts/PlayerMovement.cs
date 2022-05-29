/*
 * @Author Matt Kight
 * 
 * Tile based movement system for player
 * Information take from https://www.youtube.com/watch?v=AiZ4z4qKy44
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask mHitLayer;
    private bool mIsMoving = false;
    private Vector3 mOrigPos, mTargetPos, mMoveDir = Vector3.zero;
    [SerializeField] private float mTimeToMove = 0.05f;
    private CircleCollider2D mCollider;

    private void Awake()
    {
        mCollider = GetComponent<CircleCollider2D>();
    }


    private void Update()
    {
        if (Input.anyKey)
        {
            // TODO update to allow use of arrow keys and what not
            if (Input.GetKey(KeyCode.W) && !mIsMoving)
            {
                mMoveDir = Vector3.up;
                StartCoroutine(MovePlayer(Vector3.up));
            }


            if (Input.GetKey(KeyCode.A) && !mIsMoving)
            {
                mMoveDir = Vector3.left;
                StartCoroutine(MovePlayer(Vector3.left));
            }


            if (Input.GetKey(KeyCode.S) && !mIsMoving)
            {
                mMoveDir = Vector3.down;
                StartCoroutine(MovePlayer(Vector3.down));
            }

            if (Input.GetKey(KeyCode.D) && !mIsMoving)
            {
                mMoveDir = Vector3.right;
                StartCoroutine(MovePlayer(Vector3.right));
            }
        }
        else
        {
            if (!mIsMoving)
            {
                StartCoroutine(MovePlayer(mMoveDir));
            }
            
        }
        
        

        
    }

    private IEnumerator MovePlayer(Vector3 dir)
    {
        if (CanMove(dir))
        {
            mIsMoving = true;
        
            float elapsedTime = 0;

            mOrigPos = transform.position;
            mTargetPos = mOrigPos + dir;

            while (elapsedTime < mTimeToMove && mIsMoving)
            {
                transform.position = Vector3.Lerp(mOrigPos, mTargetPos, elapsedTime / mTimeToMove);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = mTargetPos;

            mIsMoving = false;
        }
        else
        {
            // TODO handle what happens when player tries to go into a wall while moving in a good dir
            
        }
        

    }

    

    private bool CanMove(Vector3 dir)
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(mCollider.bounds.center, dir, 2 * mCollider.bounds.extents.x , mHitLayer);
        return raycastHit.collider == null;
    }
}