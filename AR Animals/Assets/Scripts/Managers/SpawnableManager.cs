using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SpawnableManager : MonoBehaviour
{
    public GameEvent onAnimalClick;
    
    [SerializeField] private ARRaycastManager _arRaycastManager;
    private List<ARRaycastHit> _hits = new();

    [SerializeField] private GameObject spawnablePrefab;

    private Camera arCam;
    private GameObject spawnedObject;

    private void Start()
    {
        spawnedObject = null;
        arCam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.touchCount == 0)
        {
            return;
        }

        if (_arRaycastManager.Raycast(Input.GetTouch(0).position, _hits))
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && spawnedObject == null)
            {
                Ray ray = arCam.ScreenPointToRay(Input.GetTouch(0).position);
                if (Physics.Raycast(ray, out var hit))
                {
                    if (hit.collider.gameObject.CompareTag("Animal"))
                    {
                        spawnedObject = hit.collider.gameObject;
                        onAnimalClick.Raise();
                    }
                    else
                    {
                     //   SpawnPrefab(_hits[0].pose.position);
                    }
                }
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved && spawnedObject != null)
            {
                spawnedObject.transform.position = _hits[0].pose.position;
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                spawnedObject = null;
            }
        }
    }

    private void SpawnPrefab(Vector3 spawnPosition)
    {
        spawnedObject = Instantiate(spawnablePrefab, spawnPosition, Quaternion.identity);
    }
}