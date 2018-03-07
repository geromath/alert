using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour {
    

    //GameManager singleton
    public static GameManager GM;

    //public ItemTypeList itemTypes; //could be moved to a (singleton) boardmanager, if we want to implement boards with different itemtypes
    public List<ItemTypeClass> itemTypes = new List<ItemTypeClass>();
    void OnValidate()
    {
        if(GM != null)
        {
            //GameObject.Destroy(GM);
        }
        else
        {
            GM = this;
        }

        
    }

    //private void Awake()
    //{
    //    DontDestroyOnLoad(this);
    //}
    
}

