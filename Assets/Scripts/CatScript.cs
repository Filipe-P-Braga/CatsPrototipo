using UnityEngine;
using UnityEngine.SceneManagement;


public class CatScript : MonoBehaviour
{
    public Subject pettingSubject; // nome claro



    [SerializeField] private Vector3 lastMousePosition;


    [Header("Configuração")]
    public float pettingTimeout = 0.1f;
    private float pettingTimer = 0f;
    public bool isPetting = false;


    void Update()
    {
        GetOut();

        if (pettingTimer > 0)
        {
            pettingTimer -= Time.deltaTime;
        }

        else if (isPetting)
        {
            StopPetting();
        }


    }



    private void OnMouseOver()
    {

        Vector3 mousePosition = Input.mousePosition;

        bool isMouseMoved = Vector3.Distance(mousePosition, lastMousePosition) > 0.01f;

        if (isMouseMoved)
        {
            isPetting = true;
            pettingTimer = pettingTimeout;

            pettingSubject.RaisePettingEvent(true);
        }

        lastMousePosition = mousePosition;
    }

    private void StopPetting()
    {

        isPetting = false;

        pettingSubject.RaisePettingEvent(false);
    }


    public void GetOut()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
