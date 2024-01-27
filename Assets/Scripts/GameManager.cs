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
        public int dayIndex = 0;
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
        public SpecialEventSO currentSpecialEvent;

        Card[] cards;

        public static UnityEvent onOptionSelected = new UnityEvent();




        private void Awake()
        {
            cards = DataHandler.getData();

            selectedOption = cards[0].top;

        }

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
            moneyStat.fillAmount += selectedOption.audience + currentSpecialEvent.audience;
            audienceStat.fillAmount += selectedOption.money + currentSpecialEvent.money;
            securityStat.fillAmount += selectedOption.security + currentSpecialEvent.security;
        }

        public void SetSelectedOption(int i)
        {
            /*
            if (i == 0) 
            {
                selectedOption = Card.top;
            }
            else
            {
                selectedOption = Card.instance.bottom;
            }
            */
            onOptionSelected.Invoke();
        }
    }
}