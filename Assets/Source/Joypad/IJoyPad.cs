using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 */
namespace ITU.Joypad
{
    public interface IJoypad
    {
        // Buttons
        event EventHandler YellowButtonPressed;
        event EventHandler YellowButtonReleased;
        event EventHandler RedButtonPressed;
        event EventHandler RedButtonReleased;
        event EventHandler GreenButtonPressed;
        event EventHandler GreenButtonReleased;
        event EventHandler BlueButtonPressed;
        event EventHandler BlueButtonReleased;
        event EventHandler WhiteButtonPressed;
        event EventHandler WhiteButtonReleased;
        event EventHandler BlackButtonPressed;
        event EventHandler BlackButtonReleased;

        // Axis
        event EventHandler StickDirectionRight;
        event EventHandler StickDirectionLeft;
        event EventHandler StickDirectionDown;
        event EventHandler StickDirectionUp;
        event EventHandler StickDirectionMiddle;

        void init();
        void SetupKeyCodes();
        void KeyDownListener();
        void KeyUpListener();

        void YellowButtonFire(InputEventArgs e);
        void YellowButtonStop(InputEventArgs e);
        void RedButtonFire(InputEventArgs e);
        void RedButtonStop(InputEventArgs e);
        void GreenButtonFire(InputEventArgs e);
        void GreenButtonStop(InputEventArgs e);
        void BlueButtonFire(InputEventArgs e);
        void BlueButtonStop(InputEventArgs e);
        void WhiteButtonFire(InputEventArgs e);
        void WhiteButtonStop(InputEventArgs e);
        void BlackButtonFire(InputEventArgs e);
        void BlackButtonStop(InputEventArgs e);

        void StickRight(InputEventArgs e);
        void StickLeft(InputEventArgs e);
        void StickDown(InputEventArgs e);
        void StickUp(InputEventArgs e);
        void StickMiddle(InputEventArgs e);
    }
}