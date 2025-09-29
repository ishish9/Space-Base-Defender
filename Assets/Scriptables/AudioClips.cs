using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableAudioClips", menuName = "AudioClipsScriptable")]

public class AudioClips : ScriptableObject
{
    [Header("AudioClips For Words")]
    public AudioClip LetterCorrect;
    public AudioClip LetterWrong;
    public AudioClip WordComplete;
    public AudioClip WordSpawn;
    public AudioClip WordExpired;
    public AudioClip LevelUp;
    public AudioClip Defeat;
    public AudioClip Trophy;

    [Header("Menu")]
    public AudioClip Click;
 

    [Header("Misc")]
    public AudioClip MenuOpen;
    public AudioClip MenuClose;
    public AudioClip SpawnFountain;
    public AudioClip FireProjectile;
    public AudioClip ProjectileImpact;
    public AudioClip AsteroidExplode;

    [Header("Multiplier")]
    public AudioClip MultiAdd;
    public AudioClip MultiSubtract;
    public AudioClip MultiLevelUp;
    public AudioClip MultiLevelDown;

}
