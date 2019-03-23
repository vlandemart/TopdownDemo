using UnityEngine;

public class Pickupable : MonoBehaviour, IInteractable
{
	protected Player player;
	private bool interacted = false;

	private void OnTriggerEnter(Collider col)
	{
		if (interacted)
			return;

		player = col.GetComponent<Player>();
		if (player != null)
			AddInteractable();
	}

	private void OnTriggerExit()
	{
		if (player != null && interacted)
			RemoveInteractable();
	}

	public void AddInteractable()
	{
		interacted = true;
		player.Interactable = this;
		HUDManager.Instance.SetInteractableText("Press E to pick up " + gameObject.name);
	}

	public void RemoveInteractable()
	{
		interacted = false;
		player.Interactable = null;
		HUDManager.Instance.HideInteractableText();
	}

	public virtual void Interact()
	{
		Debug.Log("Interacted with " + gameObject.name);
		RemoveInteractable();
	}
}
