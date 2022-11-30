using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDropHandler : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField] private Canvas canvas;

    public string answer;
    public RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public Vector2 InitialPosition;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        InitialPosition = rectTransform.anchoredPosition;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(canvas.renderMode == RenderMode.ScreenSpaceOverlay){
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }else{
            rectTransform.position = eventData.pointerCurrentRaycast.worldPosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        rectTransform.anchoredPosition = InitialPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }
}
