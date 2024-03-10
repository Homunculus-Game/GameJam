using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeState : MonoBehaviour
{
    [SerializeField] private GameObject _stage1;
    [SerializeField] private GameObject _stage2;
    [SerializeField] private GameObject _stage3;

    [SerializeField] private GameObject _hat;

    [SerializeField] private Transform _transform;

    [SerializeField] private List<Transition> _transitions = new();
    [SerializeField] private List<State> _states = new();

    [SerializeField] private State _defaultState;

    [SerializeField] private UsePotion[] usePotionScripts;

    [SerializeField] private NextDayButton _nextDayScript;

    public static int daysWithNoPotion = 0;

    private State _currentState;

    public static int _potionsUsed = 0;

    [SerializeField] private AudioSource[] _audio;

    private Vector3 _initialScale;

    private AudioSource _audioSource;

    private void Awake()
    {
        foreach (var usePotionScript in usePotionScripts)
        {
            usePotionScript.OnPotionUsed += ApplyPotion;
        }
        _nextDayScript.FakePotion += ApplyPotion2;
    }

    private void Start()
    {
        // _currentState = _defaultState;
        _transform.localScale = _defaultState.scale;

        _potionsUsed = 0;

        _audioSource = GetComponent<AudioSource>();

        _initialScale = transform.localScale;

        // foreach (var state in _states)
        // {
        //     if (state.name == ResourceManager.currentState)
        //     {
        //         _currentState = state;
        //         break;
        //     }
        // }
        _currentState = _states.Find(x => x.name == ResourceManager.currentState); // !!!
    }

    private void Update()
    {
        switch (_currentState.stage)
        {
            case 0:
                {
                    _stage1.SetActive(true);
                    _stage2.SetActive(false);
                    //_stage3.SetActive(false);

                    // transform.localScale = new Vector3(1, 1, 1);
                    _stage1.transform.localScale = Vector3.Lerp(_stage1.transform.localScale, _currentState.scale, 4.0f * Time.deltaTime);

                    break;
                }
            case 1:
                {
                    _stage1.SetActive(false);
                    _stage2.SetActive(true);
                    //_stage3.SetActive(false);

                    // transform.localScale = new Vector3(1, 1, 1);
                    _stage2.transform.localScale = Vector3.Lerp(_stage2.transform.localScale, _currentState.scale, 4.0f * Time.deltaTime);
                    break;
                }
            case 2:
                {
                    //_stage1.SetActive(false);
                    //_stage2.SetActive(false);
                    //_stage3.SetActive(true);

                    // transform.localScale = new Vector3(1, 1, 1);
                    _stage3.transform.localScale = _currentState.scale;
                    break;
                }
        }

        if (_currentState.name == "gameOverRubedo")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (_currentState.name == "gameOverAlbedo")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
        if (_currentState.name == "funny")
        {
            _hat.SetActive(true);
        }
        else
        {
            _hat.SetActive(false);
        }

        // if (ResourceManager.currentDay % 2 == 0 && _potionsUsed == 0)
        // {
        //     transform.localScale = new Vector3(_initialScale.x / 2.0f, _initialScale.y / 2.0f, _initialScale.z / 2.0f);
        // }
    }

    List<Transition> GetPossibleTransitions(State state)
    {
        List<Transition> possibleStates = new();
        foreach (var transition in _transitions)
        {
            // Debug.Log(transition.name);
            // Debug.Log(transition.potion.name);
            // Debug.Log(transition.fromState.name);
            // Debug.Log(transition.toState.name);
            if (transition.fromState == state)
            {
                possibleStates.Add(transition);
            }
        }

        return possibleStates;
    }

    public void ApplyPotion(Potion potion)
    {
        List<Transition> transitions = GetPossibleTransitions(_currentState);
        foreach (var transition in transitions)
        {
            if (transition.potion == potion)
            {
                _potionsUsed++;
                _currentState = transition.toState;
                _audioSource.clip = _currentState.clip;
                _audioSource.Play();
                _audioSource.loop = _currentState.loop;
                break;
            }
        }
    }

    public void ApplyPotion2(string name)
    {
        List<Transition> transitions = GetPossibleTransitions(_currentState);
        foreach (var transition in transitions)
        {
            if (transition.potion.name == name)
            {
                _potionsUsed++;
                _currentState = transition.toState;
                _audioSource.clip = _currentState.clip;
                _audioSource.Play();
                _audioSource.loop = _currentState.loop;
                break;
            }
        }
    }
}
