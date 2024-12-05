using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

namespace DaTableEngine.Examples
{
    public class DisplayElementLiteScript : MonoBehaviour
    {

        public Image icon;
        public Text text;

        [HideInInspector] public ExampleDatableElement element;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            icon.sprite = element.icon;

            text.text =
                "[" + element.name + "]\n" +
                element.text;
        }
    }
}