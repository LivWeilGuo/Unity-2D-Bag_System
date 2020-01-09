using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    //组件
    public GameObject myBag;

    private void Update()
    {
        OPressed();
    }

    /// <summary>
    /// "O"键功能:
    /// 背包菜单
    /// </summary>
    void OPressed()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            ChangeMyBag();
        }
    }

    /// <summary>
    /// 改变背包状态
    /// </summary>
    public void ChangeMyBag()
    {
        myBag.SetActive(!myBag.activeSelf);
    }
}
