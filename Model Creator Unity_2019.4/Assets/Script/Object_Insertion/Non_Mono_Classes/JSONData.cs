using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class JSONData
{
    private List<Vector3> startPosValues, scalValues, rotationValues;
    private List<Color> color;
    private List<string> objType;
    private List<double> objLength;

    public void JsonDataExtraction(string jsonString)
    {

        startPosValues = new List<Vector3>();
        scalValues = new List<Vector3>();
        rotationValues = new List<Vector3>();
        color = new List<Color>();
        objType = new List<string>();
        objLength = new List<double>();

        JObject jObject = JObject.Parse(jsonString);//converting json string to json obj
        
        TockenExtraction(jObject, "Walls", 10, Color.white);
        TockenExtraction(jObject, "Windows", 30, Color.red);
        TockenExtraction(jObject, "Doors", 30, Color.yellow);


    }

    private void TockenExtraction(JObject jasonObject ,string tokenName, int objectHeight, Color defaultColor)
    {
        var tokenArray = (JArray)jasonObject.SelectToken(tokenName);//taking all values in wall tocken as an array

        foreach (JToken extractedToken in tokenArray)
        {
            var startPosition = (string)extractedToken.SelectToken("StartingPoint");
            var endingPosition = (string)extractedToken.SelectToken("EndingPoint");
            var angleInRadian = (float)extractedToken.SelectToken("AngleInRadian");
            var length = (double)extractedToken.SelectToken("Length");

            var commaPosition = startPosition.IndexOf(',');//comma pos in startPos string
            var stringLength = startPosition.Length - 1;//total length of startPos string
            float[] wallStartPos = { System.Convert.ToSingle(startPosition.Substring(0, commaPosition - 1)), System.Convert.ToSingle(startPosition.Substring(commaPosition + 1, stringLength - commaPosition)) };


            commaPosition = endingPosition.IndexOf(',');//comma pos in scalValue string
            stringLength = endingPosition.Length - 1;//total length of scalValue string
            float[] wallEndPos = { System.Convert.ToSingle(endingPosition.Substring(0, commaPosition - 1)), System.Convert.ToSingle(endingPosition.Substring(commaPosition + 1, stringLength - commaPosition)) };

            startPosValues.Add(new Vector3(wallStartPos[0] / 50, 1, wallStartPos[1] / 50));

            if (wallStartPos[0] != wallEndPos[0])
            {
                scalValues.Add(new Vector3(0, objectHeight, wallEndPos[0] - wallStartPos[0]));
                
                if (wallEndPos[0] - wallStartPos[0] > 0)
                {
                    rotationValues.Add(new Vector3(0, 90, 0));
                }
                else
                {
                    rotationValues.Add(new Vector3(0, 270, 0));
                }

            }
            else if (wallStartPos[1] != wallEndPos[1])
            {
                scalValues.Add(new Vector3(0, objectHeight, wallEndPos[1] - wallStartPos[1]));
                
                if (wallEndPos[1] - wallStartPos[1] > 0)
                {
                    rotationValues.Add(new Vector3(0, 180, 0));
                }
                else
                {
                    rotationValues.Add(new Vector3(0, 0, 0));
                }
            }

            
            color.Add(defaultColor);
            objType.Add(tokenName);
            objLength.Add(length);

        }
    }


    //Getters
    public List<Vector3> GetStartPosValues()
    {
        return startPosValues;
    }

    public List<Vector3> GetScalValues()
    {
        return scalValues;
    }

    public List<Vector3> GetRotationValues()
    {
        return rotationValues;
    }

    public List<Color> GetColor()
    {
        return color;
    }

    public List<string> GetObjType()
    {
        return objType;
    }

    public List<double> GetObjLength()
    {
        return objLength;
    }



}
