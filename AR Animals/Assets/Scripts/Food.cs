using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a player object
        if (collision.gameObject.CompareTag("Dog"))
        {
            // Destroy the ball when it collides with the player
            Destroy(gameObject,1f);
        }
    }
}
