using System.Collections;
using Unity.Android.Gradle.Manifest;
using UnityEditor;
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
    private string objectColor;

    private int score;
    private int highScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject outcomeUI;
    public Text outcomeText;

    public GameObject colorSwatch;
    public GameObject exitColorSwatchButton;

    //public GameObject ResetHighScoreButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        scoreText.text = ("Score: " + score.ToString());
        //Debug.Log(DataManager.Instance.highScore);
        highScore = DataManager.Instance.highScore;
        highScoreText.text = ("High Score: " + highScore.ToString());
        ShowObject(displayObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (displayObject != null)
        {
            
            if (enteredColor != null && objectColor != null)
            {
                Debug.Log(enteredColor + " " + objectColor);
                if(enteredColor == objectColor)
                {
                    score += 1;
                    scoreText.text = ("Score: " + score.ToString());
                    StartCoroutine(ShowOutcomeText("Good guess!"));
                    //outcomeUI.SetActive(false);
                    //Debug.Log("Right guess!");
                    if (DataManager.Instance.highScore == 0 || (score > DataManager.Instance.highScore))
                    {
                        DataManager.Instance.highScore = score;

                        highScoreText.text = "High Score : " + DataManager.Instance.highScore;
                    }
                    ChangeColor();

                }
                else
                {
                    StartCoroutine(ShowOutcomeText("Wrong. Try again!"));
                    //outcomeUI.SetActive(false);
                    Debug.Log("Wrong! Try again!");
                }
                enteredColor = null;
            }
        }
        
    }

    void ShowObject(GameObject nextObject)
    {
        displayObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        displayObject.GetComponent<Renderer>().material = colorMaterial;
        displayObject.transform.position = spawnPosition.transform.position;
        displayObject.GetComponent<Renderer>().material.SetColor("_BaseColor", Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f, 1f, 1f));
        objectColor = ColorUtility.ToHtmlStringRGB(displayObject.GetComponent<Renderer>().material.GetColor("_BaseColor"));
        Debug.Log(objectColor);
    }

    void ChangeColor()
    {
        displayObject.GetComponent<Renderer>().material.SetColor("_BaseColor", Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f, 1f, 1f));
        objectColor = ColorUtility.ToHtmlStringRGB(displayObject.GetComponent<Renderer>().material.GetColor("_BaseColor"));
        Debug.Log(objectColor);
    }

    public void ReadColorInput(InputField color)
    {
        enteredColor = color.text;
        Debug.Log(enteredColor);
    }

    public void ExitGame()
    {
        DataManager.Instance.SaveHighScore();
        //MainManager.Instance.SaveColor();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif

    }

    IEnumerator ShowOutcomeText(string textToShow)
    {
        outcomeUI.SetActive(true);
        outcomeText.text = textToShow;
        yield return new WaitForSeconds(2);
        outcomeUI.SetActive(false);

    }

    public void ResetHighScore()
    {
        DataManager.Instance.highScore = 0;
        DataManager.Instance.SaveHighScore();
        highScoreText.text = ("High Score: " + DataManager.Instance.highScore);

    }

    public void ShowColorSwatch()
    {
        colorSwatch.SetActive(true);
        exitColorSwatchButton.SetActive(true);
    }

    public void HideColorSwatch()
    {
        colorSwatch.SetActive(false);
        exitColorSwatchButton.SetActive(false);
    }


}
