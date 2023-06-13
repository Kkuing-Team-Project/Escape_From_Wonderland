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
    public TextMeshProUGUI uiText;

    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;
    public TextMeshProUGUI text5;

    public int notlogin;
    private int datacheck;

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
        string filePath = Path.Combine(Application.dataPath, "UserData/");

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
            string userFilePath = Path.Combine(filePath, id + ".csv");

            // ID.CSV 파일에 로그인 시간 저장
            if (!File.Exists(userFilePath))
            {
                File.WriteAllText(userFilePath, 0+"\n");
                Debug.Log(userFilePath + " 만듬");
            }
            else
            {
                //File.AppendAllText(userFilePath, loginTimeData + "\n");
                Debug.Log("데이터 추가");
            }

            datacheck = 1;
        }
        else
        {
            datacheck = 0;
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

    public void LoadData()
    {
        if (datacheck == 1)
        {
            string filePath = Path.Combine(Application.dataPath, "UserData/" + idInputField.text + ".csv");

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                List<string[]> data = new List<string[]>();

                foreach (string line in lines)
                {
                    string[] values = line.Split(',');
                    data.Add(values);
                }

                if (data.Count >= 5 && data[0].Length >= 5) // Ensure at least 5 rows and 5 columns are available
                {
                    // Find the highest value in each column (0 to 4)
                    string highestValue0 = FindHighestNumericValueInColumn(data, 0);
                    string highestValue1 = FindHighestNumericValueInColumn(data, 1);
                    string highestValue2 = FindHighestNumericValueInColumn(data, 2);
                    string highestValue3 = FindHighestNumericValueInColumn(data, 3);
                    string highestValue4 = FindHighestNumericValueInColumn(data, 4);

                    // Assign the highest values to the respective text fields
                    uiText.text = "User: " + idInputField.text;
                    text1.text = highestValue0;
                    text2.text = highestValue1;
                    text3.text = highestValue2;
                    text4.text = highestValue3;
                    text5.text = highestValue4;
                }
                else
                {
                    // Handle insufficient rows or columns by displaying a default or error message
                    uiText.text = "User: " + idInputField.text;
                    text1.text = "N/A";
                    text2.text = "N/A";
                    text3.text = "N/A";
                    text4.text = "N/A";
                    text5.text = "N/A";
                    Debug.LogError("Insufficient rows or columns in the data list.");
                }
            }
        }
    }

    private string FindHighestNumericValueInColumn(List<string[]> data, int columnIndex)
    {
        float highestValue = float.MinValue;
        foreach (string[] row in data)
        {
            if (row.Length > columnIndex)
            {
                string value = row[columnIndex];
                float floatValue;
                if (float.TryParse(value, out floatValue))
                {
                    if (floatValue > highestValue)
                    {
                        highestValue = floatValue;
                    }
                }
            }
        }

        return highestValue.ToString();
    }
}
