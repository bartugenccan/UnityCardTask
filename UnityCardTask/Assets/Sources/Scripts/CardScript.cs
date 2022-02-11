using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CardScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    Animator animator;

    void Start()
    {
        animator = this.GetComponent<Animator>();
      
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetTrigger("Active");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetTrigger("Back Active");

    }
}