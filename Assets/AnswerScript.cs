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
            quizManager.checkAnswer(isCorrect);
            button.GetComponent<Image>().color = Color.green;
            button.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        } else {
            quizManager.checkAnswer(isCorrect);
            button.GetComponent<Image>().color = Color.red;
            button.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        }
    }
}
