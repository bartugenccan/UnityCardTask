using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        if (eventData.pointerDrag == null)
        {
            return;
        }

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();

        if (d != null)
        {
            d.placeholderParent = this.transform;
           
        }

        //Cards no longer go up in Tabletop 
        if(GameObject.Find("/CardParent/Card") || GameObject.Find("/CardParent (1)/Card") || GameObject.Find("/CardParent (2)/Card"))
        {
            animator.enabled = false;
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {

        if (eventData.pointerDrag == null)
        {
            return;
        }

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();

        if (d != null && d.placeholderParent == this.transform)
        {
            d.placeholderParent = d.parentToReturn;
        }


    }
   public void OnDrop(PointerEventData eventData)
    {
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();

        if(d != null)
        {
            d.parentToReturn = this.transform;
        }

       
    }
}
