using UnityEngine;
using UnityEngine.Serialization;

public class FoodThrower : MonoBehaviour
{
    
    
     public GameObject[] FoodList;
     private int _foodIndex;
    public Transform arCamera;
    public float shootForce = 10f;
 
    public void ShootObject()
    {
        // Instantiate the object at the shootPoint's position and rotation
        var newObject = Instantiate(FoodList[_foodIndex], arCamera.position, arCamera.rotation);

        // Get the Rigidbody component of the new object
        var rb = newObject.GetComponent<Rigidbody>();
       
        if (rb != null)
        {
            // Apply a force to shoot the object
            rb.AddForce(arCamera.forward * shootForce, ForceMode.Impulse);
        }
    }
    
    public void UpdateSelectedAnimalFood(Component sender, object data)
    {
        if (data is not string foodName)
        {
            return;
        }

        if (foodName=="Carrot")
        {
            _foodIndex = 0;
        }
        if (foodName=="Banana")
        {
            _foodIndex = 1;
        }
    }
}