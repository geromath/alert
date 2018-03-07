using UnityEngine;

[CreateAssetMenu(fileName = "CardObjectType", menuName = "Alert/Card", order = 1)]
public class CardObjectClass : ScriptableObject {
    public ItemTypeClass itemType;
    public string[] flavourTexts;
    public Color color = Color.white;

    public string getRandomFlavourText()
    {
        return flavourTexts[Random.Range(0, flavourTexts.Length)];
    }
}
