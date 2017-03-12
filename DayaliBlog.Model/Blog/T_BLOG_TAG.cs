using System;
namespace DayaliBlog.Model.Blog
{
	/// <summary>
	/// T_BLOG_TAG:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public partial class T_BLOG_TAG
	{
		public T_BLOG_TAG()
		{}
		#region Model
		private int _tagid;
		private string _tagname;
		private int _createuser;
		private DateTime? _createtime;
		private int _updateuser;
		private DateTime? _updatetime;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int TagID
		{
			set{ _tagid=value;}
			get{return _tagid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TagName
		{
			set{ _tagname=value;}
			get{return _tagname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CreateUser
		{
			set{ _createuser=value;}
			get{return _createuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int UpdateUser
		{
			set{ _updateuser=value;}
			get{return _updateuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
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

