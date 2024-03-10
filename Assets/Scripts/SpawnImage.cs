using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnImage : MonoBehaviour
{
    // public GameObject image;

    // public GameObject canvas;
    // 
    // void Update()
    // {
    //     // if (Input.GetMouseButtonDown(0))
    //     // {
    //     //     Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //     //     Instantiate(image, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
    //     // }
    // }

    public GameObject markerPrefab;

    private GameObject obj;

    [SerializeField] private Canvas _canvas;

    private GameObject _rectTransform;
    [SerializeField] private GameObject _spawn;

    // bool inHand = false;

    [SerializeField] private GameObject _sprite;

    private SpriteRenderer _spriteRenderer;

    [SerializeField] private Potion _rubedo;

    // public void OnBeginDrag(PointerEventData eventData)
    // {
    //     eventData.pointerDrag = obj;
    // }

    private void Awake()
    {
        // If no canvas is provided get it by tag
        // if (!_canvas) _canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
    }

    private void Start()
    {
        _spriteRenderer = _sprite.GetComponent<SpriteRenderer>();

        // _rubedo.count = 3;
    }

    private void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     Ray mouseClickRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        // 
        //     if (Physics.Raycast(mouseClickRay, out RaycastHit hit))
        //     {
        //         if (hit.transform.CompareTag("sprite"))
        //         {
        //             // _rubedo.count--;
        //             _rectTransform = Instantiate(_spawn, Input.mousePosition, Quaternion.identity, _canvas.transform);
        //             inHand = true;
        //             //Debug.Log("it is sprite");
        // 
        //             if (_rubedo.count == 0)
        //             {
        //                 // _spriteRenderer.sprite = null;
        //                 _sprite.SetActive(false);
        //             }
        //         }
        //         else if (hit.transform.CompareTag("blob") && inHand == true)
        //         {
        //             Destroy(_rectTransform);
        //             inHand = false;
        //             //Debug.Log("sprite gone");
        //         }
        //         else
        //         {
        //             if (_rubedo.count != 0 && inHand == true)
        //             {
        //                 _rubedo.count++;
        //             }
        //             else if (_rubedo.count == 0 && inHand == true)
        //             {
        //                 _rubedo.count++;
        //                 // _spriteRenderer.sprite = _rubedo.sprite;
        //                 _sprite.SetActive(true);
        //             }
        // 
        //             Destroy(_rectTransform);
        //             inHand = false;
        //         }
        // 
        //     }
        // }
    }
}
