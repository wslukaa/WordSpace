using UnityEngine;
using System.Collections;

public class PlaneBullet : MonoBehaviour
{
    public int DefaultUpPanelHeight = 678;
    public int speed = 50;
    public int Attack;


    // Update is called once per frame
    void FixedUpdate()
    {
        fly();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="monster")
            Destroy(gameObject);
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
