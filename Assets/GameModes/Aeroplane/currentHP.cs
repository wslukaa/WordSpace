using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class currentHP : MonoBehaviour {

    public List<Animator> HPNumbersAnimator;
    public GameObject HPNumber;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameModeHandler.PlaneHP <= 0)
        {
            RenderNumber(0);
        }
        else {
            RenderNumber(GameModeHandler.PlaneHP);
        }
        
    }

    void RenderNumber(long number)
    {
        int length = number.ToString().Length;
        char[] strNum = number.ToString().ToCharArray();

        if (HPNumbersAnimator.Count == 0)
        {
            GameObject temp = Instantiate(HPNumber);
            temp.transform.SetParent(gameObject.transform);
            temp.transform.localScale = new Vector3(1, 1.5f, 1);
            HPNumbersAnimator.Add(temp.GetComponent<Animator>());
        }

        for (int i = 0; i < length; i++)
        {
            if (length > HPNumbersAnimator.Count)
            {
                GameObject temp = Instantiate(HPNumber);
                temp.transform.SetParent(gameObject.transform);
                temp.transform.localScale = new Vector3(1, 1.5f, 1);
                HPNumbersAnimator.Add(temp.GetComponent<Animator>());
            }
        }

        if (length < HPNumbersAnimator.Count)
        {
            int howManyToDelete = 0;
            for (int i = length; i < HPNumbersAnimator.Count; i++)
            {
                DestroyImmediate(HPNumbersAnimator[i].gameObject);
                howManyToDelete++;
            }
            HPNumbersAnimator.RemoveRange(length, howManyToDelete);
        }

        for (int i = 0; i < HPNumbersAnimator.Count; i++)
        {
            HPNumbersAnimator[i].SetInteger("number", int.Parse(strNum[i].ToString()));
        }
    }
}
