using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
	public Vector3 MoveVector = Vector3.zero;
	[SerializeField]
	private float moveSpeed = 5f;
	private Rigidbody myRB = null;

	private void Start()
	{
		myRB = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		Move();
		Rotate();
	}

	private void Move()
	{
		Vector3 movePos = MoveVector * moveSpeed * Time.deltaTime;
		myRB.MovePosition(myRB.position + movePos);
	}

	private void Rotate()
	{
		Plane plane = new Plane(Vector3.up, transform.position);
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		float hitDistance = 0;
		if (plane.Raycast(ray, out hitDistance))
		{
			Vector3 targetPos = ray.GetPoint(hitDistance);
			Quaternion targetRot = Quaternion.LookRotation(targetPos - transform.position);
			transform.rotation = targetRot;
		}
	}
}
