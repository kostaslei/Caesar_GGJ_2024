using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
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
        Color32 fillColor;

        Card[] cards;
        Card currentCard;

        public static UnityEvent OnOptionSelected = new UnityEvent();
        public static UnityEvent<gameOver> OnGameOver = new UnityEvent<gameOver>();

        private DataHandler dataHandler;


        private void Awake()
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;


            dataHandler = new DataHandler();
            cards = dataHandler.events;
            currentCard = SetCard(cards[0]);
            fillColor = new Color32(119, 195, 245, 255);
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
            switch (losingCondition)
            {
                case gameOver.AudienceUp:
                    currentCard = SetCard(cards[40]);
                    break;
                case gameOver.AudienceDown:
                    currentCard = SetCard(cards[41]);
                    break;
                case gameOver.MoneyUp:
                    currentCard = SetCard(cards[42]);
                    break;
                case gameOver.MoneyDown:
                    currentCard = SetCard(cards[43]);
                    break;
                case gameOver.SecurityUp:
                    currentCard = SetCard(cards[44]);
                    break;
                case gameOver.SecurityDown:
                    currentCard = SetCard(cards[45]);
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

            if (newAudience > 0) { StartCoroutine(ChangeColor(audienceStat, true)); }
            else if (newAudience < 0) { StartCoroutine(ChangeColor(audienceStat, false)); }

            if (newMoney > 0) { StartCoroutine(ChangeColor(moneyStat, true)); }
            else if (newMoney < 0) { StartCoroutine(ChangeColor(moneyStat, false)); }

            if (newSecurity > 0) { StartCoroutine(ChangeColor(securityStat, true)); }
            else if (newSecurity < 0) { StartCoroutine(ChangeColor(securityStat, false)); }


            if (audienceStat.fillAmount == 0)
            {
                OnGameOver.Invoke(gameOver.AudienceDown);
            }
            else if (audienceStat.fillAmount == 1)
            {
                OnGameOver.Invoke(gameOver.AudienceUp);
            }
            else if (moneyStat.fillAmount == 0)
            {
                OnGameOver.Invoke(gameOver.MoneyDown);
            }
            else if (moneyStat.fillAmount == 1)
            {
                OnGameOver.Invoke(gameOver.MoneyUp);
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
                OnPointerExitOption();
                NextCard();
            }
        }

        IEnumerator FillColor(Image img, float amount)
        {
            if (amount != 0)
            {
                float target = Mathf.Clamp01(img.fillAmount + amount);
                float time = 0;
                float speed = 2.0f;
                float initialProgress = img.fillAmount;

                while (time < 1)
                {
                    img.fillAmount = Mathf.Lerp(initialProgress, target, time);
                    time += Time.deltaTime * speed;

                    yield return null;
                }

                img.fillAmount = target;
            }

            yield return null;
        }

        IEnumerator ChangeColor(Image img, bool isPositive)
        {
            if (isPositive) { img.color = Color.green; }
            else { img.color = Color.red; }

            yield return new WaitForSeconds(1f);

            img.color = fillColor;

            yield return null; 
        }

        public void SetSelectedOption(int i)
        {   
            switch (currentCard.diff)
            {
                default:
                    if (i == 0) selectedOption = currentCard.top;
                    else selectedOption = currentCard.bottom;
                    OnOptionSelected.Invoke();
                    break;
                case Card.difficulty.end:
                    if (i == 0) Restart();
                    else ExitToMainMenu();
                    break;
            }

            EventSystem.current.SetSelectedGameObject(null);
        }

        public void Restart()
        {
            dayIndex = 0;
            daysCounter.text = dayIndex + " Days";
            currentCard = SetCard(cards[0]);
            audienceStat.fillAmount = 0.5f;
            moneyStat.fillAmount = 0.5f;
            securityStat.fillAmount = 0.5f;
        }
        public void ExitToMainMenu()
        {
            MenuManager.EnterMainMenu();
        }

        public Card SetCard(Card card)
        {
            daysCounter.text = card.DAY + " Days";
            eventImage.sprite = Resources.Load<Sprite>(card.character_art);
            Debug.Log(card.character_art);
            eventDescription.text = card.description;
            option1.GetComponentInChildren<TMP_Text>().text = card.top.text;
            option2.GetComponentInChildren<TMP_Text>().text = card.bottom.text;

            return card;
        }
    }
}