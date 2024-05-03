using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public GameObject player;

    public TMP_Text KillsText;

    private int _killsCount = 0;

    private void Awake() 
    {
        if (Instance != null) 
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void AddKill()
    {
        KillsText.text = $"Kills: {++_killsCount}";
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
