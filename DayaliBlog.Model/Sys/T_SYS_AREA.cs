using System;
namespace DayaliBlog.Model.Sys
{
	/// <summary>
	/// T_SYS_AREA:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public partial class T_SYS_AREA
	{
		public T_SYS_AREA()
		{}
		#region Model
		private string _area_id;
		private int _area_type;
		private string _area_name;
		private int? _area_order;
		private string _sm;
		private string _belong_area_id;
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
		public int AREA_TYPE
		{
			set{ _area_type=value;}
			get{return _area_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AREA_NAME
		{
			set{ _area_name=value;}
			get{return _area_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AREA_ORDER
		{
			set{ _area_order=value;}
			get{return _area_order;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sm
		{
			set{ _sm=value;}
			get{return _sm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BELONG_AREA_ID
		{
			set{ _belong_area_id=value;}
			get{return _belong_area_id;}
		}
		#endregion Model

	}
}

