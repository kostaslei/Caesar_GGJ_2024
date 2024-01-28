using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GGJ
{
    public class Option
    {
        public string text;
        public float audience, money, security = 0;
        public string achievement, extra;
    }

    public class Card
    {
        public enum difficulty { tutorial, veryEasy, easy, medium, hard, veryHard, main_story_1, main_story_2, main_story_3, main_story_4, main_story_5, main_story_6, main_story_7, end };
     
        public int ID;
        public bool audience;
        public bool money;
        public bool security;
        public difficulty diff;
        public string name;
        public string character_art;
        public string description;
        public Option top = new Option();
        public Option bottom = new Option();

        public static difficulty StringToDiff(string str)
        {
            switch (str)
            {
                default:
                    return difficulty.easy;
                case "tutorial":
                    return difficulty.tutorial;
                case "very easy":
                    return difficulty.veryEasy;
                case "easy":
                    return difficulty.easy;
                case "medium":
                    return difficulty.medium;
                case "hard":
                    return difficulty.hard;
                case "very hard":
                    return difficulty.veryHard;
                case "main_story_1":
                    return difficulty.main_story_1;
                case "main_story_2":
                    return difficulty.main_story_2;
                case "main_story_3":
                    return difficulty.main_story_3;
                case "main_story_4":
                    return difficulty.main_story_4;
                case "main_story_5":
                    return difficulty.main_story_5;
                case "main_story_6":
                    return difficulty.main_story_6;
                case "main_story_7":
                    return difficulty.main_story_7;
            }
        }
    }
}