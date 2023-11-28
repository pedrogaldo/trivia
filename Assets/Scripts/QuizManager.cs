using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public Text QuestionTxt;


    //audios
    public AudioSource source;

    public AudioClip pregunta1;
    public AudioClip pregunta2;
    public AudioClip pregunta3;

    public AudioSource Q1;
    public AudioSource Q2;
    public AudioSource Q3;


    private void Start()
    {
        generateQuestion();
    }

    public void correct()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void loop()
    {
        if (currentQuestion == 1)
        {
            /*source.clip = pregunta1;
            source.Play();*/

            Q1.Play();

        }

        else if (currentQuestion == 2)
        {
            /*source.clip = pregunta2;
            source.Play();*/
            Q2.Play();

        }

        else if (currentQuestion == 3)
        {
            /*source.clip = pregunta3;
           source.Play();*/
            Q3.Play();

        }


    }
    void SetAnswers()
    {

        for (int i = 0; i <= options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].CorrectAnswer == i + 1) 
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }

    
    }

    void generateQuestion()
    {
        currentQuestion = Random.Range(0, QnA.Count);

        QuestionTxt.text = QnA[currentQuestion].Question;
        SetAnswers();

        QnA.RemoveAt(currentQuestion);
    }

    private void OnMouseDown()
    {
        
            

    }


}
