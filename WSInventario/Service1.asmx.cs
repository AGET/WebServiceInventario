using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace WSInventario
{
    /// <summary>
    /// Descripción breve de Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

       /* [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string HolaNombre(String nombre)
        {
            return "Hola " + nombre;
        }*/


        /* Consultas */

        [WebMethod]
        public String consultaProductos(){
            String registro = "";
            SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = "Server=SYC-LP\\SQLEXPRESS;" +
            //      "Database=BDAgenda;User Id=sa; Password=12345;";
            conn.ConnectionString = "Server=WORKSTATION-PC\\SQLEXPRESS;" +
                    "Database=WSInventario;User Id=SA; Password=123;";

            try{
                conn.Open();
                SqlDataAdapter cmd = new
                    SqlDataAdapter("select * from productos;", conn);
                DataSet data = new DataSet();
                cmd.Fill(data, "datos");
                DataTable tabla = data.Tables[0];
                for (int i = 0; i < tabla.Rows.Count; i++){
                    Array a = tabla.Rows[i].ItemArray;
                    registro += a.GetValue(0).ToString() + ",";
                    registro += a.GetValue(1).ToString() + ",";
                    registro += a.GetValue(2).ToString() + ",";
                    registro += a.GetValue(3).ToString() + ",";
                    registro += a.GetValue(4).ToString() + ",";
                    registro += a.GetValue(5).ToString() + "*";
                }
            }catch (Exception ex){
                registro = "Conexion No Exitosa";
            }finally{
                conn.Close();
            }
            return registro;
        }
        
        [WebMethod]
        public String consultaProveedores(){
            String registro = "";
            SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = "Server=SYC-LP\\SQLEXPRESS;" +
            //      "Database=BDAgenda;User Id=sa; Password=12345;";
            conn.ConnectionString = "Server=WORKSTATION-PC\\SQLEXPRESS;" +
                    "Database=WSInventario;User Id=SA; Password=123;";

            try{
                conn.Open();
                SqlDataAdapter cmd = new
                    SqlDataAdapter("select * from proveedor;", conn);
                DataSet data = new DataSet();
                cmd.Fill(data, "datos");
                DataTable tabla = data.Tables[0];
                for (int i = 0; i < tabla.Rows.Count; i++){
                    Array a = tabla.Rows[i].ItemArray;
                    registro += a.GetValue(0).ToString() + ",";
                    registro += a.GetValue(1).ToString() + ",";
                    registro += a.GetValue(2).ToString() + ",";
                    registro += a.GetValue(3).ToString() + ",";
                    registro += a.GetValue(4).ToString() + ",";
                    registro += a.GetValue(5).ToString() + "*";
                }
            }catch (Exception ex){
                registro = "Conexion No Exitosa";
            }finally{
                conn.Close();
            }
            return registro;
        }
        
        [WebMethod]
        public String consultaCategoria(){
            String registro = "";
            SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = "Server=SYC-LP\\SQLEXPRESS;" +
            //      "Database=BDAgenda;User Id=sa; Password=12345;";
            conn.ConnectionString = "Server=WORKSTATION-PC\\SQLEXPRESS;" +
                    "Database=WSInventario;User Id=SA; Password=123;";

            try{
                conn.Open();
                SqlDataAdapter cmd = new
                    SqlDataAdapter("select * from categoria;", conn);
                DataSet data = new DataSet();
                cmd.Fill(data, "datos");
                DataTable tabla = data.Tables[0];
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    Array a = tabla.Rows[i].ItemArray;
                    registro += a.GetValue(0).ToString() + ",";
                    registro += a.GetValue(1).ToString() + "*";
                }
            }catch (Exception ex){
                registro = "Conexion No Exitosa";
            }finally{
                conn.Close();
            }
            return registro;
        }


        /*inserciones*/

        [WebMethod]
        public String insertarProveedor(String id, String nombre, String apPaterno, 
            String apMaterno, String telefono,String email){
            SqlConnection conn = new SqlConnection();
            // conn.ConnectionString = "Server=SYC-LP\\SQLEXPRESS;" +
            //       "Database=WSAgenda;User Id=SA; Password=123;";

            conn.ConnectionString = "Server=WORKSTATION-PC\\SQLEXPRESS;" +
                    "Database=WSInventario;User Id=SA; Password=123;";

            //WORKSTATION-PC\SQLEXPRESS;Initial Catalog=WSAgenda;User ID=SA;Password=***********
            try{
                conn.Open();
                String instruccion =
                    "Insert into proveedor (idProveedor,nombre," +
                              "apPaterno,apMaterno,telefono,email) " +
                    "Values (" +
                    "'" + id + "'," +
                    "'" + nombre + "'," +
                    "'" + apPaterno + "'," +
                    "'" + apMaterno + "'," +                    
                    "'" + telefono + "'," +
                    "'" + email + "'" +
                    ")";
                SqlCommand com = new SqlCommand(instruccion, conn);
                com.ExecuteNonQuery();
            }catch (Exception ex){
                return ex.ToString();
            }finally{
                conn.Close();
            }
            return "ok";
        }

        [WebMethod]
        public String insertarCategoria(String id, String nombre){
            SqlConnection conn = new SqlConnection();
            // conn.ConnectionString = "Server=SYC-LP\\SQLEXPRESS;" +
            //       "Database=WSAgenda;User Id=SA; Password=123;";

            conn.ConnectionString = "Server=WORKSTATION-PC\\SQLEXPRESS;" +
                    "Database=WSInventario;User Id=SA; Password=123;";

            //WORKSTATION-PC\SQLEXPRESS;Initial Catalog=WSAgenda;User ID=SA;Password=***********
            try{
                conn.Open();
                String instruccion =
                    "Insert into categoria (idCategoria,nombre) " +
                    "Values (" +
                    "'" + id + "'," +
                    "'" + nombre + "'" +
                    ")";
                SqlCommand com = new SqlCommand(instruccion, conn);
                com.ExecuteNonQuery();
            }catch (Exception ex){
                return ex.ToString();
            }finally{
                conn.Close();
            }
            return "ok";
        }


        [WebMethod]
        public String insertarProducto(String id, String nombre, String precio,int cantidad,
                                     String idCategoria, String idProveedor){
            SqlConnection conn = new SqlConnection();
            // conn.ConnectionString = "Server=SYC-LP\\SQLEXPRESS;" +
            //       "Database=WSAgenda;User Id=SA; Password=123;";

            conn.ConnectionString = "Server=WORKSTATION-PC\\SQLEXPRESS;" +
                    "Database=WSInventario;User Id=SA; Password=123;";

            //WORKSTATION-PC\SQLEXPRESS;Initial Catalog=WSAgenda;User ID=SA;Password=***********
            try{
                conn.Open();
                String instruccion =
                    "Insert into productos (idProducto,nombre," +
                              "precio,cantidad,idCategoria,idProveedor) " +
                    "Values (" +
                    "'" + id + "'," +
                    "'" + nombre + "'," +
                    "'" + precio + "'," +
                    "" + cantidad + "," +
                    "'" + idCategoria + "'," +
                    "'" + idProveedor + "'" +
                    ")";
                SqlCommand com = new SqlCommand(instruccion, conn);
                com.ExecuteNonQuery();
            }catch (Exception ex){
                return ex.ToString();
            }finally{
                conn.Close();
            }
            return "ok";
        }


        /* Actualizaciones */

        [WebMethod]
        public String actualizarProveedor(String id, String nombre, String apPeterno,
        String apMaterno, String telefono, String email)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=WORKSTATION-PC\\SQLEXPRESS;" +
                    "Database=WSInventario;User Id=SA; Password=123;";
            try
            {
                conn.Open();
                String instruccion =
                    "UPDATE proveedor "
                + "SET nombre = '" + nombre +"',"
                + " apPaterno = '" + apPeterno + "',"
                + " apMaterno = '" + apMaterno + "',"
                + " telefono = '" + telefono + "',"
                + " email = '" + email + "'"
                + " WHERE idProveedor = '" + id + "'";
                SqlCommand com = new SqlCommand(instruccion, conn);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                conn.Close();
            }
            return "OK";
        }

        [WebMethod]
        public String actualizarCategoria(String id, String nombre)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=WORKSTATION-PC\\SQLEXPRESS;" +
                    "Database=WSInventario;User Id=SA; Password=123;";
            try
            {
                conn.Open();
                String instruccion =
                    "UPDATE categoria "
                + "SET nombre = '" + nombre + "'"               
                + " WHERE idCategoria = '" + id + "'";
                SqlCommand com = new SqlCommand(instruccion, conn);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                conn.Close();
            }
            return "OK";
        }

        [WebMethod]
        public String actualizarProducto(String id, String nombre, String precio,int cantidad,
        String idCategoria, String idProveedor)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=WORKSTATION-PC\\SQLEXPRESS;" +
                    "Database=WSInventario;User Id=SA; Password=123;";
            try
            {
                conn.Open();
                String instruccion =
                    "UPDATE productos "
                + "SET nombre = '" + nombre + "',"
                + " precio = '" + precio + "',"
                + " cantidad = " + cantidad + ","
                + " idCategoria = '" + idCategoria + "',"
                + " idProveedor = '" + idProveedor + "'"
                + " WHERE idProducto = '" + id + "'";
                SqlCommand com = new SqlCommand(instruccion, conn);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally 
            {
                conn.Close();
            }
            return "OK";
        }

    /* Eliminaciones */
        [WebMethod]
        public String eliminarProveedor(String id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=WORKSTATION-PC\\SQLEXPRESS;" +
                    "Database=WSInventario;User Id=SA; Password=123;";
            try
            {
                conn.Open();
                String instruccion = "DELETE FROM proveedor WHERE idProveedor = '" + id + "'";
                SqlCommand com = new SqlCommand(instruccion, conn);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                conn.Close();
            }
            return "OK";
        }

        [WebMethod]
        public String eliminarCategoria(String id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=WORKSTATION-PC\\SQLEXPRESS;" +
                    "Database=WSInventario;User Id=SA; Password=123;";
            try
            {
                conn.Open();
                String instruccion =
                   "DELETE FROM categoria WHERE idCategoria = '" + id + "'";
                SqlCommand com = new SqlCommand(instruccion, conn);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                conn.Close();
            }
            return "OK";
        }

        [WebMethod]
        public String eliminarProducto(String id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=WORKSTATION-PC\\SQLEXPRESS;" +
                    "Database=WSInventario;User Id=SA; Password=123;";
            try
            {
                conn.Open();
                String instruccion =
                    "DELETE FROM productos WHERE idProducto = '" + id + "'";
                SqlCommand com = new SqlCommand(instruccion, conn);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                conn.Close();
            }
            return "OK";
        }
    }
}