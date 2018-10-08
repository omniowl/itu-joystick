You can find the .unitypackage file [here](https://github.com/omniowl/itu-joystick/blob/master/ITUJoypadController.unitypackage)

# Introduction
This is the Joystick example made for the ITU Joystick setup. This is just some barebones documentation.

## Please Note
All of the input is handled like Joystick Buttons, even the stick. The reason for this is because whoever produced the Arcade Stick must
have been overworked or something, because the axis goes from 1 to -2 which makes no sense at all.
So to combat this we turned the stick into buttons. This doesn't actually matter because there is no in-between states on this stick
like you'd find on an Xbox360 controller for example. It's 1 or 0. Go or No Go. The Black button is reserved as a "Start" button.
It should only be used to access a menu to get out of the game or otherwise options menu, not as an action button.

## Button Mappings to Unity
The board itself which controls all the input has two sides; P0 and P1. P0 is Player 1 and P1 is Player 2. However there is a catch;
P0 reads from Joystick 2 and P1 reads from Joystick 1 (God knows why). But we still treat them like P0 is Player 1 and P1 is Player 2.
Might be a little confusing to begin with. The actual mapping is fairly straight forward. We have 6 Buttons per player (5 if you take
away the Black "Start Button") and 4 buttons that acts as the Axis.

**The Map**:
* **PLAYER 1**
  * **BUTTONS**
    * YELLOW BUTTON - Joystick2Button0
    * RED BUTTON - Joystick2Button1
    * GREEN BUTTON - Joystick2Button2
    * BLUE BUTTON - Joystick2Button3
    * WHITE BUTTON - Joystick2Button7
    * BLACK BUTTON - Joystick2Button8
  * **STICK**
    * RIGHT - Joystick2Button4
    * LEFT - Joystick2Button5
    * DOWN - Joystick2Button6
    * UP - Joystick2Button7
* **PLAYER 2**
  * **BUTTONS**
    * YELLOW BUTTON - Joystick1Button0
    * RED BUTTON - Joystick1Button1
    * GREEN BUTTON - Joystick1Button2
    * BLUE BUTTON - Joystick1Button3
    * WHITE BUTTON - Joystick1Button7
    * BLACK BUTTON - Joystick1Button8
  * **STICK**
    * RIGHT - Joystick1Button4
    * LEFT - Joystick1Button5
    * DOWN - Joystick1Button6
    * UP - Joystick1Button7

With that in mind do not fret! A script have already been made to map all of this to System Events in C# using the `IJoypad`
and `JoystickController` files. This is merely left here for your convenience, should you want to write your own implementation. You can make a controller object by Right-Clicking in your Assets and go to Create->Joystick Controller like so:

![Right Click Menu](https://i.imgur.com/oCShe7V.png)

## For Testing
There is a controller already written for testing purposes since the arcade controller won't be physically accessible unless you test on the actual arcade (which will be seldom compared to on your computer). The `JoystickControllerTest` class is an extension of the `JoystickController` class, so you can still ask for a `JoystickController` in your production scripts and simply use the test Scripts in their place. When you create a `ScriptableObject` of type `JoystickControllerTest` it has a bunch of inputs that can be assigned from your keyboard (Or even a JoystickController port, should you wish to).

# IJoypad
The `IJoypad` interface is made for what is considered a necessary implementation for using this setup. But as mentioned above you can
make your own implementation should you so desire. The Joypad has a bunch of Event Callers that you can subscribe to like below:

`IJoypad.cs`
```c#
...
event EventHandler YellowButtonPressed;
event EventHandler YellowButtonReleased;
...
void YellowButtonFire(InputEventArgs e);
void YellowButtonStop(InputEventArgs e);
```

Then in our implementation, the `JoystickController` we have this:

`JoystickController.cs`
```c#
...
private Dictionary<KeyCode, Action<InputEventArgs>> FunctionDictionaryDown;
private Dictionary<KeyCode, Action<InputEventArgs>> FunctionDictionaryUp;
...
{ YELLOW, new Action<InputEventArgs>(YellowButtonFire) },
...
{ YELLOW, new Action<InputEventArgs>(YellowButtonStop) },
...
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
...
```

Simple event Setup. So when we actually want to use these events we can do something like in the example code found in `UIController`:

`UIController.cs`
```c#
...
public JoystickController joystick;
...
void Start()
{
    joystick.init();
    joystick.YellowButtonPressed += Joystick_YellowButtonPressed;
    joystick.YellowButtonReleased += Joystick_YellowButtonReleased;
...
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
...
```

Making a controller that just listens for events that are polled every frame and then letting whoever needs to know about it
know through events. Fairly simple. The code currently in the repo (23/09/2018) then supports the below (Takes you to a YouTube video):

[![](http://img.youtube.com/vi/vcr0sIwLlmo/0.jpg)](http://www.youtube.com/watch?v=vcr0sIwLlmo "Xin-Mo Dual Arcade demonstration in Unity 2018")

Pretty smooth!
