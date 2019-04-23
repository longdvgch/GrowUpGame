using UnityEngine;

public class Background : MonoBehaviour {

    public static Background instance;
    public float scrollSpeed;
    private Material mate;
    private Vector2 offset = Vector2.zero;

    private void Awake()
    {
        mate = GetComponent<Renderer>().material;
    }
    // Use this for initialization
    void Start () {
        float bHeight = Camera.main.orthographicSize * 2f;
        float bWitdh = bHeight * Screen.width / Screen.height;
        transform.localScale = new Vector3(bWitdh, bHeight, 0);
        offset = mate.GetTextureOffset("_MainTex");
    }
    void Update()
    {
        MakeInstance();
        offset.y += scrollSpeed * Time.deltaTime;
        mate.SetTextureOffset("_MainTex", offset);         
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
