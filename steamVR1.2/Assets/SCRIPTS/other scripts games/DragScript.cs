//Isolino
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragScript : MonoBehaviour {


	// un offset ayuda a que el objeto no tiemble al empezar a moverse
	float deltaX, deltaY;

	//referencia al rigidbody2d 
	Rigidbody2D rb;

	bool moveAllowed = false;

	void Start()
	{

		rb = GetComponent<Rigidbody2D>();


	}

	
	void Update()
	{
		
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			Vector2 touchPos = Camera.main.ScreenToViewportPoint(touch.position);

			switch (touch.phase)
			{
				case TouchPhase.Began:

					if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
					{
						//obteiene el offset entre la posicion que tocas
						//y el centro del game object
						deltaX = touchPos.x - transform.position.x;
						deltaY = touchPos.y - transform.position.y;

						moveAllowed = true;

						// restringe algunas propiedades del rigidbody para que el movimiento sea mas fluido
						//rb.freezeRotation = true;
						rb.velocity = new Vector2(0, 0);
						//rb.gravityScale = 0;


					}
					break;


				//mueves el dedo
				case TouchPhase.Moved:

					if(GetComponent<Collider2D>()== Physics2D.OverlapPoint(touchPos)&& moveAllowed)
						rb.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
					break;


				// cuando levantas el dedo
				case TouchPhase.Ended:

					//se restablesen los parametros
					moveAllowed = false;
					break;

					
			}
		}
		
	}
	
	
}