using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColocarDispositivo : MonoBehaviour
{
	public Slider slider;
	public GameObject dispositivo;
	// Start is called before the first frame update
	void Start()
    {
		//slider = GetComponent<Slider>();

	}

	private void OnTriggerEnter(Collider other)
	{
		if (slider.value == slider.maxValue)
		{
			if (other.tag == "leftHand")
			{
				dispositivo.SetActive(true);
				this.gameObject.SetActive(false);
			}


		}
	}
}
