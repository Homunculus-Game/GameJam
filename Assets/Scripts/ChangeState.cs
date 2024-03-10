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

    [SerializeField] private State _defaultState;

    [SerializeField] private UsePotion[] usePotionScripts;

    private State _currentState;

    public static int _potionsUsed = 0;

    [SerializeField] private AudioSource[] _audio;

    private AudioSource _audioSource;

    private void Awake()
    {
        foreach (var usePotionScript in usePotionScripts)
        {
            usePotionScript.OnPotionUsed += ApplyPotion;
        }
    }

    private void Start()
    {
        _currentState = _defaultState;
        _transform.localScale = _defaultState.scale;

        _potionsUsed = 0;

        _audioSource = GetComponent<AudioSource>();
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

                    _stage1.transform.localScale = Vector3.Lerp(_stage1.transform.localScale, _currentState.scale, 4.0f * Time.deltaTime);

                    break;
                }
            case 1:
                {
                    _stage1.SetActive(false);
                    _stage2.SetActive(true);
                    //_stage3.SetActive(false);

                    _stage2.transform.localScale = Vector3.Lerp(_stage2.transform.localScale, _currentState.scale, 4.0f * Time.deltaTime);
                    break;
                }
            case 2:
                {
                    //_stage1.SetActive(false);
                    //_stage2.SetActive(false);
                    //_stage3.SetActive(true);

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
        // _audioSource.clip = _currentState.clip;
        //if (_currentState.name == "big2")
        {
            //_audio[0].Play();

        }
        //if (_currentState.name == "big3")
        {
            // _audio[1].Play();
            //_audioSource.clip = _currentState.clip; _audioSource.Play();
        }
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

    void ApplyPotion(Potion potion)
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
}
