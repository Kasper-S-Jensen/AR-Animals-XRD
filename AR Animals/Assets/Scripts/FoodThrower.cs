using UnityEngine;

public class FoodThrower : MonoBehaviour
{
    public GameObject objectToInstantiate;
  
    public Transform arCamera;
    public float shootForce = 10f;

    public void ShootObject()
    {
        // Instantiate the object at the shootPoint's position and rotation
        var newObject = Instantiate(objectToInstantiate, arCamera.position, arCamera.rotation);

        // Get the Rigidbody component of the new object
        var rb = newObject.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Apply a force to shoot the object
            rb.AddForce(arCamera.forward * shootForce, ForceMode.Impulse);
        }
    }
}