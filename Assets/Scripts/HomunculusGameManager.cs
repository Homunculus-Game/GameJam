using UnityEngine;

public enum State
{
    Normal,
    Small,
    Big,
    Overwhelmed,
    // Hat,
    // Bigx2,
    // Smallx2,
    Finalboss,
    Gameover
}

public class HomunculusGameManager : MonoBehaviour
{
    [SerializeField] private Potion _albedo;
    [SerializeField] private Potion _rubedo;
    [SerializeField] private Potion _nigredo;

    [SerializeField] private GameObject _albedoObject;
    [SerializeField] private GameObject _rubedoObject;
    [SerializeField] private GameObject _nigredoObject;

    private State _currentState;

    private void Awake()
    {
        _currentState = State.Normal;
    }

    void Start()
    {
        _albedo.count = 0;
        _rubedo.count = 0;
        _nigredo.count = 0;
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
