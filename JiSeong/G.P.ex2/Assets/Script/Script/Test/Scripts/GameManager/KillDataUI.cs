using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillDataUI : MonoBehaviour
{
    public TextMeshProUGUI ak;
    public TextMeshProUGUI mk;
    // Start is called before the first frame update
    void Start()
    {    
        ak.text="Kill: "+KillCounter.instance.ailenKill;
        mk.text="Destruction: "+KillCounter.instance.meteorKill;
        int num = CheckData.instance.notlogin;

        if (num != 1){
            string id = CheckData.instance.idInputField.text;
            string FilePath = "/Users/han-seung-yeop/Documents/GitHub/SAVE-THE-EARTH/SAVE_THE_EARTH/Assets/Wargame/Data/";
            string userFilePath = Path.Combine(FilePath, id + ".csv");
            string gameData = string.Format("Character: {0}, Alien Kills: {1}, Meteor Destroyed: {2}", CharacterSelector.instance.characterNum, KillCounter.instance.ailenKill, KillCounter.instance.meteorKill);
            File.AppendAllText(userFilePath, gameData + "\n");
            Debug.Log("저장");
        }
        else{
            Debug.Log("저장할 데이터 없음");
        }
    }
}
