using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionListener : MonoBehaviour
{
    public Action<Collision> onCollisionEnter = null;
    public Action<Collision> onCollisionState = null;
    public Action<Collision> onCollisonExit = null;

    void OnCollisionEnter(Collision collision)
    {
        if(onCollisionEnter != null)
        {
            onCollisionEnter(collision);
        }
    }
}
