using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Inventory System/DataBase")]
public class ItemDataBase : ScriptableObject {
    public List<Item> items = new List<Item>();

    public Item FindItemInItemDataBase(int id)
    {
        foreach (Item item in items)
        {
            if (item.id == id)
            {
                return item;
            }
        }
        return null;

    }
    [System.Serializable]
    public class Item
    {
        public int id;
        public string name;
		public string title;
		[TextArea(5,1)]
        public string description;
        public bool isStackable;
        public bool isFauna;
        public bool isFlora;
		public bool isDiario;
		public ItemType itemType;
        public Stats stats;
        public Vector2 scrollPos;
        public Sprite itemImage;
		public Sprite descriptionImage;
		[System.Serializable]
        public struct Stats
        {
            public int cost;
            public int sellCost;
            public int damage;
            public int defense;
            public int health;
            public int mana;
        }
        public enum ItemType {FLORA,FAUNA,CONSUMABLE,WEAPON,CLOTH,QUEST,MISC}
     
        
    }
}
