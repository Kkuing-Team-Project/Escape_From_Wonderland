using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Text, Image ����UI���� ���� ���� ����Ҽ� �ְԵ˴ϴ�

public class Heart : MonoBehaviour
{
    public Image heart3; //������ �����ϴ� �̹���
    public Sprite heart2; //�ٲ���� �̹���
    public Sprite heart1;

    public void ChangeImage()
    {
        heart3.sprite = heart2; //TestImage�� SourceImage�� TestSprite�� �����ϴ� �̹����� �ٲپ��ݴϴ�
    }
}