using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TouchManager : MonoBehaviour
{
    public GameEvent onAnimalClick;

    [SerializeField] private ARRaycastManager _arRaycastManager;
    private List<ARRaycastHit> _hits = new();

    [SerializeField] private GameObject spawnablePrefab;

    private Camera arCam;


    private void Start()
    {
        arCam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.touchCount == 0)
        {
            return;
        }

        if (!_arRaycastManager.Raycast(Input.GetTouch(0).position, _hits))
        {
            return;
        }

        if (Input.GetTouch(0).phase != TouchPhase.Began)
        {
            return;
        }

        var ray = arCam.ScreenPointToRay(Input.GetTouch(0).position);
        if (!Physics.Raycast(ray, out var hit))
        {
            return;
        }

        if (hit.collider.gameObject.CompareTag("Dog"))
        {
            onAnimalClick.Raise("Dog");
        }
        else if (hit.collider.gameObject.CompareTag("Stag"))
        {
            onAnimalClick.Raise("Stag");
        }

        //if we want to drag and drop
        /*else if (Input.GetTouch(0).phase == TouchPhase.Moved && spawnedObject != null)
            {
                spawnedObject.transform.position = _hits[0].pose.position;
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                spawnedObject = null;
            }
            */
    }
    public void DeleteAllPrefabs(Component sender, object data)
    {
        DestroyByTag("Dog");
        DestroyByTag("Stag");
        DestroyByTag("WolfPortal");
    }
    
    private static void DestroyByTag(string tag)
    {
        var objectToDestroy = GameObject.FindWithTag(tag);
        if (objectToDestroy != null)
        {
            // Destroy the GameObject if it's found
            Destroy(objectToDestroy);
        }
    }
}