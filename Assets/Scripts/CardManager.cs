using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static GGJ.CardBehaviour;

namespace GGJ
{
    public class CardManager : MonoBehaviour
    {
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
            if (Input.GetKeyUp(KeyCode.Escape)) 
            {
                Option a = new Option();
                a.audience = 0.2f;
                a.money = -0.5f;
                a.security = 0f;

                selectedOption = a;

                onOptionSelected.Invoke();
            }
        }

        void UpdateStats()
        {
            moneyStat.fillAmount += selectedOption.audience;
            audienceStat.fillAmount += selectedOption.money;
            securityStat.fillAmount += selectedOption.security;
        }
    }

}
