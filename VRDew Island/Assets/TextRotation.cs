using UnityEngine;

public class TextRotation : MonoBehaviour
{

    public GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(mainCamera.transform);
        transform.rotation = Quaternion.LookRotation(mainCamera.transform.forward);
    }
}
