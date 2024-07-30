using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PlzGame
{
	/// <summary>
	/// frmOption에 대한 요약 설명입니다.
	/// </summary>
	public class frmOption : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Button btnCancel;
		internal System.Windows.Forms.GroupBox GroupBox3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.ComboBox cmbHintTime;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button btnOK;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.RadioButton rdoLevel2;
		internal System.Windows.Forms.RadioButton rdoLevel1;
		internal System.Windows.Forms.RadioButton rdoLevel0;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.RadioButton rdo5;
		internal System.Windows.Forms.RadioButton rdo4;
		internal System.Windows.Forms.RadioButton rdo3;
		internal System.Windows.Forms.RadioButton rdo2;
		internal System.Windows.Forms.RadioButton rdo1;
		internal System.Windows.Forms.RadioButton rdo0;
		internal System.Windows.Forms.PictureBox pic5;
		internal System.Windows.Forms.PictureBox pic4;
		internal System.Windows.Forms.PictureBox pic3;
		internal System.Windows.Forms.PictureBox pic2;
		internal System.Windows.Forms.PictureBox pic1;
		internal System.Windows.Forms.PictureBox pic0;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		frmMain m_frmParent;
		public int m_nSelPic, m_nSelLevel, m_nSelTime;

		public frmOption()
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
		}

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		
		#region Windows Form Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnCancel = new System.Windows.Forms.Button();
			this.GroupBox3 = new System.Windows.Forms.GroupBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.cmbHintTime = new System.Windows.Forms.ComboBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.rdoLevel2 = new System.Windows.Forms.RadioButton();
			this.rdoLevel1 = new System.Windows.Forms.RadioButton();
			this.rdoLevel0 = new System.Windows.Forms.RadioButton();
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.rdo5 = new System.Windows.Forms.RadioButton();
			this.rdo4 = new System.Windows.Forms.RadioButton();
			this.rdo3 = new System.Windows.Forms.RadioButton();
			this.rdo2 = new System.Windows.Forms.RadioButton();
			this.rdo1 = new System.Windows.Forms.RadioButton();
			this.rdo0 = new System.Windows.Forms.RadioButton();
			this.pic5 = new System.Windows.Forms.PictureBox();
			this.pic4 = new System.Windows.Forms.PictureBox();
			this.pic3 = new System.Windows.Forms.PictureBox();
			this.pic2 = new System.Windows.Forms.PictureBox();
			this.pic1 = new System.Windows.Forms.PictureBox();
			this.pic0 = new System.Windows.Forms.PictureBox();
			this.GroupBox3.SuspendLayout();
			this.GroupBox2.SuspendLayout();
			this.GroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(226)), ((System.Byte)(236)), ((System.Byte)(245)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnCancel.Location = new System.Drawing.Point(199, 326);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 10;
			this.btnCancel.Text = "취   소";
			// 
			// GroupBox3
			// 
			this.GroupBox3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(226)), ((System.Byte)(236)), ((System.Byte)(245)));
			this.GroupBox3.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.Label2,
																					this.cmbHintTime,
																					this.Label1});
			this.GroupBox3.Location = new System.Drawing.Point(144, 226);
			this.GroupBox3.Name = "GroupBox3";
			this.GroupBox3.Size = new System.Drawing.Size(130, 95);
			this.GroupBox3.TabIndex = 8;
			this.GroupBox3.TabStop = false;
			this.GroupBox3.Text = " 시간설정 ";
			// 
			// Label2
			// 
			this.Label2.Location = new System.Drawing.Point(80, 70);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(20, 10);
			this.Label2.TabIndex = 2;
			this.Label2.Text = "초";
			// 
			// cmbHintTime
			// 
			this.cmbHintTime.Location = new System.Drawing.Point(20, 65);
			this.cmbHintTime.Name = "cmbHintTime";
			this.cmbHintTime.Size = new System.Drawing.Size(55, 20);
			this.cmbHintTime.TabIndex = 1;
			this.cmbHintTime.SelectedIndexChanged += new System.EventHandler(this.cmbHintTime_SelectedIndexChanged);
			// 
			// Label1
			// 
			this.Label1.Location = new System.Drawing.Point(5, 25);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(120, 30);
			this.Label1.TabIndex = 0;
			this.Label1.Text = "힌트그림을 보여주는 시간을 설정합니다";
			// 
			// btnOK
			// 
			this.btnOK.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(226)), ((System.Byte)(236)), ((System.Byte)(245)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnOK.Location = new System.Drawing.Point(119, 326);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 9;
			this.btnOK.Text = "확  인";
			// 
			// GroupBox2
			// 
			this.GroupBox2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(226)), ((System.Byte)(236)), ((System.Byte)(245)));
			this.GroupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.rdoLevel2,
																					this.rdoLevel1,
																					this.rdoLevel0});
			this.GroupBox2.Location = new System.Drawing.Point(4, 226);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new System.Drawing.Size(130, 95);
			this.GroupBox2.TabIndex = 7;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = " 난이도 ";
			// 
			// rdoLevel2
			// 
			this.rdoLevel2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(226)), ((System.Byte)(236)), ((System.Byte)(245)));
			this.rdoLevel2.Location = new System.Drawing.Point(10, 70);
			this.rdoLevel2.Name = "rdoLevel2";
			this.rdoLevel2.Size = new System.Drawing.Size(105, 20);
			this.rdoLevel2.TabIndex = 2;
			this.rdoLevel2.Tag = "2";
			this.rdoLevel2.Text = "어렵게  (5*5)";
			this.rdoLevel2.Click += new System.EventHandler(this.rdoLevel_Click);
			// 
			// rdoLevel1
			// 
			this.rdoLevel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(226)), ((System.Byte)(236)), ((System.Byte)(245)));
			this.rdoLevel1.Location = new System.Drawing.Point(10, 45);
			this.rdoLevel1.Name = "rdoLevel1";
			this.rdoLevel1.Size = new System.Drawing.Size(105, 20);
			this.rdoLevel1.TabIndex = 1;
			this.rdoLevel1.Tag = "1";
			this.rdoLevel1.Text = "보   통  (4*4)";
			this.rdoLevel1.Click += new System.EventHandler(this.rdoLevel_Click);
			// 
			// rdoLevel0
			// 
			this.rdoLevel0.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(226)), ((System.Byte)(236)), ((System.Byte)(245)));
			this.rdoLevel0.Location = new System.Drawing.Point(10, 20);
			this.rdoLevel0.Name = "rdoLevel0";
			this.rdoLevel0.Size = new System.Drawing.Size(105, 20);
			this.rdoLevel0.TabIndex = 0;
			this.rdoLevel0.Tag = "0";
			this.rdoLevel0.Text = "쉽   게  (3*3)";
			this.rdoLevel0.Click += new System.EventHandler(this.rdoLevel_Click);
			// 
			// GroupBox1
			// 
			this.GroupBox1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(226)), ((System.Byte)(236)), ((System.Byte)(245)));
			this.GroupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.rdo5,
																					this.rdo4,
																					this.rdo3,
																					this.rdo2,
																					this.rdo1,
																					this.rdo0,
																					this.pic5,
																					this.pic4,
																					this.pic3,
																					this.pic2,
																					this.pic1,
																					this.pic0});
			this.GroupBox1.Location = new System.Drawing.Point(4, 4);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(270, 217);
			this.GroupBox1.TabIndex = 6;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = " 그림선택 ";
			// 
			// rdo5
			// 
			this.rdo5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(226)), ((System.Byte)(236)), ((System.Byte)(245)));
			this.rdo5.Location = new System.Drawing.Point(215, 195);
			this.rdo5.Name = "rdo5";
			this.rdo5.Size = new System.Drawing.Size(15, 10);
			this.rdo5.TabIndex = 12;
			this.rdo5.Tag = "5";
			this.rdo5.Click += new System.EventHandler(this.pic_Click);
			// 
			// rdo4
			// 
			this.rdo4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(226)), ((System.Byte)(236)), ((System.Byte)(245)));
			this.rdo4.Location = new System.Drawing.Point(130, 195);
			this.rdo4.Name = "rdo4";
			this.rdo4.Size = new System.Drawing.Size(15, 10);
			this.rdo4.TabIndex = 11;
			this.rdo4.Tag = "4";
			this.rdo4.Click += new System.EventHandler(this.pic_Click);
			// 
			// rdo3
			// 
			this.rdo3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(226)), ((System.Byte)(236)), ((System.Byte)(245)));
			this.rdo3.Location = new System.Drawing.Point(45, 195);
			this.rdo3.Name = "rdo3";
			this.rdo3.Size = new System.Drawing.Size(15, 10);
			this.rdo3.TabIndex = 10;
			this.rdo3.Tag = "3";
			this.rdo3.Click += new System.EventHandler(this.pic_Click);
			// 
			// rdo2
			// 
			this.rdo2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(226)), ((System.Byte)(236)), ((System.Byte)(245)));
			this.rdo2.Location = new System.Drawing.Point(215, 96);
			this.rdo2.Name = "rdo2";
			this.rdo2.Size = new System.Drawing.Size(15, 10);
			this.rdo2.TabIndex = 9;
			this.rdo2.Tag = "2";
			this.rdo2.Click += new System.EventHandler(this.pic_Click);
			// 
			// rdo1
			// 
			this.rdo1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(226)), ((System.Byte)(236)), ((System.Byte)(245)));
			this.rdo1.Location = new System.Drawing.Point(130, 96);
			this.rdo1.Name = "rdo1";
			this.rdo1.Size = new System.Drawing.Size(15, 10);
			this.rdo1.TabIndex = 8;
			this.rdo1.Tag = "1";
			this.rdo1.Click += new System.EventHandler(this.pic_Click);
			// 
			// rdo0
			// 
			this.rdo0.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(226)), ((System.Byte)(236)), ((System.Byte)(245)));
			this.rdo0.Location = new System.Drawing.Point(40, 96);
			this.rdo0.Name = "rdo0";
			this.rdo0.Size = new System.Drawing.Size(15, 10);
			this.rdo0.TabIndex = 7;
			this.rdo0.Tag = "0";
			this.rdo0.Click += new System.EventHandler(this.pic_Click);
			// 
			// pic5
			// 
			this.pic5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(226)), ((System.Byte)(236)), ((System.Byte)(245)));
			this.pic5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pic5.Location = new System.Drawing.Point(185, 117);
			this.pic5.Name = "pic5";
			this.pic5.Size = new System.Drawing.Size(70, 70);
			this.pic5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pic5.TabIndex = 6;
			this.pic5.TabStop = false;
			this.pic5.Tag = "5";
			this.pic5.Click += new System.EventHandler(this.pic_Click);
			// 
			// pic4
			// 
			this.pic4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(226)), ((System.Byte)(236)), ((System.Byte)(245)));
			this.pic4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pic4.Location = new System.Drawing.Point(100, 117);
			this.pic4.Name = "pic4";
			this.pic4.Size = new System.Drawing.Size(70, 70);
			this.pic4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pic4.TabIndex = 5;
			this.pic4.TabStop = false;
			this.pic4.Tag = "4";
			this.pic4.Click += new System.EventHandler(this.pic_Click);
			// 
			// pic3
			// 
			this.pic3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(226)), ((System.Byte)(236)), ((System.Byte)(245)));
			this.pic3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pic3.Location = new System.Drawing.Point(15, 117);
			this.pic3.Name = "pic3";
			this.pic3.Size = new System.Drawing.Size(70, 70);
			this.pic3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pic3.TabIndex = 4;
			this.pic3.TabStop = false;
			this.pic3.Tag = "3";
			this.pic3.Click += new System.EventHandler(this.pic_Click);
			// 
			// pic2
			// 
			this.pic2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(226)), ((System.Byte)(236)), ((System.Byte)(245)));
			this.pic2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pic2.Location = new System.Drawing.Point(185, 20);
			this.pic2.Name = "pic2";
			this.pic2.Size = new System.Drawing.Size(70, 70);
			this.pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pic2.TabIndex = 3;
			this.pic2.TabStop = false;
			this.pic2.Tag = "2";
			this.pic2.Click += new System.EventHandler(this.pic_Click);
			// 
			// pic1
			// 
			this.pic1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(226)), ((System.Byte)(236)), ((System.Byte)(245)));
			this.pic1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pic1.Location = new System.Drawing.Point(100, 20);
			this.pic1.Name = "pic1";
			this.pic1.Size = new System.Drawing.Size(70, 70);
			this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pic1.TabIndex = 2;
			this.pic1.TabStop = false;
			this.pic1.Tag = "1";
			this.pic1.Click += new System.EventHandler(this.pic_Click);
			// 
			// pic0
			// 
			this.pic0.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(226)), ((System.Byte)(236)), ((System.Byte)(245)));
			this.pic0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pic0.Location = new System.Drawing.Point(15, 20);
			this.pic0.Name = "pic0";
			this.pic0.Size = new System.Drawing.Size(70, 70);
			this.pic0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pic0.TabIndex = 1;
			this.pic0.TabStop = false;
			this.pic0.Tag = "0";
			this.pic0.Click += new System.EventHandler(this.pic_Click);
			// 
			// frmOption
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(226)), ((System.Byte)(236)), ((System.Byte)(245)));
			this.ClientSize = new System.Drawing.Size(278, 353);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnCancel,
																		  this.GroupBox3,
																		  this.btnOK,
																		  this.GroupBox2,
																		  this.GroupBox1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "frmOption";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "환경설정";
			this.Load += new System.EventHandler(this.frmOption_Load);
			this.GroupBox3.ResumeLayout(false);
			this.GroupBox2.ResumeLayout(false);
			this.GroupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void Init(frmMain frmParent)
		{
			m_frmParent = frmParent;
		}

		// 선택한 그림에 맞게 라디오버튼 채크
		private void CheckPic()
		{
			if (m_nSelPic == 0) 
				rdo0.Checked = true;
			else if (m_nSelPic == 1) 
				rdo1.Checked = true;
			else if (m_nSelPic == 2) 
				rdo2.Checked = true;
			else if (m_nSelPic == 3) 
				rdo3.Checked = true;
			else if (m_nSelPic == 4) 
				rdo4.Checked = true;
			else
				rdo5.Checked = true;
        
		}

		// 선택한 레벨에 맞게 라디오버튼 채크
		private void CheckLevel()
		{
			if (m_nSelLevel == 0) 
				rdoLevel0.Checked = true;
			else if (m_nSelLevel == 1) 
				rdoLevel1.Checked = true;
			else
				rdoLevel2.Checked = true;
		}

		// 폼 로드
		private void frmOption_Load(object sender, System.EventArgs e)
		{
			// 부모가 원래 가지고 있던 환경설정을 얻는다.
			m_nSelPic = m_frmParent.m_nPicNum;
			m_nSelLevel = m_frmParent.m_nLevel;
			m_nSelTime = m_frmParent.m_nHintTime;

			// 그림을 축소해서 보여준다.
			pic0.Image = new Bitmap(GetType(), "normal_1.jpg");
			pic1.Image = new Bitmap(GetType(), "normal_2.jpg");
			pic2.Image = new Bitmap(GetType(), "normal_3.jpg");
			pic3.Image = new Bitmap(GetType(), "normal_4.jpg");
			pic4.Image = new Bitmap(GetType(), "normal_5.jpg");
			pic5.Image = new Bitmap(GetType(), "num_1.jpg");

			int i;

			// 콤보박스에 1 ~ 60 추가
			for(i = 1 ; i <= 60 ; i++)
				cmbHintTime.Items.Add(i.ToString());
        
			//현재 선택된 그림을 선택한다.
			CheckPic();

			// 현재 설정된 힌트시간을 선택한다.
			cmbHintTime.SelectedIndex = m_nSelTime - 1;

			// 현재 레벨을 선택한다.
			CheckLevel();

		}

		// pic와 rdo 클릭 이벤트(그림 선택)
		private void pic_Click(object sender, System.EventArgs e)
		{
			// 클릭한 컨트롤의 tag 속성을 이용한다.
			m_nSelPic = Convert.ToInt32(((Control)sender).Tag.ToString());

			CheckPic();
		}

		// 레벨 선택 변경
		private void rdoLevel_Click(object sender, System.EventArgs e)
		{
			// 클릭한 컨트롤의 tag 속성을 이용한다.
			m_nSelLevel = Convert.ToInt32(((Control)sender).Tag.ToString());

			CheckLevel();
		}

		private void cmbHintTime_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_nSelTime = cmbHintTime.SelectedIndex + 1;
		}
	}
}
