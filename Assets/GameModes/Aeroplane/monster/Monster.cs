using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

    public long index;
    public int HP;
    public int score;
    public float speed;
    public int level;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (GameModeHandler.exstingNormalMonster.Exists(TheSame)) {
            GameModeHandler.exstingNormalMonster.Find(TheSame).HP = HP;
            GameModeHandler.exstingNormalMonster.Find(TheSame).position = gameObject.GetComponent<RectTransform>().localPosition;
            Fall();            
        }

	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "PlaneBullet") {
            HP-=other.GetComponent<PlaneBullet>().Attack;
            if (HP <= 0) {
                DieWithScore();
            }
        }
        if (other.tag == "Plane") {
            GameModeHandler.PlaneHP -= HP;
            gameObject.transform.parent.Find("Plane").GetComponent<PlaneHandler>().BeingHit();
            DieWithoutScore();
        }

    }

    void Fall() {
        if (gameObject.transform.GetComponent<RectTransform>().localPosition.y < -500)
        {
            DieWithoutScore();
        }
        else
        {
            gameObject.transform.Translate(new Vector3(0, -speed, 0));     
        }
    }

    void DieWithoutScore() {
        Destroy(gameObject);
        GameModeHandler.exstingNormalMonster.RemoveAll(TheSame);
        GameModeHandler.exstingNormalMonster.TrimExcess();
    }

    void DieWithScore() {
        GameModeHandler.score += score;
        if (GameModeHandler.score > PlayerPrefs.GetInt("HighScores"))
            PlayerPrefs.SetInt("HighScores",(int)GameModeHandler.score);
        Destroy(gameObject);
        GameModeHandler.exstingNormalMonster.RemoveAll(TheSame);
        GameModeHandler.exstingNormalMonster.TrimExcess();
    }

    public bool TheSame(ExistingNormalMonster other) {
        if (other == null) {
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
