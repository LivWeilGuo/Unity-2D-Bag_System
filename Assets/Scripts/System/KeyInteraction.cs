using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    //组件
    public GameObject myBag;
    public GameObject mainMenu;

    private void Update()
    {
        OnePressed();
    }

    /// <summary>
    /// "O"键功能:
    /// 背包菜单
    /// </summary>
    void OnePressed()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            ChangeActiveState(mainMenu);
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            ChangeActiveState(myBag);
            if (myBag.activeSelf)
            {
                BagManager.RefreshItem();
            }
        }
    }

    /// <summary>
    /// 改变背包状态
    /// </summary>
    public void ChangeActiveState(GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeSelf);
        if (!gameObject.activeSelf)
        {
            Time.timeScale = 1f;
        }
    }
}
