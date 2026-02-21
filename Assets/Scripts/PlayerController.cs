using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	private Rigidbody rb;
	private float movementX;
	private float movementY;
	public int speed = 1;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		// left
		if( Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) )
		{
			Vector3 pos = this.transform.position;
			pos.x -= speed * Time.deltaTime;
			this.transform.position = pos;
		}
		// right
		if( Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) )
		{
			Vector3 pos = this.transform.position;
			pos.x += speed * Time.deltaTime;
			this.transform.position = pos;
		}
		// up
		if( Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) )
		{
			Vector3 pos = this.transform.position;
			pos.z += speed * Time.deltaTime;
			this.transform.position = pos;
		}
		// down
		if( Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) )
		{
			Vector3 pos = this.transform.position;
			pos.z -= speed * Time.deltaTime;
			this.transform.position = pos;
		}
	}

	// Update is called once per frame
	// void Update()
	// {
	// }
}
