using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class outline_left : MonoBehaviour ,IBeginDragHandler,IEndDragHandler,IDragHandler{

    private Vector3 targetScreenPoint;

    private Vector3 pos;




    void Start()
    {
        //Vector3 pos_a = new Vector3(0, gameObject.GetComponent<basicgenerate>().height, gameObject.GetComponent<basicgenerate>().depth);
        //gameObject.transform.position = new Vector3( Camera.main.WorldToScreenPoint(pos_a).x,Camera.main.WorldToScreenPoint(pos_a).y,Camera.main.WorldToScreenPoint(pos_a).z);
    

        gameObject.GetComponent<Transform>().position = new Vector3(0, gameObject.GetComponent<basicgenerate>().height, gameObject.GetComponent<basicgenerate>().depth);
   
    
    }


    public void OnBeginDrag(PointerEventData eventData)
    {

     
        targetScreenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
       
        //target.transform.parent = GameObject.Find("Canvas").transform;

    }

    void Update()
    {

    }

    public void OnDrag(PointerEventData eventData)
    {

       
        pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenPoint.z));
        gameObject.transform.position = pos;
       

    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }
}

