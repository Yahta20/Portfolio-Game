using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public enum GameState {
	play = 0,
	pause = 1,
	start = 2,
	win = 3,
	over = 4,
	editor = 5
}
public class GameManager : MonoBehaviour
{

	public GameState currentState = GameState.start;
	
	public float speedOfEnemy	{ get; private set; }
	public float speedOfPlayer	{ get; private set; }
	public int score4Win		{ get; private set; }
	
	public int emountOfLife     { get; private set; }
	

	public float speedOfReload  { get; private set; }
	public float shotInterval	{ get; private set; }
	public int emountOfScore	{ get; private set; }


	
	private float timer;

	public int[] enemyScore = new int[3] { 1, 2, 3 };
	public int getenemyScore(int i) {
		return enemyScore[i];
	}
	
	[Space]
	public GameObject player;
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;

	public PlayerBehaviour playerBihevior;
	public EnemyBehevior e1;
	public EnemyBehevior e2;
	public EnemyBehevior e3;

	public Text lEmount;
	public Text score;

	public GameObject star1;
	public GameObject star2;
	public GameObject star3;

	public string Fire = "Fire";
	public GameState getCurrentState() {
		return currentState;
	}

	// Start is called before the first frame update
	void Awake()
	{
		currentState = GameState.start;
		playerBihevior = player.GetComponent(typeof(PlayerBehaviour)) as PlayerBehaviour;
		e1 = enemy1.GetComponent(typeof(EnemyBehevior)) as EnemyBehevior;
		e2 = enemy2.GetComponent(typeof(EnemyBehevior)) as EnemyBehevior;
		e3 = enemy3.GetComponent(typeof(EnemyBehevior)) as EnemyBehevior;
		player.hideFlags= HideFlags.HideInHierarchy;
		//enemy1.SetActive(false);
		//enemy2.SetActive(false);
		//enemy3.SetActive(false);
		emountOfLife = 3;
		score4Win = 20;
		speedOfReload = 2;
		shotInterval = 5;
		speedOfPlayer = 1;
		speedOfEnemy = 1;


	}

	// Update is called once per frame
	void FixedUpdate()
	{
		bool editor = SimpleInput.GetButtonDown("Editor");
		bool play = SimpleInput.GetButtonDown("Play");
		if (currentState == GameState.play) { 
			timer += Time.deltaTime;
			var shoting = (int)(timer % shotInterval);


			if (shoting==0 & timer> shotInterval) { 
				enemyShot();
			
			}
			if (playerBihevior.healthPoint <= 0)
			{
				setOverState();
			}
		
		}
		if (emountOfScore>=score4Win) {
			setWinState();
			emountOfScore = 0;
		}
		
		//if (editor)
		//{
		//	currentState = GameState.editor;
		//}
		//if (play)
		//{
		//
		//	currentState = GameState.play;
		//}

		lEmount.text = playerBihevior.healthPoint.ToString();
		score.text = emountOfScore.ToString();
	}

	private void enemyShot()
    {
		if (currentState == GameState.play) { 
		
		var ebih = new EnemyBehevior[3]{enemy1.GetComponent(typeof(EnemyBehevior)) as EnemyBehevior ,
						enemy2.GetComponent(typeof(EnemyBehevior)) as EnemyBehevior,
						enemy3.GetComponent(typeof(EnemyBehevior)) as EnemyBehevior };

		var chose = UnityEngine.Random.Range(0, 3);
		if (!ebih[chose].isHide) {
			ebih[chose].makeShot();

        }
        else{
			foreach (EnemyBehevior eb in ebih) {
				if (!eb.isHide) {
					eb.makeShot();

				}
			}
		}
		}
		


	//		switch (UnityEngine.Random.Range(0,3)) {
	//			case 0:
	//				if (!ebih1.isHide) { 
	//					ebih1.makeShot();
	//					break;
	//
	//				}
	//				break;
	//			case 1:
	//				if (!ebih2.isHide) { 
	//					ebih2.makeShot();
	//				break;
	//
	//				}
	//				break;
	//			case 2:
	//				if (!ebih3.isHide)
	//				{
	//					ebih3.makeShot();
	//					break;
	//
	//				}
	//				break;
	//		default:
	//
	//			break;
	//	}

		
		
	}

    void Update()
	{
		
		//enemyMasterFunc(e1,e2,e3);
	}


	private void chekBorder( Transform x)
	{
		if (x.position.y > 0.5)
		{
			x.position = new Vector3(x.position.x, 0.5f, 0);
		}	
		if (x.position.y < -3)
		{	
			x.position = new Vector3(x.position.x, -3.5f, 0);
		}
	}


	//canvas
	public void setPlayState() {
		currentState = GameState.play;
		//player.hideFlags = HideFlags.HideInHierarchy;
		//player.SetActive(true); 
		//enemy1.SetActive(true); 
		//enemy2.SetActive(true); 
		//enemy3.SetActive(true); 


		startNewGame();
	}
	public void setOverState()
	{
		currentState = GameState.over;
	}
	public void setWinState()
	{
		currentState = GameState.win;
		switch (playerBihevior.healthPoint) {
			case 1:
				star1.SetActive(true);
				star2.SetActive(false);
				star3.SetActive(false);

				break;
			case 2:
				star1.SetActive(true);
				star2.SetActive(true);
				star3.SetActive(false);

				break;
			case 3:
				star1.SetActive(true);
				star2.SetActive(true);
				star3.SetActive(true);

				break;
		}
	}

	public void setEditorState()
	{
		currentState = GameState.editor;
	}
	public void setStartState()
	{
		currentState = GameState.editor;
	}

	//Ecanvas


	public void addScore(int add) {
		emountOfScore += enemyScore[add-1]; 
		
	}
	public float verifyTime()
	{
		return timer;
	}
	
	public void startNewGame() {
		
		emountOfScore = 0;
		timer = 0;
		emountOfLife = 3;

		playerBihevior.SetSpeed(speedOfPlayer);
		playerBihevior.setHealth(emountOfLife);
		playerBihevior.setReload(speedOfReload);
		e1.SetSpeed(speedOfEnemy);
		e2.SetSpeed(speedOfEnemy);
		e3.SetSpeed(speedOfEnemy);

	}

	//Editor voids foo 
	public void	setspeedOfEnemy	(int i){
		speedOfEnemy += i;
		if (speedOfEnemy ==0) {
			speedOfEnemy = 1;
		}
	}
	public void	setspeedOfPlayer(int i)	{
		speedOfPlayer += i;
		if (speedOfPlayer == 0)
		{
			speedOfPlayer = 1;
		}
	}
	public void	setscore4Win	(int i)	{
		score4Win += i;
		if (score4Win == 0)
		{
			score4Win = 1;
		}
	}
	public void	setspeedOfReload(int i)	{
		speedOfReload += i;
		if (speedOfReload == 0)
		{
			speedOfReload = 1;
		}
	}
	public void	setshotInterval	(int i){
		shotInterval +=i;
		if (shotInterval == 0)
		{
			shotInterval = 1;
		}
	}
	
	public void setenemyScore	(int i, int a) {
		enemyScore[a] += i;
		if (enemyScore[a] <= 0)
		{
			enemyScore[a] = 1;
		}
	}
	//


	public void Quit()
	{
		Application.Quit();
	}
}
