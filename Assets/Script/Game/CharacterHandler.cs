using UnityEngine;
using System.Collections;
//this script can be found in the Component section under the option Character Set Up 
//Character Handler
public class CharacterHandler : MonoBehaviour
{ 
    #region Variables
    [Header("Character")]

    #region Character 
    //bool to tell if the player is alive
    public bool alive;
    //connection to players character controller
    public CharacterController controller;
    #endregion
    [Header( "Health")]
    #region Health
    //max and min health
    public float maxHealth;
    public float curHealth;
    public GUIStyle healthBar;
    #endregion
    //[Header("Levels and Exp")]
    #region Level and Exp
    //players current level
    public int level;
    //max and min experience 
    public int maxExp, curExp;

    #region Keycode input
    public KeyCode forward, backward, left, right, jump;
    
    #endregion
    #region Stamina
    int dex;
    int str;
    int wis;
    int intel;
    int chr;
    int con;


    #endregion

    #endregion
    [Header("Camera Connection")]
    #region MiniMap
    //render texture for the mini map that we need to connect to a camera
    public RenderTexture miniMap;
    #endregion
    #region Start
    public void Start()
    {
        //set max health to 100
        maxHealth = 100f;
        maxHealth += con * 5;
        //set current health to max
        curHealth = maxHealth;
        //make sure player is alive
        alive = true;
        //max exp starts at 60
        maxExp = 60;
        //connect the Character Controller to the controller variable
        controller = this.GetComponent<CharacterController>();

        PlayerPrefs.GetString("Forward");
        PlayerPrefs.GetString("Backward");
        PlayerPrefs.GetString("Left");
        PlayerPrefs.GetString("Right");
        PlayerPrefs.GetString("Jump");

    }
    #endregion
    #region Update
        private void Update()
    {

        //if our current experience is greater or equal to the maximum experience
        if (curExp >= maxExp)
        {
            //then the current experience is equal to our experience minus the maximum amount of experience
            curExp -= maxExp;
            //our level goes up by one
            level++;
        //the maximum amount of experience is increased by 50
        maxExp += 50;
        }
        curHealth = (int)curHealth;
    }
    #endregion
    #region LateUpdate
    private void LateUpdate()
    {
        //if our current health is greater than our maximum amount of health
        if (curHealth > maxHealth)
        {
            //then our current health is equal to the max health
            curHealth = maxHealth;
        }
        //if our current health is less than 0 or we are not alive
        if (curHealth < 0 || !alive)
        {
            //current health equals 0
            curHealth = 0;
            Debug.Log("if less than 0 = 0");
        }
        //if the player is alive
        if (alive && curHealth == 0)
        {
            //and our health is less than or equal to 0
            
                //alive is false
                alive = false;

                //controller is turned off
                controller.enabled = false;
                Debug.Log("Disable on death");
            
        }

    }
    #endregion
    #region OnGUI
    private void OnGUI()
    {


        //set up our aspect ratio for the GUI elements
        float scrW = Screen.width / 16;
        //scrW - 16
        float scrH = Screen.height / 9;

        for (int x = 0; x < 16; x++)
        {
            for (int y = 0; y < 9; y++) ;
        }
        //scrH - 9
        //GUI Box on screen for the healthbar background
        GUI.Box(new Rect(6 * scrW, 0.25f * scrH, 4 * scrW, 0.5f * scrH), "");
        //GUI Box for current health that moves in same place as the background bar
        GUI.Box(new Rect(6 * scrW, 0.25f * scrH, curHealth * (4 * scrW) / maxHealth, 0.5f * scrH), "", healthBar);
        //current Health divided by the posistion on screen and timesed by the total max health
        //GUI Box on screen for the experience background
        GUI.Box(new Rect(6 * scrW, 0.75f * scrH, 4 * scrW, 0.5f * scrH), "");
        //GUI Box for current experience that moves in same place as the background bar
        GUI.Box(new Rect(6 * scrW, 0.75f * scrH, curExp * (4 * scrW) / maxExp, 0.5f * scrH), "");
        //current experience divided by the posistion on screen and timesed by the total max experience

       

    }
    #endregion

    #endregion

}