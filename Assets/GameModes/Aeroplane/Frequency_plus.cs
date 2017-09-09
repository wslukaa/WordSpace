using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Frequency_plus : MonoBehaviour {
    public List<Animator> Frequency_plusNumbersAnimator;
    public GameObject Frequency_plusNumber;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RenderNumber(GameModeHandler.Frequency_plus);
    }

    void RenderNumber(long number)
    {
        int length = number.ToString().Length;
        char[] strNum = number.ToString().ToCharArray();

        if (Frequency_plusNumbersAnimator.Count == 0)
        {
            GameObject temp = Instantiate(Frequency_plusNumber);
            temp.transform.SetParent(gameObject.transform);
            temp.transform.localScale = new Vector3(1, 1.5f, 1);
            Frequency_plusNumbersAnimator.Add(temp.GetComponent<Animator>());
        }

        for (int i = 0; i < length; i++)
        {
            if (length > Frequency_plusNumbersAnimator.Count)
            {
                GameObject temp = Instantiate(Frequency_plusNumber);
                temp.transform.parent = gameObject.transform;
                temp.transform.localScale = new Vector3(1, 1.5f, 1);
                Frequency_plusNumbersAnimator.Add(temp.GetComponent<Animator>());
            }
        }

        if (length < Frequency_plusNumbersAnimator.Count)
        {
            int howManyToDelete = 0;
            for (int i = length; i < Frequency_plusNumbersAnimator.Count; i++)
            {
                DestroyImmediate(Frequency_plusNumbersAnimator[i].gameObject);
                howManyToDelete++;
            }
            Frequency_plusNumbersAnimator.RemoveRange(length, howManyToDelete);
        }

        for (int i = 0; i < Frequency_plusNumbersAnimator.Count; i++)
        {
            Frequency_plusNumbersAnimator[i].SetInteger("number", int.Parse(strNum[i].ToString()));
        }
    }
}
