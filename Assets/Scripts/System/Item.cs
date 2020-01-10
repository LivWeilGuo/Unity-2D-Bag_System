using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    //物品的属性
    public string itemName;//名称
    public string itemType;//种类
    public Sprite itemImage;//图片
    public int itemCount;//数量
    [TextArea]
    public string itemDescription;//介绍
}
