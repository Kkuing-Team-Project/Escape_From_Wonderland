using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Text, Image ����UI���� ���� ���� ����Ҽ� �ְԵ˴ϴ�

public class Heart : MonoBehaviour
{
    Image heart3; //������ �����ϴ� �̹���
    public Image heart2; //�ٲ���� �̹���
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