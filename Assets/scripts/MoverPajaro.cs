using UnityEngine;

public class MoverPajaro : MonoBehaviour
{
    public int velocidad;
    private Transform miTransform;
    public Vector3 _velocidad;
    public Transform posDisparo;
    public float tiempoLanzar;
    private float tiempoActual;
    public GameObject bomba;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        miTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        miTransform.Translate(_velocidad * velocidad * Time.deltaTime);
        tiempoActual += Time.deltaTime;
        if (tiempoActual >= tiempoLanzar)
        {
            TirarBomba();
            tiempoActual = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag.Equals("colDcha"))
        {
            miTransform.rotation = Quaternion.Euler(0, 0, 0);
            _velocidad.x = _velocidad.x * -1;
            

        }
        else if (collision.transform.tag.Equals("colIzda") )
        {
            miTransform.rotation = Quaternion.Euler(0, 180, 0);
            _velocidad.x = _velocidad.x * -1;
            

        }
       

    }

    private void TirarBomba()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(bomba, posDisparo.position, miTransform.rotation);
        }
    }
}

