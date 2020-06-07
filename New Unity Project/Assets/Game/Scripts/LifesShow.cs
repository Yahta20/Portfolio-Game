using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifesShow : MonoBehaviour
{
    public Text lEmount;
    public PlayerBehaviour playerBehaviour;
    // Start is called before the first frame update
    void Awake()
    {
        playerBehaviour = GameObject.Find("Player").GetComponent(typeof(PlayerBehaviour)) as PlayerBehaviour;
        lEmount = GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        print(playerBehaviour.healthPoint.ToString());
        lEmount.text = playerBehaviour.healthPoint.ToString();
    }
}
