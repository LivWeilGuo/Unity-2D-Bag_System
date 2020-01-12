using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    //要操作的变量
    public Item slotItem;
    public Image slotImage;
    public Text slotCount;
    public string slotInfo;
    public int slotID;
    public GameObject itemInSlot;
    public string itemInSlotType;

    public void ItemOnClick()
    {
        //拼接介绍信息
        string description = slotInfo;
        //刷新物品信息显示
        BagManager.UpdateItemInfo(description);
    }

    public void SetupSlot(Item item)
    {
        //若没有物品
        if (item == null)
        {
            itemInSlot.SetActive(false);
            return;
        }
        //有物品
        slotImage.sprite = item.itemImage;
        slotCount.text = item.itemCount.ToString(format: "00");
        slotInfo = item.itemDescription;
    }
}
