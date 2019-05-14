using System.Collections;
using ScriptableObjects;
using Tools;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Player player;
    public FloatReference playerScore;

    public Transform platformParent;
    
    public Platform[] platforms;
    public Item[] items;

    public float itemProbability = 0.1f;

    public float overheadDistance = 10f;
    public float maxDistance = 20f;

    private float _yGeneration;
    private float _lastPlatformY;

    private CameraFollow _cameraFollow;
    private ScoreManager _scoreManager;

    private Vector3 _basePlayerPosition;
    private float _basePlatformY;
    private float _baseY;

    private void Start()
    {
        _basePlayerPosition = player.transform.position;
        _basePlatformY = _lastPlatformY;
        _baseY = _yGeneration;
        
        if (Camera.main != null) _cameraFollow = Camera.main.GetComponent<CameraFollow>();
        _scoreManager = GetComponent<ScoreManager>();

        player.OnDeath += GameOver;
        
        ResetMap();
    }

    private void Update()
    {
        UpdateMap();
    }

    private void UpdateMap()
    {
        var baseY = player.transform.position.y;
        GeneratePartialMap(baseY, maxDistance);
    }

    private void GeneratePartialMap(float baseY, float maxY)
    {
        if (baseY + overheadDistance <= _yGeneration) return;

        _yGeneration = baseY + overheadDistance;

        var max = _yGeneration + maxY;
        GeneratePlatforms(max);
    }

    private void GeneratePlatforms(float maxY)
    {
        while (_lastPlatformY < maxY)
        {
            GeneratePlatform();
        }
    }

    private void GeneratePlatform()
    {
        var platformObject = platforms.GetRandom();
        var platformPrefab = platformObject.prefab;
        var xRange = platformObject.xRange;
        var yRange = platformObject.yRange;
        
        var xRandom = xRange.Random();
        var yRandom = _lastPlatformY + yRange.Random();
        
        var pos = new Vector2(xRandom, yRandom);

        _lastPlatformY = yRandom;

        var platform = Instantiate(platformPrefab, pos, Quaternion.identity, platformParent);

        if (Random.value <= itemProbability && platformObject.hasItem)
        {
            GenerateItem(platform.transform);
        }
    }

    private void GenerateItem(Transform platform)
    {
        var itemObject = items.GetRandom();
        var itemPrefab = itemObject.prefab;
        var xRange = itemObject.xRange;
        
        var xRandom = xRange.Random();
        var platformPos = platform.position;
        platformPos.x += xRandom;
        
        Instantiate(itemPrefab, platformPos, Quaternion.identity, platform);
    }

    private void GameOver()
    {
        StartCoroutine(GameOverCoroutine());
    }

    private IEnumerator GameOverCoroutine()
    {
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        ResetMap();
        player.gameObject.SetActive(true);
    }

    private void ResetMap()
    {
        foreach (Transform child in platformParent)
        {
            Destroy(child.gameObject);
        }
        
        player.transform.position = _basePlayerPosition;
        _lastPlatformY = _basePlatformY;
        _yGeneration = _baseY;

        _cameraFollow.ResetCamera();
        _scoreManager.ResetScore();

        GeneratePlatforms(overheadDistance);
    }
    
}
