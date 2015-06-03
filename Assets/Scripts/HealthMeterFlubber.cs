using UnityEngine;
using System.Collections;

public class HealthMeterFlubber : MonoBehaviour {
	private float health = 3;
	private float maxHealth = 3;
	public Vector2 healthOffset = new Vector2(10, 10);
	private FlubberWalking rw;
	private Animator animator;
	public Texture2D bgTexture;
	public Texture2D healthBarTexture;
	public int iconWidth = 32;
	// Use this for initialization
	void Start () {
		rw = GetComponent<FlubberWalking> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (health == 0) {
			OnDead();
		}
	}
	
	void OnTriggerStay2D(Collider2D target){
		if (target.gameObject.tag == "DecHealth") {
			if(health > 0 && rw.unArmed == true){
				health --;
				rw.unArmed = false;
				StartCoroutine(Wait());
			}
		}
	}
	
	IEnumerator Wait(){
		animator.SetInteger ("AnimState" , 1);
		yield return new WaitForSeconds (5);
		rw.unArmed = true;
		animator.SetInteger ("AnimState" , 0);
		//print ("true");
	}
	
	void OnGUI(){
		var percent = Mathf.Clamp01 (health / maxHealth);
		
		
		DrawMeter (healthOffset.x, healthOffset.y, healthBarTexture, bgTexture, percent);
	}
	
	void DrawMeter(float x, float y, Texture2D texture, Texture2D background, float percent){
		var bgW = background.width;
		var bgH = background.height;
		
		GUI.DrawTexture (new Rect (x, y, bgW, bgH), background);
		
		var nW = ((bgW - iconWidth) * percent) + iconWidth;
		
		GUI.BeginGroup (new Rect (x, y, nW, bgH));
		GUI.DrawTexture (new Rect (0, 0, bgW, bgH), texture);
		GUI.EndGroup ();
		
		
	}
	
	void OnDead(){
		Destroy (gameObject);
		
		GameObject go = new GameObject ("SpaceToContinue");
		SpaceToContinue script = go.AddComponent<SpaceToContinue> ();
		script.scene = Application.loadedLevelName;
		go.AddComponent<DisplayRestartText> ();
	}
}
