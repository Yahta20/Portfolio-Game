using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBehaviour : MonoBehaviour
{
    public GameObject play;
    public GameObject pause;
    public GameObject over;
	public GameObject editor;
	public GameObject start;

	public GameManager gm;
    private GameState currentgamestate;

    // Start is called before the first frame update
    void Start()
    {
       
        gm =  GameObject.Find("GameManager").GetComponent(typeof(GameManager)) as GameManager;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentgamestate =  gm.getCurrentState();
		switch (currentgamestate)
		{
		
			case (GameState.play):
				DisableAll();
				play.SetActive(true);
				break;
			case (GameState.win):
				DisableAll();
				pause.SetActive(true);
				break;
			case (GameState.over):
				DisableAll();
				over.SetActive(true);
				break;
			case (GameState.start):
				DisableAll();
				start.SetActive(true);
				break;
			case (GameState.editor):
				DisableAll();
				editor.SetActive(true);
				break;
		}
	}
	private void DisableAll() {
		play.SetActive(false);
		pause.SetActive(false);
		over.SetActive(false);
		editor.SetActive(false);
		start.SetActive(false);

	}
}
