using UnityEngine;
using System.Collections;

public class FallingDead : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.name == "Player") {
			OnDead(target);
		}
	}

	void OnDead(Collider2D target){
		Destroy (target.gameObject);
			
		GameObject go = new GameObject ("SpaceToContinue");
		SpaceToContinue script = go.AddComponent<SpaceToContinue> ();
		script.scene = Application.loadedLevelName;
		go.AddComponent<DisplayRestartText> ();

	}
}
