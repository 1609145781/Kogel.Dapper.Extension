﻿using Kogel.Dapper.Extension.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kogel.Dapper.Extension.Test.ViewModel
{
	public	class CommentDto
	{
		[Identity]
		public int Id { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Content { get; set; }

		public List<NewsDto> NewsList { get; set; }
	}
}