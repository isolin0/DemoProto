using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderChargin : MonoBehaviour
{
	
	public Slider slider;
	public Text porcentajeText;
	public Text ReadyText;
	// Start is called before the first frame update
	void Start()
    {
		slider = GetComponent<Slider>();
		//porcentajeText = GetComponent<Text>();
    }

	public void TextUpdate(float value)
	{
		porcentajeText.text = "%" + Mathf.RoundToInt(value * 0.02f);
	}
	// Update is called once per frame
	void Update()
    {
		slider.value += 1 + Time.deltaTime;

		if (slider.value == slider.maxValue)
		{
			porcentajeText.gameObject.SetActive(false);
			ReadyText.gameObject.SetActive(true);

		}
    }
}
