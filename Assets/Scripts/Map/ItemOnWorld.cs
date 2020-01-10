using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item item;
    public Bag bag_in;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //添加进列表
            AddItem();
        }
    }

    /// <summary>
    /// 添加物体方法
    /// </summary>
    void AddItem()
    {
        if (!bag_in.bagList.Contains(item))
        {//若果不包含
            //遍历寻找空的格子
            for (int i = 0; i < bag_in.bagList.Count; i++)
            {
                if (bag_in.bagList[i] == null)
                {//找到第一个空值
                    bag_in.bagList[i] = item;
                    //刷新列表
                    //删除物品
                    Destroy(gameObject);
                    return;
                }
            }
            //若没有找到空值
            BagIsFull();
        }
        else
        {//若包含
            item.itemCount++;
            //刷新列表
            //删除物品
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 背包已满
    /// </summary>
    void BagIsFull()
    {
        Debug.Log("The bag is full");
    }
}
