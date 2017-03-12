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
		private int _blogid;
		private int _catelogid;
		/// <summary>
		/// 
		/// </summary>
		public int BlogID
		{
			set{ _blogid=value;}
			get{return _blogid;}
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

