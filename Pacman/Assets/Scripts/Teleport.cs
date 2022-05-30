using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform mDestination;

    public Vector3 GetDestination()
    {
        return mDestination.position;
    }
}
