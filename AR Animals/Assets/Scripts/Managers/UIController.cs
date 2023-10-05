using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //ui elements
    public TextMeshProUGUI noiseButton;
    public TextMeshProUGUI selectedAnimaltext;
    public TextMeshProUGUI informationText;
    private string _currentlySelectedAnimal="";
    private int _count = 0;

    //game events
    public GameEvent onNoiseButtonClick;
    public GameEvent onSwitchFood;
    public GameEvent onAppStart;
   


    // Start is called before the first frame update
    private void Start()
    {
     onAppStart.Raise();
    }

    public void ClickNoiseButton()
    {
        onNoiseButtonClick.Raise(_currentlySelectedAnimal);
    }

    public void UpdateSelectedAnimalText(Component sender, object data)
    {
        selectedAnimaltext.text = "Currently selected animal:" + data;
    }

    public void UpdateSelectedAnimal(Component sender, object data)
    {
        _currentlySelectedAnimal = data.ToString();
    }


    public void DropdownSelect(int index)
    {
        if (index == 0)
        {
            onSwitchFood.Raise("Lettuce");
        }
        else if (index == 1)
        {
            onSwitchFood.Raise("Meat");
        }
    }
    public void ScanEnvironmentPrompt(Component sender, object data)
    {
        informationText.text = "Please take a few moments to scan your environment";
        StartCoroutine(ActivateForSeconds(informationText.gameObject, 3));
    }
    public void SelectAnimalPrompt(Component sender, object data)
    {
        if (_currentlySelectedAnimal=="")
        {
            informationText.text = "Please select an animal";
            StartCoroutine(ActivateForSeconds(informationText.gameObject, 3));
        }
    }
    
    private IEnumerator ActivateForSeconds(GameObject go, float seconds)
    {
        go.SetActive(true);
        yield return new WaitForSeconds(seconds);
        go.SetActive(false);
    }
}