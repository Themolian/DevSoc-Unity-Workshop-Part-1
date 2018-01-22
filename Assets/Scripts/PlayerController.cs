using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	public float moveSpeed;
	private float activeMoveSpeed;
	public Rigidbody2D myRigidbody;

	public float jumpHeight;

	public bool isGrounded;

	private Animator myAnim;


	// Use this for initialization
	//When the object this script is on loads into the scene
	void Start () 
	{

		myRigidbody = GetComponent<Rigidbody2D>();
		myAnim = GetComponent<Animator>();
		activeMoveSpeed = moveSpeed;

	}
	
	// Update is called once per frame
	void Update () 
	{

			if(Input.GetAxisRaw ("Horizontal") > 0f)
			{

				myRigidbody.velocity = new Vector3(activeMoveSpeed, myRigidbody.velocity.y, 0f);
				transform.localScale = new Vector3(1f,1f,0f);

			} 
			
			else if(Input.GetAxisRaw ("Horizontal") < 0f)
			{

				myRigidbody.velocity = new Vector3(-activeMoveSpeed, myRigidbody.velocity.y, 0f);
				transform.localScale = new Vector3(-1f,1f,0f);

			}
			else
			{

				myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f);

			}

			if(Input.GetButtonDown ("Jump") && isGrounded == true)
			{
				myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpHeight, 0f);
				isGrounded = false;

			}


			myAnim.SetFloat("Speed", Mathf.Abs(myRigidbody.velocity.x) );
			// myAnim.SetBool("Grounded", isGrounded);
	}

			private void OnCollisionEnter2D(Collision2D other)
			{

				if(other.gameObject.tag == "Ground")
				{

					isGrounded = true;

				}

			}

}
