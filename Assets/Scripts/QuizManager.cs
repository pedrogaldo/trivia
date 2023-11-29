using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public Text QuestionTxt;


    public AudioSource questionAudioSource;

    public AudioClip pregunta1;
    public AudioClip pregunta2;
    public AudioClip pregunta3;
    public AudioClip pregunta4;
    public AudioClip pregunta5;
    public AudioClip pregunta6;
    public AudioClip pregunta7;
    public AudioClip pregunta8;
    public AudioClip pregunta9;

    private void Start()
    {
        generateQuestion();
        playAudioForQuestion();
    }

    public void correcto()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = (currentQuestion + 1) % QnA.Count; 
            generateQuestion();
            playAudioForQuestion();
        }
        else
        {
            SceneManager.LoadScene("Fin");
        }
    }

    void playAudioForQuestion()
    {
        if (currentQuestion >= 0 && currentQuestion < QnA.Count)
        {
            AudioClip[] questionAudioClips = { pregunta1, pregunta2, pregunta3, pregunta4, pregunta5, pregunta6, pregunta7, pregunta8, pregunta9}; // hay q agregar todos los audios 1 x 1

            AudioClip audioClip = questionAudioClips[currentQuestion];
            if (audioClip != null)
            {
                questionAudioSource.clip = audioClip;
                questionAudioSource.Play();
            }
        }
        else
        {
            Debug.Log("Invalid question index!");
        }
    }


    //cambia las respuestas en base a las preguntas
    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            SceneManager.LoadScene("Fin");
        }
    }





    public void Boton()
    {
        // se fija si el indice de current question es valido
        if (currentQuestion >= 0 && currentQuestion < QnA.Count)
        {
            AudioClip[] questionAudioClips = { pregunta1, pregunta2, pregunta3, pregunta4, pregunta5, pregunta6, pregunta7, pregunta8, pregunta9}; // tambien hay que agregarlos aca

            AudioClip audioClip = questionAudioClips[currentQuestion];
            if (audioClip != null)
            {
                questionAudioSource.clip = audioClip;
                questionAudioSource.Play();
            }
        }
        else
        {
            Debug.Log("Invalid question index!");
        }
    }


}
