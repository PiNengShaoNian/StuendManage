using System;
namespace ScoreManage.Model
{
	/// <summary>
	/// StudScoreInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class StudScoreInfo
	{
		public StudScoreInfo()
		{}
		#region Model
		private string _studno;
		private string _courseid;
		private decimal? _studscore;
		/// <summary>
		/// 
		/// </summary>
		public string studNo
		{
			set{ _studno=value;}
			get{return _studno;}
		}
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
		public decimal? studScore
		{
			set{ _studscore=value;}
			get{return _studscore;}
		}
		#endregion Model

	}
}

