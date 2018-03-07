using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateItemTypeList
{
    [MenuItem("Assets/Create/ItemTypeList")]
    public static ItemTypeList Create()
    {
        ItemTypeList asset = ScriptableObject.CreateInstance<ItemTypeList>();

        AssetDatabase.CreateAsset(asset, "Assets/ItemTypeList.asset");
        AssetDatabase.SaveAssets();
        return asset;
    }
}