using System;
namespace DayaliBlog.Model.Blog
{
	/// <summary>
	/// T_BLOG_CATELOG_REL:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public partial class T_BLOG_CATELOG_REL
	{
		public T_BLOG_CATELOG_REL()
		{}
		#region Model
		private int _BlogID;
		private int _catelogid;
		/// <summary>
		/// 
		/// </summary>
		public int BlogID
		{
			set{ _BlogID=value;}
			get{return _BlogID;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CatelogID
		{
			set{ _catelogid=value;}
			get{return _catelogid;}
		}
		#endregion Model

	}
}

