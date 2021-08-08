using UnityEngine;
using System.Collections;

public class ExtendedFlycam : MonoBehaviour
{

	public float cameraSensitivity = 90;
	public float climbSpeed = 4;
	public float MoveSpeed = 10;

	private float rotationX = 0.0f;
	private float rotationY = 0.0f;

	void Update()
	{
        if (Input.GetMouseButtonDown(1))
			Cursor.lockState = CursorLockMode.Locked;

		if (Input.GetMouseButtonUp(1))
			Cursor.lockState = CursorLockMode.None;

		if (Input.GetMouseButton(1))
		{
			rotationX += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
			rotationY += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
			rotationY = Mathf.Clamp(rotationY, -90, 90);

			transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
			transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);

			transform.position += transform.forward * MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
			transform.position += transform.right * MoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;


			if (Input.GetKey(KeyCode.E)) { transform.position += transform.up * climbSpeed * Time.deltaTime; }
			if (Input.GetKey(KeyCode.Q)) { transform.position -= transform.up * climbSpeed * Time.deltaTime; }
		}
	}
}