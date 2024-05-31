using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    // public Button button;
    
    public void Answer() {
        Button button = GetComponent<Button>();

        if (isCorrect) {
            quizManager.correct();
            Debug.Log("Correct Answer");
            button.GetComponent<Image>().color = Color.green;
            button.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        } else {
            quizManager.correct();
            Debug.Log("Incorrect Answer");
            button.GetComponent<Image>().color = Color.red;
            button.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        }
    }
}
