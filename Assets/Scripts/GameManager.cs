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
        Card currentCard;

        public static UnityEvent onOptionSelected = new UnityEvent();




        private void Awake()
        {
            cards = DataHandler.getData();
            currentCard = SetCard(cards[0]);
        }

        // Start is called before the first frame update
        void Start()
        {
            onOptionSelected.AddListener(UpdateStats);


        }

        // Update is called once per frame
        public void NextCard()
        {
            currentCard = SetCard(cards[dayIndex]);
        }

        void UpdateStats()
        {
            float newAudience = selectedOption.audience + currentSpecialEvent.audience;
            float newMoney = selectedOption.money + currentSpecialEvent.money;
            float newSecurity = selectedOption.security + currentSpecialEvent.security;

            audienceStat.fillAmount += newAudience;
            moneyStat.fillAmount += newMoney;
            securityStat.fillAmount += newSecurity;

            if (newAudience >= 0) { StartCoroutine(ChangeColor(audienceStat, true)); }
            else { StartCoroutine(ChangeColor(audienceStat, false)); }

            if (newMoney >= 0) { StartCoroutine(ChangeColor(moneyStat, true)); }
            else { StartCoroutine(ChangeColor(moneyStat, false)); }

            if (newSecurity >= 0) { StartCoroutine(ChangeColor(securityStat, true)); }
            else { StartCoroutine(ChangeColor(securityStat, false)); }

        }

        IEnumerator ChangeColor(Image img, bool isPositive)
        {
            Color currentColor = img.color;

            if (isPositive) { img.color = Color.green; }
            else { img.color = Color.red; }

            yield return new WaitForSeconds(1f);

            img.color = currentColor;

            yield return null; 
        }

        public void SetSelectedOption(int i)
        {
            if (i == 0) 
            {
                selectedOption = currentCard.top;
            }
            else
            {
                selectedOption = currentCard.bottom;
            }
            
            onOptionSelected.Invoke();
        }

        public Card SetCard(Card card)
        {
            daysCounter.text = dayIndex + " Days";
            dayIndex++;
            eventDescription.text = card.description;
            option1.GetComponentInChildren<TMP_Text>().text = card.top.text;
            option2.GetComponentInChildren<TMP_Text>().text = card.bottom.text;

            return card;
        }
    }
}