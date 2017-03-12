using System;
namespace DayaliBlog.Model.Blog
{
	/// <summary>
	/// T_BLOG_COMMENT:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public partial class T_BLOG_COMMENT
	{
		public T_BLOG_COMMENT()
		{}
		#region Model
		private int _commentid;
		private int _passiveid;
		private int _replytype;
		private string _replycomment;
		private bool _replystate;
		private int _blogid;
		private int _replyuserid;
		private DateTime _replytime;
		/// <summary>
		/// 
		/// </summary>
		public int CommentID
		{
			set{ _commentid=value;}
			get{return _commentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PassiveID
		{
			set{ _passiveid=value;}
			get{return _passiveid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ReplyType
		{
			set{ _replytype=value;}
			get{return _replytype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReplyComment
		{
			set{ _replycomment=value;}
			get{return _replycomment;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool ReplyState
		{
			set{ _replystate=value;}
			get{return _replystate;}
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
		public int ReplyUserID
		{
			set{ _replyuserid=value;}
			get{return _replyuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ReplyTime
		{
			set{ _replytime=value;}
			get{return _replytime;}
		}
		#endregion Model

	}
}

