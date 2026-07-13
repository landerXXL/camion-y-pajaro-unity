using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bomba : MonoBehaviour
{
    public int velocidad;
    private Transform miTransform;
    public Vector3 _velocidad;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        miTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        miTransform.Translate(_velocidad * velocidad * Time.deltaTime);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("suelo"))
        {
            GetComponent<Animator>().SetTrigger("explosionbomba");
        }
        if (collision.transform.tag.Equals("camion"))
        {
            collision.GetComponent<MoverCamion>().golpe();
           GetComponent<Animator>().SetTrigger("explosionbomba");
        }
    }

    public void ExplotarBomba()
    {
        Destroy(gameObject);
        
    }
}