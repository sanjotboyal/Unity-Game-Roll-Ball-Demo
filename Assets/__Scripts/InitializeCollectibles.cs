using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeCollectibles : MonoBehaviour {

	public GameObject prefabCollectible;
	public int numCollectibles;
	private int radius; 

	// Use this for initialization
	void Start () {
		radius = 6;

		System.Random rand = new System.Random();
		Color[] arraySelection = {new Color(0,0,1,1),new Color(0,0,0,1),new Color(0,1,0,1)};

		for (int i = 0; i < numCollectibles; i++) {
			
			float angle = i * Mathf.PI * 2 / numCollectibles;
			Vector3 pos = new Vector3(Mathf.Cos(angle) *radius, 1, Mathf.Sin(angle)*radius);
			GameObject collectibleGenerated = Instantiate(prefabCollectible,pos,Quaternion.identity);

			int ranChose = rand.Next (3);
			Color ranColor = arraySelection [ranChose];

			collectibleGenerated.GetComponent<MeshRenderer>().material.color = ranColor;

		}
	}

}
