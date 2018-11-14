using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TimerClock : MonoBehaviour {
 
    public float timer;
  

    public Text counterText;
   
    public float seconds;
	void Start () {
        counterText = GetComponent<Text>() as Text;

        
	}
	
	// Update is called once per frame
	void Update ()
    {
       
       
        seconds = (int)(Time.time);
        counterText.text = "Time :" + 
            seconds.ToString("00");
     
    }

}
