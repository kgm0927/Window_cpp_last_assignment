using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace PlzGame
{
	/// <summary>
	/// Form1에 대한 요약 설명입니다.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Label lblScore;
		internal System.Windows.Forms.Timer timSecond;
		internal System.Windows.Forms.PictureBox picHint;
		internal System.Windows.Forms.Label lblPercent;
		internal System.Windows.Forms.Timer timHint;
		internal System.Windows.Forms.Label lblClick;
		internal System.Windows.Forms.Label lblSecond;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button btnOption;
		internal System.Windows.Forms.Button btnStart;
		internal System.Windows.Forms.GroupBox GroupBox3;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.Panel panGame;
		internal System.Windows.Forms.GroupBox GroupBox1;
		private System.ComponentModel.IContainer components;

		// 상태 저장 변수
		int m_nSecond, m_nClick, m_nPercent, m_nScore;
		ImageClip m_imgClip;

		public int m_nLevel;     // 게임 레벨
		public int m_nHintTime;  // 힌트그림 시간
		public int m_nPicNum;  //그림 종류

		int[,] m_nGame; //게임 상태
		int m_nCnt; //row, col의 갯수

		bool m_bStart, m_bEnd;

		SolidBrush m_bru; // 조각 그림 지울때 사용

		const int PIC_SIZE = 300; // 그림의 원래 크기

		const int SCORE_CLICK = 0;
		const int SCORE_HINT = 1;
		const int SCORE_TIME = 2;

		// 사운드 재생을 위한 API 함수 선언
		[System.Runtime.InteropServices.DllImport("winmm.dll")]
		public static extern int sndPlaySound(string lpszSoundName, int uFlags);

		// 사운드를 구분하기 위한 상수 선언
		const int SOUND_MOVE = 0;
		const int SOUND_NOTMOVE = 1;
		const int SOUND_RNDPIC = 2;
		const int SOUND_CLEARPIC = 3;
		const int SOUND_END = 4;

		public frmMain()
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
				if (components != null) 
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
            this.components = new System.ComponentModel.Container();
            this.lblScore = new System.Windows.Forms.Label();
            this.timSecond = new System.Windows.Forms.Timer(this.components);
            this.picHint = new System.Windows.Forms.PictureBox();
            this.lblPercent = new System.Windows.Forms.Label();
            this.timHint = new System.Windows.Forms.Timer(this.components);
            this.lblClick = new System.Windows.Forms.Label();
            this.lblSecond = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnOption = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.panGame = new System.Windows.Forms.Panel();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.picHint)).BeginInit();
            this.SuspendLayout();
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(236)))), ((int)(((byte)(245)))));
            this.lblScore.Location = new System.Drawing.Point(533, 341);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(67, 15);
            this.lblScore.TabIndex = 33;
            this.lblScore.Text = "10000 점";
            // 
            // timSecond
            // 
            this.timSecond.Interval = 1000;
            this.timSecond.Tick += new System.EventHandler(this.timSecond_Tick);
            // 
            // picHint
            // 
            this.picHint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(216)))), ((int)(((byte)(225)))));
            this.picHint.Location = new System.Drawing.Point(448, 42);
            this.picHint.Name = "picHint";
            this.picHint.Size = new System.Drawing.Size(171, 165);
            this.picHint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHint.TabIndex = 34;
            this.picHint.TabStop = false;
            this.picHint.Click += new System.EventHandler(this.picHint_Click);
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(236)))), ((int)(((byte)(245)))));
            this.lblPercent.Location = new System.Drawing.Point(533, 310);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(31, 15);
            this.lblPercent.TabIndex = 32;
            this.lblPercent.Text = "0 %";
            // 
            // timHint
            // 
            this.timHint.Tick += new System.EventHandler(this.timHint_Tick);
            // 
            // lblClick
            // 
            this.lblClick.AutoSize = true;
            this.lblClick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(236)))), ((int)(((byte)(245)))));
            this.lblClick.Location = new System.Drawing.Point(533, 279);
            this.lblClick.Name = "lblClick";
            this.lblClick.Size = new System.Drawing.Size(50, 15);
            this.lblClick.TabIndex = 31;
            this.lblClick.Text = "0 클릭";
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(236)))), ((int)(((byte)(245)))));
            this.lblSecond.Location = new System.Drawing.Point(533, 248);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(35, 15);
            this.lblSecond.TabIndex = 30;
            this.lblSecond.Text = "0 초";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(236)))), ((int)(((byte)(245)))));
            this.Label6.Location = new System.Drawing.Point(459, 341);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(62, 15);
            this.Label6.TabIndex = 27;
            this.Label6.Text = "점   수 :";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(236)))), ((int)(((byte)(245)))));
            this.Label5.Location = new System.Drawing.Point(459, 310);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(62, 15);
            this.Label5.TabIndex = 26;
            this.Label5.Text = "퍼센트 :";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(236)))), ((int)(((byte)(245)))));
            this.Label4.Location = new System.Drawing.Point(459, 279);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(62, 15);
            this.Label4.TabIndex = 25;
            this.Label4.Text = "클   릭 :";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(236)))), ((int)(((byte)(245)))));
            this.Label3.Location = new System.Drawing.Point(459, 248);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(62, 15);
            this.Label3.TabIndex = 24;
            this.Label3.Text = "시   간 :";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(236)))), ((int)(((byte)(245)))));
            this.Label2.Location = new System.Drawing.Point(437, 217);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(67, 15);
            this.Label2.TabIndex = 22;
            this.Label2.Text = "게임상태";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(236)))), ((int)(((byte)(245)))));
            this.Label1.Location = new System.Drawing.Point(437, 12);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(67, 15);
            this.Label1.TabIndex = 20;
            this.Label1.Text = "힌트그림";
            // 
            // btnOption
            // 
            this.btnOption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(236)))), ((int)(((byte)(245)))));
            this.btnOption.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOption.Location = new System.Drawing.Point(536, 382);
            this.btnOption.Name = "btnOption";
            this.btnOption.Size = new System.Drawing.Size(93, 29);
            this.btnOption.TabIndex = 29;
            this.btnOption.Text = "환경설정";
            this.btnOption.UseVisualStyleBackColor = false;
            this.btnOption.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(236)))), ((int)(((byte)(245)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStart.Location = new System.Drawing.Point(437, 382);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(94, 29);
            this.btnStart.TabIndex = 28;
            this.btnStart.Text = "게임시작";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // GroupBox3
            // 
            this.GroupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(236)))), ((int)(((byte)(245)))));
            this.GroupBox3.Location = new System.Drawing.Point(512, 217);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(117, 11);
            this.GroupBox3.TabIndex = 23;
            this.GroupBox3.TabStop = false;
            // 
            // GroupBox2
            // 
            this.GroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(236)))), ((int)(((byte)(245)))));
            this.GroupBox2.Location = new System.Drawing.Point(512, 12);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(117, 10);
            this.GroupBox2.TabIndex = 21;
            this.GroupBox2.TabStop = false;
            // 
            // panGame
            // 
            this.panGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(154)))), ((int)(((byte)(206)))));
            this.panGame.Location = new System.Drawing.Point(11, 22);
            this.panGame.Name = "panGame";
            this.panGame.Size = new System.Drawing.Size(392, 393);
            this.panGame.TabIndex = 19;
            this.panGame.Paint += new System.Windows.Forms.PaintEventHandler(this.panGame_Paint);
            this.panGame.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panGame_MouseUp);
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(236)))), ((int)(((byte)(245)))));
            this.GroupBox1.Location = new System.Drawing.Point(427, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(2, 401);
            this.GroupBox1.TabIndex = 18;
            this.GroupBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(236)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(641, 425);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.lblClick);
            this.Controls.Add(this.lblSecond);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnOption);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.panGame);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.picHint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.Text = " 그림 맞추기 게임";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picHint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// 해당 응용 프로그램의 주 진입점입니다.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}

		
		// 게임 초기화
		private void InitGame()
		{
			// 각종 상태 초기화
			m_nSecond = 0;
			m_nClick = 0;
			m_nPercent = 0;
			m_nScore = 10000;
			timSecond.Enabled = false;

			btnStart.Text = "게임시작";

			lblSecond.Text = m_nSecond.ToString() + " 초";
			lblClick.Text = m_nClick.ToString() + " 번";
			lblPercent.Text = m_nPercent.ToString() + " %";
			lblScore.Text = m_nScore.ToString() + " 점";

			m_bStart = false;
			m_bEnd = false;

			// 크기에 맞게 배열 설정
			m_nCnt = m_nLevel + 3;
			m_nGame = new int[m_nCnt, m_nCnt];

			// 그림 설정
			SetImgClip();

			// 배열에 순서대로 숫자 입력
			int i, j;
			for(i = 0 ; i < m_nCnt ; i++)
			{
				for(j = 0 ; j < m_nCnt ; j++)
					m_nGame[i, j] = i * m_nCnt + j;
            
			}

			// 배열의 마지막에 빈칸(-1) 표시
			m_nGame[m_nCnt - 1, m_nCnt - 1] = -1;

			// 게임 상태에 맞춰 panGame 크기 변경
			panGame.Size = new Size(PIC_SIZE + m_nCnt + 1, PIC_SIZE + m_nCnt + 1);

			panGame.Invalidate();
		}

		// 레벨과 종류에 맞는 그림 출력
		private void SetImgClip()
		{
			String strImgName;

			if (m_nPicNum < 5) // 일반그림
				strImgName = "normal_" + (m_nPicNum + 1).ToString() + ".jpg";
			else // 숫자형 그림
				strImgName = "num_" + (m_nLevel + 1).ToString() + ".jpg";
        
			m_imgClip = new ImageClip(new Bitmap(GetType(), strImgName), m_nCnt, m_nCnt);
		}

		// 그림 섞기
		private void RndClip()
		{
			int nCol, nRow;
			int nEmptyCol, nEmptyRow;
			int i;

			Random rnd = new Random();

			// 한 1000번 정도 클릭한 효과를 준다.
			for(i = 0 ; i < 1000 ; i++)
			{
				// 적당한 값을 발생한후
				nCol = rnd.Next(m_nCnt);
				nRow = rnd.Next(m_nCnt);

				// 클릭한 효과
				if (FindEmptyIndex(nRow, nCol, out nEmptyRow, out nEmptyCol)) // 빈칸 찾기
					MoveImg(nRow, nCol, nEmptyRow, nEmptyCol);
			}
			panGame.Invalidate();
		}

		// row, col에 맞는 위치 반환
		private Point GetImgPos(int nRow, int nCol)
		{
			// 알맞은 위치를 반환한다.
			Point pos = new Point();
			pos.X = nCol * PIC_SIZE / m_nCnt + 1 + nCol;
			pos.Y = nRow * PIC_SIZE / m_nCnt + 1 + nRow;

			return pos;
		}

		// 원본 그림 보여주기
		private void ViewEndingImag()
		{
			// 게임이 끝나면 원본그림 보여준다.
			panGame.CreateGraphics().DrawImage(m_imgClip.GetAllImage(), 2, 2, 300, 300);
		}

		// 클릭한 좌표를 Row, Col 인덱스로 변환
		// 실패(구분선 클릭)한 경우 false
		private bool PointToIndex(Point posClick, out int nRow, out int nCol) 
		{
			int i, j;
			Point pos = new Point();
			nRow = -1;
			nCol = -1;
			for(i = 0 ; i < m_nCnt ; i++)
			{
				for(j = 0 ; j < m_nCnt ; j++)
				{
					pos = GetImgPos(i, j);
					// col값 얻기
					if ((posClick.X >= pos.X) && (posClick.X <= pos.X + PIC_SIZE / m_nCnt))
						nCol = j;
                
					//row 값 얻기
					if ((posClick.Y >= pos.Y) && (posClick.Y <= pos.Y + PIC_SIZE / m_nCnt))
						nRow = i;
                
					if ((nRow != -1) && (nCol != -1))
						return true;
                
				}
			}

			return false;
		}

		// Row, Col을 기준으로 빈칸을 찾는다.
		// 찾을경우 그에 맞는 Row, Col을 저장
		// 못찾을 경우 false 리턴
		private bool FindEmptyIndex(int nRow, int nCol, out int nEmptyRow, out int nEmptyCol)
		{
			int i;

			nEmptyRow = -1;
			nEmptyCol = -1;

			// 상.하 검사
			for(i = 0 ; i < m_nCnt ; i++)
			{
				if (m_nGame[i, nCol] == -1)
				{
					nEmptyRow = i;
					nEmptyCol = nCol;
					return true;
				}
			}

			// 좌.우 검사
			for(i = 0 ; i < m_nCnt ; i++)
			{
				if (m_nGame[nRow, i] == -1)
				{
					nEmptyRow = nRow;
					nEmptyCol = i;
					return true;
				}
			}

			return false;
		}

		// 그림을 옮겨준다.
		private void MoveImg(int nRow, int nCol, int nEmptyRow, int nEmptyCol)
		{
			int nVer, nHoz;
			int i;

			Graphics gra;
			Point pos = new Point();

			gra = panGame.CreateGraphics();

			nVer = nRow - nEmptyRow;
			nHoz = nCol - nEmptyCol;

			if (nVer > 0) // 밑에서 위로 이동
			{
				for(i = nEmptyRow ; i < nRow ; i++)
				{
					m_nGame[i, nCol] = m_nGame[i + 1, nCol];

					if (m_bStart) //실제 화면 출력은 시작후에만 한다.
					{
						pos = GetImgPos(i, nCol);
						gra.DrawImage(m_imgClip.GetClipImage(m_nGame[i, nCol]), pos);
					}
				}
			}

			if (nVer < 0) // 위에서 밑으로 이동
			{
				for(i = nEmptyRow ; i >= nRow + 1 ; i--)
				{
					m_nGame[i, nCol] = m_nGame[i - 1, nCol];
					if (m_bStart) //실제 화면 출력은 시작후에만 한다.
					{
						pos = GetImgPos(i, nCol);
						gra.DrawImage(m_imgClip.GetClipImage(m_nGame[i, nCol]), pos);
					}
				}
			}

			if (nHoz > 0) // 오른쪽에서 왼쪽으로 이동
			{
				for(i = nEmptyCol ; i < nCol ; i++)
				{
					m_nGame[nRow, i] = m_nGame[nRow, i + 1];
					if (m_bStart) //실제 화면 출력은 시작후에만 한다.
					{
						pos = GetImgPos(nRow, i);
						gra.DrawImage(m_imgClip.GetClipImage(m_nGame[nRow, i]), pos);
					}
				}
			}

			if (nHoz < 0) // 왼쪽에서 오른쪽으로 이동
			{
				for(i = nEmptyCol ; i >= nCol + 1 ;  i--)
				{
					m_nGame[nRow, i] = m_nGame[nRow, i - 1];
					if (m_bStart) //실제 화면 출력은 시작후에만 한다.
					{
						pos = GetImgPos(nRow, i);
						gra.DrawImage(m_imgClip.GetClipImage(m_nGame[nRow, i]), pos);
					}
				}
			}

			// 그림을 지운다.
			m_nGame[nRow, nCol] = -1;
			if (m_bStart) //실제 화면 출력은 시작후에만 한다.
			{
				pos = GetImgPos(nRow, nCol);
				panGame.CreateGraphics().FillRectangle(m_bru, new Rectangle(pos.X, pos.Y, PIC_SIZE / m_nCnt, PIC_SIZE / m_nCnt));
			}
		}

		// 게임 종료 검사
		// 끝(True), 계속(false )
		private bool IsGameEnd()
		{
			int i, j;
			int nSameCnt; // % 계산을 위해
			int nPer;

			// 최초엔 모두
			nSameCnt = (m_nCnt * m_nCnt);

			for(i = 0 ; i < m_nCnt ; i++)
			{
				for(j = 0 ; j < m_nCnt ; j++)
				{
					if (i == m_nCnt - 1 && j == m_nCnt - 1)
						if (m_nGame[i, j] != -1) nSameCnt -= 1; //마지막칸이 -1이 아니면 false
						else
							if (m_nGame[i, j] != i * m_nCnt + j) nSameCnt -= 1; //인덱스가 틀림 false
				}
			}

			nPer = (int)(nSameCnt / (m_nCnt * m_nCnt) * 100); // % 계산
			lblPercent.Text = nPer.ToString() + " %";

			if (nSameCnt == (m_nCnt * m_nCnt)) // 게임 끝
			{
				// 게임종료시 작업
				m_bStart = false;
				m_bEnd = true;
				timSecond.Enabled = false;

				Point pos = new Point();
            
				// 그림을 한칸씩 지워준다.
				for(i = 0 ; i < m_nCnt ; i++)
				{
					for(j = 0 ; j < m_nCnt ; j++)
					{
						PlaySound(SOUND_CLEARPIC);
						System.Threading.Thread.Sleep(300);
						// 그림을 지운다.
						pos = GetImgPos(i, j);
						panGame.CreateGraphics().FillRectangle(m_bru, new Rectangle(pos.X, pos.Y, PIC_SIZE / m_nCnt, PIC_SIZE / m_nCnt));
					}
				}

				System.Threading.Thread.Sleep(300);

				panGame.Invalidate();
				return true;
			}
			else
				return false;
        

		}
   
		// 레벨과 조건에 맞는 점수 계산
		private void CalScore(int nType)
		{
			if (nType == SCORE_TIME) // 시간마다
			{
				if (m_nLevel == 2)
					m_nScore -= 1;
				else if (m_nLevel == 1)
					m_nScore -= 4;
				else
					m_nScore -= 8;
			}
			else if (nType == SCORE_CLICK) // 클릭시
			{
				if (m_nLevel == 5)
					m_nScore -= 1;
				else if (m_nLevel == 4)
					m_nScore -= 16;
				else
					m_nScore -= 60;
			}
			else // 힌트그림 볼때
			{
				if (m_nLevel == 5)
					m_nScore -= (9) + (9 * m_nHintTime / 1000);
				else if (m_nLevel == 4)
					m_nScore -= (16) + (16 * m_nHintTime / 1000);
				else
					m_nScore -= (25) + (25 * m_nHintTime / 1000);
				
			}

			lblScore.Text = m_nScore.ToString() + " 점";
		}

		// 조건에 맞는 소리 재생
		private void PlaySound(int nType)
		{
			
			if (nType == SOUND_MOVE)
				sndPlaySound(Application.StartupPath + "\\sound\\move.wav", 0 | 1);
			else if (nType == SOUND_NOTMOVE)
				sndPlaySound(Application.StartupPath + "\\sound\\unable_move.wav", 0 | 1);
			else if (nType == SOUND_RNDPIC)
				sndPlaySound(Application.StartupPath + "\\sound\\RndPic.wav", 0 | 1);
			else if (nType == SOUND_CLEARPIC)
				sndPlaySound(Application.StartupPath + "\\sound\\clear_pic.WAV", 0 | 1);
			else
				sndPlaySound(Application.StartupPath + "\\sound\\end_game.wav", 0 | 1);
        
		}


		// 폼 로드
		private void frmMain_Load(object sender, System.EventArgs e)
		{
			// 최초 시작 
			m_nLevel = 1;
			m_nHintTime = 5;
			m_nPicNum = 3;

			m_bru = new SolidBrush(panGame.BackColor); // pangame의 백칼라와 같은 색을 만든다.

			InitGame();

		}

		//시작 버튼
		private void btnStart_Click(object sender, System.EventArgs e)
		{
			if (btnStart.Text.Equals("게임시작"))
			{
				PlaySound(SOUND_RNDPIC);
				RndClip();
				IsGameEnd(); // % 계산을 위해 한번 호출
				timSecond.Enabled = true; //시간 보여주기 시작
				m_bStart = true;
				btnStart.Text = "처음부터";

				//App.Path
			}
			else
			{
				InitGame();
				btnStart.Text = "게임시작";
			}
			m_bEnd = false;
		}

		// 환경설정 버튼
		private void btnOption_Click(object sender, System.EventArgs e)
		{
			frmOption frm = new frmOption();

			frm.Init(this);

			if (frm.ShowDialog(this) == DialogResult.OK)
			{
				m_nPicNum = frm.m_nSelPic;
				m_nLevel = frm.m_nSelLevel;
				m_nHintTime = frm.m_nSelTime;

				InitGame();
			}
		}

		// 힌트그림 클릭
		private void picHint_Click(object sender, System.EventArgs e)
		{
			// 시작 전
			if (m_bStart == false) return;

			// 점수 계산
			CalScore(SCORE_HINT);

			timHint.Interval = m_nHintTime * 1000;
			picHint.Image = m_imgClip.GetAllImage(); //힌트그림 보여주기
			timHint.Enabled = true;
		}

		// 조각 그림 클릭 효과
		private void panGame_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//시작 전
			if (m_bStart == false) return;

			Point pos = new Point();
			int nRow, nCol;
			int nEmptyRow, nEmptyCol;

			// 마우스 위치 저장
			pos.X = e.X;
			pos.Y = e.Y;

			// 클릭수 올리기
			m_nClick += 1;
			lblClick.Text = m_nClick.ToString() + " 번";

			// 점수 계산
			CalScore(SCORE_CLICK);
			if (PointToIndex(pos, out nRow, out nCol))// 클릭한 곳의 인덱스 찾기
			{
				if (FindEmptyIndex(nRow, nCol, out nEmptyRow, out nEmptyCol))// 빈칸 찾기
				{
					MoveImg(nRow, nCol, nEmptyRow, nEmptyCol);
					PlaySound(SOUND_MOVE);
					if (IsGameEnd())//게임 끝인경우
					{
						m_bStart = false;
						m_bEnd = true;
						PlaySound(SOUND_END);
					}
					else
						PlaySound(SOUND_NOTMOVE);
						
				}
			}
		}

		// 화면 갱신
		private void panGame_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			// 화면이 갱신될때마다 그림을 새로 그려준다.

			if (m_bEnd == false)
			{
				int i, j;
				int nImgNum;
				Image imgTmp;
				Point pos = new Point();

				for(i = 0 ; i < m_nCnt ; i++)
				{
					for(j = 0 ; j < m_nCnt ; j++)
					{
						nImgNum = m_nGame[i, j];
						if (-1 != nImgNum)
						{
							imgTmp = m_imgClip.GetClipImage(nImgNum);
							pos = GetImgPos(i, j);
							e.Graphics.DrawImage(imgTmp, pos);
						}
					}
				}
			}
			else //
				ViewEndingImag();
        
		}

		// 시간을 1초마다 1씩 더한다.
		private void timSecond_Tick(object sender, System.EventArgs e)
		{
			m_nSecond += 1;
			lblSecond.Text = m_nSecond.ToString() + " 초";
			// 점수 계산
			CalScore(SCORE_TIME);
		}

		// 힌트 그림에 대한 타이머
		private void timHint_Tick(object sender, System.EventArgs e)
		{
			timHint.Enabled = false;
			picHint.Image = null; // 힌트그림 지우기
		}
		
	}
}
