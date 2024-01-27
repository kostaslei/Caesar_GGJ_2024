using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;

namespace GGJ
{
    public class DataHandler
    {
        public static Card[] getData()
        {
            TextAsset xmlFile = Resources.Load<TextAsset>("output");
            // Parse the XML data
            XmlDocument xmlDoc = new XmlDocument(); // Provide your XML string here
            xmlDoc.LoadXml(xmlFile.text);
            // Parse XML data into array of EventData
            XmlNodeList rowNodes = xmlDoc.SelectNodes("/root/row");

            List<Card> eventDataList = new List<Card>();
            Debug.Log(rowNodes.Count);
            foreach (XmlNode rowNode in rowNodes)
            {
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

            }
            return eventDataList.ToArray();
        }
    }
}