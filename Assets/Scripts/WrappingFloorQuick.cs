using UnityEngine;
using System.Collections;

public class WrappingFloorQuick : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.name == "Player") {
			StartCoroutine(StableWait());
		}
	}
	
	IEnumerator StableWait(){
		yield return new WaitForSeconds (0.3f);
		Destroy (gameObject);
		//print ("in");
	}
}
