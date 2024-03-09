using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    // public static ResourceManager instance;

    [HideInInspector] public static int albedoCount = 0;
    [HideInInspector] public static int rubedoCount = 0;
    [HideInInspector] public static int nigredoCount = 0;
    [HideInInspector] public static int failedCount = 0;

    [HideInInspector] public int currentDay;

    [SerializeField] private Potion _albedo;
    [SerializeField] private Potion _rubedo;
    [SerializeField] private Potion _nigredo;

    [SerializeField] private GameObject _albedoObject;
    [SerializeField] private GameObject _rubedoObject;
    [SerializeField] private GameObject _nigredoObject;

    public static int test = 2;

    void Start()
    {
        // _albedo.count = 0;
        // _rubedo.count = 0;
        // _nigredo.count = 0;

        Debug.Log("_albedo " + albedoCount);
        Debug.Log("_rubedo " + rubedoCount);
        Debug.Log("_nigredo " + nigredoCount);
        Debug.Log("_failed " + failedCount);
    }

    private void Update()
    {
        // if (_albedo.count == 0)
        // {
        //     _albedoObject.SetActive(false);
        // }
        if (_rubedo.count == 0)
        {
            _rubedoObject.SetActive(false);
        }
        else
        {
            _rubedoObject.SetActive(true);
        }
        // if (_nigredo.count == 0)
        // {
        //     _nigredoObject.SetActive(false);
        // }
    }
}
