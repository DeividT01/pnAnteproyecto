using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform[] pivotes;
    public GameObject people;
    public int elementoActual;
    [Range(.1f, 10f)]
    public int speed;
    private void Awake()
    {
        people.SetActive(false);
    }
    void Start()
    {
        elementoActual = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, pivotes[elementoActual].position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, pivotes[elementoActual].rotation, speed * Time.deltaTime * 0.9f);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(people.activeInHierarchy)
                people.SetActive(false);
            else
                people.SetActive(true);
            elementoActual = (elementoActual + 1) % pivotes.Length;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (people.activeInHierarchy)
                people.SetActive(false);
            else
                people.SetActive(true);
            elementoActual -= 1;
            if (elementoActual < 0)
            {
                elementoActual = pivotes.Length - 1;
            }

        }
        


    }
}
