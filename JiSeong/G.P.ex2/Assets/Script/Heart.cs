using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Text, Image 등의UI관련 변수 등을 사용할수 있게됩니다

public class Heart : MonoBehaviour
{
    Image heart3; //기존에 존제하는 이미지
    public Image heart2; //바뀌어질 이미지
    public Image heart1;

    public void ChangeImage()
    {
        
        heart3 = GetComponent<Image>();
    }
    private void Update()
    {
        if (GameObject.Find("Player").GetComponent<Player>().PlayerHp == 3)
        {

        }
    }

}