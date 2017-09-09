using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HPmax : MonoBehaviour {

    public List<Animator> HPmaxNumbersAnimator;
    public GameObject HPmaxNumber;

    // Update is called once per frame
    void FixedUpdate()
    {
        RenderNumber(GameModeHandler.PlaneHPmax);
    }

    void RenderNumber(long number)
    {
        int length = number.ToString().Length;
        char[] strNum = number.ToString().ToCharArray();

        if (HPmaxNumbersAnimator.Count == 0)
        {
            GameObject temp = Instantiate(HPmaxNumber);
            temp.transform.SetParent(gameObject.transform);
            temp.transform.localScale = new Vector3(1, 1.5f, 1);
            HPmaxNumbersAnimator.Add(temp.GetComponent<Animator>());
        }

        for (int i = 0; i < length; i++)
        {
            if (length > HPmaxNumbersAnimator.Count)
            {
                GameObject temp = Instantiate(HPmaxNumber);
                temp.transform.SetParent(gameObject.transform);
                temp.transform.localScale = new Vector3(1, 1.5f, 1);
                HPmaxNumbersAnimator.Add(temp.GetComponent<Animator>());
            }
        }

        if (length < HPmaxNumbersAnimator.Count)
        {
            int howManyToDelete = 0;
            for (int i = length; i < HPmaxNumbersAnimator.Count; i++)
            {
                DestroyImmediate(HPmaxNumbersAnimator[i].gameObject);
                howManyToDelete++;
            }
            HPmaxNumbersAnimator.RemoveRange(length, howManyToDelete);
        }

        for (int i = 0; i < HPmaxNumbersAnimator.Count; i++)
        {
            HPmaxNumbersAnimator[i].SetInteger("number", int.Parse(strNum[i].ToString()));
        }
    }
}
