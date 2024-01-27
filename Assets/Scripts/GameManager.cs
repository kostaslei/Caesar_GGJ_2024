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
        public enum gameOver {AudienceUp, AudienceDown, MoneyUp, MoneyDown, SecurityUp, SecurityDown};

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

        public static UnityEvent OnOptionSelected = new UnityEvent();
        public static UnityEvent<gameOver> OnGameOver = new UnityEvent<gameOver>();




        private void Awake()
        {
            cards = DataHandler.getData();
            currentCard = SetCard(cards[0]);
        }

        // Start is called before the first frame update
        void Start()
        {
            OnOptionSelected.AddListener(UpdateStats);
            OnGameOver.AddListener(GameOverCard);

        }

        // Update is called once per frame
        public void NextCard()
        {
            dayIndex++;
            currentCard = SetCard(cards[dayIndex]);
        }

        public void GameOverCard(gameOver losingCondition)
        {
            switch (losingCondition)
            {
                case gameOver.AudienceUp:
                    //currentCard = SetCard(cards[-]);
                    break;
                case gameOver.AudienceDown:
                    //currentCard = SetCard(cards[-]);
                    break;
                case gameOver.MoneyUp:
                    //currentCard = SetCard(cards[-]);
                    break;
                case gameOver.MoneyDown:
                    //currentCard = SetCard(cards[-]);
                    break;
                case gameOver.SecurityUp:
                    //currentCard = SetCard(cards[-]);
                    break;
                case gameOver.SecurityDown:
                    //currentCard = SetCard(cards[-]);
                    break;
                default:
                    break;
            }
        }

        void UpdateStats()
        {
            moneyStat.fillAmount += selectedOption.audience + currentSpecialEvent.audience;
            audienceStat.fillAmount += selectedOption.money + currentSpecialEvent.money;
            securityStat.fillAmount += selectedOption.security + currentSpecialEvent.security;

            if (moneyStat.fillAmount == 0)
            {

            }
            else if (moneyStat.fillAmount == 1)
            {

            }
            else if (audienceStat.fillAmount == 0)
            {

            }
            else if (audienceStat.fillAmount == 1)
            {

            }
            else if (securityStat.fillAmount == 0)
            {

            }
            else if (securityStat.fillAmount == 1)
            {

            }
            else
            {
                NextCard();
            }
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
            
            OnOptionSelected.Invoke();
        }

        public Card SetCard(Card card)
        {
            daysCounter.text = dayIndex + " Days";
            eventDescription.text = card.description;
            option1.GetComponentInChildren<TMP_Text>().text = card.top.text;
            option2.GetComponentInChildren<TMP_Text>().text = card.bottom.text;

            return card;
        }
    }
}