using UnityEngine;
using System.Collections;

public class SwitchTrap : MonoBehaviour {

	public Key[] key;
	//private float speed = 1f;
	//public Transform sightStart, sightEndLeft, sightEndRight;
	public bool OnKey = false;
	

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		for (int i=0 ; i < key.Length ; i++) {
			if (key[i] && OnKey) {
				if (key[i].GetDown ()) {
					StartCoroutine (StableWait ());
					
				}
			}
		}
	}

	IEnumerator StableWait(){
		yield return new WaitForSeconds (0.5f);
		Destroy (gameObject);
		//print ("in");
	}
		
		

}
