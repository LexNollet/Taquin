using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Animations;

public class TileDrag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public int tileNum;
    public int currentSlot;
    private PositionConstraint posConstraint;
    private ConstraintSource con1, con2, con3, con4, con5, con6, con7, con8, con9;

    private Vector2 tempPos;

    public void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();

        posConstraint = GetComponent<PositionConstraint>();
        con1 = posConstraint.GetSource(0);
        con2 = posConstraint.GetSource(1);
        con3 = posConstraint.GetSource(2);
        con4 = posConstraint.GetSource(3);
        con5 = posConstraint.GetSource(4);
        con6 = posConstraint.GetSource(5);
        con7 = posConstraint.GetSource(6);
        con8 = posConstraint.GetSource(7);
        con9 = posConstraint.GetSource(8);
    }

    //Function that locks the tile's movements depending on the current empty slot
    public void TileLock(int slotNum)
    {
        int empty = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().currentEmpty;
        
        //Slot n°0 is an incorrect position
        if (slotNum == 0)
        {
            slotNum = currentSlot;
            this.rectTransform.anchoredPosition = tempPos;
        }
        
        if (slotNum != currentSlot)
        {
            empty = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().currentEmpty = currentSlot;
            currentSlot = slotNum;
        }
        

        con1.weight = con2.weight = con3.weight = con4.weight = con5.weight = con6.weight = con7.weight = con8.weight = con9.weight = 0;

        switch (slotNum)
        {
            case 1:
                con1.weight = 1;
                if (empty == 2)
                    posConstraint.translationAxis = Axis.Y | Axis.Z;
                else if (empty == 4)
                    posConstraint.translationAxis = Axis.X | Axis.Z;
                else
                    posConstraint.translationAxis = Axis.X | Axis.Y | Axis.Z;
                break;
            case 2:
                con2.weight = 1;
                if (empty == 1 || empty == 3)
                    posConstraint.translationAxis = Axis.Y | Axis.Z;
                else if (empty == 5)
                    posConstraint.translationAxis = Axis.X | Axis.Z;
                else
                    posConstraint.translationAxis = Axis.X | Axis.Y | Axis.Z;
                break;
            case 3:
                con3.weight = 1;
                if (empty == 2)
                    posConstraint.translationAxis = Axis.Y | Axis.Z;
                else if (empty == 6)
                    posConstraint.translationAxis = Axis.X | Axis.Z;
                else
                    posConstraint.translationAxis = Axis.X | Axis.Y | Axis.Z;
                break;
            case 4:
                if (empty == 5)
                    posConstraint.translationAxis = Axis.Y | Axis.Z;
                else if (empty == 1 || empty == 7)
                    posConstraint.translationAxis = Axis.X | Axis.Z;
                else
                    posConstraint.translationAxis = Axis.X | Axis.Y | Axis.Z;
                con4.weight = 1;
                break;
            case 5:
                if (empty == 4 || empty == 6)
                    posConstraint.translationAxis = Axis.Y | Axis.Z;
                else if (empty == 2 || empty == 8)
                    posConstraint.translationAxis = Axis.X | Axis.Z;
                else
                    posConstraint.translationAxis = Axis.X | Axis.Y | Axis.Z;
                con5.weight = 1;
                break;
            case 6:
                if (empty == 5)
                    posConstraint.translationAxis = Axis.Y | Axis.Z;
                else if (empty == 3 || empty == 9)
                    posConstraint.translationAxis = Axis.X | Axis.Z;
                else
                    posConstraint.translationAxis = Axis.X | Axis.Y | Axis.Z;
                con6.weight = 1;
                break;
            case 7:
                if (empty == 8)
                    posConstraint.translationAxis = Axis.Y | Axis.Z;
                else if (empty == 4)
                    posConstraint.translationAxis = Axis.X | Axis.Z;
                else
                    posConstraint.translationAxis = Axis.X | Axis.Y | Axis.Z;
                con7.weight = 1;
                break;
            case 8:
                if (empty == 7 || empty == 9)
                    posConstraint.translationAxis = Axis.Y | Axis.Z;
                else if (empty == 5)
                    posConstraint.translationAxis = Axis.X | Axis.Z;
                else
                    posConstraint.translationAxis = Axis.X | Axis.Y | Axis.Z;
                con8.weight = 1;
                break;
            case 9:
                if (empty == 8)
                    posConstraint.translationAxis = Axis.Y | Axis.Z;
                else if (empty == 6)
                    posConstraint.translationAxis = Axis.X | Axis.Z;
                else
                    posConstraint.translationAxis = Axis.X | Axis.Y | Axis.Z;
                con9.weight = 1;
                break;
            default:
                Debug.Log("slotNum Error");
                break;
        }

        posConstraint.SetSource(0, con1);
        posConstraint.SetSource(1, con2);
        posConstraint.SetSource(2, con3);
        posConstraint.SetSource(3, con4);
        posConstraint.SetSource(4, con5);
        posConstraint.SetSource(5, con6);
        posConstraint.SetSource(6, con7);
        posConstraint.SetSource(7, con8);
        posConstraint.SetSource(8, con9);

        posConstraint.constraintActive = true;

        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().checkVictory();
    }



    //Functions to drag and drop the tile
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Event Triggered: OnBeginDrag");
        canvasGroup.blocksRaycasts = false;
        TileLock(currentSlot);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Event Triggered: OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Event Triggered: OnEndDrag");
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Event Triggered: OnPointerDown");
        tempPos = this.rectTransform.anchoredPosition;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Event Triggered: OnDrop on Tile " + tileNum);
        eventData.pointerDrag.GetComponent<TileDrag>().TileLock(0);
    }
}
