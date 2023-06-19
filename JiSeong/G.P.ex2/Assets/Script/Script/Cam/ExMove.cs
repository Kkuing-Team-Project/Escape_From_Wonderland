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
        // �÷��̾� ī�޶� ������ ������ �ʵ��� �ּ� X ��ǥ�� ����մϴ�.
    }

    private void Update()
    {
        // �÷��̾�� ���� �ӵ��� ���������� �̵��մϴ�.
        transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);

        // ���� ���� ��ġ�� ����Ʈ ��ǥ�� ��ȯ�մϴ�.
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        // ��ȯ�� ����Ʈ ��ǥ�� ī�޶� ������ ������ �ʵ��� �����մϴ�.
        viewportPosition.x = Mathf.Clamp(viewportPosition.x, 0f, 1f);

        // ���ѵ� ����Ʈ ��ǥ�� ���� ��ǥ�� ��ȯ�Ͽ� ���� ��ġ�� ������Ʈ�մϴ�.
        transform.position = mainCamera.ViewportToWorldPoint(viewportPosition);

        // ���� �÷��̾ �߿����� �ʵ��� �ּ� X ��ǥ�� �����մϴ�.
        if (transform.position.x < minXPosition)
        {
            transform.position = new Vector3(minXPosition, transform.position.y, transform.position.z);
        }
    }
}