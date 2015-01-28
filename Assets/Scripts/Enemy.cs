using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float minHeight, maxHeight;
	public float speed;
	public bool isSimultaneous = false;
	public bool canFollowPlayer = false;
	public float minRange, maxRange;	

	public float killDistance = -15;

	private Transform player = null;

	void OnAwake() {
		if (canFollowPlayer) {
			player = GameObject.FindGameObjectWithTag("Player").transform;
		}
	}


	void Update () {
		transform.Translate(Vector3.left * speed * Time.deltaTime);
		if (transform.position.x <= this.killDistance){
			Destroy(gameObject);
		}

		if (this.canFollowPlayer && (this.minRange <= this.player.position.y && this.player.position.y <= this.maxRange)){
			//gameObject.transform.position.y = player.position.y;
		}
	}


}
