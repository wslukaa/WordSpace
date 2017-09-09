using UnityEngine;
using System.Collections;

public class hit_belly_CannonBullet : MonoBehaviour {
    public int DefaultUpPanelHeight = 506;
    public int speed = 3;
    public int explode_time;
    int explode_time_left;


    // Use this for initialization
    void Start() {
        GetComponent<Animator>().SetBool("explode", false);
        explode_time_left = explode_time;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (GetComponent<Animator>().GetBool("explode") == false)
            fly();
        else if (explode_time_left > 0)
            explode_time_left--;
        else
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.childCount > 0)
            if (other.transform.GetChild(0).tag == gameObject.tag)
            {
                GetComponent<Animator>().SetBool("explode", true);
            }
            else {
                Destroy(gameObject);
            }
    }

    void fly()
    {
        float LocalHeight = gameObject.GetComponent<RectTransform>().rect.height;
        Vector3 LocalPosition = gameObject.GetComponent<RectTransform>().localPosition;
        gameObject.GetComponent<RectTransform>().localPosition = new Vector3(LocalPosition.x, LocalPosition.y + speed, LocalPosition.z);
        if (LocalPosition.y.CompareTo((DefaultUpPanelHeight - LocalHeight) / 2) >= 0)
            DestroyObject(gameObject);
    }

}
