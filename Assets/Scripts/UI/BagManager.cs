using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagManager : MonoBehaviour
{
    static BagManager instance;

    //变量
    public Bag myBag;
    public GameObject slotGrid;
    public GameObject emptySlot;
    public Text itemInformation;
    public List<GameObject> slotList = new List<GameObject>();

    private void Awake()
    {
        //单例模式
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    private void OnEnable()
    {
        //刷新所有物品格内的物品
        RefreshItem();
        //初始化物品介绍信息
        instance.itemInformation.text = "";
    }

    /// <summary>
    /// 刷新物品信息的显示
    /// </summary>
    /// <param name="itemDescription">
    /// 汇总后的物品信息
    /// </param>
    public static void UpdateItemInfo(string itemDescription)
    {
        instance.itemInformation.text = itemDescription;
    }

    /// <summary>
    /// 刷新所有物品
    /// </summary>
    public static void RefreshItem()
    {
        Transform grid = instance.slotGrid.transform;
        int slotNum = grid.childCount;
        int slotNumInBag = instance.myBag.bagList.Count;
        //销毁原有的所有子集
        if (slotNum != 0)//物品栏内存在物品格
        {
            for (int i = 0; i < slotNum; i++)//遍历所有物品格
            {
                Destroy(grid.GetChild(i).gameObject);
            }
            instance.slotList.Clear();
        }

        //重新生成现有的子集
        for (int i = 0; i < slotNumInBag; i++)//遍历背包物品列表
        {
            //生成Slot
            instance.slotList.Add(Instantiate(instance.emptySlot, instance.slotGrid.transform.position, Quaternion.identity, instance.slotGrid.transform));
            //赋予对应的id值
            instance.slotList[i].GetComponent<Slot>().slotID = i;
            //设置Slot状态
            instance.slotList[i].GetComponent<Slot>().SetupSlot(instance.myBag.bagList[i]);
        }
    }
}
