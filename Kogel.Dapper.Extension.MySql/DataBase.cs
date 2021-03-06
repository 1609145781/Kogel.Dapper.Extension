﻿using System;
using System.Data;
using Kogel.Dapper.Extension.Core.SetC;
using Kogel.Dapper.Extension.Core.SetQ;
using Kogel.Dapper.Extension.Model;

namespace Kogel.Dapper.Extension.MySql
{
    public static class DataBase
    {
		/// <summary>
		/// 用来解决表达式树不能使用默认参数
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="sqlConnection"></param>
		/// <returns></returns>
		public static QuerySet<T> QuerySet<T>(this IDbConnection sqlConnection)
		{
			return new QuerySet<T>(sqlConnection, new MySqlProvider(), null);
		}
		public static QuerySet<T> QuerySet<T>(this IDbConnection sqlConnection, IDbTransaction dbTransaction = null)
		{
			return new QuerySet<T>(sqlConnection, new MySqlProvider(), dbTransaction);
		}
		/// <summary>
		/// 用来解决表达式树不能使用默认参数
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="sqlConnection"></param>
		/// <returns></returns>
		public static CommandSet<T> CommandSet<T>(this IDbConnection sqlConnection)
		{
			return new CommandSet<T>(sqlConnection, new MySqlProvider(), null);
		}
		public static CommandSet<T> CommandSet<T>(this IDbConnection sqlConnection, IDbTransaction dbTransaction = null)
		{
			return new CommandSet<T>(sqlConnection, new MySqlProvider(), dbTransaction);
		}
	}
}
