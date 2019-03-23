using UnityEngine;

public class CameraManager : MonoBehaviour
{
	[SerializeField]
	private Vector3 cameraOffset;
	[SerializeField]
	private Player player;

	private void Update()
	{
		if (player != null)
			transform.position = player.transform.position + cameraOffset;
	}

	[ContextMenu("Set camera offset")]
	private void SetOffset()
	{
		cameraOffset = transform.position;
	}

	[ContextMenu("Find player")]
	private void FindPlayer()
	{
		player = FindObjectOfType<Player>();
	}
}
