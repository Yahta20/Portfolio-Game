using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SceneObject : MonoBehaviour
{
    public readonly float yHight = 0.5f;
    public readonly float yBottom = -3f;

    public float timeMove;
    public float timeShote;
    public int direction;
    public float moveSpeed { get; private set; }
    public float reloadSpeeed{ get; private set; }

    public bool isHide { get; private set; }
    public float Xpos { get; private set; }
    public float Ypos { get; private set; }
    public float Zpos { get; private set; }

    
    public Rigidbody2D rgEnemy;

    // Start is called before the first frame update
    
    public virtual void Moving()
    {
        if (timeMove > 0)
        {
            rgEnemy.velocity = new Vector2(0, direction * moveSpeed);
        }
        if (timeMove <= 0)
        {
            while (true)
            {
                direction = UnityEngine.Random.Range(-50, 50);
                if (direction != 0)
                {
                    break;
                }
            }
            direction /= Mathf.Abs(direction);
            timeMove = UnityEngine.Random.Range(0.2f, 0.6f);
        }
    }
    public virtual void chekBorder()
    {
        if (transform.position.y >= yHight)
        {
            transform.position = new Vector3(Xpos, yHight, Zpos);
        }
        if (transform.position.y <= yBottom)
        {
            transform.position = new Vector3(Xpos, yBottom, Zpos);
        }
    }

    public virtual void Hide()
    {
        Ypos = transform.position.y;
        Xpos = transform.position.x;
        Zpos = 0.5f;

        this.gameObject.transform.position = new Vector3(Xpos, Ypos, Zpos);

        isHide = true;

    }

    public virtual void setSetting(float speedo,float reloado) {
        moveSpeed = speedo;
        reloadSpeeed = reloado;
    }
    


}
