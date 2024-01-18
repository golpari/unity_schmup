using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class GameOverCondition : MonoBehaviour
{
    public int enemiesToKill = 3;
    public Sprite winScreen;
    public Sprite loseScreen;
    [HideInInspector] public int bugsKilled = 0;

    public static GameOverCondition instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bugsKilled >= enemiesToKill)
        {
            this.GetComponentInChildren<Image>().sprite = winScreen;
            foreach (RectTransform child in this.GetComponentsInChildren<RectTransform>())
            {
                child.gameObject.SetActive(true);
            }
        }
        else if (HasHealth.instance.currentHealth <= 0)
        {
            this.GetComponentInChildren<Image>().sprite = loseScreen;
            foreach (RectTransform child in this.GetComponentsInChildren<RectTransform>())
            {
                child.gameObject.SetActive(true);
            }
        }
    }
}
