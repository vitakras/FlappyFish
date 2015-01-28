using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {
	
	public enum Type {
		PlayPause,
		Home,
		MenuPlay,
		sound
	}

	public Type buttonType;
	public Texture[] textures;
	public bool usesTextures = false;

	private GUITexture texture;
	private bool isActive = false;
	private StateManager stateManager = null;
	
	void Awake() {
		texture = gameObject.GetComponent<GUITexture>();
		stateManager = GameObject.FindGameObjectWithTag("GameManagers").GetComponent<StateManager>();
	}

	void OnMouseDown() {
		switch (this.buttonType) {
			case Type.PlayPause:
				if(isActive) {
					isActive = false;
					stateManager.setState(States.playGame);
				} else {
					isActive = true;
					stateManager.setState(States.pauseGame);
				}
				break;
	     	case Type.MenuPlay:
				stateManager.setState(States.loadGame);
				break;
			case Type.Home:
				stateManager.setState(States.loadMenu);
				break;
			case Type.sound:
				if(isActive) {
					isActive = false;
				} else {
					isActive = true;
				}
				break;
		}

		if (this.usesTextures) {
			if (this.isActive){
				texture.texture = textures[1];
			} else {
				texture.texture = textures[0];
			}
		}
	}

}
