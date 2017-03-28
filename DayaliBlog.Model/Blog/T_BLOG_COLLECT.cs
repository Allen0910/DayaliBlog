using System;
namespace DayaliBlog.Model.Blog
{
	/// <summary>
	/// T_BLOG_COLLECT:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public partial class T_BLOG_COLLECT
	{
		public T_BLOG_COLLECT()
		{}
		#region Model
		private int _collectid;
		private int _collectstate;
		private int _BlogID;
		private int _collecter;
		private DateTime? _collecttime;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int CollectID
		{
			set{ _collectid=value;}
			get{return _collectid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CollectState
		{
			set{ _collectstate=value;}
			get{return _collectstate;}
		}
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
		public int Collecter
		{
			set{ _collecter=value;}
			get{return _collecter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CollectTime
		{
			set{ _collecttime=value;}
			get{return _collecttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

