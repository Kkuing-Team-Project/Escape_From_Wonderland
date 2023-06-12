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

        // CSV 파일에서 ID가 이미 존재하는지 확인
        string filePath = Path.Combine(Application.dataPath, "UserData/game_data.csv");

        if (!File.Exists(filePath))
        {
            // 파일을 생성하고 헤더를 작성합니다.
            string header = "ID,Password\n";
            File.WriteAllText(filePath, header);
        }

        // CSV 파일에서 기존의 행을 읽어옴
        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            string[] splitLine = line.Split(',');
            if (splitLine.Length > 0 && splitLine[0] == id)
            {
                Debug.Log("다른 아이디로 가입하세요!");
                return; // 저장하지 않고 메서드를 종료
            }
        }

        // CSV 파일에 쓸 데이터를 준비
        string data = string.Format("{0},{1}", id, pwd);

        // 데이터를 CSV 파일에 추가
        File.AppendAllText(filePath, data + "\n");
    }
}
