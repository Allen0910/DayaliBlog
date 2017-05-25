using System;
using System.ComponentModel.DataAnnotations;

namespace DayaliBlog.Model.Blog
{
	/// <summary>
	/// T_BLOG_CONTENT:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public partial class T_BLOG_CONTENT
	{
		public T_BLOG_CONTENT()
		{}
        #region Model
        private int _BlogID;
        private string _blogtitle;
		private string _blogcontent;
		private int _blogtype;
		private int _blogstate;
		private DateTime? _lastupttime;
		private int _createuser;
		private DateTime? _createtime;
		private int _updateuser;
		private DateTime? _updatetime;
		private string _remark;
	    private string _blogTypeName;
	    private int _catelogID;
	    private string _catelogName;
        /// <summary>
        /// 
        /// </summary>
        public int BlogID
        {
            set { _BlogID = value; }
            get { return _BlogID; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "标题")]
        [Required(ErrorMessage = "博客标题不能为空")]
        [StringLength(12, MinimumLength = 1, ErrorMessage = "博客标题长度不能超过12个字")]
        public string BlogTitle
		{
			set => _blogtitle=value;
            get => _blogtitle;
        }
		/// <summary>
		/// 
		/// </summary>
		public string BlogContent
		{
			set{ _blogcontent=value;}
			get{return _blogcontent;}
		}
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int BlogType
		{
			set{ _blogtype=value;}
			get{return _blogtype;}
		}
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int BlogState
		{
			set{ _blogstate=value;}
			get{return _blogstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LastUptTime
		{
			set{ _lastupttime=value;}
			get{return _lastupttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CreateUser
		{
			set => _createuser=value;
		    get => _createuser;
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTIme
		{
			set => _createtime=value;
		    get => _createtime;
		}
		/// <summary>
		/// 
		/// </summary>
		public int UpdateUser
		{
			set => _updateuser=value;
		    get{return _updateuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdateTIme
		{
			set => _updatetime=value;
		    get => _updatetime;
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set => _remark=value;
		    get => _remark;
		}

	    public string BlogTypeName
	    {
            get => _blogTypeName;
	        set => _blogTypeName = value;
	    }

	    public int CatelogID
        {
            get => _catelogID;
	        set => _catelogID = value;
	    }

	    public string CatelogName
        {
            get => _catelogName;
	        set => _catelogName = value;
	    }
        #endregion Model

    }
}

