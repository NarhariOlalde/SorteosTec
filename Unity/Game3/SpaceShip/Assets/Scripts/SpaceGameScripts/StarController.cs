using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{

    public float velocity;

    Vector2 limit;

    // Start is called before the first frame update
    void Start()
    {
        limit = Camera.main.ScreenToWorldPoint(
            new Vector3(Screen.width,
            Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.down * Time.deltaTime * velocity;
        if (transform.position.y < -50)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
