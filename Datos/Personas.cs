﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Personas
    {
        public static DataTable Listar()
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_PERSONAS_LISTAR", cn);

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las personas: " + ex.Message);
            }
        }

        public static DataTable Obtener(int idPersona)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_PERSONAS_OBTENER", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@IdPersona", idPersona));

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;


                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener a la persona deseada: " + ex.Message);
            }
        }

        public static DataTable Buscar(int idPersona)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_PERSONAS_BUSCAR", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@IdPersona", idPersona));

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;


                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener a la persona deseada: " + ex.Message);
            }
        }

        public static int Insertar(string nombre, 
            string apellido,
            int dni,
            string direccion,
            string email,
            int estadoCivil)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_PERSONAS_INSERTAR", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@Apellido", apellido));
                    cmd.Parameters.Add(new SqlParameter("@DNI", dni));
                    cmd.Parameters.Add(new SqlParameter("@Direccion", direccion));
                    cmd.Parameters.Add(new SqlParameter("@Email", email));
                    cmd.Parameters.Add(new SqlParameter("@Id_EstadoCivil", estadoCivil));

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }

                return Convert.ToInt32(dt.Rows[0][0]);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar una persona: " + ex.Message);
            }
        }

        public static void Modificar(int idPersona,
            string nombre,
            string apellido,
            int dni,
            string direccion,
            string email,
            int estadoCivil)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_PERSONAS_MODIFICAR", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@IdPersona", idPersona));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@Apellido", apellido));
                    cmd.Parameters.Add(new SqlParameter("@DNI", dni));
                    cmd.Parameters.Add(new SqlParameter("@Direccion", direccion));
                    cmd.Parameters.Add(new SqlParameter("@Email", email));
                    cmd.Parameters.Add(new SqlParameter("@Id_EstadoCivil", estadoCivil));


                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error al modificar a la persona: " + ex.Message);
            }
        }

        public static void Eliminar(int idPersona)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_PERSONAS_ELIMINAR", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@IdPersona", idPersona));

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar a la persona: " + ex.Message);
            }
        }
    }
}
