using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
{
    // Dropped card's return spot.
    public Transform parentToReturn = null;

    // Placeholder for the selected card.
    GameObject placeholder = null;

    public Transform placeholderParent = null;

    Animator animator;

    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
 
    }
    void Update()
    {
        
    }

    
    public void OnBeginDrag(PointerEventData eventData) 
    {

        placeholder = new GameObject();
        placeholder.transform.SetParent(this.transform.parent);
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleWidth = 0;
        le.flexibleHeight = 0;

        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        parentToReturn = this.transform.parent;
        placeholderParent = parentToReturn;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log ("OnDrag");

        this.transform.position = eventData.position;

        if (placeholder.transform.parent != placeholderParent)
            placeholder.transform.SetParent(placeholderParent);

        int newSiblingIndex = placeholderParent.childCount;

        for (int i = 0; i < placeholderParent.childCount; i++)
        {
            if (this.transform.position.x < placeholderParent.GetChild(i).position.x)
            {

                newSiblingIndex = i;

                if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                    newSiblingIndex--;

                break;
            }
        }

        placeholder.transform.SetSiblingIndex(newSiblingIndex);

    }

    public void OnEndDrag(PointerEventData eventData)
    {

        this.transform.SetParent(parentToReturn);
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        animator.SetTrigger("Drop Active");
      

        GetComponent<CanvasGroup>().blocksRaycasts = true;

        Destroy(placeholder);

    }
}
