using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using System.Windows.Forms;


namespace bitacoras_pgsys
{
    class conexion_bd
    {
        public static DataTable arreglo_datatable(string nomb) {
            DataTable dt;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "server=www.pgsys.cl; user id=cuadrala_nova; password=ME_feb112011; database=cuadrala_nova;";
            try
            {
                string sql;
                if (nomb.Equals(""))
                {
                    sql = "SELECT * FROM datos_config ORDER BY empresa_datos ASC";
                }
                else { sql = "SELECT * FROM datos_config WHERE empresa_datos LIKE '%" + nomb + "%' OR titulo_datos LIKE '%" + nomb + "%' ORDER BY empresa_datos ASC"; }
                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                dt = new DataTable("bitacoras");
                da.Fill(dt);
                return dt;
            }
            catch (Exception) { 
            dt = new DataTable();
            dt = null;
            return dt;
            }
            finally
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
            }
        }
        public static bitacora detalle_bitacora(int cod) { 
        bitacora bita = new bitacora();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = "server=www.pgsys.cl; user id=cuadrala_nova; password=ME_feb112011; database=cuadrala_nova;";
        MySqlCommand cmd = new MySqlCommand("SELECT * FROM datos_config WHERE cod_datos=" + cod, con);
        try{
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) {
                bita.codigo_bitacora = cod;
                bita.empresa_bitacora = reader.GetString(1);
                bita.titulo_bitacora = reader.GetString(2);
                bita.descripcion_bitacora = reader.GetString(3);
                bita.ultmod_bitacora = reader.GetDateTime(4);
            }
            con.Close();
            return bita;
        }
        catch (Exception) {
            bita = null;
            return bita;
        }
        finally { if (con.State == ConnectionState.Open) { con.Close(); } }
        }
        public static void crear_bitacora(string empresa, string titulo, string descripcion) { Ejecutar("INSERT INTO `datos_config` (`cod_datos`,`empresa_datos`,`titulo_datos`,`descripcion_datos`,`ultmod_datos`) VALUES (NULL, '" + empresa + "', '" + titulo + "', '" + descripcion + "', NOW());"); }
        public static void editar_bitacora(int cod,string empresa, string titulo, string descripcion) { Ejecutar("UPDATE `datos_config` SET `empresa_datos`='" + empresa + "',`titulo_datos`='" + titulo + "',`descripcion_datos`='" + descripcion + "',`ultmod_datos`=now() WHERE `cod_datos`=" + cod); }
        public static void eliminar_bitacora(int cod) { Ejecutar("DELETE FROM datos_config WHERE `cod_datos` = " + cod); }
        public static void Ejecutar(string stc) {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "server=www.pgsys.cl; user id=cuadrala_nova; password=ME_feb112011; database=cuadrala_nova;";
            MySqlCommand cmd = new MySqlCommand(stc, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.ToString()); }
            finally {
                if (con.State == ConnectionState.Open) { con.Close(); }
            }
        }
    }
}
