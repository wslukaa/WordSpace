using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HPmax_plus : MonoBehaviour {
    public List<Animator> HPmax_plusNumbersAnimator;
    public GameObject HPmax_plusNumber;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RenderNumber(GameModeHandler.HPmax_plus);
    }

    void RenderNumber(long number)
    {
        int length = number.ToString().Length;
        char[] strNum = number.ToString().ToCharArray();

        if (HPmax_plusNumbersAnimator.Count == 0)
        {
            GameObject temp = Instantiate(HPmax_plusNumber);
            temp.transform.SetParent(gameObject.transform);
            temp.transform.localScale = new Vector3(1, 1.5f, 1);
            HPmax_plusNumbersAnimator.Add(temp.GetComponent<Animator>());
        }

        for (int i = 0; i < length; i++)
        {
            if (length > HPmax_plusNumbersAnimator.Count)
            {
                GameObject temp = Instantiate(HPmax_plusNumber);
                temp.transform.parent = gameObject.transform;
                temp.transform.localScale = new Vector3(1, 1.5f, 1);
                HPmax_plusNumbersAnimator.Add(temp.GetComponent<Animator>());
            }
        }

        if (length < HPmax_plusNumbersAnimator.Count)
        {
            int howManyToDelete = 0;
            for (int i = length; i < HPmax_plusNumbersAnimator.Count; i++)
            {
                DestroyImmediate(HPmax_plusNumbersAnimator[i].gameObject);
                howManyToDelete++;
            }
            HPmax_plusNumbersAnimator.RemoveRange(length, howManyToDelete);
        }

        for (int i = 0; i < HPmax_plusNumbersAnimator.Count; i++)
        {
            HPmax_plusNumbersAnimator[i].SetInteger("number", int.Parse(strNum[i].ToString()));
        }
    }
}
