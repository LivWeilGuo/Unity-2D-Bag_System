using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "InventorySystem/Goods/Equipment")]
public class Equipment : Item
{
    //装备属性
    public float attackValue;//攻击
    public float defenceValue;//防御
    public float strengthValue;//力量
    public float agileValue;//敏捷
    public float intelligenceValue;//智力
    public float[] resistanceValue = new float[5];//抗性种类
}
