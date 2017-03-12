using System;
namespace DayaliBlog.Model.Blog
{
	/// <summary>
	/// T_BLOG_LOOK:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public partial class T_BLOG_LOOK
	{
		public T_BLOG_LOOK()
		{}
		#region Model
		private int _recordid;
		private int _blogid;
		private int _rederid;
		private DateTime? _readlasttime;
		/// <summary>
		/// 
		/// </summary>
		public int RecordID
		{
			set{ _recordid=value;}
			get{return _recordid;}
		}
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
		public int RederID
		{
			set{ _rederid=value;}
			get{return _rederid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ReadLastTime
		{
			set{ _readlasttime=value;}
			get{return _readlasttime;}
		}
		#endregion Model

	}
}

