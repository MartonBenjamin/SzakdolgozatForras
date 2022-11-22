using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeColor : MonoBehaviour
{
    Material bodyMaterial;
    Material eyeMaterial;
    [SerializeField]Shader shader;
    [SerializeField]Slider red;
    [SerializeField]Slider green;
    [SerializeField]Slider blue;
    [SerializeField] GameObject[] eyes;
    void Start()
    {
        bodyMaterial = new Material(shader);
        eyeMaterial = new Material(shader);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateColor();
    }

    private void UpdateColor()
    {
        bodyMaterial.color = new Color(red.value, green.value, blue.value);
        gameObject.GetComponent<Renderer>().material = bodyMaterial;
    }
    public void newEye()
    {
        Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        Debug.Log("New eye color "+color);
        eyeMaterial.color = color;
        foreach (var eye in eyes)
        {
            eye.GetComponent<Renderer>().material = eyeMaterial;
        }
    }
}
