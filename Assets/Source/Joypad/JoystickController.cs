using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ITU.Joypad;

[CreateAssetMenu]
public class JoystickController : ScriptableObject, IJoyPad
{
    [Range(1, 2)]
    public int PlayerId = 1;

    internal KeyCode YELLOW;
    internal KeyCode RED;
    internal KeyCode GREEN;
    internal KeyCode BLUE;
    internal KeyCode WHITE;
    internal KeyCode BLACK;
    internal KeyCode RIGHT;
    internal KeyCode LEFT;
    internal KeyCode DOWN;
    internal KeyCode UP;

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

    internal Dictionary<KeyCode, Action<InputEventArgs>> FunctionDictionaryDown;
    internal Dictionary<KeyCode, Action<InputEventArgs>> FunctionDictionaryUp;

    public virtual void init()
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

    public virtual void SetupKeyCodes()
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

    public virtual void YellowButtonFire(InputEventArgs e)
    {
        if (YellowButtonPressed != null)
        {
            YellowButtonPressed(this, e);
        }
    }

    public virtual void YellowButtonStop(InputEventArgs e)
    {
        if (YellowButtonReleased != null)
        {
            YellowButtonReleased(this, e);
        }
    }

    public virtual void RedButtonFire(InputEventArgs e)
    {
        if (RedButtonPressed != null)
        {
            RedButtonPressed(this, e);
        }
    }

    public virtual void RedButtonStop(InputEventArgs e)
    {
        if (RedButtonReleased != null)
        {
            RedButtonReleased(this, e);
        }
    }

    public virtual void GreenButtonFire(InputEventArgs e)
    {
        if (GreenButtonPressed != null)
        {
            GreenButtonPressed(this, e);
        }
    }

    public virtual void GreenButtonStop(InputEventArgs e)
    {
        if (GreenButtonReleased != null)
        {
            GreenButtonReleased(this, e);
        }
    }

    public virtual void BlueButtonFire(InputEventArgs e)
    {
        if (BlueButtonPressed != null)
        {
            BlueButtonPressed(this, e);
        }
    }

    public virtual void BlueButtonStop(InputEventArgs e)
    {
        if (BlueButtonReleased != null)
        {
            BlueButtonReleased(this, e);
        }
    }

    public virtual void WhiteButtonFire(InputEventArgs e)
    {
        if (WhiteButtonPressed != null)
        {
            WhiteButtonPressed(this, e);
        }
    }

    public virtual void WhiteButtonStop(InputEventArgs e)
    {
        if (WhiteButtonReleased != null)
        {
            WhiteButtonReleased(this, e);
        }
    }

    public virtual void BlackButtonFire(InputEventArgs e)
    {
        if (BlackButtonPressed != null)
        {
            BlackButtonPressed(this, e);
        }
    }

    public virtual void BlackButtonStop(InputEventArgs e)
    {
        if (BlackButtonReleased != null)
        {
            BlackButtonReleased(this, e);
        }
    }

    public virtual void StickRight(InputEventArgs e)
    {
        if (StickDirectionRight != null)
        {
            StickDirectionRight(this, e);
        }
    }

    public virtual void StickLeft(InputEventArgs e)
    {
        if (StickDirectionLeft != null)
        {
            StickDirectionLeft(this, e);
        }
    }

    public virtual void StickDown(InputEventArgs e)
    {
        if (StickDirectionDown != null)
        {
            StickDirectionDown(this, e);
        }
    }

    public virtual void StickUp(InputEventArgs e)
    {
        if (StickDirectionUp != null)
        {
            StickDirectionUp(this, e);
        }
    }

    public virtual void StickMiddle(InputEventArgs e)
    {
        if (StickDirectionMiddle != null)
        {
            StickDirectionMiddle(this, e);
        }
    }

    public virtual void KeyDownListener()
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

    public virtual void KeyUpListener()
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