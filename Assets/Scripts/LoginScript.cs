using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginScript : MonoBehaviour
{

    // Variables que obtendrán los datos de la GUI
    
    [SerializeField] private GameObject m_interfazloginUI = null;
    [SerializeField] private GameObject m_interfazregistrarUI = null;
    public InputField correo;
    public InputField contraseña;

    // Botones

    public Button btnCrearCuenta;

    // Variables públicas

    private string Correo;
    private string Contraseña;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener datos de la GUI

        TomarDatos();

        // Escuchar clic de botones
        
        btnCrearCuenta.onClick.AddListener(irCrearCuenta);

    }

    private void irCrearCuenta()
    {
        m_interfazloginUI.SetActive(false);
        m_interfazregistrarUI.SetActive(true);
        LimpiarCampos();
    }

    public void LimpiarCampos()
    {
        correo.GetComponent<InputField>().text = "";
        contraseña.GetComponent<InputField>().text = "";
    }

    public void TomarDatos()
    {
        Correo = correo.GetComponent<InputField>().text;
        Contraseña = contraseña.GetComponent<InputField>().text;
    }

}
