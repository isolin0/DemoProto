using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemDataBase))]
public class DataBaseEditor : Editor {
    private ItemDataBase itemDataBase;

    private string searchString;

    private bool shouldSearch;

    private void OnEnable()
    {
        itemDataBase = (ItemDataBase)target;
    }
    public override void OnInspectorGUI()
    {
        //  base.OnInspectorGUI();
       // base.DrawDefaultInspector();
        if (itemDataBase)
        {
            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("Items in ItemDataBase:" + itemDataBase.items.Count);
            EditorGUILayout.EndHorizontal();
            if (itemDataBase.items.Count > 0)
            {
                EditorGUILayout.BeginHorizontal("Box");
                GUILayout.Label("Search:");
                searchString = GUILayout.TextField(searchString);
                EditorGUILayout.EndHorizontal();
            }

            if (GUILayout.Button("Add Item"))
            {
                Debug.Log("abrir ventana");
                ItemWindow.ShowEmptyWindow(itemDataBase);
            }

            if (System.String.IsNullOrEmpty(searchString))
            {
                shouldSearch = false;
            }
            else
                shouldSearch = true;

            foreach (ItemDataBase.Item item in itemDataBase.items)
            {
                //dibujar la representacion del item

                if (shouldSearch)
                {
                    if (item.name == searchString || item.name.Contains(searchString) || item.id.ToString() == searchString)
                    {
                        DisplayItem(item);
                    }
                }
                else
                    DisplayItem(item);

                
            }

            if (deletedItem != null)
                itemDataBase.items.Remove(deletedItem);

        }
    }

    private ItemDataBase.Item deletedItem;
    private void DisplayItem(ItemDataBase.Item item)
    {
        GUIStyle labelStyle = new GUIStyle(GUI.skin.label)
        {
            wordWrap = true
        };
        GUIStyle valueStyle = new GUIStyle(GUI.skin.label)
        {
            wordWrap = true
        };
        valueStyle.alignment = TextAnchor.MiddleLeft;
        valueStyle.fixedWidth = 50;
        valueStyle.margin = new RectOffset(0, 50, 0, 0);

        EditorGUILayout.BeginVertical("Box");

        Sprite itemSprite = item.itemImage;
        if(itemSprite != null)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Image:" + item.itemImage.ToString());
            EditorGUILayout.EndHorizontal();
        }

		Sprite itemDesSprite = item.descriptionImage;
		if (itemDesSprite != null)
		{
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField("Descrition Image:" + item.descriptionImage.ToString());
			EditorGUILayout.EndHorizontal();
		}


		EditorGUILayout.BeginHorizontal();
        GUILayout.Label("ID: ");
        GUILayout.Label(item.id.ToString(), valueStyle);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Name: ");
        GUILayout.Label(item.name, labelStyle);
        EditorGUILayout.EndHorizontal();
		EditorGUILayout.BeginHorizontal();
		GUILayout.Label("Title: ");
		GUILayout.Label(item.title, labelStyle);
		EditorGUILayout.EndHorizontal();
		EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Type: ");
        GUILayout.Label(item.itemType.ToString(), labelStyle);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Stackable: ");
        GUILayout.Label(item.isStackable.ToString(), labelStyle);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("IsFauna: ");
        GUILayout.Label(item.isFauna.ToString(), labelStyle);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("IsFlora: ");
        GUILayout.Label(item.isFlora.ToString(), labelStyle);
        EditorGUILayout.EndHorizontal();
		EditorGUILayout.BeginHorizontal();
		GUILayout.Label("IsDiario: ");
		GUILayout.Label(item.isDiario.ToString(), labelStyle);
		EditorGUILayout.EndHorizontal();
		GUILayout.Label("Description: ");

        item.scrollPos = EditorGUILayout.BeginScrollView(item.scrollPos, GUILayout.MinHeight(3), GUILayout.MinHeight(70));
        GUILayout.Label(item.description, labelStyle);
        EditorGUILayout.EndScrollView();

        GUILayout.Label("Statistics: ");
        EditorGUILayout.BeginVertical("box");
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Cost: ");
        GUILayout.Label(item.stats.sellCost.ToString(), valueStyle);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Selling Cost: ");
        GUILayout.Label(item.stats.sellCost.ToString(), valueStyle);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Damage: ");
        GUILayout.Label(item.stats.damage.ToString(), valueStyle);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Defense: ");
        GUILayout.Label(item.stats.defense.ToString(), valueStyle);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Health: ");
        GUILayout.Label(item.stats.health.ToString(), valueStyle);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Mana: ");
        GUILayout.Label(item.stats.mana.ToString(), valueStyle);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginHorizontal();
        
        if (GUILayout.Button("Modify"))
        {
            ItemModifyWindow.ShowItemWindow(itemDataBase, item);
        }
        if (GUILayout.Button("Delete"))
        {
            deletedItem = item;
           
        }
        else
            deletedItem = null;
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.EndVertical();
        
    }

}
