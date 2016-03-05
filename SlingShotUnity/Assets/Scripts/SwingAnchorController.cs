using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class SwingAnchorController : MonoBehaviour, IPointerDownHandler {

    public void OnPointerDown(PointerEventData eventData)
    {
        print("Clicked anchor: " + name);
        GameObject.Find("Player").GetComponent<PlayerController>().AttachToSwingAnchor(this.GetComponent<Rigidbody2D>());
    }

}
