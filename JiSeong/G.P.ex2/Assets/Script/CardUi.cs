using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Text, Image ����UI���� ���� ���� ����Ҽ� �ְԵ˴ϴ�

public class CardUi : MonoBehaviour
{
    Image heart3; //������ �����ϴ� �̹���
    public Sprite Card1;
    public Sprite Card2;
    public Sprite Card3;
    public Sprite Card;
    public Player player;
    public Image cardUi;

    public void ChangeImage()
    {

    }
    private void Update()
    {
       /* switch (player.card)
        {
            case 3:
                cardUi.sprite = Card3;
                break;
            case 2:
                cardUi.sprite = Card2;
                break;
            case 1:
                cardUi.sprite = Card1;
                break;
            default:
                cardUi.sprite = Card;
                break;
        }*/
    }
}