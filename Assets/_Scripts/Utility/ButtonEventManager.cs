using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEventManager : MonoBehaviour
{
    public static ButtonEventManager Instance { get; private set; }
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
    public void OnExit() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void OnStart() => GameManager.Instance.LoadScene(EnumScene.Level_00);
    public void OnMainMenu() => GameManager.Instance.LoadScene(EnumScene.MainMenu);

    public void OnLevel00() => GameManager.Instance.LoadScene(EnumScene.Level_00);
    public void OnLevel01() => GameManager.Instance.LoadScene(EnumScene.Level_01);
    public void OnLevel02() => GameManager.Instance.LoadScene(EnumScene.Level_02);
    public void OnLevel03() => GameManager.Instance.LoadScene(EnumScene.Level_03);
    public void OnLevel04() => GameManager.Instance.LoadScene(EnumScene.Level_04);
}
