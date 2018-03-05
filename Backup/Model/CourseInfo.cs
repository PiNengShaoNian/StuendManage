using System;
namespace ScoreManage.Model
{
	/// <summary>
	/// CourseInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CourseInfo
	{
		public CourseInfo()
		{}
		#region Model
		private string _courseid;
		private string _coursename;
		private string _coursetype;
		private decimal? _coursecredit;
		private string _coursedesc;
		/// <summary>
		/// 
		/// </summary>
		public string courseID
		{
			set{ _courseid=value;}
			get{return _courseid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string courseName
		{
			set{ _coursename=value;}
			get{return _coursename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string courseType
		{
			set{ _coursetype=value;}
			get{return _coursetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? courseCredit
		{
			set{ _coursecredit=value;}
			get{return _coursecredit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string courseDesc
		{
			set{ _coursedesc=value;}
			get{return _coursedesc;}
		}
		#endregion Model

	}
}

