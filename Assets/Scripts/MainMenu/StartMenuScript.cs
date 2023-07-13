using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _title,
                       _start,
                       _HTPButton,
                       _HTPPanel,
                       _return,
                       _quit;

    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _audioClip;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>(); 
        _audioSource.PlayOneShot(_audioClip,0.5f);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void HowToPlay()
    {
        _title.SetActive(false);
        _start.SetActive(false);
        _HTPButton.SetActive(false);
        _HTPPanel.SetActive(true);
        _quit.SetActive(false);
    }
    public void Return()
    {
        _title.SetActive(true);
        _start.SetActive(true);
        _HTPButton.SetActive(true);
        _HTPPanel.SetActive(false);
        _quit.SetActive(true);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
