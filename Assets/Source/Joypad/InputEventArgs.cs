using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class InputEventArgs : EventArgs
{
    private KeyCode Key;

    public InputEventArgs(KeyCode key)
    {
        this.Key = key;
    }

    public KeyCode GetKey()
    {
        return Key;
    }
}
