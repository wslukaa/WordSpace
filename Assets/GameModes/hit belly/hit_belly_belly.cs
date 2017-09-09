using UnityEngine;
using System.Collections;

public class hit_belly_belly : MonoBehaviour {
    float speed = 10;
    public int lives;
    public long max_stomach;
    public GameObject[] stomach=new GameObject[1];
    public AudioClip grow;
    public AudioClip hit;
    int DefaultCanvasWidth = 1024;
    int DefaultCanvasHeight = 768;
    public int freezing_time;
    int freezing_time_left;

    // Use this for initialization
    void Start () {
        generate_belly_stomach();
        GetComponent<Animator>().SetBool("walk", true);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (GetComponent<Animator>().GetBool("walk") == true)
            walking();
        else if (freezing_time_left > 0)
            freezing_time_left--;
        else
        {
            generate_belly_stomach();
            GetComponent<Animator>().SetBool("walk", true);
        }
        if (gameObject.transform.localPosition.y + 100 * gameObject.transform.localScale.y - 250 > 1) {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y - 50, gameObject.transform.localPosition.z);
        }
        if (gameObject.transform.localPosition.y < 0)
            GameModeHandler.Exit();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.transform.childCount > 0)
        {
            if (other.tag == gameObject.transform.GetChild(0).tag)
            {
                Destroy(gameObject.transform.GetChild(0).gameObject);
                lives--;
                AudioSource.PlayClipAtPoint(hit, new Vector3(0, 0, 0));
                if (lives > 0)
                {
                    GameModeHandler.correct++;
                    freezing_time_left = freezing_time;
                    GetComponent<Animator>().SetBool("walk", false);
                }
                else {
                    GameModeHandler.pass = true;
                    GameModeHandler.Exit();
                }
            }
            else {
                AudioSource.PlayClipAtPoint(grow, new Vector3(0, 0, 0));
                GameModeHandler.wrong++;
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x+(float)0.5, gameObject.transform.localScale.y+(float)0.5, 1);
            }
        }
    }

    private void generate_belly_stomach()
    {
        GameObject NewStomach = (GameObject)Instantiate(stomach[Mathf.FloorToInt(Random.value * max_stomach)], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        NewStomach.transform.SetParent(gameObject.transform);
        NewStomach.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
        NewStomach.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        NewStomach.GetComponent<RectTransform>().localPosition = new Vector3(0, -20, 0);
    }

    private void walking()
    {
        Vector3 LocalPosition = gameObject.GetComponent<RectTransform>().localPosition;
        float LocalWidth = gameObject.GetComponent<RectTransform>().rect.width;
        if (LocalPosition.x.CompareTo(-(DefaultCanvasWidth - LocalWidth) / 2) <= 0)
        {
            speed = -speed;
        }
        if (LocalPosition.x.CompareTo((DefaultCanvasWidth - LocalWidth) / 2) >= 0)
        {
            speed = -speed;
        }
        gameObject.GetComponent<RectTransform>().localPosition = new Vector3(LocalPosition.x + speed, LocalPosition.y, LocalPosition.z);
    }

}

