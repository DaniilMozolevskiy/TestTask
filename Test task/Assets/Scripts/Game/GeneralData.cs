using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "General Data", fileName = "New data")]
public class GeneralData : ScriptableObject
{
    [Header("PlayerInfo")]
    [SerializeField] private Sprite playerSprite;
    public Sprite PlayerSprite
    {
        get { return playerSprite; }
        protected set { }
    }
    [SerializeField] private float playerSpeed;
    public float PlayerSpeed
    {
        get { return playerSpeed; }
        protected set { }
    }

    [Header("EnemyInfo")]
    [SerializeField] private Sprite enemySprite;
    public Sprite EnemySprite
    {
        get { return enemySprite; }
        protected set { }
    }
    [SerializeField] private float enemySpeed;
    public float EnemySpeed
    {
        get { return enemySpeed; }
        protected set { }
    }

    [Header("GenerateEnemyInfo")]
    [SerializeField] private int enemyGenerateCount;
    public int EnemyGenerateCount
    {
        get { return enemyGenerateCount; }
        protected set { }
    }
    [SerializeField] private float enemyGenerateInterval;
    public float EnemyGenerateInterval
    {
        get { return enemyGenerateInterval; }
        protected set { }
    }
    [SerializeField] private float coefficientSpeed;
    public float CoefficientSpeed
    {
        get { return coefficientSpeed; }
        protected set { }
    }

    [Header("GenerateScoreInfo")]
    [SerializeField] private int scoreGenerateCount;
    public int ScoreGenerateCount
    {
        get { return scoreGenerateCount; }
        protected set { }
    }
    [SerializeField] private float scoreGenerateInterval;
    public float ScoreGenerateInterval
    {
        get { return scoreGenerateInterval; }
        protected set { }
    }

    [Header("GenerateBonusInfo")]
    [SerializeField] private float bonusGenerateInterval;
    public float BonusGenerateInterval
    {
        get { return bonusGenerateInterval; }
        protected set { }
    }
    [SerializeField] private float timeBonus;
    public float TimeBonus
    {
        get { return timeBonus; }
        protected set { }
    }
    [SerializeField] private List<GameObject> bonusPrefabs;
    public List<GameObject> BonusPrefabs
    {
        get { return bonusPrefabs; }
        protected set { }
    }
}
