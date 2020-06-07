using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorModeBihavior : MonoBehaviour
{
    public Text score4win;
    public Text hippoSpeed;
    public Text hippoReload;
    public Text enemyReload;
    public Text enemySpeed;
    public Text enemy1Score;
    public Text enemy2Score;
    public Text enemy3Score;

    public bool iscore4win { get; private set; }
    public bool ihippoSpeed    { get; private set; }
    public bool ihippoReload   {get;private set;}
    public bool ienemyReload   {get;private set;}
    public bool ienemySpeed    {get;private set;}
    public bool ienemy1Score   {get;private set;}
    public bool ienemy2Score   {get;private set;}
    public bool ienemy3Score { get; private set;}

    public bool dscore4win { get; private set; }
    public bool dhippoSpeed { get; private set; }
    public bool dhippoReload { get; private set; }
    public bool denemyReload { get; private set; }
    public bool denemySpeed { get; private set; }
    public bool denemy1Score { get; private set; }
    public bool denemy2Score { get; private set; }
    public bool denemy3Score { get; private set; }

    private bool isTap;

    public string Iscore4win   ="iScore" ,
                  IhippoSpeed  ="iHippoSpeed" ,
                  IhippoReload ="iHippoReload",
                  IenemyReload ="iEnemyReload",
                  IenemySpeed  ="iEnemySpeed",
                  Ienemy1Score ="iEnemy1Score",
                  Ienemy2Score ="iEnemy2Score" ,
                  Ienemy3Score ="iEnemy3Score" ;

    public string Dscore4win   = "dScore",
                  DhippoSpeed  = "dHippoSpeed",
                  DhippoReload = "dHippoReload",
                  DenemyReload = "dEnemyReload",
                  DenemySpeed  = "dEnemySpeed",
                  Denemy1Score = "dEnemy1Score",
                  Denemy2Score = "dEnemy2Score",
                  Denemy3Score = "dEnemy3Score";

    public GameManager gm;
    // Start is called before the first frame update
    void Awake()
    {
        isTap = false;
        gm = GameObject.Find("GameManager").GetComponent(typeof(GameManager)) as GameManager;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //PosY = SimpleInput.GetAxis(verticalAxis);
        iscore4win   =SimpleInput.GetButtonDown(Iscore4win  )       ;
        ihippoSpeed  =SimpleInput.GetButtonDown(IhippoSpeed )       ;
        ihippoReload =SimpleInput.GetButtonDown(IhippoReload)       ;
        ienemyReload =SimpleInput.GetButtonDown(IenemyReload)       ;
        ienemySpeed  =SimpleInput.GetButtonDown(IenemySpeed )       ;
        ienemy1Score =SimpleInput.GetButtonDown(Ienemy1Score)       ;
        ienemy2Score =SimpleInput.GetButtonDown(Ienemy2Score)       ;
        ienemy3Score =SimpleInput.GetButtonDown(Ienemy3Score)       ;

        dscore4win = SimpleInput.GetButtonDown  (Dscore4win);
        dhippoSpeed = SimpleInput.GetButtonDown (DhippoSpeed);
        dhippoReload = SimpleInput.GetButtonDown(DhippoReload);
        denemyReload = SimpleInput.GetButtonDown(DenemyReload);
        denemySpeed = SimpleInput.GetButtonDown (DenemySpeed);
        denemy1Score = SimpleInput.GetButtonDown(Denemy1Score);
        denemy2Score = SimpleInput.GetButtonDown(Denemy2Score);
        denemy3Score = SimpleInput.GetButtonDown(Denemy3Score);


        if (iscore4win  )
        {
            if (isTap) {
                return;
            }
            isTap = true;
            gm.setscore4Win(1);
        }
        if (ihippoSpeed )
        {
            if (isTap)
            {
                return;
            }
            isTap = true;

            gm.setspeedOfPlayer(1);
        }
        if (ihippoReload)
        {
            if (isTap)
            {
                return;
            }
            isTap = true;

            gm.setspeedOfReload(1);
        }
        if (ienemySpeed )
        {
            if (isTap)
            {
                return;
            }
            isTap = true;

            gm.setspeedOfEnemy(1);
        }
        if (ienemyReload)
        {
            if (isTap)
            {
                return;
            }
            isTap = true;

            gm.setshotInterval(1);
        }
        if (ienemy1Score)
        {
            if (isTap)
            {
                return;
            }
            isTap = true;

            gm.setenemyScore(1,0);
        }
        if (ienemy2Score)
        {
            if (isTap)
            {
                return;
            }
            isTap = true;

            gm.setenemyScore(1, 1);
        }
        if (ienemy3Score)
        {
            if (isTap)
            {
                return;
            }
            isTap = true;

            gm.setenemyScore(1, 2);
        }

        if (dscore4win  )
        {
            if (isTap)
            {
                return;
            }
            isTap = true;

            gm.setscore4Win(-1);
        }
        if (dhippoSpeed )
        {
            if (isTap)
            {
                return;
            }
            isTap = true;

            gm.setspeedOfPlayer(-1);
        }
        if (dhippoReload)
        {
            if (isTap)
            {
                return;
            }
            isTap = true;

            gm.setspeedOfReload(-1);
        }
        if (denemySpeed )
        {
            if (isTap)
            {
                return;
            }
            isTap = true;

            gm.setspeedOfEnemy(-1);
        }
        if (denemyReload)
        {
            if (isTap)
            {
                return;
            }
            isTap = true;

            gm.setshotInterval(-1);
        }
        if (denemy1Score)
        {
            if (isTap)
            {
                return;
            }
            isTap = true;

            gm.setenemyScore(-1, 0);
        }
        if (denemy2Score)
        {
            if (isTap)
            {
                return;
            }
            isTap = true;

            gm.setenemyScore(-1, 1);
        }
        if (denemy3Score)
        {
            if (isTap)
            {
                return;
            }
            isTap = true;

            gm.setenemyScore(-1, 2);
        }

        if (!iscore4win  &
            !ihippoSpeed &
            !ihippoReload&
            !ienemySpeed &
            !ienemyReload&
            !ienemy1Score&
            !ienemy2Score&
            !ienemy3Score&
                        
            !dscore4win  &
            !dhippoSpeed &
            !dhippoReload&
            !denemySpeed &
            !denemyReload&
            !denemy1Score&
            !denemy2Score&
            !denemy3Score         
            
            ) {
            isTap = false;
        } 


        score4win.text = gm.score4Win.ToString() ;
        hippoSpeed .text = gm.speedOfPlayer.ToString();
        hippoReload.text = gm.speedOfReload.ToString();
        enemyReload.text = gm.shotInterval.ToString();
        enemySpeed .text = gm.speedOfEnemy.ToString();
        enemy1Score.text = gm.getenemyScore(0).ToString()  ;
        enemy2Score.text = gm.getenemyScore(1).ToString();
        enemy3Score.text = gm.getenemyScore(2).ToString();

    }
}
