using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GGJ
{
    public class GameManager : MonoBehaviour
    {
        int dayIndex = 0;
        public TMP_Text daysCounter;

        [Header("STATS")]
        public Image audienceStat;
        public Image moneyStat;
        public Image securityStat;

        [Header("EVENT")]
        public Image eventImage;
        public TMP_Text eventDescription;
        public Button option1;
        public Button option2;

        [Header("DATA")]
        public Option selectedOption;

        public static UnityEvent onOptionSelected = new UnityEvent();




        // Start is called before the first frame update
        void Start()
        {
            onOptionSelected.AddListener(UpdateStats);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void UpdateStats()
        {
            moneyStat.fillAmount += selectedOption.audience;
            audienceStat.fillAmount += selectedOption.money;
            securityStat.fillAmount += selectedOption.security;
        }

        public void SetSelectedOption(int i)
        {
            if (i == 0) 
            {
                selectedOption = CardBehaviour.instance.top;
            }
            else
            {
                selectedOption = CardBehaviour.instance.bottom;
            }

            onOptionSelected.Invoke();
        }
    }
}