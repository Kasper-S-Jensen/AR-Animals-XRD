using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivoreFood : MonoBehaviour
{
    public LayerMask targetLayer;
    public GameObject explosion;
    public GameEvent onAnimalEat;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }


    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a player object
        if (((1 << collision.gameObject.layer) & targetLayer) != 0)
        {
            var instantiatedExplosion =
                Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity);
            onAnimalEat.Raise();
            Destroy(instantiatedExplosion, 2f);
            // Destroy the ball when it collides with the player
            Destroy(gameObject);
        }
    }
}