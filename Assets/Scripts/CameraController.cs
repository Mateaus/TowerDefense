using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    private bool isCameraMovementEnabled = true;

    public float scrollSpeed = 5.0f;
    public float minY = 10f;
    public float maxY = 35f;

    private void Update() {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isCameraMovementEnabled = !isCameraMovementEnabled;
        }

        if (!isCameraMovementEnabled)
        {
            return;
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scrollCamera = Input.GetAxis("Mouse ScrollWheel");
        
        Vector3 cameraPosition = transform.position;
        cameraPosition.y -= scrollCamera * 1000 * scrollSpeed * Time.deltaTime;
        cameraPosition.y = Mathf.Clamp(cameraPosition.y, minY, maxY);

        transform.position = cameraPosition;
    }
}
