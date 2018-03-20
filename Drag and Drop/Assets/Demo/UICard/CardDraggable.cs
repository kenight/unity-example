using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardDraggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public GameObject placeHolderPrefab;

    // 拖拽时，创建一个占位符，占位符的位置即卡牌的新位置
    [HideInInspector]
    public Transform placeHolder;

    public void OnBeginDrag(PointerEventData e) {
        // 创建 placeHolder
        CreatePlaceHolder();
        // 开始拖拽后，将物体置于本层级之上
        transform.SetParent(placeHolder.parent.parent);
        // 开始拖拽后，忽略射线检测。如果没有其他子物体可以使用 GetComponent<Image>().raycastTarget = false 
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData e) {
        transform.position = e.position;

        // 判断拖拽中的卡牌的坐标是否超过哪个子物体的坐标
        // 如果超过，则取代它的 SiblingIndex 到达交互的效果
        for (int i = 0; i < placeHolder.parent.childCount; i++) {
            if (transform.position.x - 75 < placeHolder.parent.GetChild(i).transform.position.x) {
                placeHolder.SetSiblingIndex(i);
                break;
            }
        }
    }

    public void OnEndDrag(PointerEventData e) {
        transform.SetParent(placeHolder.parent);
        transform.SetSiblingIndex(placeHolder.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        // 完成时，删除占位符
        Destroy(placeHolder.gameObject);
    }

    void CreatePlaceHolder() {
        placeHolder = Instantiate(placeHolderPrefab).transform;
        // placeHolder = new GameObject();
        // placeHolder.name = "PlaceHolder";
        // RectTransform rectTransform = placeHolder.AddComponent<RectTransform>();
        // rectTransform.sizeDelta = GetComponent<RectTransform>().sizeDelta;
        placeHolder.SetSiblingIndex(transform.GetSiblingIndex());
        placeHolder.SetParent(transform.parent);
    }

}