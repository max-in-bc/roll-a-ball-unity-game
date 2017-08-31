using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject player;
	private Vector3 offset;


	/**
	 * Start - initializes camera position 
	 */
	void Start () {
		offset = transform.position - player.transform.position;
	}

	/**
	 * LateUpdate - Update is called once per frame; LateUpdate is called after Update() is finished processing
	 *	Note: This was done so that the camera does not roll with player
	 */
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
