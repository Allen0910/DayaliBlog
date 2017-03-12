using System;
namespace DayaliBlog.Model.Sys
{
	/// <summary>
	/// T_SYS_USER:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public partial class T_SYS_USER
	{
		public T_SYS_USER()
		{}
		#region Model
		private int _userid;
		private string _username;
		private string _password;
		private int _personalid;
		private string _qqopenid;
		private int? _createuser;
		private DateTime? _createtime;
		private int? _updateuser;
		private DateTime? _updatetime;
		/// <summary>
		/// 
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PersonalID
		{
			set{ _personalid=value;}
			get{return _personalid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QQOpenid
		{
			set{ _qqopenid=value;}
			get{return _qqopenid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CreateUser
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
		public int? UpdateUser
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
		#endregion Model

	}
}

