using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public TextMeshProUGUI QuestionTxt;
    private string targetTag = "Respawn";
    GameController _gameController;

    // Start is called before the first frame update
    void Start()
    {
        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        generateQuestion();
    }

    public void checkAnswer(bool ans)
    {
        _gameController.chooseAnswer();
        GameObject helicopterFound = GameObject.FindGameObjectWithTag(targetTag);
        if (ans) {
            helicopterFound.GetComponent<Helicopter>().DestroyGameObject();
        } else {
            helicopterFound.GetComponent<Helicopter>().SelfKill();
        }
        processForNextQuestion();
    }

    public void processForNextQuestion() {
        StartCoroutine(DelayBeforeNextQuestion());
    }

    IEnumerator DelayBeforeNextQuestion()
    {
        DisableAllButtons();
        yield return new WaitForSeconds(2f); // Adjust the delay time as needed
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
        EnableAllButtons();
    }

    void DisableAllButtons()
    {
        foreach (GameObject option in options)
        {
            option.transform.GetComponent<Button>().interactable = false;
        }
    }

    void EnableAllButtons()
    {
        foreach (GameObject option in options)
        {
            option.transform.GetComponent<Button>().interactable = true;
        }
    }

    void SetAnswer() {
        // reset all answer and condition
        for (int i = 0; i < options.Length; i++) {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.black;
            options[i].transform.GetComponent<Image>().color = Color.white;
            if (QnA[currentQuestion].CorrectAnswer == i + 1) {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion() {
        currentQuestion = Random.Range(0, QnA.Count);
        QuestionTxt.text = QnA[currentQuestion].Question;
        _gameController.spawnHelicopter();
        SetAnswer();
    }
}
