using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer _instance;

    [SerializeField] private SceneAsset[] scenesWhereTheObjectIsDestroyed;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        DestroyGameObject();
    }

    // Check if the current playing scene is one of the specified scenes to destroy the music player.
    private void DestroyGameObject()
    {
        if (scenesWhereTheObjectIsDestroyed == null) return;
        
        foreach (var scene in scenesWhereTheObjectIsDestroyed)
        {
            if (SceneManager.GetActiveScene().name.Equals(scene.name))
            {
                Destroy(gameObject);
            }
        }
    }
}
