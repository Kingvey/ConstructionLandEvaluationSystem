using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace ConnectionManager
{
    public class SQLHelper
    {
        protected SqlConnection Connection;
    private string connectionString;
 
    public SQLHelper()
    {
        connectionString = ConfigurationSettings.AppSettings["ConnectionString"];
        Connection = new SqlConnection(connectionString);
    }
   
   /// <summary>
   /// 带参数的构造函数
   /// </summary>
   /// <param name="ConnString">数据库联接字符串</param>
   public SQLHelper(string ConnString)
   {
       string connStr;
       connStr = System.Configuration.ConfigurationSettings.AppSettings[ConnString].ToString();
       Connection = new SqlConnection(connStr);
   }
 
   /// <summary>
   /// 打开数据库
   /// </summary>
   public void  OpenConn()
   {
       if (this.Connection.State != ConnectionState.Open)
       {
           this.Connection.Open();
       }
   }
 
   /// <summary>
   /// 关闭数据库联接
   /// </summary>
   public void CloseConn()
   {
       if (Connection.State == ConnectionState.Open)
       {
           Connection.Close();
       }
   }
 
   #region 执行SQL语句，返回数据到DataSet中
   /// <summary>
   /// 执行SQL语句，返回数据到DataSet中
   /// </summary>
   /// <param name="sql">sql语句</param>
   /// <returns>返回DataSet</returns>
   public DataSet ReturnDataSet(string sql, string tableName)
   {
        DataSet dataSet = new DataSet();
        OpenConn();
        SqlDataAdapter OraDA = new SqlDataAdapter(sql, Connection);
        OraDA.Fill(dataSet, tableName);
        return dataSet;
   }
   #endregion
 
   #region 执行Sql语句,返回带分页功能的dataset
   /// <summary>
   /// 执行Sql语句,返回带分页功能的dataset
   /// </summary>
   /// <param name="sql">Sql语句</param>
   /// <param name="PageSize">每页显示记录数</param>
   /// <param name="CurrPageIndex"><当前页/param>
   /// <param name="DataSetName">返回dataset表名</param>
   /// <returns>返回DataSet</returns>
   public DataSet ReturnDataSet(string sql,int PageSize,int CurrPageIndex,string DataSetName)
   {
        DataSet dataSet = new DataSet();
        OpenConn();
        SqlDataAdapter OraDA = new SqlDataAdapter(sql, Connection);
        OraDA.Fill(dataSet, PageSize * (CurrPageIndex - 1), PageSize,DataSetName);
        return dataSet;
   }
   #endregion
 
   #region 执行SQL语句，返回 DataReader,用之前一定要先.read()打开,然后才能读到数据
   /// <summary>
   /// 执行SQL语句，返回 DataReader,用之前一定要先.read()打开,然后才能读到数据
   /// </summary>
   /// <param name="sql">sql语句</param>
   /// <returns>返回一个SqlDataReader</returns>
   public SqlDataReader ReturnDataReader(String sql)
   {
        OpenConn();
        SqlCommand command = new SqlCommand(sql,Connection);
        return command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
   }
   #endregion
 
   #region 执行SQL语句，返回记录总数数
   /// <summary>
   /// 执行SQL语句，返回记录总数数
   /// </summary>
   /// <param name="sql">sql语句</param>
   /// <returns>返回记录总条数</returns>
   public int GetRecordCount(string sql)
   {
       int recordCount = 0;
       OpenConn();
       SqlCommand command = new SqlCommand(sql,Connection);
       SqlDataReader dataReader = command.ExecuteReader();
       while(dataReader.Read())
       {
           recordCount++;
       }
       dataReader.Close();
 
       return recordCount;
   }
   #endregion
 
   #region 取当前序列,条件为seq.nextval或seq.currval
   /// <summary>
   /// 取当前序列
   /// </summary>
   /// <param name="seqstr"></param>
   /// <returns></returns>
   public decimal GetSeq(string seqstr)
   {
        decimal seqnum = 0;
        string sql = "select " + seqstr + " from dual";
        OpenConn();
        SqlCommand command = new SqlCommand(sql,Connection);
        SqlDataReader dataReader = command.ExecuteReader();
        if(dataReader.Read())
        {
            seqnum = decimal.Parse(dataReader[0].ToString());
        }
        dataReader.Close();
        //   CloseConn();
        return seqnum;
   }
   #endregion
 
   #region 执行SQL语句,返回所影响的行数
   /// <summary>
   /// 执行SQL语句,返回所影响的行数
   /// </summary>
   /// <param name="sql"></param>
   /// <returns></returns>
   public int ExecuteSQL(string sql)
   {
        int Cmd = 0;
        OpenConn();
        SqlCommand command = new SqlCommand(sql, Connection);
        try
        {
            Cmd = command.ExecuteNonQuery();
        }
        catch (SqlException e)
        {
            CloseConn();
            throw e;
        }
 
        return Cmd;
    }
    #endregion
 
   //　＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
   //　＝＝用hashTable对数据库进行insert,update,del操作,注意此时只能用默认的数据库连接"connstr"＝＝
   //　＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
 
    #region 根据表名及哈稀表自动插入数据库 用法：Insert("test",ht)
 
    /// <summary>
    /// 用hashTable对数据库进行insert操作,注意此时只能用默认的数据库连接"connstr"＝＝
    /// </summary>
    /// <param name="TableName">表名</param>
    /// <param name="ht">键值对的HashTable(字段名，值)</param>
    /// <returns>影响的行数</returns>
    public int Insert(string TableName, Hashtable ht)
    {
        SqlParameter[] Parms = new SqlParameter[ht.Count];
        IDictionaryEnumerator et = ht.GetEnumerator();
        DataTable dt = GetTabType(TableName);
        System.Data.SqlDbType otype;
        int size = 0;
        int i = 0;
        // 作哈希表循环
        while (et.MoveNext())
        {
            GetoType(et.Key.ToString().ToUpper(), dt, out otype, out size);
            SqlParameter op = MakeParam(":"+et.Key.ToString(),otype,size,et.Value.ToString());
            // 添加SqlParameter对象
            Parms[i] = op;
            i = i+1;
        }
        string str_Sql = GetInsertSqlbyHt(TableName, ht); // 获得插入sql语句
        int val = ExecuteNonQuery(str_Sql, Parms);
        return val;
    }
    #endregion
  
    #region 根据相关条件对数据库进行更新操作 用法：Update("test","Id=:Id",ht);
    
    public int Update(string TableName, string ht_Where, Hashtable ht)
    {
        SqlParameter[] Parms = new SqlParameter[ht.Count];
        IDictionaryEnumerator et = ht.GetEnumerator();
        DataTable dt = GetTabType(TableName);
        System.Data.SqlDbType otype;
        int size = 0;
        int i = 0;
        // 作哈希表循环
        while ( et.MoveNext() )
        {
            GetoType(et.Key.ToString().ToUpper(),dt,out otype,out size);
            System.Data.SqlClient.SqlParameter op=MakeParam(":"+et.Key.ToString(),otype,size,et.Value.ToString());
            Parms[i] = op; // 添加SqlParameter对象
            i = i + 1;
        }
        string str_Sql = GetUpdateSqlbyHt(TableName, ht_Where, ht); // 获得插入sql语句
        int val = ExecuteNonQuery(str_Sql, Parms);
        return val;
    }
    #endregion
   
    #region del操作,注意此处条件个数与hash里参数个数应该一致 用法：Del("test","Id=:Id",ht)
    
    /// <summary>
    /// 删除一条记录
    /// </summary>
    /// <param name="TableName">表名</param>
    /// <param name="ht_Where"></param>
    /// <param name="ht"></param>
    /// <returns></returns>
    public int Del(string TableName, string ht_Where, Hashtable ht)
    {
        SqlParameter[] Parms = new SqlParameter[ht.Count];
        IDictionaryEnumerator et = ht.GetEnumerator();
        DataTable dt = GetTabType(TableName);
        System.Data.SqlDbType otype;
        int i = 0;
        int size = 0;
        // 作哈希表循环
        while (et.MoveNext())
        {
            GetoType(et.Key.ToString().ToUpper(), dt, out otype, out size);
            SqlParameter op = MakeParam(":"+et.Key.ToString(),et.Value.ToString());
            // 添加SqlParameter对象
            Parms[i] = op;
            i = i + 1;
        }
        // 获得删除sql语句
        string str_Sql = GetDelSqlbyHt(TableName, ht_Where, ht);
        int val = ExecuteNonQuery(str_Sql,null);
        return val;
    }
    #endregion
 
   //　＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
   //　＝＝＝＝＝＝＝＝上面三个操作的内部调用函数＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
   //　＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
 
    #region 根据哈稀表及表名自动生成相应insert语句(参数类型的)
    /// <summary>
    /// 根据哈稀表及表名自动生成相应insert语句
    /// </summary>
    /// <param name="TableName">要插入的表名</param>
    /// <param name="ht">哈稀表</param>
    /// <returns>返回sql语句</returns>
    public static string GetInsertSqlbyHt(string TableName, Hashtable ht)
    {
        string str_Sql = "";
        int i = 0;
        int ht_Count = ht.Count; // 哈希表个数
        IDictionaryEnumerator myEnumerator = ht.GetEnumerator();
        string before = "";
        string behide = "";
        while ( myEnumerator.MoveNext() )
        {
             if (i==0)
             {
                before = "(" + myEnumerator.Key;
             }
             else if ( i+1 == ht_Count)
             {
                before = before+","+myEnumerator.Key+")";
             }
             else
             {
                before=before+","+myEnumerator.Key;
             }
             i = i+1;
        }
        behide = " Values"+before.Replace(",",",:").Replace("(","(:");
        str_Sql = "Insert into " + TableName + before + behide;
        return str_Sql;
    }
    #endregion
 
    #region 根据表名，where条件，哈稀表自动生成更新语句(参数类型的)
    
    public static string GetUpdateSqlbyHt(string Table,string ht_Where,Hashtable ht)
    {
        string str_Sql = "";
        int i = 0;
        int ht_Count = ht.Count; // 哈希表个数
        IDictionaryEnumerator myEnumerator = ht.GetEnumerator();
        while ( myEnumerator.MoveNext() )
        {
            if (i==0)
            {
                 if (ht_Where.ToString().ToLower().IndexOf((myEnumerator.Key+"=:"+myEnumerator.Key).ToLower())==-1)
                 {
                   str_Sql=myEnumerator.Key+"=:"+myEnumerator.Key;
                 }
            }
            else
            {
                 if (ht_Where.ToString().ToLower().IndexOf((":"+myEnumerator.Key+" ").ToLower())==-1)
                 {
                    str_Sql=str_Sql+","+myEnumerator.Key+"=:"+myEnumerator.Key;
                 }
            }
            i=i+1;
        }
        if (ht_Where==null || ht_Where.Replace(" ","") == "")  // 更新时候没有条件
        {
            str_Sql = "update "+Table+" set "+str_Sql;
        }
        else
        {
            str_Sql = "update "+ Table +" set " + str_Sql + " where " + ht_Where;
        }
        str_Sql = str_Sql.Replace("set ,","set ").Replace("update ,","update ");
        return str_Sql;
    }
    #endregion
 
    #region 根据表名，where条件，哈稀表自动生成del语句(参数类型的)
     
    public static string GetDelSqlbyHt(string Table, string ht_Where, Hashtable ht)
    {
        string str_Sql = "";
        int i = 0;
        
        int ht_Count = ht.Count; // 哈希表个数
        IDictionaryEnumerator myEnumerator = ht.GetEnumerator();
        while ( myEnumerator.MoveNext() )
        {
             if (i==0)
             {
                  if (ht_Where.ToString().ToLower().IndexOf((myEnumerator.Key+"=:"+myEnumerator.Key).ToLower())==-1)
                  {
                    str_Sql = myEnumerator.Key+"=:"+myEnumerator.Key;
                  }
             }
             else
             {
                  if (ht_Where.ToString().ToLower().IndexOf((":"+myEnumerator.Key+" ").ToLower())==-1)
                  {
                    str_Sql = str_Sql+","+myEnumerator.Key+"=:"+myEnumerator.Key;
                  }
             }
             i = i + 1;
        }
        if (ht_Where == null || ht_Where.Replace(" ","") == "")  // 更新时候没有条件
        {
            str_Sql = "Delete "+Table;
        }
        else
        {
            str_Sql = "Delete "+Table+" where "+ht_Where;
        }
        return str_Sql;
    }
    #endregion
 
    #region 生成Sql参数
    /// <summary>
    /// 生成Sql参数
    /// </summary>
    /// <param name="ParamName">字段名</param>
    /// <param name="otype">数据类型</param>
    /// <param name="size">数据大小</param>
    /// <param name="Value">值</param>
    /// <returns></returns>
    public static SqlParameter MakeParam(string ParamName,System.Data.SqlDbType otype,int size,Object Value)
    {
        SqlParameter para = new SqlParameter(ParamName,Value);
        para.SqlDbType = otype;
        para.Size = size;
        return para;
    }
    #endregion
 
    #region 生成Sql参数
    
    public static SqlParameter MakeParam(string ParamName, string Value)
    {
        return new SqlParameter(ParamName, Value);
    }
    #endregion
 
    #region 根据表结构字段的类型和长度拼装Sql sql语句参数

    public static void GetoType(string key, DataTable dt, out System.Data.SqlDbType otype, out int size)
    {
        DataView dv = dt.DefaultView;
        dv.RowFilter = "column_name='" + key + "'";
         
        string fType = dv[0]["data_type"].ToString().ToUpper();
        switch (fType)
        {  
            case "DATE":
                otype = System.Data.SqlDbType.DateTime;
               size = int.Parse(dv[0]["data_length"].ToString());
               break;
            case "CHAR":
               otype = System.Data.SqlDbType.Char;
              size=int.Parse(dv[0]["data_length"].ToString());
              break;
            case "LONG":
              otype = System.Data.SqlDbType.Decimal;
 
              size=int.Parse(dv[0]["data_length"].ToString());
              break;
            case "NVARCHAR2":
              otype = System.Data.SqlDbType.NVarChar;
              size=int.Parse(dv[0]["data_length"].ToString());
              break;
            case "VARCHAR2":
              otype = System.Data.SqlDbType.NVarChar;
              size=int.Parse(dv[0]["data_length"].ToString());
              break;
            default:
              otype = System.Data.SqlDbType.NVarChar;
              size=100;
              break;
        }
    }
     
    #endregion
 
    #region 动态取表里字段的类型和长度,此处没有动态用到connstr,是默认的！by/文少
    
    public System.Data.DataTable GetTabType(string tabname)
    {
        string sql = "select column_name,data_type,data_length from all_tab_columns where table_name='"
            + tabname.ToUpper() + "'";
        OpenConn();
        return (ReturnDataSet(sql, "dv")).Tables[0];
    }
    #endregion
 
    #region 执行sql语句
    
    public int ExecuteNonQuery(string cmdText, params SqlParameter[] cmdParms)
   {
        SqlCommand cmd = new SqlCommand();
        OpenConn(); 
        cmd.Connection = Connection;
        cmd.CommandText = cmdText;
        if (cmdParms != null)
        {
            foreach (SqlParameter parm in cmdParms)
            {
                cmd.Parameters.Add(parm);
            }
        }
        int val = cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
 
        return val;
    }
    #endregion
 
    /// <summary>
    /// 根据表名得到所属用户
    /// </summary>
    /// <param name="strTableName">表名</param>
    /// <returns>属于用户</returns>
   public string GetTableOwner(string strTableName)
   {
       string strTableOwner = string.Empty;
       OpenConn();
       string sql = "select owner from dba_tables where table_name='" + strTableName.ToUpper() + "'";
       SqlCommand cmd = new SqlCommand(sql, Connection);
       SqlDataReader odr = cmd.ExecuteReader();
       if (odr.Read())
       {
           strTableOwner = odr[0].ToString();
       }
       odr.Close();
       return strTableOwner;
   }
    }
}
