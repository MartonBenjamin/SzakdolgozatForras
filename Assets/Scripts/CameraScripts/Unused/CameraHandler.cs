using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject currentCharacterInPlay;
    private Dictionary<GameObject, List<Camera>> playableCharactersWithCamera;
    private const string playableCharacterTag = "playable";
    private int activePlayerIndex = 0;
    void Start()
    {
        Debug.Log("CameraHandler onStart");
        playableCharactersWithCamera = new Dictionary<GameObject, List<Camera>>();
        fillPlayableCharacterList();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            changeCamera();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            changeCharacter();
            changeCamera();
        }
    }

    /// <summary>
    /// Change to next character
    /// </summary>
    public void changeCharacter()
    {
        playableCharactersWithCamera.Keys.ElementAt(activePlayerIndex).GetComponentInChildren<PlayerStats>().IsCurrentActive = false;
        Debug.Log("Playable character deactivated at index: " + activePlayerIndex);
        activePlayerIndex++;
        if (activePlayerIndex == playableCharactersWithCamera.Count)
        {
            activePlayerIndex = 0;
        }
        playableCharactersWithCamera.Keys.ElementAt(activePlayerIndex).GetComponentInChildren<PlayerStats>().IsCurrentActive = true;
        Debug.Log("Playable character activated at index: " + activePlayerIndex);
    }

    /// <summary>
    /// Change between two cameras
    /// </summary>
    private void changeCamera()
    {
        foreach (Camera camera in playableCharactersWithCamera.Values.ElementAt(activePlayerIndex))
        {
            if (camera.enabled)
            {
                camera.enabled = false;
            }
            else
            {
                camera.enabled = true;
            }
        }
    }

    /// <summary>
    /// Add playable character with its cameras
    /// </summary>
    /// <param name="character"></param>
    /// <param name="cameras"></param>
    public void addPlayableCharacter(GameObject character, List<Camera> cameras)
    {
        playableCharactersWithCamera.Add(character, cameras);
        Debug.Log(character + "was added as playable Character with " + cameras.Count + " camera objects");
    }
    /// <summary>
    /// Removes character from playable characters and also its cameras.
    /// Call this if character is destroyed(Dead)
    /// </summary>
    /// <param name="character"></param>
    public void removePlayableChracter(GameObject character)
    {
        playableCharactersWithCamera.Remove(character);
    }
    //Used to debug
    private void fillPlayableCharacterList()
    {
        GameObject[] playableGameObjects = GameObject.FindGameObjectsWithTag(playableCharacterTag);
        foreach (GameObject playableObject in playableGameObjects)
        {
            Camera[] cameraArray = playableObject.GetComponentsInChildren<Camera>();
            playableCharactersWithCamera.Add(playableObject, cameraArray.ToList());
            Debug.Log("Attached object: " + playableObject.name + "with camera count: " + cameraArray.Count());
        }
        currentCharacterInPlay = playableCharactersWithCamera.First().Key;
    }

    /// <summary>
    /// Disable camera
    /// </summary>
    /// <param name="camera"></param>
    private void disableCamera(Camera camera)
    {
        camera.enabled = false;
    }

    /// <summary>
    /// Set the active camera to the input camera
    /// All the others cameras will be inactive
    /// </summary>
    /// <param name="camera"></param>
    public void setActiveCamera(Camera camera)
    {
        bool cameraActivated = false;
        foreach (KeyValuePair<GameObject, List<Camera>> entry in playableCharactersWithCamera)
        {
            foreach (Camera cameraInList in entry.Value)
            {
                if (cameraInList.Equals(camera))
                {
                    camera.enabled = true;
                    cameraActivated = true;
                    Debug.Log("Active camera set to: " + camera);
                    break;
                }
                else
                {
                    camera.enabled = false;
                }
            }
            if (cameraActivated)
            {
                break;
            }
        }
    }

}
