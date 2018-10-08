using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ITU.Joypad
{
    public class InputEventArgs : EventArgs
    {
        readonly KeyCode Key;

        public InputEventArgs(KeyCode key)
        {
            this.Key = key;
        }

        public KeyCode GetKey()
        {
            return Key;
        }
    }
}