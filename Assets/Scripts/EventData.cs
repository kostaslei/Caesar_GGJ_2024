using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;


public class EventData
{
    public int ID { get; set; }
    public string Repeatable { get; set; }
    public string Weight { get; set; }
    public string CharacterArt { get; set; }
    public string Description { get; set; }
    public string LeftText { get; set; }
    public string RightText { get; set; }
    public string LeftAudience { get; set; }
    public string LeftMoney { get; set; }
    public string LeftSecurity { get; set; }
    public string LeftAchievement { get; set; }
    public string LeftExtra { get; set; }
    public string RightAudience { get; set; }
    public string RightMoney { get; set; }
    public string RightSecurity { get; set; }
    public string RightAchievements { get; set; }
    public string RightExtra { get; set; }

    public static EventData[] getData()
    {
        TextAsset xmlFile = Resources.Load<TextAsset>("output");
        // Parse the XML data
        XmlDocument xmlDoc = new XmlDocument(); // Provide your XML string here
        xmlDoc.LoadXml(xmlFile.text);
        // Parse XML data into array of EventData
        XmlNodeList rowNodes = xmlDoc.SelectNodes("/root/row");

        List<EventData> eventDataList = new List<EventData>();
        Debug.Log(rowNodes.Count);
        foreach (XmlNode rowNode in rowNodes)
        {
            EventData eventData = new EventData
            {
                ID = Int32.Parse(rowNode.SelectSingleNode("ID").InnerText),
                Repeatable = rowNode.SelectSingleNode("Repeatable").InnerText,
                Weight = rowNode.SelectSingleNode("Weight").InnerText,
                CharacterArt = rowNode.SelectSingleNode("Character_Art").InnerText,
                Description = rowNode.SelectSingleNode("Description").InnerText,
                LeftText = rowNode.SelectSingleNode("Left_Text").InnerText,
                RightText = rowNode.SelectSingleNode("Right_Text").InnerText,
                LeftAudience = rowNode.SelectSingleNode("Left_Audience").InnerText,
                LeftMoney = rowNode.SelectSingleNode("Left_Money").InnerText,
                LeftSecurity = rowNode.SelectSingleNode("Left_Security").InnerText,
                LeftAchievement = rowNode.SelectSingleNode("Left_Achievement").InnerText,
                LeftExtra = rowNode.SelectSingleNode("Left_Extra").InnerText,
                RightAudience = rowNode.SelectSingleNode("Right_Audience").InnerText,
                RightMoney = rowNode.SelectSingleNode("Right_Money").InnerText,
                RightSecurity = rowNode.SelectSingleNode("Right_Security").InnerText,
                RightAchievements = rowNode.SelectSingleNode("Right_Achievements").InnerText,
                RightExtra = rowNode.SelectSingleNode("Right_Extra").InnerText
            };

            eventDataList.Add(eventData);

        }
        return eventDataList.ToArray();
    }
}
