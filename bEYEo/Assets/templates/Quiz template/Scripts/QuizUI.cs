using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private QuizManager quizManager;
    [SerializeField] private Text questionText;
    [SerializeField] private Image questionImage;
    [SerializeField] private UnityEngine.Video.VideoPlayer questionVideo;
    [SerializeField] AudioSource questionAudio;
    [SerializeField] private List<Button> options;
    [SerializeField] private bool shuffleOptions;
    [SerializeField] private Color correctColor;
    [SerializeField] private Color wrongColor;
    [SerializeField] private Color normalColor;
    [SerializeField] public Button replayButton;



    private Question question;
    private bool answered;
    private float audioLength;
    bool audioPlayed;


    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < options.Count; i++)
        {
            Button localBtn = options[i];
            options[i].onClick.AddListener(() => OnClick(localBtn));
        }
        replayButton.onClick.AddListener(()=>OnClick(replayButton));
    }

    public void SetQuestion(Question question) {

        this.question = question;
        switch (question.questionType) {
            case QuestionType.TEXT:
                questionImage.transform.parent.gameObject.SetActive(false);
                break;
            case QuestionType.IMAGE:
                ImageHolder();
                questionImage.transform.gameObject.SetActive(true);
                questionImage.sprite = question.questionsImg;
                break;
            case QuestionType.VIDEO:
                ImageHolder();
                questionVideo.transform.gameObject.SetActive(true);
                questionVideo.clip = question.questionVideo;
                questionVideo.Play();
                break;
            case QuestionType.AUDIO:
                ImageHolder();
                questionAudio.transform.gameObject.SetActive(true);
                audioLength = question.questionClip.length;
                StartCoroutine(PlayAudio());
                break;
        }

        questionText.text = question.questionInfo;
        List<string> answerList;

        if (shuffleOptions)
        {
            answerList = ShuffleList.ShuffleListItems<string>(question.options);
        }
        else { 
           answerList = question.options;
        }



        for (int i = 0; i < options.Count; i++)
        {
            options[i].GetComponentInChildren<Text>().text = answerList[i];
            options[i].name = answerList[i];
            options[i].image.color = normalColor;
        }

        answered = false;

    }

    IEnumerator PlayAudio() {
        
        if (question.audioPlayed == false) {
            question.audioPlayed = true;
            if (question.questionType == QuestionType.AUDIO)
            {
                questionAudio.PlayOneShot(question.questionClip);
                yield return new WaitForSeconds(audioLength + 1f);
                StartCoroutine(PlayAudio());
            }
            else {
                StopCoroutine(PlayAudio());
                yield return null;
            }
        }
        
    }
    
    
    void ImageHolder() {
        questionImage.transform.parent.gameObject.SetActive(true);
        questionImage.transform.gameObject.SetActive(false);
        questionAudio.transform.gameObject.SetActive(false);
        questionVideo.transform.gameObject.SetActive(false);
    }

    private void OnClick(Button btn) {

        if (btn.name == "replayButton")
        {
             questionAudio.Stop();
             questionAudio.PlayOneShot(question.questionClip);

        }
        else
        {

            if (!answered)
            {
                bool val = quizManager.Anwser(btn.name);
                if (val)
                {
                    btn.image.color = correctColor;
                }
                else
                {
                    btn.image.color = wrongColor;
                }

            }
        }

    }
}
