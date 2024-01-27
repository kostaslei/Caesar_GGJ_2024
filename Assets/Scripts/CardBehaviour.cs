using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GGJ
{

    public class CardBehaviour : MonoBehaviour
    {
        public enum difficulty { tutorial, veryEasy, easy, medium, hard, veryHard, main_story_1, main_story_2, main_story_3, main_story_4, main_story_5, main_story_6, main_story_7 };
        public class Option
        {
            public string text;
            public float audience, money, security;
            public string achievement, extra;
        }

        public int ID;
        public bool audience;
        public bool money;
        public bool security;
        public difficulty diff;
        public Image character_art;
        public string description;
        public Option top;
        public Option bottom;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void FixedUpdate()
        {

        }
    }
}
    