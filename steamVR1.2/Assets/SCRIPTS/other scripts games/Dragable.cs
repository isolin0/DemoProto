//Isolino
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Dragable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	Vector3 startPosition;


	
	public void OnBeginDrag(PointerEventData eventData)
	{


		startPosition = transform.position;
	}


	public void OnDrag(PointerEventData eventData)
	{
		
		transform.position = eventData.position;
	}


	
	public void OnEndDrag(PointerEventData eventData)
	{
		

		if (startPosition != transform.position)
		{
			
			this.GetComponent<ItemPickUp>().OnClick();
			Destroy(gameObject);
		}

	}

}