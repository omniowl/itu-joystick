using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ITU.Joypad
{
    [CreateAssetMenu]
    public class JoystickControllerTest : JoystickController, IJoyPad
    {
        [Tooltip("The enum name for the button to use. Look at 'KeyCode' for names.")]
        public String BTN_YELLOW = "";
        [Tooltip("The enum name for the button to use. Look at 'KeyCode' for names.")]
        public String BTN_RED = "";
        [Tooltip("The enum name for the button to use. Look at 'KeyCode' for names.")]
        public String BTN_GREEN = "";
        [Tooltip("The enum name for the button to use. Look at 'KeyCode' for names.")]
        public String BTN_BLUE = "";
        [Tooltip("The enum name for the button to use. Look at 'KeyCode' for names.")]
        public String BTN_WHITE = "";
        [Tooltip("The enum name for the button to use. Look at 'KeyCode' for names.")]
        public String BTN_BLACK = "";
        [Tooltip("The enum name for the button to use. Look at 'KeyCode' for names.")]
        public String BTN_RIGHT = "";
        [Tooltip("The enum name for the button to use. Look at 'KeyCode' for names.")]
        public String BTN_LEFT = "";
        [Tooltip("The enum name for the button to use. Look at 'KeyCode' for names.")]
        public String BTN_DOWN = "";
        [Tooltip("The enum name for the button to use. Look at 'KeyCode' for names.")]
        public String BTN_UP = "";

        public override void init()
        {
            SetupKeyCodes();
            FunctionDictionaryDown = new Dictionary<KeyCode, Action<InputEventArgs>>
        {
            { YELLOW, new Action<InputEventArgs>(YellowButtonFire) },
            { RED, new Action<InputEventArgs>(RedButtonFire) },
            { GREEN, new Action<InputEventArgs>(GreenButtonFire) },
            { BLUE, new Action<InputEventArgs>(BlueButtonFire) },
            { WHITE, new Action<InputEventArgs>(WhiteButtonFire) },
            { BLACK, new Action<InputEventArgs>(BlackButtonFire) },
            { RIGHT, new Action<InputEventArgs>(StickRight) },
            { LEFT, new Action<InputEventArgs>(StickLeft) },
            { DOWN, new Action<InputEventArgs>(StickDown) },
            { UP, new Action<InputEventArgs>(StickUp) }
        };

            FunctionDictionaryUp = new Dictionary<KeyCode, Action<InputEventArgs>>
        {
            { YELLOW, new Action<InputEventArgs>(YellowButtonStop) },
            { RED, new Action<InputEventArgs>(RedButtonStop) },
            { GREEN, new Action<InputEventArgs>(GreenButtonStop) },
            { BLUE, new Action<InputEventArgs>(BlueButtonStop) },
            { WHITE, new Action<InputEventArgs>(WhiteButtonStop) },
            { BLACK, new Action<InputEventArgs>(BlackButtonStop) },
            { RIGHT, new Action<InputEventArgs>(StickRight) },
            { LEFT, new Action<InputEventArgs>(StickLeft) },
            { DOWN, new Action<InputEventArgs>(StickDown) },
            { UP, new Action<InputEventArgs>(StickUp) }
        };
        }

        public override void SetupKeyCodes()
        {
            if (PlayerId != 1 && PlayerId != 2)
            {
                Debug.Log("[JoystickController]: Invalid Player ID: " + PlayerId);
            }
            else
            {
                YELLOW = (KeyCode)Enum.Parse(typeof(KeyCode), BTN_YELLOW);
                RED = (KeyCode)Enum.Parse(typeof(KeyCode), BTN_RED);
                GREEN = (KeyCode)Enum.Parse(typeof(KeyCode), BTN_GREEN);
                BLUE = (KeyCode)Enum.Parse(typeof(KeyCode), BTN_BLUE);
                WHITE = (KeyCode)Enum.Parse(typeof(KeyCode), BTN_WHITE);
                BLACK = (KeyCode)Enum.Parse(typeof(KeyCode), BTN_BLACK);
                RIGHT = (KeyCode)Enum.Parse(typeof(KeyCode), BTN_RIGHT);
                LEFT = (KeyCode)Enum.Parse(typeof(KeyCode), BTN_LEFT);
                DOWN = (KeyCode)Enum.Parse(typeof(KeyCode), BTN_DOWN);
                UP = (KeyCode)Enum.Parse(typeof(KeyCode), BTN_UP);
            }
        }

        public override void KeyUpListener()
        {
            foreach (KeyValuePair<KeyCode, Action<InputEventArgs>> pair in FunctionDictionaryUp)
            {
                if (Input.GetKeyUp(pair.Key))
                {
                    InputEventArgs inputArgs = new InputEventArgs(pair.Key);
                    if (pair.Key == RIGHT || pair.Key == LEFT || pair.Key == DOWN || pair.Key == UP)
                    {
                        StickMiddle(inputArgs);
                    }
                    else
                    {
                        pair.Value.Invoke(inputArgs);
                    }
                }
            }
        }
    }
}