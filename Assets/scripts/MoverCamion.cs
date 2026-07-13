using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoverCamion : MonoBehaviour
{
    public int velocidad;
    private Transform miTransform;
    public Vector3 _velocidad;
    public int numGolpes;
    private GameObject texto;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        texto = GameObject.Find("texto").gameObject;
        texto.GetComponent<TextMeshProUGUI>().text = numGolpes.ToString();
        miTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        miTransform.Translate(_velocidad * velocidad * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("colIzda"))
        {
            _velocidad.x = _velocidad.x * -1;
            miTransform.rotation = Quaternion.Euler(0, 0, 0);

        }else if (collision.transform.tag.Equals("colDcha"))
        {
            _velocidad.x = _velocidad.x * -1;
            miTransform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public void golpe()
    {
        numGolpes--;
        texto.GetComponent<TextMeshProUGUI>().text = numGolpes.ToString();

        if (numGolpes == 0)
        {
            //Destroy(this.gameObject);

            this.transform.GetComponent<Animator>().SetTrigger("explotar");
        }
    }

    public void DestruirCamion()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene("NewScene");
    }
}
