using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using DaTableEngine;

namespace DaTableEngine.Examples
{
    public class ExampleDatableElement : DaTableElement
    {
        public Sprite icon;
        [TextArea]
        public string text;
    }
}