using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBasketController : MonoBehaviour
{

    static public GameBasketController Instance;

    public BasketController basketController;
    public fallingObject fallingObject;
    public UIControl UIControl;

    private void Awake()
    {
        StopAllCoroutines();
        //PlayerPrefs.SetInt("score", 0);
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            Instance.SetReferences();
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void SetReferences()
    {
        if (UIControl == null)
        {
            UIControl.FindObjectOfType<UIControl>();
        }
        
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
