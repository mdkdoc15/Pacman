/*
 * @Author Matt Kight
 * 
 * Tile based movement system for player
 * Information take from https://www.youtube.com/watch?v=AiZ4z4qKy44
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool mIsMoving = false;
    private Vector3 mOrigPos, mTargetPos, mMoveDir = Vector3.zero;
    [SerializeField] private float mTimeToMove = 0.2f;


    private void Update()
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

        // else if(!mIsMoving)
        // {
        //     StartCoroutine(MovePlayer(mMoveDir));
        // }
    }

    private IEnumerator MovePlayer(Vector3 dir)
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

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            StopAllCoroutines();
            mIsMoving = false;
            transform.position = mOrigPos;
        }
    }
}