using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    
    //ui elements
    public TextMeshProUGUI noiseButton;

    private int _count=0;
    //game events
    public GameEvent onNoiseButtonClick;
   


    // Start is called before the first frame update
    private void Start()
    {
        //initialize ui text
    }
    
    public void ClickNoiseButton()
    {
        _count++;
        onNoiseButtonClick.Raise();
        noiseButton.text = "Noise: "+_count;
    }
}