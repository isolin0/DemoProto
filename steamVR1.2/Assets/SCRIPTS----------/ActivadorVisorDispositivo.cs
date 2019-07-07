using UnityEngine;
using UnityEngine.UI;


public class ActivadorVisorDispositivo : MonoBehaviour
{
	


	//mi agregado

	public Camera cam;
	//public Light[] lightsSegundoPlano;
	//public Light[] lightsDispositivo;
	public GameObject conDisp;

	private bool pressed;

	int standerMask;

	private void Start()
	{
		pressed = false;
		standerMask = cam.cullingMask;
	}

	private void OnTriggerEnter(Collider other)
	{

		if (other.tag == "IndexR" && !pressed )
		{
			//Debug.Log("Presion de index en boton");
			pressed = true;
			cam.cullingMask = (1 << 0) | (1 << 8);
			conDisp.SetActive(true);

			/*foreach (var light in lightsSegundoPlano)
			{
				light.gameObject.SetActive(true);
			}
			foreach (var light_ in lightsDispositivo)
			{
				light_.gameObject.SetActive(false);
			}*/
		}else if (other.tag == "IndexR" && pressed)
		{

			pressed = false;
			cam.cullingMask = standerMask;
			conDisp.SetActive(false);
			/*foreach (var light in lightsSegundoPlano)
			{
				light.gameObject.SetActive(false);
			}
			foreach (var light_ in lightsDispositivo)
			{
				light_.gameObject.SetActive(true);
			}*/
		}

	}
}
