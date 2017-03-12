using System;
namespace DayaliBlog.Model.Sys
{
	/// <summary>
	/// T_SYS_CONFIG:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public partial class T_SYS_CONFIG
	{
		public T_SYS_CONFIG()
		{}
		#region Model
		private int _id;
		private string _nm;
		private int _sub_id;
		private string _sub_nm;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NM
		{
			set{ _nm=value;}
			get{return _nm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SUB_ID
		{
			set{ _sub_id=value;}
			get{return _sub_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SUB_NM
		{
			set{ _sub_nm=value;}
			get{return _sub_nm;}
		}
		#endregion Model

	}
}

