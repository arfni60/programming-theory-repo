using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject spawnPosition;
    public Material colorMaterial;
    public Color setColor;

    private GameObject displayObject;

    private string enteredColor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        ShowObject(displayObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (displayObject != null)
        {
            Debug.Log(ColorUtility.ToHtmlStringRGB(displayObject.GetComponent<Renderer>().material.GetColor("_Color")));
            // if (enteredColor != null && displayObject.GetComponent<Renderer>().material.GetColor("_Color") != null)
            // {
            //     Debug.Log(displayObject.GetComponent<Renderer>().material.GetColor("_Color"));
            // }
        }
        
    }

    void ShowObject(GameObject nextObject)
    {
        displayObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        displayObject.GetComponent<Renderer>().material = colorMaterial;
        displayObject.transform.position = spawnPosition.transform.position;
    }

    public void ReadColorInput(InputField color)
    {
        enteredColor = color.text;
        Debug.Log(enteredColor);
    }
}
