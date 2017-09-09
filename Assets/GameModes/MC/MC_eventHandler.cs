using UnityEngine;
using System.Collections;

public class MC_eventHandler : MonoBehaviour {
    public GameObject[] characterCatergory = new GameObject[4];
    public GameObject[] horizontal = new GameObject[1];
    public GameObject[] round = new GameObject[1];
    public GameObject[] vertical = new GameObject[1];
    public GameObject[] whole = new GameObject[1];
    public GameObject tick;
    public GameObject cross;
    public AudioClip correctSound;
    public AudioClip wrongSound;
    // Use this for initialization
    public void Start () {
        clearUpPanel();
        randomAssignChoices(randomAssignQuestion());
    }
	

    void clearUpPanel()
    {
        int childCount = gameObject.transform.Find("LPanel").childCount;
        if (childCount > 0) {
            for (int i = 0; i < childCount; i++)
                Destroy(gameObject.transform.Find("LPanel").GetChild(i).gameObject);
        }
        childCount = gameObject.transform.Find("RPanel").childCount;
        if (childCount > 0){
            for (int i = 0; i<childCount; i++)
                Destroy(gameObject.transform.Find("RPanel").GetChild(i).gameObject);
        }
    }

    int randomAssignQuestion() {
        int random_question_number = Mathf.FloorToInt(Random.value * characterCatergory.Length);
        GameObject question = (GameObject)Instantiate(characterCatergory[random_question_number]);
        question.transform.SetParent(transform.Find("LPanel"));
        question.transform.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        question.name = "question";
        return random_question_number;
    }

    void randomAssignChoices(int questionNumber) {
        GameObject[] choices = new GameObject[4];
        randomAssignObjectToChoice(choices, 0, questionNumber);
        for (int i = 1; i< choices.Length; i++) {
            int not_questionNumber = questionNumber;
            while (not_questionNumber == questionNumber)
                not_questionNumber = Mathf.FloorToInt(Random.value * characterCatergory.Length);
            randomAssignObjectToChoice(choices, i, not_questionNumber);
        }
            int random = Mathf.FloorToInt(Random.value * choices.Length);
            GameObject temp = choices[0];
            choices[0] = choices[random];
            choices[random] = temp;

        for (int i = 0; i < choices.Length; i++) {
            choices[i].transform.SetParent(transform.Find("RPanel"));
            choices[i].transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void randomAssignObjectToChoice(GameObject[] choices, int i, int questionNumber) {
        switch (questionNumber)
        {
            case 0:
                choices[i] = (GameObject)Instantiate(horizontal[Mathf.FloorToInt(Random.value * horizontal.Length)]);
                break;
            case 1:
                choices[i] = (GameObject)Instantiate(round[Mathf.FloorToInt(Random.value * round.Length)]);
                break;
            case 2:
                choices[i] = (GameObject)Instantiate(vertical[Mathf.FloorToInt(Random.value * vertical.Length)]);
                break;
            case 3:
                choices[i] = (GameObject)Instantiate(whole[Mathf.FloorToInt(Random.value * whole.Length)]);
                break;
        }
    }

    public void playSound(bool correct) {
        if (correct == true) {
            AudioSource.PlayClipAtPoint(correctSound, new Vector3(0, 0, 0));
        }
        else
        {
            AudioSource.PlayClipAtPoint(wrongSound, new Vector3(0, 0, 0));
        }
    }

}
