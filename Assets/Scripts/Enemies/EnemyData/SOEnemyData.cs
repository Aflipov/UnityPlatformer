using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyData", menuName = "Scriptable Objects/SOEnemyData")]
public class SOEnemyData : ScriptableObject
{
    [Header("Health")]
    public int maxHealth;

    [Header("Move")]
    public float moveSpeed;

    [Header("Collisions")]
    public float groundRayLngth = 1f;
    public float wallRayLngth = 0.5f;



    [Header("Player Detection")]
    public float detectionRange = 7f;
}
