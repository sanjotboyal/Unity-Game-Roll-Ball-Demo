using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float speed;
	public Text gameScore;

	private Rigidbody rb;

	private int points;


	void Start(){
		rb = GetComponent<Rigidbody> ();
		points = 0;
		setScore ();

	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);

			if (other.GetComponent<MeshRenderer>().material.color == new Color (0, 0, 1, 1)) {
				points += 3;
			}


			else if (other.GetComponent<MeshRenderer>().material.color == new Color (0, 0, 0, 1)) {
				points += 2;
			}

			else if (other.GetComponent<MeshRenderer>().material.color == new Color (0, 1, 0, 1)) {
				points += 1;
			}

			setScore ();

		}
	}

	void setScore(){
		gameScore.text = "Score: " + points.ToString ();
	}

}
