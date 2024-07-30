using System;
using System.Drawing; // 추가

namespace PlzGame
{
	/// <summary>
	/// ImageClip에 대한 요약 설명입니다.
	/// </summary>
	public class ImageClip
	{
		private Image m_imgMain; // 원본 이미지 저장
		private Bitmap m_bitMain; // 원본 이미지를 BItmap으로 저장
		private int m_nCol, m_nRow; // 행, 열 값
		private int m_nClipHeight, m_nClipWidth; //조각 그림의 높이, 너비

		// 생성자
		// 원본 이미지와, 조각 그림의 row, col 갯수(1부터 시작)
		public ImageClip(Image imgMain, int nRowCnt, int nColCnt)
		{
			// 이미지와 비트맵 저장
			m_imgMain = imgMain;
			m_bitMain = new Bitmap(imgMain);

			m_nCol = nColCnt;
			m_nRow = nRowCnt;

			// 클립의 크기 저장
			m_nClipHeight = m_imgMain.Height / nRowCnt;
			m_nClipWidth = m_imgMain.Width / nColCnt;
		}

		// 이미지와 크기 재지정
		public void SetImage(Image imgMain, int nRowCnt, int nColCnt)
		{
			// 저장된 이미지가 있을경우 삭제
			if(m_imgMain != null)
				m_imgMain.Dispose();
        

			if(m_bitMain != null)
				m_bitMain.Dispose();
        

			m_imgMain = imgMain;
			m_bitMain = new Bitmap(imgMain);

			// 클립의 크기 저장
			m_nClipHeight = m_imgMain.Height / nRowCnt;
			m_nClipWidth = m_imgMain.Width / nColCnt;
		}


		// 원하는 인덱스의 이미지 얻기
		//row, col 기준으로 얻기
		public Image GetClipImage(int nRow, int nCol)
		{
			if (nCol >= m_nCol || nRow >= m_nRow)
				return null;
        
			Bitmap bitTmp;
			Image imgTmp;

			// 크기와 위치에 맞게 비트맵 얻기
			bitTmp = m_bitMain.Clone
				(new System.Drawing.Rectangle(nCol * m_nClipWidth, nRow * m_nClipHeight, 
				m_nClipWidth, m_nClipHeight), System.Drawing.Imaging.PixelFormat.Format24bppRgb); 
				
			imgTmp = Image.FromHbitmap(bitTmp.GetHbitmap());

			return imgTmp;

		}

		// 1차원 인덱스 기준으로 얻기
		public Image GetClipImage(int nIndex)
		{
			int nRow, nCol;

			if (nIndex < 0) return null; // 0보다 작을때 빈 이미지 반환

			nRow = (int)(nIndex / m_nCol);
			nCol = nIndex % m_nCol;

			return GetClipImage(nRow, nCol);

		}


		// 전체그림 반환
		public Image GetAllImage()
		{
			return m_imgMain;
		}
	}
}
