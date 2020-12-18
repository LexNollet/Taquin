using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Animations;

public class TileSlot : MonoBehaviour, IDropHandler
{
    public int slotNum;

    private void Start()
    {
        
    }

    //When tile is dropped, move the tile in the slot's position and lock its movements
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Event Triggered: OnDrop on Slot " + slotNum);

        if (slotNum == 0)
        {
            eventData.pointerDrag.GetComponent<TileDrag>().TileLock(slotNum);
        }
        else if (eventData.pointerDrag != null)
        {            
            eventData.pointerDrag.GetComponent<TileDrag>().TileLock(slotNum);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
        }
        
    }
}
