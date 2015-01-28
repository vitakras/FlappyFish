using UnityEngine;
using System.Collections;

public class FishFood : MonoBehaviour {

	public float speed;
	public float killDistance = -15;

	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * speed * Time.deltaTime);
		if (transform.position.x <= this.killDistance){
			Destroy(gameObject);
		}
	}
}
