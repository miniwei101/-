
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace NAME.Models
{
    public class Class1
    {
        public int fId { get; set; }
        public string fClass { get; set; }
        public string fName { get; set; }
        public string fTime { get; set; }
        public int fnum { get; set; }
        public List<Class1> queryBySql(string sql)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=shopping;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Class1> list = new List<Class1>();
            while (reader.Read())
            {
                Class1 x = new Class1()
                {
                    fId = (int)reader["id"],
                    fnum = (int)reader["anum"],
                    fClass = reader["aclass"].ToString(),
                    fName = reader["aname"].ToString(),
                    fTime = reader["atime"].ToString()
                };
                list.Add(x);
            }
            con.Close();
            return list;
        }
        public void create(Class1 p)
        {
            string sql = "insert into CLASS_A(";
            //sql += "fId,";
            sql += "aclass,";
            sql += "aname,";
            sql += "atime,";
            sql += "anum";
            sql += ")VALUES(";
            sql += "'" + "全端工程師就業養成班" + "',";
            sql += "'" + "陳小饅" + "',";
            sql += "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',";
            sql += "'" + "1" + "')";

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=shopping;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<Class1> queryByKeyword(string keyword)
        {
            string sql = "select * from CLASS_A where aclass LIKE '%" + keyword + "%'";
            sql += "or aname LIKE '%" + keyword + "%'";
            sql += "or anum LIKE '%" + keyword + "%'";
            return queryBySql(sql);
        }
        public List<Class1> queryByDate(string datetime)
        {
            //string noon = Request.Form["txtnoon"];
            //int qq=
            //string sql = "select * from CLASS_A where atime LIKE '%" + datetime + "%'";
            string sql = "select * from CLASS_A where atime LIKE '%" + datetime + "%'";
            return queryBySql(sql);
        }
        public List<Class1> queryAll()
        {
            return queryBySql("select * from CLASS_A");
        }
    }
}