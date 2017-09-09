using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HP_plus : MonoBehaviour {
    public List<Animator> HP_plusNumbersAnimator;
    public GameObject HP_plusNumber;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RenderNumber(GameModeHandler.HP_plus);
    }

    void RenderNumber(long number)
    {
        int length = number.ToString().Length;
        char[] strNum = number.ToString().ToCharArray();

        if (HP_plusNumbersAnimator.Count == 0)
        {
            GameObject temp = Instantiate(HP_plusNumber);
            temp.transform.SetParent(gameObject.transform);
            temp.transform.localScale = new Vector3(1, 1.5f, 1);
            HP_plusNumbersAnimator.Add(temp.GetComponent<Animator>());
        }

        for (int i = 0; i < length; i++)
        {
            if (length > HP_plusNumbersAnimator.Count)
            {
                GameObject temp = Instantiate(HP_plusNumber);
                temp.transform.parent = gameObject.transform;
                temp.transform.localScale = new Vector3(1, 1.5f, 1);
                HP_plusNumbersAnimator.Add(temp.GetComponent<Animator>());
            }
        }

        if (length < HP_plusNumbersAnimator.Count)
        {
            int howManyToDelete = 0;
            for (int i = length; i < HP_plusNumbersAnimator.Count; i++)
            {
                DestroyImmediate(HP_plusNumbersAnimator[i].gameObject);
                howManyToDelete++;
            }
            HP_plusNumbersAnimator.RemoveRange(length, howManyToDelete);
        }

        for (int i = 0; i < HP_plusNumbersAnimator.Count; i++)
        {
            HP_plusNumbersAnimator[i].SetInteger("number", int.Parse(strNum[i].ToString()));
        }
    }
}
