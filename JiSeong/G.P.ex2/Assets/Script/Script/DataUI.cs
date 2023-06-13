using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataUI : MonoBehaviour
{
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;
    public TextMeshProUGUI text5;
    public TextMeshProUGUI text6;

    public void DataLoad(){
        text1.text ="Kill: " +Player.instance.KillCountNull;
        text2.text ="Use: " +Player.instance.CardCountNull;
        text3.text ="Use: " +Player.instance.hatCountNull;
        text4.text ="Use: " +Player.instance.timeCountNull;
        text5.text ="Use: " +Player.instance.teaCupCountNull;
        text6.text ="Distance: " +Player.instance.distance;
    }
}
