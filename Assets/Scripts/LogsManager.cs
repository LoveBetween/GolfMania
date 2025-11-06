using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System;
using System.IO;


[Serializable]
public class PlayerData
{
    public String pickedItem;
    public int rightTakenItem_count;
    public int wrongTakenItem_count;
    public float distance;
    public float numberListDisplayed;
    public float totalTime;

    public String getAllData()
    {
        return pickedItem + '\n' + "rightTakenItem_count:" +rightTakenItem_count + '\n' + "wrongTakenItem:" + wrongTakenItem_count + '\n' + "distance:"+distance + '\n'+"numberListDisplayed:"+numberListDisplayed + '\n' + "totalTime:"+totalTime;

    }
}

public class LogsManager : MonoBehaviour
{

    public float targetTime = 0.00f;
    public TMP_Text displayTimer;
    public bool isStarted = false;

    public PlayerData playerData;

    public InputReader inputReader;


    private void Start()
    {
        PlayerData playerData = new PlayerData
        {
            pickedItem = "",
            rightTakenItem_count =0,
            wrongTakenItem_count=0,
            distance=0,
            numberListDisplayed=0,
            totalTime=0
        };


    }


    void Update()
    {

        targetTime += Time.deltaTime;

        //if (targetTime <= 0.0f)
        //{
        //    timerEnded();
        //}
        displayTimer.text = ((int)targetTime).ToString();
    }

    void timerEnded()
    {
        //do your stuff here.
    }

    public float getTime()
    {
        return targetTime;
    }
    //public void writeData(String)
    //{

    //}
    public void createText()
    {
        String date = (DateTime.Now).ToString();
        date = date.Replace(":", "-");
        date = date.Replace(' ', '_');
        date = date.Replace("/", "-");
        //Path of the file
        //string path = "C:\\Users\\nguyen\\Documents\\Log"+date+".txt";//Application.dataPath + "/Logs/Log.txt";
        //string path = "C:\\Users\\nguyen\\Documents\\Log_" + inputReader.getNom() + ".txt";//Application.dataPath + "/Logs/Log.txt";
        //File.CreateText(path);
        ////Create File if it doesn't exist
        //if (!File.Exists(path))
        //{
        //    File.CreateText(path);
        //    Debug.Log("1");
        //}
        ////Content of the file
        ////string content = "Login date: " + System.DateTime.Now + "\n";
        ////Add some to text to it
        //File.AppendAllText(path, "Login log \n\n"+playerData.getAllData());
        using (StreamWriter writer = new StreamWriter(Application.dataPath + "/Logs/Log_" + inputReader.getNom()+"_"+date + ".txt"))
        {
            writer.Write("Login "+ inputReader.getNom() + " \n\n" + playerData.getAllData());
        }
    }


    public void setPickedItem(string pickedItem)
    {
        playerData.pickedItem += pickedItem;
        Debug.Log("Picked item"+pickedItem);
    }
    public void addWrongItemCount()
    {
        playerData.wrongTakenItem_count += 1;
    }
    public void addRightItemCount()
    {
        playerData.rightTakenItem_count += 1;
    }
    public void setDistance()
    {
        playerData.distance = playerData.totalTime * 2.5f;
    }
    public void setTotalTime()
    {
        playerData.totalTime += targetTime;
    }

    public void addNumberListDisplayed(int i) {  playerData.numberListDisplayed += i; }

}

