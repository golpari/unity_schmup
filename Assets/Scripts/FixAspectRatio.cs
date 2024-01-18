using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FixAspectRatio : MonoBehaviour
{
    private Camera _camera;

    private float targetAspectRatio = 1280.0f / 720.0f; // Desired aspect ratio

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        UpdateAspectRatio();
    }

    private void UpdateAspectRatio()
    {
        float screenAspectRatio = (float)Screen.width / (float)Screen.height;
        float scaleHeight = screenAspectRatio / targetAspectRatio;
        Rect rect = _camera.rect;

        if (screenAspectRatio > targetAspectRatio) // Screen is wider than target
        {
            float scaleWidth = targetAspectRatio / screenAspectRatio;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
        }
        else // Screen is taller or equal to target
        {
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
        }

        _camera.rect = rect;
    }
}
