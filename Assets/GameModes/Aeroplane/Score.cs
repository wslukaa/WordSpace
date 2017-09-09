using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Score : MonoBehaviour
{
    public List<Animator> ScoreNumbersAnimator;
    public GameObject ScoreNumber;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RenderNumber(GameModeHandler.score);
    }

    void RenderNumber(long number)
    {
        int length = number.ToString().Length;
        char[] strNum = number.ToString().ToCharArray();

        if (ScoreNumbersAnimator.Count == 0)
        {
            GameObject temp = Instantiate(ScoreNumber);
            temp.transform.SetParent(gameObject.transform);
            temp.transform.localScale = new Vector3(1, 1.5f, 1);
            ScoreNumbersAnimator.Add(temp.GetComponent<Animator>());
        }

        for (int i = 0; i < length; i++)
        {
            if (length > ScoreNumbersAnimator.Count)
            {
                GameObject temp = Instantiate(ScoreNumber);
                temp.transform.SetParent(gameObject.transform);
                temp.transform.localScale = new Vector3(1, 1.5f, 1);
                ScoreNumbersAnimator.Add(temp.GetComponent<Animator>());
            }
        }

        if (length < ScoreNumbersAnimator.Count)
        {
            int howManyToDelete = 0;
            for (int i = length; i < ScoreNumbersAnimator.Count; i++)
            {
                DestroyImmediate(ScoreNumbersAnimator[i].gameObject);
                howManyToDelete++;
            }
            ScoreNumbersAnimator.RemoveRange(length, howManyToDelete);
        }

        for (int i = 0; i < ScoreNumbersAnimator.Count; i++)
        {
            ScoreNumbersAnimator[i].SetInteger("number", int.Parse(strNum[i].ToString()));
        }
    }
}
