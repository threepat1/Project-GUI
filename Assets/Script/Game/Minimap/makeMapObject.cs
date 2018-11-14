using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class makeMapObject : MonoBehaviour {

    public Image image;

	// Use this for initialization
	void Start () {
        MiniMapController.RegisterMapObject(this.gameObject, image);
	}
	
	// Update is called once per frame
	void Update () {
       
		
	}
    public void OnDestroy()
    {
        MiniMapController.RemoveMapObject(this.gameObject);
    }
}
