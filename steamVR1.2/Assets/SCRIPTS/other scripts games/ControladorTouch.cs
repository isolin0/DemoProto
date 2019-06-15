using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorTouch : MonoBehaviour {

    Ray ray;
    RaycastHit hit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            //ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                
            }

        }
        
    }

}
