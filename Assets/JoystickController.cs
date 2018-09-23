using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class JoystickController : ScriptableObject, IJoyPad
{
    [Range(1, 2)]
    public int PlayerId = 1;

    private KeyCode YELLOW;
    private KeyCode RED;
    private KeyCode GREEN;
    private KeyCode BLUE;
    private KeyCode WHITE;
    private KeyCode BLACK;
    private KeyCode RIGHT;
    private KeyCode LEFT;
    private KeyCode DOWN;
    private KeyCode UP;

    public event EventHandler YellowButtonPressed;
    public event EventHandler YellowButtonReleased;
    public event EventHandler RedButtonPressed;
    public event EventHandler RedButtonReleased;
    public event EventHandler GreenButtonPressed;
    public event EventHandler GreenButtonReleased;
    public event EventHandler BlueButtonPressed;
    public event EventHandler BlueButtonReleased;
    public event EventHandler WhiteButtonPressed;
    public event EventHandler WhiteButtonReleased;
    public event EventHandler BlackButtonPressed;
    public event EventHandler BlackButtonReleased;
    public event EventHandler StickDirectionRight;
    public event EventHandler StickDirectionLeft;
    public event EventHandler StickDirectionDown;
    public event EventHandler StickDirectionUp;
    public event EventHandler StickDirectionMiddle;

    private Dictionary<KeyCode, Action<InputEventArgs>> FunctionDictionaryDown;
    private Dictionary<KeyCode, Action<InputEventArgs>> FunctionDictionaryUp;

    public void init()
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

    public void SetupKeyCodes()
    {

        switch (PlayerId)
        {
            case 1:
                YELLOW = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick2Button0");
                RED = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick2Button1");
                GREEN = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick2Button2");
                BLUE = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick2Button3");
                WHITE = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick2Button8");
                BLACK = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick2Button9");
                RIGHT = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick2Button4");
                LEFT = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick2Button5");
                DOWN = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick2Button6");
                UP = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick2Button7");
                break;
            case 2:
                YELLOW = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick1Button0");
                RED = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick1Button1");
                GREEN = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick1Button2");
                BLUE = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick1Button3");
                WHITE = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick1Button8");
                BLACK = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick1Button9");
                RIGHT = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick1Button4");
                LEFT = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick1Button5");
                DOWN = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick1Button6");
                UP = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick1Button7");
                break;
            default:
                Debug.Log("[JoystickController]: Invalid Player ID: " + PlayerId);
                break;
        }
    }

    public void YellowButtonFire(InputEventArgs e)
    {
        if (YellowButtonPressed != null)
        {
            YellowButtonPressed(this, e);
        }
    }

    public void YellowButtonStop(InputEventArgs e)
    {
        if (YellowButtonReleased != null)
        {
            YellowButtonReleased(this, e);
        }
    }

    public void RedButtonFire(InputEventArgs e)
    {
        if (RedButtonPressed != null)
        {
            RedButtonPressed(this, e);
        }
    }

    public void RedButtonStop(InputEventArgs e)
    {
        if (RedButtonReleased != null)
        {
            RedButtonReleased(this, e);
        }
    }

    public void GreenButtonFire(InputEventArgs e)
    {
        if (GreenButtonPressed != null)
        {
            GreenButtonPressed(this, e);
        }
    }

    public void GreenButtonStop(InputEventArgs e)
    {
        if (GreenButtonReleased != null)
        {
            GreenButtonReleased(this, e);
        }
    }

    public void BlueButtonFire(InputEventArgs e)
    {
        if (BlueButtonPressed != null)
        {
            BlueButtonPressed(this, e);
        }
    }

    public void BlueButtonStop(InputEventArgs e)
    {
        if (BlueButtonReleased != null)
        {
            BlueButtonReleased(this, e);
        }
    }

    public void WhiteButtonFire(InputEventArgs e)
    {
        if (WhiteButtonPressed != null)
        {
            WhiteButtonPressed(this, e);
        }
    }

    public void WhiteButtonStop(InputEventArgs e)
    {
        if (WhiteButtonReleased != null)
        {
            WhiteButtonReleased(this, e);
        }
    }

    public void BlackButtonFire(InputEventArgs e)
    {
        if (BlackButtonPressed != null)
        {
            BlackButtonPressed(this, e);
        }
    }

    public void BlackButtonStop(InputEventArgs e)
    {
        if (BlackButtonReleased != null)
        {
            BlackButtonReleased(this, e);
        }
    }

    public void StickRight(InputEventArgs e)
    {
        if (StickDirectionRight != null)
        {
            StickDirectionRight(this, e);
        }
    }

    public void StickLeft(InputEventArgs e)
    {
        if (StickDirectionLeft != null)
        {
            StickDirectionLeft(this, e);
        }
    }

    public void StickDown(InputEventArgs e)
    {
        if (StickDirectionDown != null)
        {
            StickDirectionDown(this, e);
        }
    }

    public void StickUp(InputEventArgs e)
    {
        if (StickDirectionUp != null)
        {
            StickDirectionUp(this, e);
        }
    }

    public void StickMiddle(InputEventArgs e)
    {
        if (StickDirectionMiddle != null)
        {
            StickDirectionMiddle(this, e);
        }
    }

    public void KeyDownListener()
    {
        foreach (KeyValuePair<KeyCode, Action<InputEventArgs>> pair in FunctionDictionaryDown)
        {
            if (Input.GetKeyDown(pair.Key))
            {
                InputEventArgs inputArgs = new InputEventArgs(pair.Key);
                pair.Value.Invoke(inputArgs);
            }
        }
    }

    public void KeyUpListener()
    {
        foreach (KeyValuePair<KeyCode, Action<InputEventArgs>> pair in FunctionDictionaryUp)
        {
            if (Input.GetKeyUp(pair.Key))
            {
                // We need a special case here because going back to the Middle with the
                // arcade stick, technically has no button to refer to.
                if (PlayerId == 1)
                {
                    InputEventArgs inputArgs = new InputEventArgs(pair.Key);
                    switch (pair.Key)
                    {
                        case KeyCode.Joystick2Button4:
                        case KeyCode.Joystick2Button5:
                        case KeyCode.Joystick2Button6:
                        case KeyCode.Joystick2Button7:
                            StickMiddle(inputArgs);
                            break;
                        default:
                            pair.Value.Invoke(inputArgs);
                            break;
                    }
                }
                else
                {
                    InputEventArgs inputArgs = new InputEventArgs(pair.Key);
                    switch (pair.Key)
                    {
                        case KeyCode.Joystick1Button4:
                        case KeyCode.Joystick1Button5:
                        case KeyCode.Joystick1Button6:
                        case KeyCode.Joystick1Button7:
                            StickMiddle(inputArgs);
                            break;
                        default:
                            pair.Value.Invoke(inputArgs);
                            break;
                    }
                }
            }
        }
    }
}
