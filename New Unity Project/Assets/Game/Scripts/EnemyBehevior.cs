using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class EnemyBehevior : MonoBehaviour
{
    private float timeMove;
    private float timeShote;
    private float timeResurect;


    private int direction;
    public int time2Respawn { get; private set; }
    public int priseScore { get; private set; }
    public float moveSpeed { get; private set; }
    public bool isHide { get; private set; }
    public bool respaun { get; private set; }
    public float Xpos { get; private set; }
    public float Ypos { get; private set; }
    public float Zpos { get; private set; }
    public float topBorder { get; private set; }
    public float bottomBorder { get; private set; }

    public GameObject snowball;
    public GameManager gameManager;
    public Rigidbody2D rgEnemy;

    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset idle, run;

    public string currentState, currentAnimation;

    public string[] enemies = new string[9] { 
                   "DogSon",
                   "FoxSon",
                   "LeoSon",
                   "PigSon",
                   "PumaDaughter",
                   "RaccoonSon",
                   "PigDaughter",
                   "CatDaughter",
                   "Lala"};


    // Start is called before the first frame update
    void Awake()
    {
        rgEnemy = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent(typeof(GameManager)) as GameManager;
        SetSpeed(1.1f);
        string s = this.name.ToString();
        s=s.Substring(5);
        priseScore = int.Parse(s);
        topBorder    = 0.5f;
        bottomBorder = -3f;
        time2Respawn = 5;

        currentState = "Idle";
        SetCharacterState(currentState);
        //.gameObject.name;
        //if () { 
        //}

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //print(isHide+" "+this.gameObject.GetInstanceID()+" ");
        timeMove-=Time.deltaTime;
        if (isHide)
        {

           direction = Mathf.Abs(topBorder - this.gameObject.transform.position.y) < 2 ? 1: -1 ;

           rgEnemy.velocity = new Vector2(0, direction * moveSpeed);
            SetCharacterState("run");
            if (this.gameObject.transform.position.y - 2 >=  bottomBorder|
                this.gameObject.transform.position.y + 2 <= topBorder ) {
                timeResurect += Time.deltaTime;
            }
            if (timeResurect>time2Respawn) {
                Resurection();
                
            }
        }
        else {
            Moving();
            chekBorder();
            Zpos = 0;
        }
        
    }

    private void changeCharacter()
    {
        int variable = UnityEngine.Random.Range(0, 9);
        skeletonAnimation.Skeleton.SetSkin(enemies[variable]) ;
    }

    private void Moving()
    {
        

        if (timeMove > 0) {
            rgEnemy.velocity = new Vector2(0, direction * moveSpeed);
        }
        if (direction == 0) {
            SetCharacterState("Idle");

        }
        else { 
        
            SetCharacterState("run");
        }
        if (timeMove <= 0)
        {
            
            direction = UnityEngine.Random.Range(-1,2) ;
            
            
            timeMove = UnityEngine.Random.Range(0.2f, 0.6f);
        }               
    }                   
    private void chekBorder()
    {
        if (this.gameObject.transform.position.y > topBorder)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, topBorder, Zpos);
        }                                                                                           
        if (this.gameObject.transform.position.y < bottomBorder 
)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, bottomBorder, Zpos);
        }
    }
    public void Resurection()
    {
        rgEnemy.velocity = new Vector2(0, -direction * moveSpeed);
        if (this.gameObject.transform.position.y > bottomBorder   |
            this.gameObject.transform.position.y < topBorder )
        {
            timeResurect = 0;
            isHide = false;
            changeCharacter();
        }

    }

    public Transform getTransform() {
        return this.gameObject.transform;
    }
    public void Hide()
    {
        isHide = true;
        gameManager.addScore(priseScore);
    }

    public void SetSpeed(float f)
    {
        moveSpeed = f;
    }
    public void makeShot() {
        var sbB = snowball.GetComponent(typeof(snowballBehevior)) as snowballBehevior;
        if (sbB.isHide) {
            sbB.MoveTo((float)transform.position.x + 0.6f, (float)transform.position.y + 0.8f);
            sbB.Show();
            sbB.addForse(-5,0);
        }

    }


    public void SetAnimation(AnimationReferenceAsset animation, bool loop, float timescale)
    {
        if (animation.name.Equals(currentAnimation))
        {
            return;
        }
        skeletonAnimation.state.SetAnimation(0, animation, loop).TimeScale = timescale;
        currentAnimation = animation.name;
    }
    public void SetCharacterState(string state)
    {
        if (state.Equals("Idle"))
        {
            SetAnimation(idle, true, 1f);
        }
        if (state.Equals("run"))
        {
            SetAnimation(run, true, 1f);
        }
    }


}

