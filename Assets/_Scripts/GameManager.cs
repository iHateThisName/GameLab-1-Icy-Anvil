using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private GameObject _playerPrefab;

    private Vector2 _levelStartPosition;
    public Vector2? LastCheckPointPosition;
    public bool IsPlayerDead { get; private set; } = false;

    [SerializeField] private CinemachineVirtualCamera _cinemachineCamera;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void LoadScene(EnumScene scene) {
        SceneManager.LoadScene(scene.ToString());
    }

    public void SetLevelStartPosition(Vector2 position) {
        _levelStartPosition = position;
        LastCheckPointPosition = null;
        Respawn();
    }

    public void Respawn() {
        if (_cinemachineCamera == null) GetFollowCameraInScene();

        if (!LastCheckPointPosition.HasValue) {
            GameObject go = Instantiate(_playerPrefab, _levelStartPosition, Quaternion.identity);
            _cinemachineCamera.Follow = go.transform;
        } else {
            GameObject go = Instantiate(_playerPrefab, LastCheckPointPosition.Value, Quaternion.identity);
            _cinemachineCamera.Follow = go.transform;
        }
        IsPlayerDead = false;
    }

    public void Death(GameObject player) {
        if (!IsPlayerDead) {
            IsPlayerDead = true;
            Destroy(player);
            Respawn();
        }
    }

    private void GetFollowCameraInScene() {
        GameObject camera = GameObject.FindWithTag("PlayerFollowCamera");
        if (camera != null) _cinemachineCamera = camera.GetComponent<CinemachineVirtualCamera>();
    }

}
