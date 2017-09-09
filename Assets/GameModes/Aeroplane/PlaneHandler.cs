using UnityEngine;
using System.Collections;

public class PlaneHandler : MonoBehaviour {
 
    public int DefaultCanvasWidth=1024;
    int currentPlaneBulletTime = 0;

    public int translate_speed = 30;

    public GameObject[] PlaneBullet = new GameObject[1];
    public int[] PlaneBulletPeriod = new int[1];

    public AudioClip shoot;
    public AudioClip lose;
    public AudioClip[] beinghit=new AudioClip[2];

    // Use this for initialization
    void Start () {
        gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector3(GameModeHandler.PlanePosition, gameObject.transform.GetComponent<RectTransform>().localPosition.y, gameObject.transform.GetComponent<RectTransform>().localPosition.z);
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        if (!IsDie())
        {
            float LocalHeight = gameObject.GetComponent<RectTransform>().rect.height;

            if (currentPlaneBulletTime >= PlaneBulletPeriod[GameModeHandler.PlaneBulletFrequencyLevel])
            {
                GameObject NewBullet = (GameObject)Instantiate(PlaneBullet[GameModeHandler.PlaneBulletLevel], new Vector3(transform.position.x, transform.position.y + LocalHeight / 3, transform.position.z), Quaternion.identity);
                NewBullet.transform.SetParent(GameObject.Find("GamePanel").transform);
                NewBullet.transform.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                currentPlaneBulletTime = 0;
                PlayShootSound();
            }
            else
            {
                currentPlaneBulletTime++;
            }
        }
        else {
            CheckDead();
        }

    }

    public void left() {
        Vector3 LocalPosition = gameObject.GetComponent<RectTransform>().localPosition;
        float LocalWidth = gameObject.GetComponent<RectTransform>().rect.width;
        if (LocalPosition.x-translate_speed > -(DefaultCanvasWidth - LocalWidth) / 2)
        {
            gameObject.transform.Translate(new Vector3(-translate_speed, 0, 0));
            GameModeHandler.PlanePosition = gameObject.transform.GetComponent<RectTransform>().localPosition.x;
        }
    }

    public void right()
    {
        Vector3 LocalPosition = gameObject.GetComponent<RectTransform>().localPosition;
        float LocalWidth = gameObject.GetComponent<RectTransform>().rect.width;
        if (LocalPosition.x + translate_speed < (DefaultCanvasWidth - LocalWidth) / 2)
        {
            gameObject.transform.Translate(new Vector3(translate_speed, 0, 0));
            GameModeHandler.PlanePosition = gameObject.transform.GetComponent<RectTransform>().localPosition.x;
        }
    }

    bool IsDie() {
        if (GameModeHandler.PlaneHP <= 0)
        {
            if (gameObject.GetComponent<Animator>().GetBool("explosed") != true) {
                PlayLoseSound();
            }
            gameObject.GetComponent<Animator>().SetBool("explosed", true);
            return true;
        }
        else {
            return false;
        }
    }

    void CheckDead() {
        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("planeExplosed"))
        {
            GameModeHandler.SetZero();
            GameModeHandler.Exit();
        }
            
    }

    void PlayShootSound() {
        AudioSource.PlayClipAtPoint(shoot, new Vector3(60, 60, 60));
    }

    void PlayLoseSound() {
        AudioSource.PlayClipAtPoint(lose, new Vector3(0, 0, 0));
    }

    public void BeingHit() {
        if (GameModeHandler.PlaneHP > 0) {
            int i = Mathf.RoundToInt(Random.value);
            AudioSource.PlayClipAtPoint(beinghit[i], new Vector3(0, 0, 0));
        }
    }

}
