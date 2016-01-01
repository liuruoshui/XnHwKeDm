using SXEdu2XHKD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SXEdu2XHKD.Domain.Concrete.DAL
{
    public partial class Member
    {
        public Member()
        {
            DbHelper.connectionString = ConfigurationManager.AppSettings["ConnectionStringSXEdu"];
        }
        /// <summary>
        /// 判断某个用户名的用户是否存在
        /// </summary>
        /// <param name="name">全表唯一的用户名</param>
        /// <returns></returns>
        public bool NameExists(string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Members");
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar)};
            parameters[0].Value = name;

            return DbHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据用户名获取用户对象
        /// </summary>
        /// <param name="name">全表唯一的用户名</param>
        /// <returns></returns>
        public SXEdu2XHKD.Domain.Entities.Member GetModelByName(string name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MemberId,SxEduUserInfo,SXEduUserName,School,Grade,ClassName,UserName,PassWord,BirthDay,Email,Name,RegisterTime,QQ,UserType,ParentName,UserStatus from Members ");
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar)			};
            parameters[0].Value = name;

            SXEdu2XHKD.Domain.Entities.Member model = new SXEdu2XHKD.Domain.Entities.Member();
            DataSet ds = DbHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public SXEdu2XHKD.Domain.Entities.Member GetModelBySXEduUserName(string name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MemberId,SxEduUserInfo,SXEduUserName,School,Grade,ClassName,UserName,PassWord,BirthDay,Email,Name,RegisterTime,QQ,UserType,ParentName,UserStatus from Members ");
            strSql.Append(" where SXEduUserName=@SXEduUserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@SXEduUserName", SqlDbType.NVarChar)			};
            parameters[0].Value = name;

            //SXEdu2XHKD.Domain.Entities.Member model = new SXEdu2XHKD.Domain.Entities.Member();
            DataSet ds = DbHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public List<SXEdu2XHKD.Domain.Entities.Member> GetMemberListByRegisterDate(DateTime date)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MemberId,SxEduUserInfo,SXEduUserName,School,Grade,ClassName,UserName,PassWord,BirthDay,Email,Name,RegisterTime,QQ,UserType,ParentName,UserStatus from Members ");
            DateTime dateStart = date;
            DateTime dateEnd = date.AddDays(1);

            strSql.Append(" where RegisterTime between @DateStart and @DateEnd");
            SqlParameter[] parameters = {
					new SqlParameter("@DateStart", SqlDbType.DateTime),
                    new SqlParameter("@DateEnd", SqlDbType.DateTime)
			};
            parameters[0].Value = dateStart;
            parameters[1].Value = dateEnd;


            DataSet ds = DbHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                List<SXEdu2XHKD.Domain.Entities.Member> memberList = new List<Entities.Member>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    memberList.Add(DataRowToModel(row));
                }
                return memberList;
            }
            else
            {
                return null;
            }
        }
        
        /// <summary>
        /// 获取全部用户列表
        /// </summary>
        /// <returns></returns>
        public List<SXEdu2XHKD.Domain.Entities.Member> GetAllMemberList()
        {
            DataSet ds =  GetList("");
            if (ds.Tables[0].Rows.Count > 0)
            {
                List<SXEdu2XHKD.Domain.Entities.Member> memberList = new List<Entities.Member>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    memberList.Add(DataRowToModel(row));
                }
                return memberList;
            }
            else
            {
                return null;
            }
        }
    }
}
