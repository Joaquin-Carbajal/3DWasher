using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public class Conexion : MonoBehaviour
{
	
    // Variables de conexión

    SqlConnection cn;
    SqlCommand cmd;
    SqlDataReader dr;

    public Conexion(){
		try
		{
			cn = new SqlConnection("Data Source=.;Initial Catalog=SoftwareII;Integrated Security=True");
			cn.Open();
			print("Conectado a BD");
		}catch(Exception ex)
		{
			print("Error en la conexión con BD: "+ex.ToString());
		}
	}

	public void CrearCuenta(int id, string nombre, string apepat, string apemat, string fechanac, string pais, string correo, string contraseña){
		try
		{
			cmd = new SqlCommand("Insert into Usuarios(Id,Nombre,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,Pais,Correo,Contraseña) values("+id+",'"+nombre+"','"+apepat+"','"+apemat+"','"+fechanac+"','"+pais+"','"+correo+"','"+contraseña+"')",cn);
			cmd.ExecuteNonQuery();
			print("Se creó la cuenta");
		}
		catch (Exception ex)
		{
			print("Error en la creación de cuenta: "+ex.ToString());
		}
		
	}

}
