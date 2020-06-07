using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBehevior : MonoBehaviour
{
    public Text timer;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Awake()
    {
       
        timer = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.getCurrentState() == GameState.play) { 
            var time = (int)gameManager.verifyTime();
            var min = 0;
            var sec = (int)time;

            sec = (int)time % 60;
            min = (int)time/60 ;

            string timeShow="";

            if (min < 10)
            {
                timeShow += "0" + min.ToString();

            }
            else {
                timeShow +=min.ToString();
            }
            timeShow += ":";
            if (sec < 10)
            {
                timeShow += "0" + sec.ToString();
            }
            else
            {
                timeShow += sec.ToString();
            }


            timer.text = timeShow;
            //timer.text = min.ToString() + ":" + sec.ToString();
            //timer.text = time.ToString();

        }

    }
}
