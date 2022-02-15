using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CardScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    Animator animator;

    Transform rootParent;
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(this.transform.parent.parent.name != "Tabletop")
        {
            animator.SetTrigger("Active");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        if (this.transform.parent.parent.name != "Tabletop")
        {
            animator.SetTrigger("Back Active");
        }


    }
}