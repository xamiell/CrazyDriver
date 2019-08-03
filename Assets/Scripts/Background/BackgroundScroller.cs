using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    private Material _material;
    private Vector2 _offset;

    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        _offset = new Vector2( 0f, GameManager.backgroundScrollSpeed );
        _material.mainTextureOffset += _offset * Time.deltaTime;
    }
}
