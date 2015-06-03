using UnityEngine;
using System.Collections;

public class SpaceToContinue : MonoBehaviour {
	public string scene;
	
	private bool loadLock;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Jump") && !loadLock)
			LoadScene ();
	}
	
	void LoadScene(){
		loadLock = true;
		Application.LoadLevel (scene);
	}
}
