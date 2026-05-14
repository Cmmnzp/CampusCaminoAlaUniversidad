using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public string currentBlock;

    public void OnDrop(PointerEventData eventData)
    {
        DraggableBlock block =
            eventData.pointerDrag.GetComponent<DraggableBlock>();

        if (block != null)
        {
            block.transform.SetParent(transform);

            RectTransform blockRect =
                block.GetComponent<RectTransform>();

            blockRect.anchoredPosition = Vector2.zero;

            currentBlock = block.blockID;
        }
    }
}