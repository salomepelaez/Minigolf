using System;
using UnityEngine;

public class CollisionListener : MonoBehaviour
{
    public Action<Collision> onCollisionEnter   = null;
    public Action<Collision> onCollisionStay    = null;
    public Action<Collision> onCollisionExit    = null;

    private void OnCollisionEnter(Collision collision)
    {
        if (onCollisionEnter != null)
            onCollisionEnter(collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (onCollisionStay != null)
            onCollisionStay(collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (onCollisionExit != null)
            onCollisionExit(collision);
    }

}
