using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEditor;

public class RegisterScript : MonoBehaviour
{

    Conexion c = new Conexion();

    // Variables que obtendrán los datos de la GUI
    
    [SerializeField] private GameObject m_interfazloginUI = null;
    [SerializeField] private GameObject m_interfazregistrarUI = null;
    public InputField nombre;
    public InputField apellidopaterno;
    public InputField apellidomaterno;
    public InputField fechanacimiento;
    public InputField pais;
    public InputField correo;
    public InputField contraseña;
    public InputField confcontraseña;

    // Botones

    public Button btnCrearCuenta;
    public Button btnIniciarSesion;

    // Variables Privadas

    private string Nombre;
    private string Apellidopaterno;
    private string Apellidomaterno;
    private string Fechanacimiento;
    private string Pais;
    private string Correo;
    private string Contraseña;
    private string Confcontraseña;
    private bool CorreoValido = false;
    private string[] Caracteres = {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","ñ","o","p","q","r","s","t","u","v","w","x","y","z","A","B","C","D","E","F","G","H","I","J","K","L","M","N","Ñ","O","P","Q","R","S","T","U","V","W","X","Y","Z","1","2","3","4","5","6","7","8","9","0","_","-"};

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

        btnCrearCuenta.onClick.AddListener(CrearCuenta);
        btnIniciarSesion.onClick.AddListener(irIniciarSesion);

    }

    public void CrearCuenta()
    {
        
        bool NOMB = false;
        bool APAT = false;
        bool AMAT = false;
        bool FNAC = false;
        bool PAIS = false;
        bool CORR = false;
        bool CONT = false;
        bool CONF = false;

        // Validación para nombre

        if (Nombre != "") {
            if (Nombre.Length >= 3) {
                NOMB = true;
            } else {
                Debug.LogWarning("Ingresar nombre con más de 2 letras");
            }
        } else {
            Debug.LogWarning("Ingresar nombre");
        }

        // Validación para ape pat

        if (Apellidopaterno != "") {
            if (Apellidopaterno.Length >= 3) {
                APAT = true;
            } else {
                Debug.LogWarning("Ingresar apellido con más de 2 letras");
            }
        } else {
            Debug.LogWarning("Ingresar apellido");
        }

        // Validación para ape mat

        if (Apellidomaterno != "") {
            if (Apellidomaterno.Length >= 3) {
                AMAT = true;
            } else {
                Debug.LogWarning("Ingresar apellido con más de 2 letras");
            }
        } else {
            Debug.LogWarning("Ingresar apellido");
        }

        // Validación para fecha nac

        if (Fechanacimiento != "") {
            if (Fechanacimiento.Length == 10) {
                FNAC = true;
            } else {
                Debug.LogWarning("Ingresar fecha de nacimiento correcta");
            }
        } else {
            Debug.LogWarning("Ingresar fecha de nacimiento");
        }

        // Validación para pais

        if (Pais != "") {
                PAIS = true;
            } else {
            Debug.LogWarning("Ingresar pais de residencia");
        }

        // Validación para correo

        if (Correo != "") {
            ValidarCorreo();
            if (CorreoValido) {
                if (Correo.Contains("@")) {
                    if (Correo.Contains(".")) {
                        CORR = true;
                    } else {
                        Debug.LogWarning("Correo incorrecto");
                    }
                } else {
                    Debug.LogWarning("Correo incorrecto");
                }
            } else {
                Debug.LogWarning("Correo incorrecto");
            }
        } else {
            Debug.LogWarning("Ingresar correo");
        }

        // Validación para contraseña

        if (Contraseña != "") {
            if (Contraseña.Length >= 8){
                CONT = true;
            } else {
                Debug.LogWarning("La contraseña debe tener más de 8 caracteres");
            }
        } else {
            Debug.LogWarning("Ingresar contraseña");
        } 

        // Validación para confirmación de contraseña

        if (Confcontraseña != "") {
            if (Confcontraseña == Contraseña) {
                CONF = true;
            } else {
                Debug.LogWarning("Las contraseñas no coinciden");
            }
        } else {
            Debug.LogWarning("Ingresar confirmación de contraseña");
        } 


        if(NOMB == true && APAT == true && AMAT == true && FNAC == true && PAIS == true && CORR == true && CONT == true && CONF == true)
        {
            c.CrearCuenta(Nombre,Apellidopaterno,Apellidomaterno,Fechanacimiento,Pais,Correo,Contraseña);
            //print("Creación de cuenta exitosa");
            LimpiarCampos();
        }else{
            print("Error en la creación de cuenta");
        }        
    }

    private void irIniciarSesion()
    {
        //  No Mostrar vista Registrar y Mostrar vista Login 
        
        m_interfazregistrarUI.SetActive(false);
        m_interfazloginUI.SetActive(true);
        LimpiarCampos();

    }

    public void LimpiarCampos()
    {
        nombre.GetComponent<InputField>().text = "";
        apellidopaterno.GetComponent<InputField>().text = "";
        apellidomaterno.GetComponent<InputField>().text = "";
        fechanacimiento.GetComponent<InputField>().text = "";
        pais.GetComponent<InputField>().text = "";
        correo.GetComponent<InputField>().text = "";
        contraseña.GetComponent<InputField>().text = "";
        confcontraseña.GetComponent<InputField>().text = "";
    }

    public void TomarDatos()
    {
        Nombre = nombre.GetComponent<InputField>().text;
        Apellidopaterno = apellidopaterno.GetComponent<InputField>().text;
        Apellidomaterno = apellidomaterno.GetComponent<InputField>().text;
        Fechanacimiento = fechanacimiento.GetComponent<InputField>().text;
        Pais = pais.GetComponent<InputField>().text;
        Correo = correo.GetComponent<InputField>().text;
        Contraseña = contraseña.GetComponent<InputField>().text;
        Confcontraseña = confcontraseña.GetComponent<InputField>().text;
    }
    
    public void ValidarCorreo(){
       
        bool INICIO = false;
        bool FINAL = false;

        for (int i=0; i<Caracteres.Length; i++)
        {
            if (Correo.StartsWith(Caracteres[i])) {
                INICIO = true;
            }
        }
        
        for (int i=0; i<Caracteres.Length; i++)
        {
            if (Correo.EndsWith(Caracteres[i])) {
                FINAL = true;
            }
        }

        if (INICIO == true && FINAL == true){
            CorreoValido = true;
        } else {
            CorreoValido = false;
        }
    }  

}
