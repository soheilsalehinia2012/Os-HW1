using UnityEngine;
using System.Collections;

public class WrappingFloor : MonoBehaviour {

	public float sec = 2f;
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
		yield return new WaitForSeconds (sec);
		Destroy (gameObject);
		//print ("in");
	}
}
