using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Text, Image ����UI���� ���� ���� ����Ҽ� �ְԵ˴ϴ�

public class Heart : MonoBehaviour
{
    Image heart3; //������ �����ϴ� �̹���
    public Sprite HpImage2;
    public Sprite HpImage1;
    public Sprite HpImage;
    public Player player;
    public Image hpUi;

    public void ChangeImage()
    {
        
    }
    private void Update()
    {
        switch (player.PlayerHp)
        {
            case 3:
                hpUi.sprite = HpImage;
                break;
            case 2:
                hpUi.sprite = HpImage1;
                break;
            case 1:
                hpUi.sprite = HpImage2;
                break;
            default:
                // PlayerHp�� 3, 2, 1�� �ƴ� ��쿡 ���� ó���� ���⿡ �߰��� �� �ֽ��ϴ�.
                Destroy(gameObject);
                break;
        }
    }
}