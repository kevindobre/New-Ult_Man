using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using core.Singleton;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{
    [Header("Player")]
    public GameObject playerprefab;

    [Header("Enemies")]
    public List<GameObject> enemies;

    [Header("references")]
    public Transform startpoint;

    [Header("Animation")]
    public float duration = .2f;
    public float delay = 0.05f;
    public Ease ease = Ease.OutBack;

    private GameObject _current;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        SpawnPlayer();
    }
    private void SpawnPlayer()
    {
        _current = Instantiate(playerprefab);
        _current.transform.position = startpoint.transform.position;
        _current.transform.DOScale(0, duration).SetEase(ease).From();
    }
}
