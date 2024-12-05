using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaTableEngine.Examples
{
    public class DisplayLiteScript : MonoBehaviour
    {

        public DaTableLite datable;
        public GameObject displayElementPrefab;

        // Use this for initialization
        void Start()
        {
            for (int i = 1; i < datable.elementsCount; i++)
            {
                var obj = Instantiate(displayElementPrefab, transform);
                var com = obj.GetComponent<DisplayElementLiteScript>();

                com.element = datable.GetElement<ExampleDatableElement>(i);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}