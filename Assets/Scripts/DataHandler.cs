using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;
using System.Linq;

namespace GGJ
{
    public class DataHandler
    {

        public Card[] events;

        public DataHandler()
        {
            events = getData();
        }

        private static Card[] getData()
        {
            TextAsset xmlFile = Resources.Load<TextAsset>("GGJ 2024 - 30 days fake");
            // Parse the XML data
            XmlDocument xmlDoc = new XmlDocument(); // Provide your XML string here
            xmlDoc.LoadXml(xmlFile.text);
            // Parse XML data into array of EventData
            XmlNodeList rowNodes = xmlDoc.SelectNodes("/root/row");

            List<Card> eventDataList = new List<Card>();
            Debug.Log(rowNodes.Count);
            int index = 0;
            foreach (XmlNode rowNode in rowNodes)
            {
                Debug.Log(index);
                Card cards = new Card
                {
                    ID = Int32.Parse(rowNode.SelectSingleNode("ID").InnerText),
                    audience = bool.Parse(rowNode.SelectSingleNode("Audience").InnerText),
                    money = bool.Parse(rowNode.SelectSingleNode("Money").InnerText),
                    security = bool.Parse(rowNode.SelectSingleNode("Security").InnerText),
                    diff = (Card.difficulty)Enum.Parse(typeof(Card.difficulty), rowNode.SelectSingleNode("Difficulty").InnerText),
                    character_art = rowNode.SelectSingleNode("Character_Art").InnerText,
                    description = rowNode.SelectSingleNode("Description").InnerText,
                    top = new Option
                    {
                        text = rowNode.SelectSingleNode("Left_Text").InnerText,
                        audience = float.Parse(rowNode.SelectSingleNode("Left_Audience").InnerText),
                        money = float.Parse(rowNode.SelectSingleNode("Left_Money").InnerText),
                        security = float.Parse(rowNode.SelectSingleNode("Left_Security").InnerText),
                        achievement = "",
                        extra = rowNode.SelectSingleNode("Left_Extra").InnerText
                    },
                    bottom = new Option
                    {
                        text = rowNode.SelectSingleNode("Right_Text").InnerText,
                        audience = float.Parse(rowNode.SelectSingleNode("Right_Audience").InnerText),
                        money = float.Parse(rowNode.SelectSingleNode("Right_Money").InnerText),
                        security = float.Parse(rowNode.SelectSingleNode("Right_Security").InnerText),
                        achievement = "",
                        extra = rowNode.SelectSingleNode("Right_Extra").InnerText
                    }
                };

                eventDataList.Add(cards);
                index++;
            }
            return eventDataList.ToArray();
        }

        public Card[] getDataByDifficulty(Card.difficulty difficulty)
        {
            return events.Where(dict => dict.diff == difficulty).ToArray();
        }
    }
}