using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomToObject : MonoBehaviour
{
    public Transform targetObject; // Ȯ���Ͽ� ������ ��ü�� Transform
    public float zoomDistance = 5f; // ��ü�κ����� ī�޶� �Ÿ�

    private Vector3 originalCameraPosition; // ���� ī�޶� ��ġ ����
    private bool isZoomed = false; // ��ü�� Ȯ�� ������ ���θ� ��Ÿ���� �÷���

    void Start()
    {
        // ���� ī�޶� ��ġ ����
        originalCameraPosition = transform.position;
    }

    void Update()
    {
        // ���콺 ���� ��ư�� Ŭ���ϸ鼭 ��ü�� ���콺 Ŀ���� ���� ��
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Raycast�� ����Ͽ� ��ü�� �浹�ϴ��� Ȯ��
            if (Physics.Raycast(ray, out hit) && hit.transform == targetObject)
            {
                // ��ü�� Ȯ���ϰų� ���� ��ġ�� �ǵ����ϴ�.
                if (!isZoomed)
                {
                    // ��ü�� ���ߴ� �������� ī�޶� �̵�
                    Vector3 directionToTarget = (targetObject.position - transform.position).normalized;
                    transform.position = targetObject.position - directionToTarget * zoomDistance;

                    // ī�޶��� ���̸� ����� ���̿� �����ϰ� ����
                    Vector3 cameraPosition = transform.position;
                    cameraPosition.y = targetObject.position.y;
                    transform.position = cameraPosition;

                    isZoomed = true;
                }
                else
                {
                    // ���� ī�޶� ��ġ�� �ǵ�����
                    transform.position = originalCameraPosition;
                    isZoomed = false;
                }
            }
        }
    }
}
