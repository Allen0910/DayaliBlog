using System;
namespace DayaliBlog.Model.Blog
{
	/// <summary>
	/// T_BLOG_CATELOG:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public partial class T_BLOG_CATELOG
	{
		public T_BLOG_CATELOG()
		{}
		#region Model
		private int _catelogid;
		private int? _parentcategid;
		private string _catelogname;
		private int _createuser;
		private DateTime? _createtime;
		private int _updateuser;
		private DateTime? _updatetime;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int CatelogID
		{
			set{ _catelogid=value;}
			get{return _catelogid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParentCategID
		{
			set{ _parentcategid=value;}
			get{return _parentcategid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CatelogName
		{
			set{ _catelogname=value;}
			get{return _catelogname;}
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

