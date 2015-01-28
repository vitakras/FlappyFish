using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour {

	public  States initialState;
	private States current;

	private PlayerController playerControler;
	private GUITexture homeButton;
	private ScoreManager scoreManager = null;

	void Awake() {
		DontDestroyOnLoad(this);
		scoreManager = GameObject.FindGameObjectWithTag("GameManagers").GetComponent<ScoreManager>();
		setState(initialState);
	}

	public void setState(States state) {
		this.current = state;
		handler();
	}

	private void handler(){
		switch (current){
			case States.loadGame:
				Application.LoadLevel(1);
				break;
			case States.playGame:
				playerControler.setFloatCountDown(0);
				this.homeButton.enabled = false;
				Time.timeScale = 1F;
				break;
			case States.pauseGame:
				Time.timeScale = 0;
				playerControler.setFloatCountDown(0);
				this.homeButton.enabled = true;
				break;
			case States.loadMenu:
				scoreManager.resetScore();
				Application.LoadLevel(0);
				break;
			case States.mainMenu:
			break;
			case States.loseMenu:
				scoreManager.resetScore();
				setState(States.loadGame);
			break;
		}
	}

	void OnLevelWasLoaded(int level) {
		if (level == 1) {
			this.playerControler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
			this.homeButton = GameObject.FindGameObjectWithTag("HomeButton").guiTexture;
			setState(States.playGame);
		} else if (level == 0){
			setState (States.mainMenu);
		}
	}
}
