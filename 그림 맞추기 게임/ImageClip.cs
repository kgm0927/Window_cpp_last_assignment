using System;
using System.Drawing; // �߰�

namespace PlzGame
{
	/// <summary>
	/// ImageClip�� ���� ��� �����Դϴ�.
	/// </summary>
	public class ImageClip
	{
		private Image m_imgMain; // ���� �̹��� ����
		private Bitmap m_bitMain; // ���� �̹����� BItmap���� ����
		private int m_nCol, m_nRow; // ��, �� ��
		private int m_nClipHeight, m_nClipWidth; //���� �׸��� ����, �ʺ�

		// ������
		// ���� �̹�����, ���� �׸��� row, col ����(1���� ����)
		public ImageClip(Image imgMain, int nRowCnt, int nColCnt)
		{
			// �̹����� ��Ʈ�� ����
			m_imgMain = imgMain;
			m_bitMain = new Bitmap(imgMain);

			m_nCol = nColCnt;
			m_nRow = nRowCnt;

			// Ŭ���� ũ�� ����
			m_nClipHeight = m_imgMain.Height / nRowCnt;
			m_nClipWidth = m_imgMain.Width / nColCnt;
		}

		// �̹����� ũ�� ������
		public void SetImage(Image imgMain, int nRowCnt, int nColCnt)
		{
			// ����� �̹����� ������� ����
			if(m_imgMain != null)
				m_imgMain.Dispose();
        

			if(m_bitMain != null)
				m_bitMain.Dispose();
        

			m_imgMain = imgMain;
			m_bitMain = new Bitmap(imgMain);

			// Ŭ���� ũ�� ����
			m_nClipHeight = m_imgMain.Height / nRowCnt;
			m_nClipWidth = m_imgMain.Width / nColCnt;
		}


		// ���ϴ� �ε����� �̹��� ���
		//row, col �������� ���
		public Image GetClipImage(int nRow, int nCol)
		{
			if (nCol >= m_nCol || nRow >= m_nRow)
				return null;
        
			Bitmap bitTmp;
			Image imgTmp;

			// ũ��� ��ġ�� �°� ��Ʈ�� ���
			bitTmp = m_bitMain.Clone
				(new System.Drawing.Rectangle(nCol * m_nClipWidth, nRow * m_nClipHeight, 
				m_nClipWidth, m_nClipHeight), System.Drawing.Imaging.PixelFormat.Format24bppRgb); 
				
			imgTmp = Image.FromHbitmap(bitTmp.GetHbitmap());

			return imgTmp;

		}

		// 1���� �ε��� �������� ���
		public Image GetClipImage(int nIndex)
		{
			int nRow, nCol;

			if (nIndex < 0) return null; // 0���� ������ �� �̹��� ��ȯ

			nRow = (int)(nIndex / m_nCol);
			nCol = nIndex % m_nCol;

			return GetClipImage(nRow, nCol);

		}


		// ��ü�׸� ��ȯ
		public Image GetAllImage()
		{
			return m_imgMain;
		}
	}
}
