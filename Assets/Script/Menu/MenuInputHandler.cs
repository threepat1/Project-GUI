using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;//interacting with scene change
using UnityEngine.UI;//interacting with GUI elements
using UnityEngine.EventSystems;//control the event (this is needed to save keybindings)

using System.Xml.Serialization;
using System.IO;
using System;

public class KeyData
{
    public Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
}

public class MenuInputHandler : MonoBehaviour
{
    #region Variables
    [Header("Keys")]

    [Header("KeyBind References")]
    public Text forwardText;
    public Text backwardText;
    public Text jumpText;
    public Text leftText;
    public Text rightText;

    [Header("File Saving")]
    public string fileName;

    
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    private GameObject currentKey;

    private KeyData saveData;
    #endregion

    #region Start
    void Start()
    {
        // Here, the key bindings are set to what is stored in the save file. If it is unable to find the stored (KeyCode), then the named input is set to a defined default KeyCode.
        string fullPath = Application.dataPath + "/Data/" + fileName + ".xml";
        if (File.Exists(fullPath))
        {
            // Load it
            saveData = Load();
            keys = saveData.keys;
        }
        else
        {
            // Add defaults
            // set out keys to the preset keys we may have saved, else set the keys to default
            keys.Add("Forward", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Forward", "W")));
            keys.Add("Backward", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Backward", "S")));
            keys.Add("Jump", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space")));
            keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A")));
            keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));
        }

        forwardText.text = keys["Forward"].ToString();
        backwardText.text = keys["Backward"].ToString();
        jumpText.text = keys["Jump"].ToString();
        leftText.text = keys["Left"].ToString();
        rightText.text = keys["Right"].ToString();

    }
    #endregion
    private void Update()
    {
        if(Input.GetKeyDown(keys["Forward"]))
        {

            Debug.Log("Forward");

        }
    }

    #region OnGUI
    private void OnGUI()
    {
        if(currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey = null;
                // Save the keys array
                Save();
            }
        }
    }
    #endregion
    #region Key

    void Save()
    {
        string path = Application.dataPath + "/Data/" + fileName + ".xml";
        var serializer = new XmlSerializer(typeof(KeyData));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, saveData);
        }
    }

    KeyData Load()
    {
        string path = Application.dataPath + "/Data/" + fileName + ".xml";

        var serializer = new XmlSerializer(typeof(KeyData));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as KeyData;
        }
    }


    public void Changekey(GameObject clicked)
    {
        currentKey = clicked;
    }
    #endregion
    #region Save
   
    public void SaveKey()
    {
        foreach (var key in keys)
        { PlayerPrefs.SetString(key.Key, key.Value.ToString()); }
        PlayerPrefs.Save();

    }
    #endregion
}
