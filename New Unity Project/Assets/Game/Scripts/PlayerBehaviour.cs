using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;
public class PlayerBehaviour : MonoBehaviour
{


    public float yHight = 0.5f;
    public float yBottom = -3f;
    [Range(0, 10)]
    public int snowSpeed = 5;
    [Range(0, 10)]
    public int gravity = 1;
    public int healthPoint { get; private set; }
    public bool onLoad { get; private set; }
    public Rigidbody2D rgHippo;
    public GameObject snowball;
    public GameObject reloadBar;
    public GameObject forseBar;
    //reload
    public float reloadTime { get; private set; }
    public float startReload;
    public float time;



    public float PosY = 0;

    public string verticalAxis = "Vertical", Fire = "Fire";
    private float moveSpeed;



    // Start is called before the first frame update
    


    // Spine.AnimationState and Spine.Skeleton are not Unity-serialized objects. You will not see them as fields in the inspector.
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset idle, run;
    
    public string currentState,currentAnimation;
    //

    void Awake()
    {
        rgHippo = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(-2.7f, PosY, 0);
        yBottom = -3.1f;
        SetSpeed(1.1f);
        startReload = 0.3f;
        onLoad = false;
        reloadBar.transform.localScale= new Vector3(1, 0);
        currentState = "Idle";
        SetCharacterState(currentState);
        //skeletonAnimation = GetComponent<SkeletonAnimation>();
        //spineAnimationState = skeletonAnimation.AnimationState;
        //skeleton = skeletonAnimation.Skeleton;

    }

    void FixedUpdate()
    {
        PosY = SimpleInput.GetAxis(verticalAxis);
        var trig = SimpleInput.GetButtonDown(Fire);
        time += Time.deltaTime;
        if (trig == true & onLoad)
        {
            var sbB = snowball.GetComponent(typeof(snowballBehevior)) as snowballBehevior;
            sbB.MoveTo((float)transform.position.x + 0.6f, (float)transform.position.y + 0.8f);
            sbB.Show();
            sbB.addForse((int)(10*(Mathf.Sin(time) + 1) / 2), -gravity);
            startReload = 0;
            onLoad = false;
            reloadBar.transform.localScale = new Vector3(1, 0f);
        }

        
        startReload += Time.deltaTime;
        if (reloadTime < startReload)
        {
            startReload = reloadTime;
            onLoad = true;
        }

        //Mathf.sin(time) + 0.5f;
        var yscale = ((startReload / reloadTime) / 2).ToString().Equals("NaN") ? 0 : (startReload / reloadTime) / 2;

        reloadBar.transform.localScale = new Vector3(1, yscale);

        forseBar.transform.localScale  = new Vector3((Mathf.Sin(time)+1)/2, 1);

        if (PosY!=0) { 
            SetCharacterState("run");
        }
        else{
            SetCharacterState("Idle"); 
        }

        rgHippo.velocity = new Vector2(0, PosY * moveSpeed);


        /*
        if (PosY==0) {
            spineAnimationState.SetAnimation(0, walkAnimationName, true);
        }
        */
        borderChek();
    }


    private void borderChek()
    {
        if (transform.position.y >= yHight)
        {
            transform.position = new Vector3(-2.7f, yHight, 0);
        }
        if (transform.position.y <= yBottom)
        {
            transform.position = new Vector3(-2.7f, yBottom, 0);
        }

    }
    public void SetSpeed(float f)
    {
        moveSpeed = f;
    }
    public void getDemage()
    {
        healthPoint--;
        
    }
    public void setHealth( int i)
    {
        healthPoint =i;
    }
    public void setReload(float a) {
        reloadTime = a;
    }

    public void SetAnimation(AnimationReferenceAsset animation,bool loop,float timescale) {
        if (animation.name.Equals(currentAnimation)) {
            return;
        }
        skeletonAnimation.state.SetAnimation(0, animation, loop).TimeScale = timescale;
        currentAnimation = animation.name;
    }
    public void SetCharacterState(string state) {
        if (state.Equals("Idle")) {
            SetAnimation(idle, true, 1f);
        }
        if (state.Equals("run"))
        {
            SetAnimation(run, true, 1f);
        }
    }
    
}
