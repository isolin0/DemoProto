namespace VRTK.Examples
{
	using UnityEngine;
	using UnityEngine.UI;
	using VRTK.Controllables;

	public class ToogleLights : MonoBehaviour
	{
		public VRTK_BaseControllable controllable;
		
		public GameObject toggleObject;
		public bool minL;
		public bool maxL;
		

		protected VRTK_InteractableObject io;

		protected virtual void OnEnable()
		{
			if (controllable != null)
			{
				controllable.MaxLimitReached += MaxLimitReached;
				controllable.MinLimitReached += MinLimitReached;
			}
			Invoke("SetupIOListeners", 0.1f);
		}

		protected virtual void OnDisable()
		{
			if (controllable != null)
			{
				controllable.MaxLimitReached -= MaxLimitReached;
				controllable.MinLimitReached -= MinLimitReached;
			}

			if (io != null)
			{
				io.InteractableObjectTouched -= InteractableObjectTouched;
			}
		}

		protected virtual void SetupIOListeners()
		{
			io = controllable.GetComponentInParent<VRTK_InteractableObject>();
			if (io != null)
			{
				io.InteractableObjectTouched += InteractableObjectTouched;
			}
		}

		protected virtual void MinLimitReached(object sender, ControllableEventArgs e)
		{
			ToggleObject(minL);
			
		}

		protected virtual void MaxLimitReached(object sender, ControllableEventArgs e)
		{
			ToggleObject(maxL);
			
		}

		protected virtual void InteractableObjectTouched(object sender, InteractableObjectEventArgs e)
		{
			
			
		}


		protected virtual void ToggleObject(bool state)
		{
			if (toggleObject != null)
			{
				toggleObject.SetActive(state);
			}
		}

	
	}
}
