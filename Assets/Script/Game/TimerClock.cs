using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TimerClock : MonoBehaviour {
 
    public float timer;
  

    public Text counterText;
   
    public float seconds, minutes;
	void Start () {
        counterText = GetComponent<Text>() as Text;

        
	}
	
	// Update is called once per frame
	void Update ()
    {
       
        minutes = (int)(Time.time / 60f);
        seconds = (int)(Time.time % 60f);
        counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
     
    }

}
