using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public struct ItemScore{
    public string name;
    public int score;
}

[System.Serializable]
public struct ItemBool
{
    public string name;
    public bool accepted;
}

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

    public Text scoreText;
    private int score = 0;

    //TODO: link itemscore and itemlist with ItemTypeList singleton
    //T
    public List<ItemScore> itemScores = new List<ItemScore>();
    public List<ItemBool> itemList = new List<ItemBool>();


    private Dictionary<string, int> itemScoresDict = new Dictionary<string, int>();
    private Dictionary<string, bool> itemListDict = new Dictionary<string, bool>();


    //public List<int> scores = new List<int>(listTypes.Count);

    //static ItemTypeList itemTypes = GameManager.GM.itemTypes;
    //public List<ItemTypeClass> itemScoresList = GameManager.GM.itemTypes.itemList;
    //public ItemTypeList il = GameManager.GM.itemTypes;
    //public List<ItemTypeClass> il = GameManager.GM.itemTypes;
    //private int test = GameManager.GM.itemTypes.Count;

    //private void OnValidate()
    //{
    //    //itemScores.Clear();
    //    //itemList.Clear();
    //    foreach (ItemTypeClass item in GameManager.GM.itemTypes)
    //    {
    //        if (!itemScoresDict.ContainsKey(item.typeName))
    //        {
    //            ItemScore itemScore = new ItemScore();
    //            itemScore.name = item.typeName;
    //            itemScore.score = 0;
    //            itemScores.Add(itemScore);
    //            itemScoresDict.Add(itemScore.name, itemScore.score);
    //        }


    //        if (!itemListDict.ContainsKey(item.typeName))
    //        {
    //            ItemBool itemBool = new ItemBool();
    //            itemBool.name = item.typeName;
    //            itemBool.accepted = true;
    //            itemList.Add(itemBool);
    //            itemListDict.Add(itemBool.name, itemBool.accepted);
    //        }
            

    //    }

    //}

    public void Awake()
    {
        itemScoresDict.Clear();
        itemListDict.Clear();
        foreach (ItemScore itemScore in itemScores)
        {
            itemScoresDict.Add(itemScore.name, itemScore.score);

        }
        foreach (ItemBool item in itemList)
        {
            itemListDict.Add(item.name, item.accepted);
        }
    }

    public void Start()
    {
        
        scoreText.text = score.ToString();
    }

    public void OnPointerEnter (PointerEventData eventData) {
	}

	public void OnPointerExit (PointerEventData eventData) {
	}
	
	public void OnDrop (PointerEventData eventData) {
		Debug.Log("OnDrop + " + gameObject.name);

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null) {
            d.originalParent = this.transform;
            ItemTypeClass itemType = d.GetComponent<cardManager>().cardObjectClass.itemType;
            if(itemType != null)
            {
                if (IsAcceptedType(itemType))
                {
                    score = int.Parse(scoreText.text) + GetTypeScore(itemType);
                    scoreText.text = score.ToString();
                }
            }
            
            
            Destroy(d.gameObject);
        }
	}

    private int GetTypeScore(ItemTypeClass itemType)
    {
        return (itemScoresDict[itemType.typeName]);
    }

    private bool IsAcceptedType(ItemTypeClass itemType)
    {
        if (itemListDict.ContainsKey(itemType.typeName))
        {
            return (itemListDict[itemType.typeName]);
        }
        else
        {
            return false;
        }
        
    }
}
