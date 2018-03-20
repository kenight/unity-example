using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardDraggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public Transform parentToReturn;

    // 拖拽时，创建一个空物体作为占位符，实现后续交换卡牌等逻辑
    GameObject placeHolder;

    public void OnBeginDrag(PointerEventData e) {
        // 记录本来的父级，如果没有 Drop 到其他位置，则释放时回到本来的父级下
        parentToReturn = transform.parent;
        // 创建占位物体
        CreatePlaceHolder();
        // 开始拖拽后，将物体置于本层级之上
        transform.SetParent(parentToReturn.parent);
        // 开始拖拽后，忽略射线检测。如果没有其他子物体可以使用 GetComponent<Image>().raycastTarget = false 
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData e) {
        transform.position = e.position;
    }

    public void OnEndDrag(PointerEventData e) {
        transform.SetParent(parentToReturn);
        transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        // 完成时，删除占位符
        Destroy(placeHolder);
    }

    void CreatePlaceHolder() {
        placeHolder = new GameObject();
        placeHolder.name = "PlaceHolder";
        RectTransform rectTransform = placeHolder.AddComponent<RectTransform>();
        rectTransform.sizeDelta = GetComponent<RectTransform>().sizeDelta;
        placeHolder.transform.SetParent(parentToReturn);
        placeHolder.transform.SetSiblingIndex(transform.GetSiblingIndex());
    }

}