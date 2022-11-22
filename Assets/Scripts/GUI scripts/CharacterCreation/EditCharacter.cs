using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditCharacter : MonoBehaviour
{
    [SerializeField] GameObject hatPlaceHolder;
    [SerializeField] GameObject[] hats;
    private int hatIndex = 0;

    public void nextHat()
    {
        Debug.Log("HatIndex: " + hatIndex);
        resetHatIndex();
        hats[hatIndex].SetActive(false);
        try { 
        hats[hatIndex + 1].SetActive(true);
        hatIndex++;
        }
        catch{
            hatIndex = 0;
        }
    }
    private void resetHatIndex()
    {
        if (hatIndex >= hats.Length)
            hatIndex = 0;
    }
}
