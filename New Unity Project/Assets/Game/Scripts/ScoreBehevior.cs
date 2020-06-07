using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehevior : MonoBehaviour
{
    public Text score;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Awake()
    {

        score = GetComponent<Text>();
        gameManager = GameObject.Find("GameManager").GetComponent(typeof(GameManager)) as GameManager;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        score.text = gameManager.emountOfScore.ToString();
    }
}
