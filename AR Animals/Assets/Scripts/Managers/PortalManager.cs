using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tags
{
    WolfPortal,
    DeerPortal
}
public class PortalManager : MonoBehaviour
{

    public GameEvent onPortalSpawn;
    private void Start()
    {
        onPortalSpawn.Raise("");
        if (gameObject.CompareTag(Tags.WolfPortal.ToString()))
        {
            DestroyPortal(Tags.DeerPortal.ToString());
        }
      
        if (gameObject.CompareTag(Tags.DeerPortal.ToString()))
        {
           DestroyPortal(Tags.WolfPortal.ToString());
        }
    }

    private static void DestroyPortal(string tag)
    {
        var objectToDestroy = GameObject.FindWithTag(tag);
        if (objectToDestroy != null)
        {
            // Destroy the GameObject if it's found
            Destroy(objectToDestroy);
        }
    }
}
