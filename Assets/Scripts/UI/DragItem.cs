using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform originalParent;
    public Bag myBag;
    int startItemId;//起始物体的列表位置索引

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;//Slot级别
        startItemId = originalParent.GetComponent<Slot>().slotID;
        transform.SetParent(transform.parent.parent);
        transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject mouseOnObject = eventData.pointerCurrentRaycast.gameObject;

        if (mouseOnObject != null)
        {
            if (mouseOnObject.name == "Item Image")
            {
                //变量
                Transform itemRank = mouseOnObject.transform.parent;
                Transform slotRank = itemRank.parent;
                var tempVar = myBag.bagList[startItemId];
                int endItemId = mouseOnObject.GetComponent<Slot>().slotID;

                //被拖动物体的操作
                transform.SetParent(slotRank);
                transform.position = slotRank.position;

                //列表操作
                myBag.bagList[startItemId] = myBag.bagList[endItemId];
                myBag.bagList[endItemId] = tempVar;

                //拖动到达位置物体的操作
                itemRank.SetParent(originalParent);
                itemRank.position = originalParent.position;
            }
            else if (mouseOnObject.name == "Slot(Clone)")
            {
                Transform slotRank = mouseOnObject.transform;
                int endSlotId = mouseOnObject.GetComponent<Slot>().slotID;

                //被拖动物体的操作
                transform.SetParent(slotRank);
                transform.position = slotRank.position;

                //列表的操作
                myBag.bagList[endSlotId] = myBag.bagList[startItemId];

                //到达位置物体的操作
                if (endSlotId != startItemId)
                {
                    myBag.bagList[startItemId] = null;
                }
            }
            else
            {
                //恢复原位置状态
                transform.SetParent(originalParent);
                transform.position = originalParent.position;
            }

            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }
        else
        {
            //恢复原位置状态
            transform.SetParent(originalParent);
            transform.position = originalParent.position;

            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }
}
