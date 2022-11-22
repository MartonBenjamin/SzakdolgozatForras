using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineCameraHandler
{
    static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();
    public static CinemachineVirtualCamera activeCamera = null;

    /// <summary>
    /// Register a camera into all cameras list
    /// </summary>
    /// <param name="camera"></param>
    public static void AddCamera(CinemachineVirtualCamera camera)
    {
        cameras.Add(camera);
        if (activeCamera == null)
        {
            activeCamera = camera;
            Debug.Log("Active camera set to:" + camera.name);
        }
        Debug.Log("Camera added: " + camera.name);
    }

    /// <summary>
    /// Remove camera from all cameras list
    /// </summary>
    /// <param name="camera"></param>
    public static void RemoveCamera(CinemachineVirtualCamera camera)
    {
        cameras.Remove(camera);
        Debug.Log("Camera removed: " + camera.name);
    }
    /// <summary>
    /// Camera in the parameter will be the active camera
    /// </summary>
    /// <param name="camera"></param>
    public static void SwitchCamera(CinemachineVirtualCamera camera)
    {
        foreach (CinemachineVirtualCamera cinemachineVirtualCamera in cameras)
        {
            if (!cinemachineVirtualCamera.Equals(camera) && cinemachineVirtualCamera.Priority != 0)
            {
                cinemachineVirtualCamera.Priority = 0;
            }
        }
        camera.Priority = 10;
        activeCamera = camera;
        Debug.Log("Camera switched to " + camera.name);
    }

    /// <summary>
    /// Follow the given trasform
    /// </summary>
    /// <param name="followableObject"></param>
    public static void ActiveCameraFollowTarget(Transform followableTransform)
    {
        activeCamera.Follow = followableTransform;
    }
    /// <summary>
    /// Look at the given trasform
    /// </summary>
    /// <param name="followableObject"></param>
    public static void ActiveCameraLookAtTarget(Transform followableTransform)
    {
        activeCamera.LookAt = followableTransform;
    }
}
