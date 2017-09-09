using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletLevel_plus : MonoBehaviour {

        public List<Animator> BulletLevel_plusNumbersAnimator;
        public GameObject BulletLevel_plusNumber;

        // Update is called once per frame
        void FixedUpdate()
        {
            RenderNumber(GameModeHandler.BulletLevel_plus);
        }

        void RenderNumber(long number)
        {
            int length = number.ToString().Length;
            char[] strNum = number.ToString().ToCharArray();

            if (BulletLevel_plusNumbersAnimator.Count == 0)
            {
                GameObject temp = Instantiate(BulletLevel_plusNumber);
                temp.transform.SetParent(gameObject.transform);
                temp.transform.localScale = new Vector3(1, 1.5f, 1);
                BulletLevel_plusNumbersAnimator.Add(temp.GetComponent<Animator>());
            }

            for (int i = 0; i < length; i++)
            {
                if (length > BulletLevel_plusNumbersAnimator.Count)
                {
                    GameObject temp = Instantiate(BulletLevel_plusNumber);
                    temp.transform.parent = gameObject.transform;
                    temp.transform.localScale = new Vector3(1, 1.5f, 1);
                    BulletLevel_plusNumbersAnimator.Add(temp.GetComponent<Animator>());
                }
            }

            if (length < BulletLevel_plusNumbersAnimator.Count)
            {
                int howManyToDelete = 0;
                for (int i = length; i < BulletLevel_plusNumbersAnimator.Count; i++)
                {
                    DestroyImmediate(BulletLevel_plusNumbersAnimator[i].gameObject);
                    howManyToDelete++;
                }
                BulletLevel_plusNumbersAnimator.RemoveRange(length, howManyToDelete);
            }

            for (int i = 0; i < BulletLevel_plusNumbersAnimator.Count; i++)
            {
                BulletLevel_plusNumbersAnimator[i].SetInteger("number", int.Parse(strNum[i].ToString()));
            }
        }
    }
