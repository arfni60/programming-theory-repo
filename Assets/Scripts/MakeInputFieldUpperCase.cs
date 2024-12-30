using UnityEngine;
using UnityEngine.UI;



public class MakeInputFieldUpperCase : MonoBehaviour
{
    public InputField inputField;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnValueChange()
    {
        inputField.text = inputField.text.ToUpper();
    }
}
