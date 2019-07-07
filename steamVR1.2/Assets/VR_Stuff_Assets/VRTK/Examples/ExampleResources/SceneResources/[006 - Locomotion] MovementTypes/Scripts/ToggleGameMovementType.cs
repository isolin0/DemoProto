namespace VRTK.Examples
{
	using UnityEngine;
	using UnityEngine.UI;
	using VRTK.Controllables;

	public class ToggleGameMovementType : MonoBehaviour
	{
		public VRTK_BaseControllable controllable;
		public Text displayText;
		public Text descriptionText;
		public GameObject toggleMoveInPlace;
		public GameObject toggleTeleport;
		public GameObject toggleBoolean;

		public string onText = "On";
		public string offText = "Off";
		public string description = "";

		protected VRTK_InteractableObject io;

		private void Start()
		{
			toggleBoolean.GetComponent<SetPointer>();
		}
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
			ToggleTeleport(false);
			ToggleBoolean(false);
			ToggleMoveInPlace(true);
			UpdateText(onText);

		}

		protected virtual void MaxLimitReached(object sender, ControllableEventArgs e)
		{
			

			ToggleTeleport(true);
			ToggleBoolean(true);
			ToggleMoveInPlace(false);
			UpdateText(offText);

		}

		protected virtual void InteractableObjectTouched(object sender, InteractableObjectEventArgs e)
		{
			if (descriptionText != null)
			{
				descriptionText.text = description;
			}
		}


		protected virtual void ToggleMoveInPlace(bool state)
		{
			if (toggleMoveInPlace != null)
			{
				toggleMoveInPlace.SetActive(state);
			}
		

		}

		protected virtual void ToggleBoolean(bool state)
		{
			if (toggleBoolean != null)
			{
				toggleBoolean.SendMessage("PointerState", state);
			}
		}

		protected virtual void ToggleTeleport(bool state)
		{
			if (toggleTeleport != null)
			{
				toggleTeleport.SetActive(state);
			}
			
			
		}

		protected virtual void UpdateText(string text)
		{
			if (displayText != null)
			{
				displayText.text = text;
			}
		}
	}
}
