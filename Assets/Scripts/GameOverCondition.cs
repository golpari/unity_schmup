using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverCondition : MonoBehaviour
{
    public AudioClip winAudio;
    public AudioClip loseAudio;

    public int enemiesToKill = 3;
    public GameObject winScreen;
    public GameObject loseScreen;
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
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (bugsKilled >= enemiesToKill)
        {
            // Play sound effect at the location of the main camera
            AudioSource.PlayClipAtPoint(winAudio, Camera.main.transform.position);

            bugsKilled = 0; //reset just to fix audio lol

            winScreen.SetActive(true);
        }
        else if (HasHealth.instance.currentHealth <= 0)
        {
            // Play sound effect at the location of the main camera
            AudioSource.PlayClipAtPoint(loseAudio, Camera.main.transform.position);

            HasHealth.instance.currentHealth = 3; //reset just to fix audio lol

            loseScreen.SetActive(true);
        }
    }
}
