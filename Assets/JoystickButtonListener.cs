using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class JoystickButtonListener : MonoBehaviour
{
    public int JoystickNumber = 0;
    public int JoystickButtonNumber = 0;
    public float PressedButtonAlpha;
    private KeyCode JoystickButton = KeyCode.Joystick1Button0;
    private Image ButtonImage;
    private Color InitialColor;
    private Color PressedColor;

    public void Start()
    {
        ButtonImage = GetComponent<Image>();
        InitialColor = ButtonImage.color;
        PressedColor = new Color(ButtonImage.color.r, ButtonImage.color.g, ButtonImage.color.b, PressedButtonAlpha);
        String joystickString = "Joystick" + JoystickNumber + "Button" + JoystickButtonNumber;
        JoystickButton = (KeyCode) Enum.Parse(typeof(KeyCode), joystickString);
}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(JoystickButton))
        {
            ButtonImage.color = PressedColor;
        }
        else
        {
            ButtonImage.color = InitialColor;
        }
    }
}
