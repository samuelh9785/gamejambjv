using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private List<Level> levels = default;
    private int currentLevel = 0;

    private static GameManager _instance;
    public static GameManager Instance => _instance;

    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        levels[currentLevel].gameObject.SetActive(true);
    }

    public void NextLevel()
    {
        levels[currentLevel].gameObject.SetActive(false);
        currentLevel++;

        if (levels.Count >= currentLevel)
        {
            levels[currentLevel].gameObject.SetActive(true);
        }   
    }

}
