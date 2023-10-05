using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public GameObject animalFactWindow;

    public bool animalFactWindowActive=false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ToggleAnimalFactWindow(Component sender, object data)
    {
        if (!data.ToString().Equals(gameObject.tag))
        {
            return;
        }

        animalFactWindowActive = !animalFactWindowActive;
        animalFactWindow.SetActive(animalFactWindowActive);
    }
}