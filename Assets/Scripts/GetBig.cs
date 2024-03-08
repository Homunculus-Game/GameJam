using UnityEngine;

public class GetBig : MonoBehaviour
{
    public Potion rubedo;
    public Potion albedo;
    public Potion nigredo;

    public Material material;

    private Vector3 initialScale;

    private void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {
        if (rubedo.number == 1)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, initialScale * 1.2f, 4.0f * Time.deltaTime);
        }
        if (rubedo.number == 2)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, initialScale * 1.4f, 4.0f * Time.deltaTime);
        }
        if (rubedo.number == 3)
        {
            GetComponent<Renderer>().material = material;
        }
    }
}
