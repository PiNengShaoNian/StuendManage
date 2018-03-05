using System;
namespace ScoreManage.Model
{
	/// <summary>
	/// ClassInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ClassInfo
	{
		public ClassInfo()
		{}
		#region Model
		private string _classid;
		private string _classname;
		private string _classdesc;
		/// <summary>
		/// 
		/// </summary>
		public string classID
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string className
		{
			set{ _classname=value;}
			get{return _classname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string classDesc
		{
			set{ _classdesc=value;}
			get{return _classdesc;}
		}
		#endregion Model

	}
}

