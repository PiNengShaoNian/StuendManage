using System;
namespace ScoreManage.Model
{
	/// <summary>
	/// StudInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class StudInfo
	{
		public StudInfo()
		{}
		#region Model
		private string _studno;
		private string _studname;
		private string _studsex;
		private DateTime? _studbirthday;
		private string _classid;
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
		public string studName
		{
			set{ _studname=value;}
			get{return _studname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string studSex
		{
			set{ _studsex=value;}
			get{return _studsex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? studBirthDay
		{
			set{ _studbirthday=value;}
			get{return _studbirthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string classID
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		#endregion Model

	}
}

