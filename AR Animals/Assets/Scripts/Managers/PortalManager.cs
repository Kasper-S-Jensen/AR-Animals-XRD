using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    
    public GameObject[] animalList;
    private int _animalIndex=0;
    public Transform  planeObject;

   
    private Vector3 planeCenter;
    void Start()
    {
        CalculatePlaneCenter();
        // Instantiate the object at the shootPoint's position and rotation
       Instantiate(animalList[_animalIndex], planeCenter, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    void CalculatePlaneCenter()
    {
        // Calculate the center of the plane based on its current position and size
        Renderer planeRenderer = planeObject.GetComponent<Renderer>(); // Assuming the plane has a renderer
        Bounds planeBounds = planeRenderer.bounds;

        // Calculate the center based on the bounds
        planeCenter = planeBounds.center;
    }
}
