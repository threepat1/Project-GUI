using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TimerClock : MonoBehaviour {
 
  

    public Text counterText;
   
    public float mins, seconds;
	void Start () {
        counterText = GetComponent<Text>() as Text;
        counterText.text = "Time" + ("\n") + ("00") + (":") +
           ("00");
        return;
    }
	
	// Update is called once per frame
	void Update ()
    {

        int mins = Mathf.FloorToInt(Time.time / 60);
        int seconds = Mathf.FloorToInt(Time.time - mins * 60);
        counterText.text = "Time" +("\n") + mins.ToString("00") + (":") +
            seconds.ToString("00");
     
    }

}
