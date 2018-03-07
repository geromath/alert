using UnityEngine;
using UnityEngine.UI;

public class cardManager : MonoBehaviour
{

    public CardObjectClass cardObjectClass;

    public Text text;

    // Use this for initialization
    void Start()
    {
        this.text.text = cardObjectClass.getRandomFlavourText();
        this.gameObject.GetComponent<Image>().color = cardObjectClass.color;
    }

}