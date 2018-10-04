using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public JoystickController joystick;
    public Image[] buttonImages = new Image[6];
    public Image[] directionImages = new Image[4];
    public float PressedAlpha = 0.2f;
    private float NormalAlpha = 1.0f;

    // Use this for initialization
    void Start()
    {
        joystick.init();
        joystick.YellowButtonPressed += Joystick_YellowButtonPressed;
        joystick.YellowButtonReleased += Joystick_YellowButtonReleased;
        joystick.RedButtonPressed += Joystick_RedButtonPressed;
        joystick.RedButtonReleased += Joystick_RedButtonReleased;
        joystick.GreenButtonPressed += Joystick_GreenButtonPressed;
        joystick.GreenButtonReleased += Joystick_GreenButtonReleased;
        joystick.BlueButtonPressed += Joystick_BlueButtonPressed;
        joystick.BlueButtonReleased += Joystick_BlueButtonReleased;
        joystick.WhiteButtonPressed += Joystick_WhiteButtonPressed;
        joystick.WhiteButtonReleased += Joystick_WhiteButtonReleased;
        joystick.BlackButtonPressed += Joystick_BlackButtonPressed;
        joystick.BlackButtonReleased += Joystick_BlackButtonReleased;
        joystick.StickDirectionRight += Joystick_StickDirectionRight;
        joystick.StickDirectionLeft += Joystick_StickDirectionLeft;
        joystick.StickDirectionDown += Joystick_StickDirectionDown;
        joystick.StickDirectionUp += Joystick_StickDirectionUp;
        joystick.StickDirectionMiddle += Joystick_StickDirectionMiddle;
    }

    public void Update()
    {
        joystick.KeyDownListener();
        joystick.KeyUpListener();
    }

    private void Joystick_YellowButtonPressed(object sender, System.EventArgs e)
    {
        Color color = buttonImages[0].color;
        buttonImages[0].color = new Color(color.r, color.g, color.b, PressedAlpha);
    }

    private void Joystick_YellowButtonReleased(object sender, System.EventArgs e)
    {
        Color color = buttonImages[0].color;
        buttonImages[0].color = new Color(color.r, color.g, color.b, NormalAlpha);
    }

    private void Joystick_RedButtonPressed(object sender, System.EventArgs e)
    {
        Color color = buttonImages[1].color;
        buttonImages[1].color = new Color(color.r, color.g, color.b, PressedAlpha);
    }

    private void Joystick_RedButtonReleased(object sender, System.EventArgs e)
    {
        Color color = buttonImages[1].color;
        buttonImages[1].color = new Color(color.r, color.g, color.b, NormalAlpha);
    }

    private void Joystick_GreenButtonPressed(object sender, System.EventArgs e)
    {
        Color color = buttonImages[2].color;
        buttonImages[2].color = new Color(color.r, color.g, color.b, PressedAlpha);
    }

    private void Joystick_GreenButtonReleased(object sender, System.EventArgs e)
    {
        Color color = buttonImages[2].color;
        buttonImages[2].color = new Color(color.r, color.g, color.b, NormalAlpha);
    }

    private void Joystick_BlueButtonPressed(object sender, System.EventArgs e)
    {
        Color color = buttonImages[3].color;
        buttonImages[3].color = new Color(color.r, color.g, color.b, PressedAlpha);
    }

    private void Joystick_BlueButtonReleased(object sender, System.EventArgs e)
    {
        Color color = buttonImages[3].color;
        buttonImages[3].color = new Color(color.r, color.g, color.b, NormalAlpha);
    }

    private void Joystick_WhiteButtonPressed(object sender, System.EventArgs e)
    {
        Color color = buttonImages[4].color;
        buttonImages[4].color = new Color(color.r, color.g, color.b, PressedAlpha);
    }

    private void Joystick_WhiteButtonReleased(object sender, System.EventArgs e)
    {
        Color color = buttonImages[4].color;
        buttonImages[4].color = new Color(color.r, color.g, color.b, NormalAlpha);
    }

    private void Joystick_BlackButtonPressed(object sender, System.EventArgs e)
    {
        Color color = buttonImages[5].color;
        buttonImages[5].color = new Color(color.r, color.g, color.b, PressedAlpha);
    }

    private void Joystick_BlackButtonReleased(object sender, System.EventArgs e)
    {
        Color color = buttonImages[5].color;
        buttonImages[5].color = new Color(color.r, color.g, color.b, NormalAlpha);
    }

    private void Joystick_StickDirectionRight(object sender, System.EventArgs e)
    {
        Color color = directionImages[0].color;
        directionImages[0].color = new Color(color.r, color.g, color.b, PressedAlpha);
    }

    private void Joystick_StickDirectionLeft(object sender, System.EventArgs e)
    {
        Color color = directionImages[1].color;
        directionImages[1].color = new Color(color.r, color.g, color.b, PressedAlpha);
    }

    private void Joystick_StickDirectionDown(object sender, System.EventArgs e)
    {
        Color color = directionImages[2].color;
        directionImages[2].color = new Color(color.r, color.g, color.b, PressedAlpha);
    }

    private void Joystick_StickDirectionUp(object sender, System.EventArgs e)
    {
        Color color = directionImages[3].color;
        directionImages[3].color = new Color(color.r, color.g, color.b, PressedAlpha);
    }

    private void Joystick_StickDirectionMiddle(object sender, System.EventArgs e)
    {
        InputEventArgs args = (InputEventArgs)e;
        int imageIndex = 0;
        KeyCode key = args.GetKey();

        // For development purposes. Can be commented out or should be removed for production.
        if (joystick.GetType() == typeof(JoystickControllerTest))
        {
            if (key == joystick.RIGHT)
            {
                imageIndex = 0;
            }
            else if (key == joystick.LEFT)
            {
                imageIndex = 1;
            }
            else if (key == joystick.DOWN)
            {
                imageIndex = 2;
            }
            else if (key == joystick.UP)
            {
                imageIndex = 3;
            }
        }
        else
        {
            switch (key)
            {
                case KeyCode.Joystick2Button4:
                case KeyCode.Joystick1Button4:
                    imageIndex = 0;
                    break;
                case KeyCode.Joystick2Button5:
                case KeyCode.Joystick1Button5:
                    imageIndex = 1;
                    break;
                case KeyCode.Joystick2Button6:
                case KeyCode.Joystick1Button6:
                    imageIndex = 2;
                    break;
                case KeyCode.Joystick2Button7:
                case KeyCode.Joystick1Button7:
                    imageIndex = 3;
                    break;
            }
        }
        Color color = directionImages[imageIndex].color;
        directionImages[imageIndex].color = new Color(color.r, color.g, color.b, NormalAlpha);
    }
}
