using UnityEngine;
using System.Collections;

public class Supplement : MonoBehaviour {

    public long index;
    public int type;
    public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameModeHandler.exstingSupplement.Exists(TheSame))
        {
            GameModeHandler.exstingSupplement.Find(TheSame).position = gameObject.GetComponent<RectTransform>().localPosition;
            Fall();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Plane")
        {
            switch (type) {
                case 0:
                    if (GameModeHandler.HP_plus < 9)
                        GameModeHandler.HP_plus++;
                    break;
                case 1:
                    if (GameModeHandler.HPmax_plus < 9)
                        GameModeHandler.HPmax_plus++;
                    break;
                case 2:
                    if (GameModeHandler.BulletLevel_plus < 9)
                        GameModeHandler.BulletLevel_plus++;
                    break;
                case 3:
                    if (GameModeHandler.Frequency_plus < 9)
                        GameModeHandler.Frequency_plus++;
                    break;
                default:
                    break;
            }
            Die();
        }
    }

    void Fall()
    {
        if (gameObject.transform.GetComponent<RectTransform>().localPosition.y < -500)
        {
            Die();
        }
        else
        {
            gameObject.transform.Translate(new Vector3(0, -speed, 0));
        }
    }

    void Die()
    {
        Destroy(gameObject);
        GameModeHandler.exstingSupplement.RemoveAll(TheSame);
        GameModeHandler.exstingSupplement.TrimExcess();
    }

    public bool TheSame(ExistingSupplement other)
    {
        if (other == null)
        {
            return false;
        }
        else
        {
            if (other.index == index)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
