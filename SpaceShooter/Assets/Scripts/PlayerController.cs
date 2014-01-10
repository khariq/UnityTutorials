using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundry
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour 
{
	public float Speed;
	public Boundry boundry;
	public float tilt;

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = movement * Speed;

		rigidbody.position = new Vector3(
			Mathf.Clamp(rigidbody.position.x, boundry.xMin, boundry.xMax), 
			0.0f,
			Mathf.Clamp(rigidbody.position.z, boundry.zMin, boundry.zMax)
		);

		rigidbody.rotation = Quaternion.Euler(x: 0.0f, y: 0.0f, z: rigidbody.velocity.x * (-1 * tilt));

	}

	public GameObject shot;
	public Transform shotSpawn;

	public float fireRate = 0.5f;
	public float nextFire = 0.0f;

	void Update()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(original: shot, position: shotSpawn.position, rotation: shotSpawn.rotation);
		}
	}
}
