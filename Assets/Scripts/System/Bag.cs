using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bag", menuName = "InventorySystem/Bag")]
public class Bag : ScriptableObject
{
    public List<Item> bagList = new List<Item>();
}
