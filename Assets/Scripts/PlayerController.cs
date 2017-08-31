using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/**
 * PlayerController : MonoBehaviour - controls movement and collection of points by player
 */
public class PlayerController : MonoBehaviour {
	private Rigidbody rb;	//rigidbody container
	private int count; 		//point counter

	public float speed; 	//variable player speed
	public Text countText; 	//text displaying current score
	public Text winText;	//text displaying win scenario

	/**
	 * Start - initializes game variables
	 */
	void Start(){
		rb = GetComponent<Rigidbody> ();
		count = 0;
		winText.text = "";
		SetCountText ();
	}

	/**
	 * FixedUpdate - Called every frame; add direction + speed to players position
	 */
	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal"); 	//left and right keys
		float moveVertical = Input.GetAxis ("Vertical");  		//up and down keys

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical); //apply player input to vector
		rb.AddForce (movement * speed); //apply vector to player position
	}

	/**
	 * OnTriggerEnter - called by trigger colliders when colliding; when player touches pickup object then collect it
	 */
	void OnTriggerEnter(Collider other) {

		//set prefab "Pickup" to also have a tag of the same name
		if (other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
		}
	}

	/**
	 * SetCountText - update the score counter, or let user know they have won
	 */
	void SetCountText(){
		countText.text = "Count: " + count.ToString ();

		if (count >= 8) {
			winText.text = "You win!";
		}
	}
}
