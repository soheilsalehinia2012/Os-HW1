using UnityEngine;
using System.Collections;

public class ExitLevelDoor : MonoBehaviour {

	public Key key;
	public bool OnKey = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (key && OnKey) {
			if(key.GetDown()){
				OnOpen();
			}
		}
	}

	void OnOpen(){
		Destroy (gameObject);
	}
}
