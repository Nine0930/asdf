using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform judgeLine;
    public TextAsset Cheabo;
    public AudioSource AudioSource;

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    public void Awake()
    {
         if (Instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy (gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);

        CreateNote createNote = FindObjectOfType<CreateNote>();
        createNote.StartCreatNote();

        isGaming = true;
        AudioSource.Play();
    }

    public int SongTime { get; private set; } = 0;
    public bool isGaming { get; private set; } = false;

    public void Update()
    {
        if(isGaming == true)
        {
            SongTime += (int)(Time.deltaTime * 1000f);
        }
    }
}
