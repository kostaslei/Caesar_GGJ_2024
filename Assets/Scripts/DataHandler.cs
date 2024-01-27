using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;

namespace GGJ
{
    public class DataHandler
    {
        public CardBehaviour[] getData()
        {
            TextAsset xmlFile = Resources.Load<TextAsset>("output");
            // Parse the XML data
            XmlDocument xmlDoc = new XmlDocument(); // Provide your XML string here
            xmlDoc.LoadXml(xmlFile.text);
            // Parse XML data into array of EventData
            XmlNodeList rowNodes = xmlDoc.SelectNodes("/root/row");

            List<CardBehaviour> eventDataList = new List<CardBehaviour>();
            Debug.Log(rowNodes.Count);
            foreach (XmlNode rowNode in rowNodes)
            {
                CardBehaviour cards = new CardBehaviour
                {
                    ID = Int32.Parse(rowNode.SelectSingleNode("ID").InnerText),
                    audience = bool.Parse(rowNode.SelectSingleNode("Audience").InnerText),
                    money = bool.Parse(rowNode.SelectSingleNode("Money").InnerText),
                    security = bool.Parse(rowNode.SelectSingleNode("Security").InnerText),
                    diff = (CardBehaviour.difficulty)Enum.Parse(typeof(CardBehaviour.difficulty), rowNode.SelectSingleNode("Difficulty").InnerText),
                    character_art = rowNode.SelectSingleNode("Character_Art").InnerText,
                    description = rowNode.SelectSingleNode("Description").InnerText,
                    top = new CardBehaviour.Option
                    {
                        text = rowNode.SelectSingleNode("Left_Text").InnerText,
                        audience = float.Parse(rowNode.SelectSingleNode("Left_Audience").InnerText),
                        money = float.Parse(rowNode.SelectSingleNode("Left_Money").InnerText),
                        security = float.Parse(rowNode.SelectSingleNode("Left_Security").InnerText),
                        achievement = "",
                        extra = rowNode.SelectSingleNode("Left_Extra").InnerText
                    },
                    bottom = new CardBehaviour.Option
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