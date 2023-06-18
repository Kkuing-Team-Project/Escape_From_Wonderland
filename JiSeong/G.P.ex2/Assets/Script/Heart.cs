using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Text, Image 등의UI관련 변수 등을 사용할수 있게됩니다

public class Heart : MonoBehaviour
{
    Image heart3; //기존에 존제하는 이미지
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
                // PlayerHp가 3, 2, 1이 아닌 경우에 대한 처리를 여기에 추가할 수 있습니다.
                Destroy(gameObject);
                break;
        }
    }
}