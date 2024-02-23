using UnityEngine;

public class Manager : MonoBehaviour
{
    private static Manager instance;
    public static Manager Inst { get {  return instance; } }

    [SerializeField] GameManager gameManager;
    [SerializeField] DataManager dataManager;
    public static GameManager Game { get { return instance.gameManager; } }
    public static DataManager Data { get { return instance.dataManager; } }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Init()
    {
        instance = FindObjectOfType<Manager>(true);
        if (instance == null)
        {
            Debug.LogError("Manager : Can't find singleton instance");
            return;
        }
        DontDestroyOnLoad(instance);

        Game.Init();
        Data.Init();
    }

    private void Awake()
    {
        if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }
}
