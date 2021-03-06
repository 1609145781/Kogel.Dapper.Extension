﻿using Kogel.Dapper.Extension.Test.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kogel.Dapper.Extension.Oracle;
using Oracle.ManagedDataAccess.Client;

namespace Kogel.Dapper.Extension.Test.UnitTest.Oracle
{
   public class Command
    {
        string oracleConnection = @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))
                    (CONNECT_DATA=(SERVICE_NAME=ORCL)));User Id=system;Password=A5101264a";
        public void Test()
        {
            var commne = new Comment()
            {
                Id = 10,
                Content = "test",
                ArticleId = 11,
                Type = 1,
                SubTime = DateTime.Now,
                PId = 0,
                RefCommentId = 0
            };

            using (var conn = new OracleConnection(oracleConnection))
            {
                //根据成员修改
                var result = conn.CommandSet<Comment>()
                .Where(x => x.Id > commne.Id || x.Id < commne.Id)
                .Update(x => new Comment()
                {
                    Content = commne.Content,
                    SubTime = commne.SubTime
                });
                ////全部修改
                //var result1 = conn.CommandSet<Comment>()
                //    .Where(x => x.Id == commne.Id)
                //    .Update(commne);

                //新增
                var result2 = conn.CommandSet<Comment>()
                    .Insert(new Comment()
                    {
                        ArticleId = 11,
                        Type = 1,
                        SubTime = DateTime.Now,
                        Content = "test",
                        PId = 0,
                        RefCommentId = 0
                    });
                //新增返回自增id
                var result3 = conn.CommandSet<Comment>()
                    .InsertIdentity(new Comment()
                    {
                        ArticleId = 11,
                        Type = 1,
                        SubTime = DateTime.Now,
                        Content = "test",
                        PId = 0,
                        RefCommentId = 0
                    });
                //批量新增
                var result4 = conn.CommandSet<Comment>()
                    .Insert(new List<Comment>()
                    {
                        commne,
                        commne,
                        commne
                    });
                //删除
                var result5 = conn.CommandSet<Comment>()
                    .Where(x => x.Id == result3)
                    .Delete();
            }
        }
    }
}
