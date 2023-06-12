using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckData : MonoBehaviour
{
    public static CheckData instance;

    public TMP_InputField idInputField;
    public TMP_InputField pwdInputField;

    public int notlogin;

    public void NOTLOGINS()
    {
        instance = this;
        notlogin = 1;
    }

    public void SaveGameData()
    {
        string id = idInputField.text;
        string pwd = pwdInputField.text;

        // UserData 파일 경로
        string FilePath = Path.Combine(Application.dataPath, "UserData/");

        // game_data.csv 파일 경로
        string gameDataFilePath = Path.Combine(Application.dataPath, "UserData/game_data.csv");
        instance = this;

        // 입력된 ID와 PWD가 game_data.csv 파일의 ID/PWD와 일치하는지 확인
        if (CheckGameCredentials(id, pwd, gameDataFilePath))
        {
            Debug.Log("일치");

            // 현재 시간을 로그인 시간으로 저장
            string currentTime = System.DateTime.Now.ToString();
            string loginTimeData = string.Format("Login Time: {0}", currentTime);

            // ID.CSV 파일 경로
            string userFilePath = Path.Combine(FilePath, id + ".csv");

            // ID.CSV 파일에 로그인 시간 저장
            if (!File.Exists(userFilePath))
            {
                File.WriteAllText(userFilePath, loginTimeData + "\n");
                Debug.Log(userFilePath + " 만듬");
            }
            else
            {
                File.AppendAllText(userFilePath, loginTimeData + "\n");
                Debug.Log("데이터 추가");
            }
        }
    }

    private bool CheckGameCredentials(string id, string pwd, string gameDataFilePath)
    {
        string[] lines = File.ReadAllLines(gameDataFilePath);

        foreach (string line in lines)
        {
            string[] values = line.Split(',');
            if (values.Length >= 2 && values[0] == id && values[1] == pwd)
            {
                return true;
            }
        }

        return false;
    }
}
