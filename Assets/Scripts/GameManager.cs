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
        public GameObject audienceIndicator, moneyIndicator, securityIndicator;

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
        private void FixedUpdate()
        {
            
        }

        public void OnPointerEnterOption(int index)
        {
            Option hoveringOption;

            if (index == 0) { hoveringOption = currentCard.top; }
            else { hoveringOption = currentCard.bottom; } 

            if (hoveringOption.audience != 0) { audienceIndicator.SetActive(true); }
            if (hoveringOption.money != 0) { moneyIndicator.SetActive(true); }
            if (hoveringOption.security != 0) { securityIndicator.SetActive(true); }
        }

        public void OnPointerExitOption()
        {
            audienceIndicator.SetActive(false);
            moneyIndicator.SetActive(false);
            securityIndicator.SetActive(false);
        }

        public void NextCard()
        {
            dayIndex++;
            currentCard = SetCard(cards[dayIndex]);
        }

        public void GameOverCard(gameOver losingCondition)
        {
            //dayIndex = 0;
            //daysCounter.text = dayIndex + " Days";
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
            float newAudience = selectedOption.audience + currentSpecialEvent.audience;
            float newMoney = selectedOption.money + currentSpecialEvent.money;
            float newSecurity = selectedOption.security + currentSpecialEvent.security;

            StartCoroutine(FillColor(audienceStat, newAudience));
            StartCoroutine(FillColor(moneyStat, newMoney));
            StartCoroutine(FillColor(securityStat, newSecurity));

            if (newAudience >= 0) { StartCoroutine(ChangeColor(audienceStat, true)); }
            else { StartCoroutine(ChangeColor(audienceStat, false)); }

            if (newMoney >= 0) { StartCoroutine(ChangeColor(moneyStat, true)); }
            else { StartCoroutine(ChangeColor(moneyStat, false)); }

            if (newSecurity >= 0) { StartCoroutine(ChangeColor(securityStat, true)); }
            else { StartCoroutine(ChangeColor(securityStat, false)); }


            if (moneyStat.fillAmount == 0)
            {
                OnGameOver.Invoke(gameOver.MoneyDown);
            }
            else if (moneyStat.fillAmount == 1)
            {
                OnGameOver.Invoke(gameOver.MoneyUp);
            }
            else if (audienceStat.fillAmount == 0)
            {
                OnGameOver.Invoke(gameOver.AudienceDown);
            }
            else if (audienceStat.fillAmount == 1)
            {
                OnGameOver.Invoke(gameOver.AudienceUp);
            }
            else if (securityStat.fillAmount == 0)
            {
                OnGameOver.Invoke(gameOver.SecurityDown);
            }
            else if (securityStat.fillAmount == 1)
            {
                OnGameOver.Invoke(gameOver.SecurityUp);
            }
            else
            {
                NextCard();
            }
        }

        IEnumerator FillColor(Image img, float amount)
        {
            if (amount != 0)
            {
                float target = Mathf.Clamp01(img.fillAmount + amount);
                Debug.Log(target);


                float multiplier = 1;

                if (amount < 0)
                {
                    multiplier = -1;
                }

                while (true)
                {
                    img.fillAmount += 0.01f * multiplier;

                    Debug.Log(img.fillAmount);

                    yield return new WaitForSeconds(0.01f);

                    if (img.fillAmount == target) continue;
                }
            }

            yield return null;
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