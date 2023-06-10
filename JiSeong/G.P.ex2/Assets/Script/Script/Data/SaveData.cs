using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveData : MonoBehaviour
{
    public TMP_InputField idInputField;
    public TMP_InputField pwdInputField;

    public void SaveGameData()
    {
        Debug.Log("성공");
        string id = idInputField.text;
        string pwd = pwdInputField.text;

        // CSV 파일에서 ID가 이미 존재하는지 확인합니다
        string UserPath = @"D:\Git\Escape_From_Wonderland\JiSeong\G.P.ex2\";
        string filePath = Path.Combine(UserPath, @"Assets\UserData\game_data.csv");

        if (!File.Exists(filePath))
        {
            // 파일을 생성하고 헤더를 작성합니다.
            string header = "ID,Password\n";
            File.WriteAllText(filePath, header);
        }

        // CSV 파일에서 기존의 행을 읽어옵니다.
        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            string[] splitLine = line.Split(',');
            if (splitLine.Length > 0 && splitLine[0] == id)
            {
                Debug.Log("다른 아이디로 가입하세요!");
                return; // 저장하지 않고 메서드를 종료합니다.
            }
        }

        // Prepare data to be written to the CSV file
        string data = string.Format("{0},{1}", id, pwd);

        // Append the data to the CSV file
        File.AppendAllText(filePath, data + "\n");
    }
}
