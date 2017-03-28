using System;
namespace DayaliBlog.Model.Sys
{
	/// <summary>
	/// T_PERSONAL:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public partial class T_PERSONAL
	{
		public T_PERSONAL()
		{}
		#region Model
		private int _personalid;
		private string _personalname;
		private int _gender;
		private DateTime? _birthday;
		private string _idcard;
		private string _area_id;
		private string _address;
		private string _telphone;
		private int? _createuser;
		private DateTime? _createtime;
		private int? _updateuser;
		private DateTime? _updatetime;
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
		public string PersonalName
		{
			set{ _personalname=value;}
			get{return _personalname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Gender
		{
			set{ _gender=value;}
			get{return _gender;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BlogIDCard
		{
			set{ _idcard=value;}
			get{return _idcard;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AREA_ID
		{
			set{ _area_id=value;}
			get{return _area_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TelPhone
		{
			set{ _telphone=value;}
			get{return _telphone;}
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

