using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowballBehevior : MonoBehaviour
{
    public float startXPos= -10;
    public float startYPos= -10;

    public bool isHide { get; private set; }
    
    public ParticleSystem system;
    public Rigidbody2D rb;
    

    public void MoveTo(float x, float y){
        this.gameObject.transform.position = new Vector2(x, y);
        startXPos = x;
        startYPos = y;

    }
    public void Show()
    {
        this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        isHide = false;
    }
    

    private void Awake()
    {
        isHide = true;
        rb = GetComponent<Rigidbody2D>();
        Hide();
    }
    void FixedUpdate()
    {
        if (startYPos-1>this.gameObject.transform.position.y) {
            Hide();
        }
        if (-5 > this.gameObject.transform.position.x)
        {
            Hide();
        }
    }

    public void addForse(int x,int y) {
        
        rb.velocity = new Vector2(x ,y);
        
        Show();
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
       if (collision.gameObject.transform.position.z==
                this.gameObject.transform.position.z){
            
        
        if (collision.tag != this.tag & collision.tag == "Player")
        {
           var pb=collision.gameObject.GetComponent(typeof(PlayerBehaviour)) as PlayerBehaviour;
            if (collision.gameObject.name == "Player") { 
            
                pb.getDemage();
                Hide();
                }
        }

        if (collision.tag != this.tag & collision.tag == "Enemys")
        {
                system.transform.position = this.gameObject.transform.position;
                system.Play();  

                var x = collision.gameObject.GetComponent(typeof(EnemyBehevior)) as EnemyBehevior;
                if (x != null )
                {
                    if ( !x.isHide)
                    {
                        x.Hide();
                        Hide();
                }
            }
        

                var s = collision.gameObject.GetComponent(typeof(snowballBehevior)) as snowballBehevior;
            if (s != null )
            {
                if ( !s.isHide)
                {
                    s.Hide();
                    
                }
            }

        }
        
       }

        
    }
    public void Hide()
    {
        
        rb.velocity = new Vector2(0, 0);
        this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 0.5f);
        isHide = true;
        
    }



}
