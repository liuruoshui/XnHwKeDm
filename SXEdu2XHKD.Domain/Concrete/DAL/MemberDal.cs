using MySql.Data.MySqlClient;
using SXEdu2XHKD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Data;

namespace SXEdu2XHKD.Domain.Concrete.DAL
{
    public class MemberDal
    {
        public MemberDal()
        {
        }

        /// <summary>
        /// 根据用户名获取用户对象
        /// </summary>
        /// <param name="name">全表唯一的用户名</param>
        /// <returns></returns>
        public SXEdu2XHKD.Domain.Entities.Member GetModelByName(string userName)
        {
            using (IDbConnection conn = DapperHelper.ConnectToSxEdu())
            {
                StringBuilder queryStr = new StringBuilder();
                queryStr.Append("select * from Members ");
                queryStr.Append(" where UserName=@UserName ");

                return conn.Query<SXEdu2XHKD.Domain.Entities.Member>(queryStr.ToString(), new { UserName = userName }).FirstOrDefault();
            }
        }

        /// <summary>
        /// 根据山西省教育平台用户名获得对象
        /// </summary>
        /// <param name="sxEduUserName">省平台返回的NickName</param>
        /// <returns></returns>
        public SXEdu2XHKD.Domain.Entities.Member GetModelBySXEduUserName(string sxEduUserName)
        {
            using (IDbConnection conn = DapperHelper.ConnectToSxEdu())
            {
                StringBuilder queryStr = new StringBuilder();
                queryStr.Append("select * from Members ");
                queryStr.Append(" where SXEduUserName=@SXEduUserName ");

                return conn.Query<SXEdu2XHKD.Domain.Entities.Member>(queryStr.ToString(), new { SXEduUserName = sxEduUserName }).FirstOrDefault();
            }
        }

        public IEnumerable<SXEdu2XHKD.Domain.Entities.Member> GetMemberListByRegisterDate(DateTime date)
        {
            using (IDbConnection conn = DapperHelper.ConnectToSxEdu())
            {
                StringBuilder queryStr = new StringBuilder();
                queryStr.Append("select * from Members ");
                queryStr.Append(" where RegisterTime between @DateStart and @DateEnd");
                DateTime dateStart = date;
                DateTime dateEnd = date.AddDays(1);
                return conn.Query<SXEdu2XHKD.Domain.Entities.Member>(queryStr.ToString(), new { DateStart = dateStart, DateEnd = dateEnd });
            }
        }

        /// <summary>
        /// 获取全部用户列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SXEdu2XHKD.Domain.Entities.Member> GetAllMemberList()
        {
            using (IDbConnection conn = DapperHelper.ConnectToSxEdu())
            {
                const string query = "SELECT * FROM members;";
                return conn.Query<SXEdu2XHKD.Domain.Entities.Member>(query, null);
            }
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SXEdu2XHKD.Domain.Entities.Member member)
        {
            using (IDbConnection conn = DapperHelper.ConnectToSxEdu())
            {
                StringBuilder queryStr = new StringBuilder();
                queryStr.Append("insert into Members(");
                queryStr.Append("SxEduUserInfo,SXEduUserName,School,Grade,ClassName,UserName,PassWord,BirthDay,Email,Name,RegisterTime,QQ,UserType,ParentName,UserStatus)");
                queryStr.Append(" values (");
                queryStr.Append("@SxEduUserInfo,@SXEduUserName,@School,@Grade,@ClassName,@UserName,@PassWord,@BirthDay,@Email,@Name,@RegisterTime,@QQ,@UserType,@ParentName,@UserStatus);");

                return conn.Execute(queryStr.ToString(), member);
                //queryStr.Append(";select CAST(SCOPE_IDENTITY() as int) as int");

                //var returnId = conn.Query<int>(queryStr.ToString(), member).SingleOrDefault();
                //return returnId;
            }
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SXEdu2XHKD.Domain.Entities.Member member)
        {
            using (IDbConnection conn = DapperHelper.ConnectToSxEdu())
            {
                StringBuilder queryStr = new StringBuilder();
                queryStr.Append("update Members set ");
                queryStr.Append("SxEduUserInfo=@SxEduUserInfo,");
                queryStr.Append("SXEduUserName=@SXEduUserName,");
                queryStr.Append("School=@School,");
                queryStr.Append("Grade=@Grade,");
                queryStr.Append("ClassName=@ClassName,");
                queryStr.Append("PassWord=@PassWord,");
                queryStr.Append("BirthDay=@BirthDay,");
                queryStr.Append("Email=@Email,");
                queryStr.Append("Name=@Name,");
                queryStr.Append("RegisterTime=@RegisterTime,");
                queryStr.Append("QQ=@QQ,");
                queryStr.Append("UserType=@UserType,");
                queryStr.Append("ParentName=@ParentName,");
                queryStr.Append("UserStatus=@UserStatus");
                queryStr.Append(" where MemberId=@MemberId");

                int count = conn.Execute(queryStr.ToString(), member);
                return count > 0;
            }
        }
    }
}