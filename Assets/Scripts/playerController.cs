using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class playerController : MonoBehaviour
{
	// Create public variables for player speed, and for the Text UI game objects
	public float speed;
	public int maxHealth = 5;
	public int currentHealth;
	public Text healthTxt;
	public Text WinText;
	public Text TimeText;
	private float movementX;
	private float movementY;
	private Rigidbody rb;

	// At the start of the game..
	void Start()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();
		//start at max health
		currentHealth = 5;
	}
	void FixedUpdate()
	{
		// Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
		Vector3 movement = new Vector3(movementX, 0.0f, movementY);
		rb.AddForce(movement * speed); 	
	}
	void Update()
    {
		//check health
		if(currentHealth <=0)
        {
			Application.LoadLevel("play area");
        }
		//update health
		healthTxt.text = "Health: " + currentHealth;
    }
	void OnMove(InputValue value)
	{
		Vector2 v = value.Get<Vector2>();

		movementX = v.x;
		movementY = v.y;
	}
	private void OnCollisionEnter (Collision collision)
    {
	if (collision.collider.gameObject.CompareTag("Wall"))
        {
			currentHealth -= 1;
		}
		if (collision.collider.gameObject.CompareTag("Finish"))
		{
			WinText.text = "WIN!!!";
			TimeText.text = "Time: " + Time.timeSinceLevelLoad + " seconds";
		}
	}
}