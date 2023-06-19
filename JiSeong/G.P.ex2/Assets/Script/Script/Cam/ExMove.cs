using UnityEngine;

public class ExMove : MonoBehaviour
{
    public Transform player;
    public float movementSpeed = 5f;

    private Camera mainCamera;
    private float playerScreenOffset = 1f;
    private float minXPosition;

    private void Start()
    {
        mainCamera = Camera.main;
        transform.position = new Vector3(-44f, 0f, 0f);
        // 플레이어 카메라 밖으로 나가지 않도록 최소 X 좌표를 계산합니다.
    }

    private void Update()
    {
        // 플레이어와 같은 속도로 오른쪽으로 이동합니다.
        transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);

        // 현재 적의 위치를 뷰포트 좌표로 변환합니다.
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        // 변환된 뷰포트 좌표가 카메라 밖으로 나가지 않도록 제한합니다.
        viewportPosition.x = Mathf.Clamp(viewportPosition.x, 0f, 1f);

        // 제한된 뷰포트 좌표를 월드 좌표로 변환하여 적의 위치를 업데이트합니다.
        transform.position = mainCamera.ViewportToWorldPoint(viewportPosition);

        // 적이 플레이어를 추월하지 않도록 최소 X 좌표를 유지합니다.
        if (transform.position.x < minXPosition)
        {
            transform.position = new Vector3(minXPosition, transform.position.y, transform.position.z);
        }
    }
}