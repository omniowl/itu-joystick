using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public List<KeyCode> KeyCodeList = new List<KeyCode>();

	// Use this for initialization
	void Start () {
        KeyCodeList.Add(KeyCode.Joystick2Button0);
        KeyCodeList.Add(KeyCode.Joystick2Button1);
        KeyCodeList.Add(KeyCode.Joystick2Button2);
        KeyCodeList.Add(KeyCode.Joystick2Button3);
        KeyCodeList.Add(KeyCode.Joystick2Button4);
        KeyCodeList.Add(KeyCode.Joystick2Button5);
        KeyCodeList.Add(KeyCode.Joystick2Button6);
        KeyCodeList.Add(KeyCode.Joystick2Button7);
        KeyCodeList.Add(KeyCode.Joystick2Button8);
        KeyCodeList.Add(KeyCode.Joystick2Button9);
        KeyCodeList.Add(KeyCode.Joystick2Button10);
        KeyCodeList.Add(KeyCode.Joystick2Button11);
        KeyCodeList.Add(KeyCode.Joystick2Button12);
        KeyCodeList.Add(KeyCode.Joystick2Button13);
    }
	
	// Update is called once per frame
	void Update () {
        foreach(KeyCode code in KeyCodeList)
        {
            if(Input.GetKey(code))
            {
                Debug.Log(code.ToString());
            }
        }
    }
}
