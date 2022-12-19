using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int _score;
    [SerializeField] float delayLevelTime = 0f;
    [SerializeField] int _extraLife = 1;
    [SerializeField] int _coinValue = 1;
    [SerializeField] int _frozen = 1;
    [SerializeField] int _boost = 1;



    public static GameManager Instance { get; private set; }

    public event System.Action<int> OnScoreChanged;
    public event System.Action OnSceneChanged;

    public event System.Action<bool> OnSceneChangedForCanvas;


    public int ExtraLife => _extraLife;
    public float PlayerLevel { get; set; }

   

    private void Awake()
    {
        SingletonThisGameObject();
    }

    private void SingletonThisGameObject()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void IncreaseScore()
    {
        _score++;
        OnScoreChanged?.Invoke(_score);
    }

    #region bunlar gameu için benzer kodlar
    public void StartGame()
    {
        Time.timeScale = 1f;
        StartCoroutine(StartGameAsync());
    }

    private IEnumerator StartGameAsync()
    {
        OnSceneChanged?.Invoke();
        yield return SceneManager.LoadSceneAsync("Game");
    }

    //public void LoadScene(int levelIndex = 0)
    //{
    //    StartCoroutine(LoadSceneAsync(levelIndex));
    //}

    //private IEnumerator LoadSceneAsync(int levelIndex)
    //{
    //    yield return new WaitForSeconds(delayLevelTime);

    //    int buildIndex = SceneManager.GetActiveScene().buildIndex;


    //    yield return SceneManager.UnloadSceneAsync(buildIndex);


    //    SceneManager.LoadSceneAsync(buildIndex + levelIndex, LoadSceneMode.Additive).completed += (AsyncOperation obj) =>
    //    {
    //        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(buildIndex + levelIndex));
    //    };
    //    OnSceneChangedForCanvas?.Invoke(false);
    //}
    #endregion





    public void ExitGame()
    {
        Application.Quit();
    }


    #region bunlar menu ve ui için benzer kodlar

    public void ReturnMenu()
    {

        StartCoroutine(ReturnMenuAsync());
    }

    public IEnumerator ReturnMenuAsync()
    {
        OnSceneChanged?.Invoke();
        yield return SceneManager.LoadSceneAsync("Menu");
    }

    //public void LoadMenuAndUi(float delayLoadingTime)
    //{
    //    StartCoroutine(LoadMenuAndUiAsync(delayLoadingTime));
    //}
    //private IEnumerator LoadMenuAndUiAsync(float delayLoadingTime)
    //{
    //    yield return new WaitForSeconds(delayLoadingTime);
    //    yield return SceneManager.LoadSceneAsync("Menu");
    //    yield return SceneManager.LoadSceneAsync("Ui", LoadSceneMode.Additive);

    //    OnSceneChangedForCanvas!.Invoke(true);
    //}
    #endregion






    //-------------------------------------------------------------------------------
    public void RestartGame()
    {
        _score = 0;
        StartCoroutine(RestartGameAsync());
        
    }
    private IEnumerator RestartGameAsync()
    {
        yield return SceneManager.LoadSceneAsync("Game");
    }

}
