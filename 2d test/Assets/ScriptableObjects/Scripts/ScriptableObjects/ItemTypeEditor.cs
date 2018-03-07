using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class ItemTypeEditor : EditorWindow
{

    public ItemTypeList itemTypeList;
    private int viewIndex = 1;

    [MenuItem("Window/Inventory Item Editor %#e")]
    static void Init()
    {
        EditorWindow.GetWindow(typeof(ItemTypeEditor));
    }

    void OnEnable()
    {
        if (EditorPrefs.HasKey("ObjectPath"))
        {
            string objectPath = EditorPrefs.GetString("ObjectPath");
            itemTypeList = AssetDatabase.LoadAssetAtPath(objectPath, typeof(ItemTypeList)) as ItemTypeList;
        }

    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Inventory Item Editor", EditorStyles.boldLabel);
        if (itemTypeList != null)
        {
            if (GUILayout.Button("Show Item List"))
            {
                EditorUtility.FocusProjectWindow();
                Selection.activeObject = itemTypeList;
            }
        }
        if (GUILayout.Button("Open Item List"))
        {
            OpenItemList();
        }
        if (GUILayout.Button("New Item List"))
        {
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = itemTypeList;
        }
        GUILayout.EndHorizontal();

        if (itemTypeList == null)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            if (GUILayout.Button("Create New Item List", GUILayout.ExpandWidth(false)))
            {
                CreateNewItemList();
            }
            if (GUILayout.Button("Open Existing Item List", GUILayout.ExpandWidth(false)))
            {
                OpenItemList();
            }
            GUILayout.EndHorizontal();
        }

        GUILayout.Space(20);

        if (itemTypeList != null)
        {
            GUILayout.BeginHorizontal();

            GUILayout.Space(10);

            if (GUILayout.Button("Prev", GUILayout.ExpandWidth(false)))
            {
                if (viewIndex > 1)
                    viewIndex--;
            }
            GUILayout.Space(5);
            if (GUILayout.Button("Next", GUILayout.ExpandWidth(false)))
            {
                if (viewIndex < itemTypeList.itemList.Count)
                {
                    viewIndex++;
                }
            }

            GUILayout.Space(60);

            if (GUILayout.Button("Add Item", GUILayout.ExpandWidth(false)))
            {
                AddItem();
            }
            if (GUILayout.Button("Delete Item", GUILayout.ExpandWidth(false)))
            {
                DeleteItem(viewIndex - 1);
            }

            GUILayout.EndHorizontal();
            if (itemTypeList.itemList == null)
                Debug.Log("wtf");
            if (itemTypeList.itemList.Count > 0)
            {
                GUILayout.BeginHorizontal();
                viewIndex = Mathf.Clamp(EditorGUILayout.IntField("Current Item", viewIndex, GUILayout.ExpandWidth(false)), 1, itemTypeList.itemList.Count);
                //Mathf.Clamp (viewIndex, 1, itemTypeList.itemList.Count);
                EditorGUILayout.LabelField("of   " + itemTypeList.itemList.Count.ToString() + "  items", "", GUILayout.ExpandWidth(false));
                GUILayout.EndHorizontal();

                itemTypeList.itemList[viewIndex - 1].typeName = EditorGUILayout.TextField("Item Name", itemTypeList.itemList[viewIndex - 1].typeName as string);

                GUILayout.Space(10);

                GUILayout.BeginHorizontal();
                itemTypeList.itemList[viewIndex - 1].isUnique = (bool)EditorGUILayout.Toggle("Unique", itemTypeList.itemList[viewIndex - 1].isUnique, GUILayout.ExpandWidth(false));
                GUILayout.EndHorizontal();

                GUILayout.Space(10);

            }
            else
            {
                GUILayout.Label("This Inventory List is Empty.");
            }
        }
        if (GUI.changed)
        {
            EditorUtility.SetDirty(itemTypeList);
        }
    }

    void CreateNewItemList()
    {
        // There is no overwrite protection here!
        // There is No "Are you sure you want to overwrite your existing object?" if it exists.
        // This should probably get a string from the user to create a new name and pass it ...
        viewIndex = 1;
        itemTypeList = CreateItemTypeList.Create();
        if (itemTypeList)
        {
            itemTypeList.itemList = new List<ItemTypeClass>();
            string relPath = AssetDatabase.GetAssetPath(itemTypeList);
            EditorPrefs.SetString("ObjectPath", relPath);
        }
    }

    void OpenItemList()
    {
        string absPath = EditorUtility.OpenFilePanel("Select Inventory Item List", "", "");
        if (absPath.StartsWith(Application.dataPath))
        {
            string relPath = absPath.Substring(Application.dataPath.Length - "Assets".Length);
            itemTypeList = AssetDatabase.LoadAssetAtPath(relPath, typeof(ItemTypeList)) as ItemTypeList;
            if (itemTypeList.itemList == null)
                itemTypeList.itemList = new List<ItemTypeClass>();
            if (itemTypeList)
            {
                EditorPrefs.SetString("ObjectPath", relPath);
            }
        }
    }

    void AddItem()
    {
        ItemTypeClass newItem = new ItemTypeClass();
        newItem.typeName = "New Item";
        itemTypeList.itemList.Add(newItem);
        viewIndex = itemTypeList.itemList.Count;
    }

    void DeleteItem(int index)
    {
        itemTypeList.itemList.RemoveAt(index);
    }
}