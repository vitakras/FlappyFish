using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float float_up_speed = 0;
	public float swim_down_speed = 0;
	public float touchDeadZone = 3F;

	[HideInInspector]
	public bool above_water = false;

	//For Swimming
	private float swimTimeLimit = 0.2f; // how long the player will swim down for
	private float floatCountDown = 0;
	private Vector2 initTouch;
	private Animation anim;

	void Awake () {
		anim = gameObject.GetComponentInChildren<Animation>();
	}

	// Update is called once per frame
	void Update () {
		this.floatCountDown -= Time.deltaTime; 

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
			this.initTouch = Input.GetTouch(0).position;
		} else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
			floatCountDown = swimTimeLimit;
			if (this.above_water && (Input.touchCount > 0) && (this.initTouch.x-Input.GetTouch(0).position.x) >= touchDeadZone){
				anim.Play ();
			}
		} else if (Input.GetMouseButton(0)) {
			floatCountDown = swimTimeLimit;
		} else if (Input.GetKey(KeyCode.Space) &&  this.above_water){
			anim.Play ();
		} 

		//Swimming Up or Down
		if (floatCountDown > 0) {
			transform.Translate(Vector3.down* this.swim_down_speed * Time.deltaTime);
		} else {
			if (!above_water) {
				transform.Translate(Vector3.up * this.float_up_speed * Time.deltaTime);
			}
		}
	}

	public void setFloatCountDown(float time) {
		this.floatCountDown = time;
	}
}
