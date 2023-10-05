using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //ui elements
    public TextMeshProUGUI noiseButton;
    public TextMeshProUGUI selectedAnimaltext;

    private int _count = 0;

    //game events
    public GameEvent onNoiseButtonClick;
    public GameEvent onSwitchFood;
   


    // Start is called before the first frame update
    private void Start()
    {
        //initialize ui text
    }

    public void ClickNoiseButton()
    {
        _count++;
        onNoiseButtonClick.Raise();
        noiseButton.text = "Noise: " + _count;
    }

    public void UpdateSelectedAnimalText(Component sender, object data)
    {
        selectedAnimaltext.text = "Currently selected animal:" + data;
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
}